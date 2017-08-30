using System;
using System.Collections.Generic;

namespace data.nsi{
     public partial class TreeNodeEmployee
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsDeputy { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int TreeNodeId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual TreeNode TreeNode { get; set; }
    }
}
