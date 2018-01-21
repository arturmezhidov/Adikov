using System.ComponentModel;

namespace Adikov.Domain.Models
{
    public enum ProductStatus
    {
        [Description("В наличии")]
        InStock,

        [Description("Под заказ")]
        UnderOrder,

        [Description("Ожидается")]
        Pending
    }
}