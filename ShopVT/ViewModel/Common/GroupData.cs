using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Common
{
    public class GroupData
    {
        public int Data { get; set; }
        public int ParentId { get; set; }
        public string Label { get; set; }
        public List<GroupData> Children { get; set; }
    }
  
}
