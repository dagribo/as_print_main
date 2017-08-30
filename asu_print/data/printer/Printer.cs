using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace printer.Database
{
    public class Printer{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Серийный номер принтера
        /// </summary>
        [Required]
        [MaxLength(128)]
        public string SerialNumber { get; set; }


        /// <summary>
        /// Штрихкод сервисной компании
        /// </summary>        
        [MaxLength(128)]
        public string Barcode { get; set; }

        public int FirmId { get;set;}

        /// <summary>
        /// Модель принтера
        /// </summary>
        public virtual Model Model { get; set; }
    }
}