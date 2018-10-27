using CodeAndCloud.Core;
using CodeAndCloud.Core.Entities;
using CodeAndCloud.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure; //Namespace for CloudConfigurationManager
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using CodeAndCloud.Services.ContactService;

namespace CodeAndCloud.Services.ContactServices
{
    public class ContactService : IContactService
    {
        public void Add(AddContactViewModel model)
        {
            var db = new DataContext();

            var contact = new ContactModel()
            {
                CreateDate = DateTime.Now,
                Email = model.Email,
                Name = model.Name,
                PhoneNumber = model.PhoneNumber
            };

            db.Add<ContactModel>(contact);
            db.SaveChanges();

            // Retrieve the storage account from the connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("DefaultEndpointsProtocol=https;AccountName=devcodeandcloud;AccountKey=9LhuuclWYiF5Oisb20idnhr8omIrghiGG8E4neyptO3MmXSRmjwVULkJslfzY4omSSdenU9ZS+0A8sv6XXsQtQ==;EndpointSuffix=core.windows.net"));

            // Create the table client.
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            // Create the CloudTable object that represents the "people" table.
            CloudTable table = tableClient.GetTableReference("people");

            // Create a new customer entity.
            CustomerEntity customer1 = new CustomerEntity(model.Name);
            customer1.Email = model.Email;
            customer1.PhoneNumber = model.PhoneNumber;

            // Create the TableOperation object that inserts the customer entity.
            TableOperation insertOperation = TableOperation.Insert(customer1);

            // Execute the insert operation.
            table.ExecuteAsync(insertOperation);
        }
    }
}
