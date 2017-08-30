using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace printer.Database
{
    /// <summary>
    /// Модель принтера
    /// </summary>
    public class Model
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set;}

        /// <summary>
        /// Наименование
        /// </summary>
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
        public virtual Producer Producer { get; set; }

        /// <summary>
        /// Формат мечати принтера
        /// </summary>
        public PrinterFormat Format { get; set; }

        /// <summary>
        /// Цветность принтера 
        /// </summary>
        public PrinterColor Color { get ; set; }

        /// <summary/>
        /// Тип принтера
        /// </summary>
        public PrinterType Type { get; set; }

        /// <summary/>
        /// Способ подачи бумаги
        /// </summary>
        public PaperFeed PaperFeed { get; set;}

        public ICollection<ModelZip> ModelsZips { get; set;}
        public ICollection<Printer> Printers { get ; set;}
    }
}