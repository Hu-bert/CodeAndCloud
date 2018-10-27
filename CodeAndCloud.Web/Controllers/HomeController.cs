using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CodeAndCloud.Services.ContactServices;
using CodeAndCloud.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure; // Namespace for CloudConfigurationManager

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace CodeAndCloud.Web.Controllers
{
    public class HomeController : Controller
    {
        private IContactService _service;
        public HomeController(IContactService contactService)
        {
            _service = contactService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Leave contact to yourself";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ContactAsync(AddContactViewModel model)
        {
            // Retrieve the storage account from the connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("DefaultEndpointsProtocol=https;AccountName=devcodeandcloud;AccountKey=9LhuuclWYiF5Oisb20idnhr8omIrghiGG8E4neyptO3MmXSRmjwVULkJslfzY4omSSdenU9ZS+0A8sv6XXsQtQ==;EndpointSuffix=core.windows.net"));


            // Create the queue client.
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

            // Retrieve a reference to a queue.
            CloudQueue queue = queueClient.GetQueueReference("myqueue");

            // Create the queue if it doesn't already exist.
            await queue.CreateIfNotExistsAsync();

            // Create a message and add it to the queue.
            CloudQueueMessage message = new CloudQueueMessage(model.Email);
            await queue.AddMessageAsync(message);

            _service.AddAsync(model);
            return View("Contact");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
