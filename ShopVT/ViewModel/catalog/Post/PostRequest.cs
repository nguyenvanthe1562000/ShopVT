using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.catalog.Post
{
    public class PostRequest
    {

        public int Id { set; get; }
        public string Name { set; get; }
        public string Alias { set; get; }
        public string PostCategoryCode { set; get; }
        public IFormFile Image { set; get; }
        public string Description { set; get; }
        public string Content { set; get; }
        public string MetaDescription { set; get; }
        public string MetaKeyword { set; get; }
    }
}
