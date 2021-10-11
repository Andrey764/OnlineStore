using System;
using OnlineStore.Core.Abstracts;
using Microsoft.AspNetCore.Identity;

namespace OnlineStore.Core.DBClasses
{
    public class User : IdentityUser, IUser
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}