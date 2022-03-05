using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.catalog.ProductImg
{
    public class ProductImageRequest
    {
        public int Id { get; set; } 
        public string ProductCode { get; set; }
        public string Caption { get; set; }

        public bool IsDefault { get; set; }

        public int SortOrder { get; set; }

        public IFormFile ImageFile { get; set; }
        public bool isActive { get; set; }
    }
}