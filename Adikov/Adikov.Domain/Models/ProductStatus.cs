using System.ComponentModel;

namespace Adikov.Domain.Models
{
    public enum ProductStatus
    {
        [Description("Не указан")]
        None,

        [Description("В наличии")]
        InStock,

        [Description("Под заказ")]
        UnderOrder,

        [Description("Ожидается")]
        Pending
    }
}