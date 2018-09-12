namespace Numiteq.Common.Entities
{
    public class File : BaseEntity
    {
        public string OriginName { get; set; }

        public string PhysicalName { get; set; }

        public string ContentType { get; set; }

        public long ContentLength { get; set; }
    }
}