using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeAndCloud.Services.ContactService
{
    public class CustomerEntity : TableEntity
    {
        public CustomerEntity(string lastName)
        {
            this.PartitionKey = lastName;
            this.RowKey = lastName;
        }

        public CustomerEntity() { }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}
