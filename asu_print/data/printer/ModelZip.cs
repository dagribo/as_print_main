using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace printer.Database
{
    public class ModelZip
    {
        public int ModelId { get; set; }
        public int ZipId { get; set; }

        [ForeignKey(nameof(ModelId))]
        public virtual Model Model { get; set; }
        [ForeignKey(nameof(ZipId))]
        public virtual Zip Zip { get; set; }
        public ZipType Type { get; set; }
    }
}