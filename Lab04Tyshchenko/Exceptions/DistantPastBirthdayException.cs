using System;

namespace Lab04Tyshchenko.Exceptions
{
    class DistantPastBirthdayException : Exception
    {
        public DistantPastBirthdayException(DateTime birthDate)
            : base(String.Format("Хіба хтось так довго живе?\nНекоректна дата - {0}", birthDate.ToString("dd.MM.yyy")))
        { }
    }
}
