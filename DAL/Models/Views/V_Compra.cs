using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Views
{
    public class V_Compra
    {
        public int? id { get; set; }
        public Guid? guidCompra { get; set; }
        public DateTime? fechaCompra { get; set; }
        public string tipoFacturaCompra { get; set; }
        public string numeroFactura { get; set; }
        public int? idResolucion { get; set; }
        public string prefijo { get; set; }
        public int? number { get; set; }
        public string notes { get; set; }
        public int? payment_form_id { get; set; }
        public string namePayment_form { get; set; }
        public int? payment_method_id { get; set; }
        public string namePayment_method { get; set; }
        public DateTime? patment_due_date { get; set; }
        public int? estadoCompra { get; set; }
        public decimal? totalBruto { get; set; }
        public decimal? totalDescuento { get; set; }
        public decimal? totalBase { get; set; }
        public decimal? totalImpuestos { get; set; }
        public decimal? totalretefuente { get; set; }
        public decimal? impuestosMenosRetenciones { get; set; }
        public decimal? totalFactura { get; set; }
        public decimal? abonado { get; set; }
        public decimal? saldoCompra { get; set; }
        public string nombreProveedor { get; set; }
        public string estado_DS { get; set; }
        public string uuid { get; set; }
        public string numberDS { get; set; }
        public string issue_date { get; set; }
    }
}
