using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.ViewModels.Catalog.ProductImages
{
    public class ProductImageViewModel
    {
        public int Id { get; set; }

        public int ProductCode { get; set; }

        public string ImagePath { get; set; }

        public string Caption { get; set; }

        public bool ImageDefault { get; set; }
        public int SortOrder { get; set; }

        public long FileSize { get; set; }
    }
}