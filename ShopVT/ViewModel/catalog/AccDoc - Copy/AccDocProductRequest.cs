using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.catalog.AccDoc
{
    public class AccDocProductRequest
    {

        public int Id { set; get; }
        public string DocCode { set; get; }
        public DateTime DocDate { set; get; }
        public string Stt { set; get; }
        public string SupplierCode { set; get; }
        public string Person { set; get; }
        public string Address { set; get; }
        public decimal TotalOriginalAmount { set; get; }
        public int RateVAT { set; get; }
        public decimal Amount { set; get; }
        public string Description { set; get; }
        public bool IsActive { set; get; }
        public int CreatedBy { set; get; }
        public DateTime CreatedAt { set; get; }
        public int ModifiedBy { set; get; }
        public DateTime ModifiedAt { set; get; }
        public string vB20AccDocProductDetail { get; set; }

    }
}
