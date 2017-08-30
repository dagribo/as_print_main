using System;
using System.Collections.Generic;

namespace data.nsi{
     public partial class Firm
    {
        public Firm()
        {
            Employee = new HashSet<Employee>();
            TreeNode = new HashSet<TreeNode>();
            ZoneFirmFirmMain = new HashSet<ZoneFirm>();
            ZoneFirmFirmZone = new HashSet<ZoneFirm>();
        }

        public int Id { get; set; }
        public Guid? AsozCode { get; set; }
        public int? AsozId { get; set; }
        public int? AsutrCode { get; set; }
        public DateTime DateCreated { get; set; }
        public int? FirmMainId { get; set; }
        public int? FirmZoneId { get; set; }
        public string FullName { get; set; }
        public bool IsDeleted { get; set; }
        public bool? IsMain { get; set; }
        public bool? IsZone { get; set; }
        public DateTime LastUpdated { get; set; }
        public int? ManagerId { get; set; }
        public string ShortName { get; set; }
        public int? ZoneId { get; set; }
        public Guid Code { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<TreeNode> TreeNode { get; set; }
        public virtual ICollection<ZoneFirm> ZoneFirmFirmMain { get; set; }
        public virtual ICollection<ZoneFirm> ZoneFirmFirmZone { get; set; }
        public virtual Firm FirmMain { get; set; }
        public virtual ICollection<Firm> InverseFirmMain { get; set; }
        public virtual Firm FirmZone { get; set; }
        public virtual ICollection<Firm> InverseFirmZone { get; set; }
        public virtual Employee Manager { get; set; }
        public virtual Zone Zone { get; set; }
    }

     

     

     

       


    

}