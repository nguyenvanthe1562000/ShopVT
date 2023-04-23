using System;
using System.Collections.Generic;
namespace Model.Model
{
    public class vB10ProductModel
    {

        public int ID { set; get; }
        public bool IsGroup { set; get; }
        public int ParentId { set; get; }
        public string Code { set; get; }
        public string Name { set; get; }
        public string Alias { set; get; }
        public string Unit0 { set; get; }
        public decimal ConvertRate0 { set; get; }
        public string Unit { set; get; }
        public decimal ConvertRate { set; get; }
        public string ManufacturerCode { set; get; }
        public string ProductCategoryCode { set; get; }
        public decimal UnitCost { set; get; }
        public decimal UnitPrice { set; get; }
        public int MinCloseQty { set; get; }
        public int MaxCloseQty { set; get; }
        public int Warranty { set; get; }
        public string Description { set; get; }
        public string Content { set; get; }
        public string Information { set; get; }
        public bool IsActive { set; get; }
        public int CreatedBy { set; get; }
        public DateTime CreatedAt { set; get; }
        public int ModifiedBy { set; get; }
        public DateTime ModifiedAt { set; get; }
        public decimal Weight { set; get; }
        public string Gender { set; get; }
        public string Size { set; get; }
        public string ItemSetCode { set; get; }
        public string ColorCode { set; get; }
        public string Image { set; get; }
        public string ImageCation { set; get; }

        public List<B10ProductInformationModel> B10ProductInformation_Json { get; set; }
        public List<B10ProductImgModel> B10ProductImg_Json { get; set; }


    }
}


