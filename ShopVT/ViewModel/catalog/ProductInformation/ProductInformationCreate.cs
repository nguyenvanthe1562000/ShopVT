using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.catalog.ProductInformation
{
    public class ProductInformationCreate
    {
        public bool IsGroup { set; get; }
        public int ParentId { set; get; }
        public string Code { set; get; }
        public string Name { set; get; }
        public int DisplayOrder { set; get; }
        public bool IsActive { set; get; }

    }
}
