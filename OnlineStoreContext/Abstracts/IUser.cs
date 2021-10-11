using System;

namespace OnlineStore.Core.Abstracts
{
    public interface IUser : IFullName
    {
        public DateTime DateOfBirth { get; set; }
    }
}