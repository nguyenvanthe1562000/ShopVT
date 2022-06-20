using System;
using System.Collections.Generic;
namespace Model.Model
{
    public class B10HomePageModel
    {

        public int Id { set; get; }
        public string Stt { set; get; }
        public string Name { set; get; }
        public bool Show { set; get; }
        public int DisplayOrder { set; get; }
        public bool IsActive { set; get; }
        public int CreatedBy { set; get; }
        public DateTime CreatedAt { set; get; }
        public int ModifiedBy { set; get; }
        public DateTime ModifiedAt { set; get; }

        public List<vB10HomePageDetailModel> vB10HomePageDetail_Json { set; get; }
    }
}



