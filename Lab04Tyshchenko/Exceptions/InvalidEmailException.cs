using System;

namespace Lab04Tyshchenko.Exceptions
{
    class InvalidEmailException : Exception
    {
        public InvalidEmailException(string email)
            : base(String.Format("Некоректна пошта - {0}", email))
        { }
    }
}
