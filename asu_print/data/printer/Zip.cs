using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace printer.Database
{
    /// <summary>
    /// Расходные материалы (ЗИП - запасные части, инструменты)
    /// </summary>
    public class Zip
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get; set;}

        /// <summary>
        /// Наименование
        /// </summary>
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
        
        /// <summary>
        ///  Модель
        /// </summary>
        [MaxLength(128)]
        public string Model { get; set; }

        /// <summary>
        /// Производитель
        /// </summary>
        public Producer Producer { get; set; }

        /// <summary/>
        /// Ресурс печати 
        /// </summary>
        public int Resource { get; set;}

        /// <summary>
        /// Стоимость
        /// </summary>
        public int Cost { get; set; }

        public ICollection<ModelZip> ModelsZips { get; set;}
    }
}