using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
namespace Model.Model
{
    public class B10PostCategoryModel
    {

        public int ID { set; get; }
        public bool IsGroup { set; get; }
        public int ParentId { set; get; }
        public string Code { set; get; }
        public string Name { set; get; }
        public string Alias { set; get; }
        public string Description { set; get; }
        public int DisplayOrder { set; get; }
        public string MetaDescription { set; get; }
        public string MetaKeyword { set; get; }
        public bool IsActive { set; get; }
        public int CreatedBy { set; get; }
        public List<IFormFile> files { set; get; }
        public IFormFile file { set; get; }
        public DateTime CreatedAt { set; get; }
        public int ModifiedBy { set; get; }
        public DateTime ModifiedAt { set; get; }

    }
}


