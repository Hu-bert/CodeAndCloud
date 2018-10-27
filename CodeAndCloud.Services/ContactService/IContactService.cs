using System;
using System.Collections.Generic;
using System.Text;
using CodeAndCloud.Core;
using CodeAndCloud.Core.Entities;
using CodeAndCloud.ViewModels;

namespace CodeAndCloud.Services.ContactServices
{
    public interface IContactService
    {
        void Add(AddContactViewModel model);
    }
}