using System.ComponentModel;

namespace Adikov.Domain.Models
{
    public enum ProductCategoryType
    {
        [Description("Разные")]
        Default,

        [Description("Одиночка")]
        Single,

        [Description("Идентичные")]
        Identical
    }
}