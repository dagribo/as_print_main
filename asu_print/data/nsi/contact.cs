using System;

namespace data.nsi{
    public partial class Contact
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int IsLocked { get; set; }
        public string MailOuter { get; set; }
        public string PhoneCity { get; set; }
        public string PhoneMobile { get; set; }
        public string PhoneRzd { get; set; }
        public string PhotoId { get; set; }
        public DateTime LastUpdated { get; set; }

        public virtual Employee IdNavigation { get; set; }
    }
}