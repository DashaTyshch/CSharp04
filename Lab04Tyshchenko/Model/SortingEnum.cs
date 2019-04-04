using System.ComponentModel;

namespace Lab04Tyshchenko.Model
{
    public enum SortingEnum
    {
        [Description("-")]
        Default,
        [Description("Ім'я")]
        Name,
        [Description("Прізвище")]
        Surname,
        [Description("Пошта")]
        Email,
        [Description("Західний знак")]
        SunSign,
        [Description("Китайський знак")]
        ChineseSign
    }
}
