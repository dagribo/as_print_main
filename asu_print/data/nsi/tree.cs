using System;
using System.Collections.Generic;

namespace data.nsi{
public partial class Tree
    {
        public Tree()
        {
            TreeNode = new HashSet<TreeNode>();
        }

        public int Id { get; set; }
        public string Caption { get; set; }
        public DateTime DateCreated { get; set; }
        public string Description { get; set; }
        public DateTime LastUpdated { get; set; }
        public int Type { get; set; }
        public Guid Code { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<TreeNode> TreeNode { get; set; }
    }
}