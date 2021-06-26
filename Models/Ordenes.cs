using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SegundoRegistroDetalle.Models
{
    public class Ordenes
    {
        [Key]
        public int OrdenId { get; set; }
        public DateTime Fecha { get; set; }
        public int SuplidorId { get; set; }
        public decimal Monto { get; set; }
        [ForeignKey("OrdenId")]
        public List<OrdenesDetalle> Detalle = new List<OrdenesDetalle>();

    }
}
