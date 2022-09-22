using System;
using System.Collections.Generic;

namespace CreateAndSearchBook.Models
{
    public class Purch
    {
        public int PurchaseId { get; set; }
        public string? EmailId { get; set; }
        public int? BookId { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public string? PaymentMode { get; set; }
    }
}

