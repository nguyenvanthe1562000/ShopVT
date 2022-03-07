using Model.Auth;
using System;
using System.Collections.Generic;
namespace Model.Model
{
    public class B00CommandModel
    {

        public int ParentId { set; get; }
        public bool IsGroup { set; get; }
        public string TableName { set; get; }
        public string Description { set; get; }
        public PermissionFunction FunctionType { set; get; }
        public bool IsActive { set; get; }
        public int CreatedBy { set; get; }
        public DateTime CreatedAt { set; get; }
        public int ModifiedBy { set; get; }
    }

    public enum FunctionType
    {
        Category,//danh mục
        Receipt,//chứng từ - hóa đơn
        General,//tổng hợp -các thông tin tồn hàng hóa đầu kì.
        Report,// báo cáo.
        System,//hệ thống
    }
}


