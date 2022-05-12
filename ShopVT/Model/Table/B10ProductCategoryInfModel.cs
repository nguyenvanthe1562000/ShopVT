using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Table
{
    public class B10ProductCategoryInfModel
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public int DisplayOrder { set; get; }
        public string ProductCategoryCode { set; get; }
        public bool IsActive { set; get; }
        public int CreatedBy { set; get; }
        public DateTime CreatedAt { set; get; }
        public int ModifiedBy { set; get; }
        public DateTime ModifiedAt { set; get; }

    }
}
