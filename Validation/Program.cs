using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Validation
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person
            {
                FirstName = "Alex",
                LastName = "1",
                BirthDate = new DateTime(2000, 1, 1),
                Email = "alex1@gmail.com"
            };

            //var isValid = IsValid_old(person);
            var isValid = IsValid(person);
            Console.WriteLine(isValid);
        }

        private static bool IsValid(Person person)
        {
            var validationContext = new ValidationContext(person);
            
            return Validator.TryValidateObject(
                person, 
                validationContext, 
                new List<ValidationResult>(),
                true);
        }

        static bool IsValid_old(Person p)
        {
            if (string.IsNullOrEmpty(p.FirstName))
            {
                return false;
            }

            if (string.IsNullOrEmpty(p.LastName))
            {
                return false;
            }

            if (p.BirthDate < new DateTime(1900, 1, 1) &&
                p.BirthDate > DateTime.Now)
            {
                return false;
            }
            Regex regex = new Regex(@"\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,6}");
            if (string.IsNullOrEmpty(p.Email) || regex.Matches(p.Email).Count == 0)
            {
                return false;
            }

            return true;
        }
    }

    class Person
    {
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Range(typeof(DateTime), "1/1/1900", "1/1/2021")]
        public DateTime BirthDate { get; set; }
    }
}
