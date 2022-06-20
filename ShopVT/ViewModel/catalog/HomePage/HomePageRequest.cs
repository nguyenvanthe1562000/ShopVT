using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.catalog.AccDoc
{
    public class HomePageRequest
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

        public string vB10HomePageDetail { set; get; }

    }
}
