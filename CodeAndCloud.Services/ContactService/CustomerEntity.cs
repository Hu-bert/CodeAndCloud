using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeAndCloud.Services.ContactService
{
    public class CustomerEntity : TableEntity
    {
        public CustomerEntity(string fullname)
        {
            string[] name = fullname.Split(new char[] { ' ' });
            this.PartitionKey = name[0];
            this.RowKey = name[1];
        }

        public CustomerEntity() { }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}
