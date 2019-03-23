using System.ComponentModel;

namespace Lab04Tyshchenko.Model
{
    class ZodiacEnums
    {
        public enum WestZodiac
        {
            [Description("Овен")]
            Aries,
            [Description("Тілець")]
            Taurus,
            [Description("Близнюки")]
            Gemini,
            [Description("Рак")]
            Canser,
            [Description("Лев")]
            Leo,
            [Description("Діва")]
            Virgo,
            [Description("Терези")]
            Libra,
            [Description("Скорпіон")]
            Scorpio,
            [Description("Стрілець")]
            Sagittarius,
            [Description("Козоріг")]
            Capricorn,
            [Description("Водолій")]
            Aquarius,
            [Description("Риби")]
            Pisces
        }

        public enum ChineseZodiac
        {
            [Description("Мавпа")]
            Monkey,
            [Description("Півень")]
            Rooster,
            [Description("Собака")]
            Dog,
            [Description("Свиня")]
            Pig,
            [Description("Пацюк")]
            Rat,
            [Description("Бик")]
            Ox,
            [Description("Тигр")]
            Tiger,
            [Description("Кролик")]
            Rabbit,
            [Description("Дракон")]
            Dragon,
            [Description("Змія")]
            Snake,
            [Description("Кінь")]
            Horse,
            [Description("Вівця")]
            Sheep
        }
    }
}
