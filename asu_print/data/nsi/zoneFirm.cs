using System;

namespace data.nsi{
    public partial class ZoneFirm
    {
        public int Id { get; set; }
        public int? FirmMainId { get; set; }
        public int? ZoneId { get; set; }
        public int? FirmZoneId { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Firm FirmMain { get; set; }
        public virtual Firm FirmZone { get; set; }
        public virtual Zone Zone { get; set; }
    }
}
