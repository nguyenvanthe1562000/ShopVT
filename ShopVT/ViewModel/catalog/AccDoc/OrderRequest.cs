using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.catalog.AccDoc
{
    public class OrderRequest
    {
        public int ID { set; get; }
        public string Stt { set; get; }
        public string code { set; get; }
        public string CustomerName { set; get; }
        public string CustomerAddress { set; get; }
        public string CustomerEmail { set; get; }
        public string CustomerMobile { set; get; }
        public int IdCardNo { set; get; }
        public string note { set; get; }
        public string PaymentMethod { set; get; }
        public string PaymentStatus { set; get; }
        public int OrderStatus { set; get; }
        public decimal Amount { set; get; }
        public bool IsActive { set; get; }
        public int CreatedBy { set; get; }
        public DateTime CreatedAt { set; get; }
        public int ModifiedBy { set; get; }
        public DateTime ModifiedAt { set; get; }
        public string OrderStatusName { set; get; }
        public string PaymentMethodName { set; get; }
        public string vB20OrderDetail { get; set; }
    }
}
