using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace printer.Database
{
    /// <summary>
    /// Производитель
    /// </summary>
    public class Producer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Наименовение
        /// </summary>
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        public ICollection<Zip> Zips { get; set; }

        public ICollection<Model> Models { get; set; }
    }
}