using System;
using System.Collections.Generic;
using NpgsqlTypes;

namespace data.nsi{
    public partial class Employee
    {
        public Employee()
        {
            FirmNavigation = new HashSet<Firm>();
            TreeNode = new HashSet<TreeNode>();
            TreeNodeEmployee = new HashSet<TreeNodeEmployee>();
        }

        public int Id { get; set; }
        public string Account { get; set; }
        public Guid? AsozCode { get; set; }
        public int? AsozId { get; set; }
        public int? AsutrCode { get; set; }
        public DateTime DateCreated { get; set; }
        public string DomainObject { get; set; }
        public string Email { get; set; }
        public string EsppCode { get; set; }
        public int? EsppId { get; set; }
        public string Fio { get; set; }
        public int? FirmId { get; set; }
        public string FirstName { get; set; }
        public bool IsExternal { get; set; }
        public bool IsLocked { get; set; }
        public bool IsVip { get; set; }
        public string LastName { get; set; }
        public DateTime LastUpdated { get; set; }
        public string MiddleName { get; set; }
        public string Password { get; set; }
        public int? PostId { get; set; }
        public int StatusCode { get; set; }
        public string Username { get; set; }
        public NpgsqlTsVector FtsFio { get; set; }
        public string FioSearch { get; set; }
        public Guid Code { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual ICollection<Firm> FirmNavigation { get; set; }
        public virtual ICollection<TreeNode> TreeNode { get; set; }
        public virtual ICollection<TreeNodeEmployee> TreeNodeEmployee { get; set; }
        public virtual Firm Firm { get; set; }
        public virtual Post Post { get; set; }
    }
}