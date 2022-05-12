using Model.Table;
using System;
using System.Collections.Generic;
namespace Model.Model
{
    public class B10ProductCategoryModel
    {

        public int Id { set; get; }
        public bool IsGroup { set; get; }
        public int ParentId { set; get; }
        public string Code { set; get; }
        public string Name { set; get; }
        public string Alias { set; get; }
        public string Description { set; get; }
        public int DisplayOrder { set; get; }
        public bool IsActive { set; get; }
        public int CreatedBy { set; get; }
        public DateTime CreatedAt { set; get; }
        public int ModifiedBy { set; get; }
        public DateTime ModifiedAt { set; get; }
        public List<B10ProductCategoryInfModel> B10ProductCategoryInf_Json { get; set; }
    }
}


