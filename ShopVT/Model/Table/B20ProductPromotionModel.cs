using System;
using System.Collections.Generic;
namespace Model.Model
{
     public class B20ProductPromotionModel 
     {

        public int Id { set; get; }
        public string Code { set; get; }
        public string Name { set; get; }
        public int DisplayOrder { set; get; }
        public string ProductCategoryCode { set; get; }
        public bool IsActive { set; get; }
        public int CreatedBy { set; get; }
        public DateTime CreatedAt { set; get; }
        public int ModifiedBy { set; get; }
        public DateTime ModifiedAt { set; get; }


    }
}


