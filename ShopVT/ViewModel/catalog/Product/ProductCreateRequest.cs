using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.catalog.Product
{
    public class ProductCreateRequest
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
        public string ProductInformation_Json { set; get; }
        public IFormFile ImageDefault { get; set; }

        public List<IFormFile> ThumbnailImage { get; set; }

    }
    public class ProductInformation
    {

        public int ID { set; get; }
        public bool IsGroup { set; get; }
        public int ParentId { set; get; }
        public string ProductCode { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public int DisplayOrder { set; get; }
        public bool IsActive { set; get; }
        public int CreatedBy { set; get; }
        public DateTime CreatedAt { set; get; }
        public int ModifiedBy { set; get; }
        public DateTime ModifiedAt { set; get; }


    }

}
