namespace Adikov.Domain.Models
{
    public class File : BaseEntity
    {
        public string OriginName { get; set; }

        public string PhysicalName { get; set; }

        public string ContentType { get; set; }

        public int ContentLength { get; set; }
    }
}