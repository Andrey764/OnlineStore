using OnlineStore.Core.DBClasses;
using OnlineStore.View.ViewModels;

namespace OnlineStore.View.Models
{
    public static class UserFactory
    {
        public static User CreateUser(RegistrationViewModel model)
        {
            return new User()
            {
                UserName = model.Login,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                DateOfBirth = model.DateOfBirth,
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                Region = model.Region,
                City = model.City,
                NumberHouse = model.NumberHouse,
                Address = model.Address
            };
        }
    }
}