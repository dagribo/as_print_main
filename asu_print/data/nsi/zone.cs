using System;
using System.Collections.Generic;

namespace data.nsi{
public partial class Zone
    {
        public Zone()
        {
            Firm = new HashSet<Firm>();
            ZoneFirm = new HashSet<ZoneFirm>();
        }

        public int Code { get; set; }
        public Guid? AsozCode { get; set; }
        public string CodeEspp { get; set; }
        public string DispGroup { get; set; }
        public string FullName { get; set; }
        public bool IsActive { get; set; }
        public bool IsRoad { get; set; }
        public string ShiftGroup { get; set; }
        public string ShiftMail { get; set; }
        public string ShiftPhone { get; set; }
        public string Timezone { get; set; }
        public string ShortName { get; set; }
        public DateTime LastUpdated { get; set; }
        public long? MaskCode { get; set; }

        public virtual ICollection<Firm> Firm { get; set; }
        public virtual ICollection<ZoneFirm> ZoneFirm { get; set; }
    }
}