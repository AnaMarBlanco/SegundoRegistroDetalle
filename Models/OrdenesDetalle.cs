using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegundoRegistroDetalle.Models
{
    public class OrdenesDetalle
    {
        public int Id { get; set; }
        public int OrdenId { get; set; }
        public int ProductoId { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Costo { get; set; }
        public decimal SubTotal { get; set; }
        //OrdenesDetalle(Id,OrdenId,ProductoId,Cantidad,Costo)
    }
}
