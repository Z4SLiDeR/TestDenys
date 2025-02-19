using System;
using System.Text.RegularExpressions;

namespace TestDenys.Model
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        // Constructeur avec paramètres
        public User(int id, string lastName, string firstName, string email, string password, string role)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            Email = email;
            Password = password;
            Role = role;
        }

        // Constructeur sans paramètres
        public User() { }

        // Validation des noms (lettres, espaces, apostrophes, tirets)
        public bool IsValidName(string name)
        {
            string regex = "^[A-Za-zÀ-ÖØ-öø-ÿ]{2,50}([ '-][A-Za-zÀ-ÖØ-öø-ÿ]{2,50})*$";
            return !string.IsNullOrEmpty(name) && Regex.IsMatch(name, regex);
        }

        // Validation de l'email
        public bool IsValidEmail(string email)
        {
            string regex = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$";
            return !string.IsNullOrEmpty(email) && Regex.IsMatch(email, regex);
        }

        // Validation du mot de passe (au moins une lettre, un chiffre, min. 5 caractères)
        public bool IsValidPassword(string password)
        {
            string regex = "^(?=.*[A-Za-z])(?=.*\\d).{5,}$";
            return !string.IsNullOrEmpty(password) && Regex.IsMatch(password, regex);
        }

        // Changement de mot de passe
        public bool ChangePassword(string currentPassword, string newPassword)
        {
            if (string.IsNullOrEmpty(currentPassword) || newPassword == currentPassword || !IsValidPassword(newPassword))
            {
                return false;
            }
            Password = newPassword; // Mise à jour du mot de passe
            return true;
        }

        public bool Register(string firstName, string lastName, string email, string password)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProfile()
        {
            throw new NotImplementedException();
        }

        public bool Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public bool isValidName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
