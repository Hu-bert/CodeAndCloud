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
using Microsoft.WindowsAzure.Storage.Queue;

namespace CodeAndCloud.Services.ContactServices
{
    public class ContactService : IContactService
    {
        public void AddAsync(AddContactViewModel model)
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
            
        }
    }
}
