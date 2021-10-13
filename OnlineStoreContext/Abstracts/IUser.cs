using System;

namespace OnlineStore.Core.Abstracts
{
    public interface IUser : IFullName, ILocation
    {
        public DateTime? DateOfBirth { get; set; }
    }
}