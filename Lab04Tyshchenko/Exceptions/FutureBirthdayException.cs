using System;

namespace Lab04Tyshchenko.Exceptions
{
    class FutureBirthdayException : Exception
    {
        public FutureBirthdayException(DateTime birthDate)
            : base(String.Format("Ви з майбутнього?\nНекоректна дата - {0}", birthDate.ToString("dd.MM.yyy")))
        { }
    }
}
