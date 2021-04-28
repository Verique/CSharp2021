using System;
using System.Linq;

namespace Students
{
    public class Student
    {
        private readonly string _fullName;
        private readonly string _email;

        public Student(string email)
        {
            if ((!email.Contains("@")) || (!email.Contains('.')))
                throw new ArgumentException();
            
            if (email.IndexOf('.') > email.IndexOf('@'))
                throw new ArgumentException();
            
            _email = email;
            _fullName = GetNameFromEmail(email);
        }

        public Student(string name, string surname)
        {
            _email = string.Concat(FirstLetterToLower(name), '.', FirstLetterToLower(surname), "@epam.com");
            _fullName = string.Concat(name, ' ', surname);
        }

        public override string ToString()
        {
            return _fullName;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Student student))
                return false;
            
            return this.GetHashCode().Equals(student.GetHashCode());
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        private static string GetNameFromEmail(string email)
        {
            var nameAndSurname = email.Remove(email.IndexOf('@')).Split('.');
            return string.Concat(FirstLetterToUpper(nameAndSurname[0]), ' ', FirstLetterToUpper(nameAndSurname[1]));
        }

        private static string FirstLetterToUpper(string input)
        {
            return string.Concat(input.First().ToString().ToUpper(), input.Substring(1));
        }

        private static string FirstLetterToLower(string input)
        {
            return string.Concat(input.First().ToString().ToLower(), input.Substring(1));
        }
    }
}