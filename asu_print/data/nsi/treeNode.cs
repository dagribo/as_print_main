using System;
using System.Collections.Generic;

namespace data.nsi{
public partial class TreeNode
    {
        public TreeNode()
        {
            TreeNodeEmployee = new HashSet<TreeNodeEmployee>();
        }

        public int Id { get; set; }
        public int? TreeId { get; set; }
        public int? ParentId { get; set; }
        public int? FirmId { get; set; }
        public string Caption { get; set; }
        public DateTime LastUpdated { get; set; }
        public int? ManagerId { get; set; }
        public int? UserRoleId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<TreeNodeEmployee> TreeNodeEmployee { get; set; }
        public virtual Firm Firm { get; set; }
        public virtual Employee Manager { get; set; }
        public virtual TreeNode Parent { get; set; }
        public virtual ICollection<TreeNode> InverseParent { get; set; }
        public virtual Tree Tree { get; set; }
    }}