using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateWay.Model
{
    public class Paymentmodel
    {
        public int PurchaseId { get; set; }
        public string? EmailId { get; set; }
        public int? BookId { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public string? PaymentMode { get; set; }

    }
    public class CreatePaymentmodel
    {
        public string? EmailId { get; set; }
        public int? BookId { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public string? PaymentMode { get; set; }
    }
    public class UpdateTaskModel
    {
        public string? EmailId { get; set; }
        public int? BookId { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public string? PaymentMode { get; set; }

    }
}
