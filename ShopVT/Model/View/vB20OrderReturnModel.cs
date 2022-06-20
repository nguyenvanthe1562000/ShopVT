using System;
using System.Collections.Generic;
namespace Model.Model
{
    public class vB20OrderReturnModel
    {

        public int ID { set; get; }
        public string Stt { set; get; }
        public DateTime DocDate { set; get; }
        public string code { set; get; }
        public string CustomerCode { set; get; }
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
        public List<vB20OrderDetailModel> vB20OrderDetail_Json { get; set; }

    }
}



