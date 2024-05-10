using Booking.BLL.Models;
using System.Text.RegularExpressions;

namespace Booking.WebAPI.Validation
{
    public static class Validator
    {
        private const int MaxLenght = 255;
        public static string Apartament(ApartamentModel model)
        {
            string error = string.Empty;

            if(string.IsNullOrWhiteSpace(model.Location) || model.Location.Length > MaxLenght)
            {
                error += $"Location cant be empty or more than {MaxLenght} symbols\n";
            }

            if(model.Price < 1)
            {
                error += "Price must be 1 or higher\n";
            }

            if(model.Rooms < 1)
            {
                error += "Aparament must have 1 or more rooms\n";
            }

            if (string.IsNullOrWhiteSpace(model.Owner) || model.Owner.Length > MaxLenght)
            {
                error += $"Owner cant be empty or more than {MaxLenght} symbols\n";
            }

            return error;
        }

        public static string User(UserModel model)
        {
            string error = string.Empty;

            if(string.IsNullOrWhiteSpace(model.Name) || model.Name.Length > MaxLenght)
            {
                error += $"User name cant be empty or more than {MaxLenght} symbols\n";
            }

            if (string.IsNullOrWhiteSpace(model.Email) || model.Name.Length > MaxLenght)
            {
                error += $"User name cant be empty or more than {MaxLenght} symbols\n";
            }

            if(!IsValidEmail(model.Email))
            {
                error += $"Incorrect email format\n";
            }

            return error;
        }

        public static string Book(BookModel model)
        {
            string error = string.Empty;

            if(model.UserId == Guid.Empty)
            {
                error += "User id cant be empty\n";
            }

            if (model.ApartamentId == Guid.Empty)
            {
                error += "Apartament id cant be empty\n";
            }

            if(model.StartDate > new DateTime(2099, 12, 30) || model.EndDate > new DateTime(2099, 12, 30))
            {
                error += "Any date cant be more than 2100 year\n";
            }

            if(model.Price < 1)
            {
                error += "Price must be 1 or higher\n";
            }

            return error;
        }

        private static bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

            return Regex.IsMatch(email, pattern);
        }
    }
}
