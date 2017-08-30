using System;
using System.Collections.Generic;

namespace data.nsi{
public partial class Post
    {
        public Post()
        {
            Employee = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public Guid? AsozCode { get; set; }
        public string PostName { get; set; }
        public Guid Code { get; set; }
        public DateTime LastUpdated { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}