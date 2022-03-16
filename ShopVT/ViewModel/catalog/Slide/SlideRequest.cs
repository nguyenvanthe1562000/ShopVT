using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.catalog.Slide
{
    public class SlideRequest
    {
        public int ID { set; get; }
        public bool IsGroup { set; get; }
        public int ParentId { set; get; }
        public string code { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public IFormFile Image { set; get; }
        public string Url { set; get; }
        public int DisplayOrder { set; get; }
        public int Type { set; get; }
        public bool IsActive { set; get; }
        public int CreatedBy { set; get; }
        public DateTime CreatedAt { set; get; }
        public int ModifiedBy { set; get; }
        public DateTime ModifiedAt { set; get; }
    }
}
