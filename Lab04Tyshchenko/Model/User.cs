using Lab04Tyshchenko.Tools;
using Newtonsoft.Json;
using System;
using static Lab04Tyshchenko.Model.ZodiacEnums;

namespace Lab04Tyshchenko.Model
{
    [Serializable]
    public class User
    {
        public string Name { get; }
        public string Surname { get; }
        public string Email { get; set; }
        public DateTime BirthdayDate { get; set; }

        public string SunSign { get; }
        public string ChineseSign { get; }

        [JsonConstructor]
        public User(string name, string surname, string email, DateTime birthdayDate)
        {
            Name = name;
            Surname = surname;
            Email = email;
            BirthdayDate = birthdayDate;

            SunSign = FindWestZodiac(BirthdayDate);
            ChineseSign = FindChineseZodiac(BirthdayDate.Year);
        }

        public User(string name, string surname, DateTime birthdayDate)
        {
            Name = name;
            Surname = surname;
            BirthdayDate = birthdayDate;

            SunSign = FindWestZodiac(BirthdayDate);
            ChineseSign = FindChineseZodiac(BirthdayDate.Year);
        }

        public User(string name, string surname, string email)
        {
            Name = name;
            Surname = surname;
            Email = email;

            SunSign = FindWestZodiac(BirthdayDate);
            ChineseSign = FindChineseZodiac(BirthdayDate.Year);
        }

        public bool IsAdult
        {
            get
            {
                var age = DateTime.Today.Date.Year - BirthdayDate.Date.Year;
                if (BirthdayDate > DateTime.Today.AddYears(-age))
                    age--;

                return (age >= 18);
            }
        }

        public bool IsBirthday
        {
            get
            {
                return BirthdayDate.DayOfYear == DateTime.Today.DayOfYear;
            }
        }

        private string FindWestZodiac(DateTime date)
        {
            var day = date.Day;
            var month = date.Month;

            if ((month == 3 && day >= 21) || (month == 4 && day <= 20))
                return WestZodiac.Aries.GetDescription();
            if ((month == 4 && day >= 21) || (month == 5 && day <= 20))
                return WestZodiac.Taurus.GetDescription();
            if ((month == 5 && day >= 21) || (month == 6 && day <= 21))
                return WestZodiac.Gemini.GetDescription();
            if ((month == 6 && day >= 22) || (month == 7 && day <= 22))
                return WestZodiac.Canser.GetDescription();
            if ((month == 7 && day >= 23) || (month == 8 && day <= 23))
                return WestZodiac.Leo.GetDescription();
            if ((month == 8 && day >= 24) || (month == 9 && day <= 23))
                return WestZodiac.Virgo.GetDescription();
            if ((month == 9 && day >= 24) || (month == 10 && day <= 22))
                return WestZodiac.Libra.GetDescription();
            if ((month == 10 && day >= 23) || (month == 11 && day <= 22))
                return WestZodiac.Scorpio.GetDescription();
            if ((month == 11 && day >= 23) || (month == 12 && day <= 21))
                return WestZodiac.Sagittarius.GetDescription();
            if ((month == 12 && day >= 22) || (month == 1 && day <= 20))
                return WestZodiac.Capricorn.GetDescription();
            if ((month == 1 && day >= 21) || (month == 2 && day <= 19))
                return WestZodiac.Aquarius.GetDescription();
            if ((month == 2 && day >= 20) || (month == 3 && day <= 20))
                return WestZodiac.Pisces.GetDescription();
            return "Упсс, щось пішло не так!";
        }

        private string FindChineseZodiac(int year)
        {
            var modY = year % 12;
            return ((ChineseZodiac)modY).GetDescription();
        }
    }
}
