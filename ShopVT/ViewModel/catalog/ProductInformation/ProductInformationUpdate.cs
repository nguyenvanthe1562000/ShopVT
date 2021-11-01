using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.catalog.ProductInformation
{
    class ProductInformationUpdate
    {
		public bool IsGroup { set; get; }
		public int ParentId { set; get; }
		public string code { set; get; }
		public string name { set; get; }
		public int DisplayOrder { set; get; }
		public bool IsActive { set; get; }

	}
}
