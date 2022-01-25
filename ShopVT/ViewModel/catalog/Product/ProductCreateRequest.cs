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
		public string code { set; get; }
		public string Name { set; get; }
		public string Alias { set; get; }
		public string ProductCategoryCode { set; get; }
		public decimal UnitCost { set; get; }
		public decimal UnitPrice { set; get; }
		public int Warranty { set; get; }
		public string Description { set; get; }
		public string Content { set; get; }
		public string Information { set; get; }
		public bool IsActive { set; get; }
		public IFormFile ImageDefault { get; set; }	
		public List<IFormFile> ThumbnailImage { get; set; }
	}
}
