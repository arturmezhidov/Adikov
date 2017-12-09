using System.ComponentModel;

namespace Adikov.Domain.Models
{
    public enum ColumnType
    {
        [Description("Целое число")]
        IntNumber,

        [Description("Вещественное число")]
        DoubleNumber,

        [Description("Строка")]
        String,

        [Description("Статус")]
        Status
    }
}