using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.catalog.PermissionViewModel
{
    public class PermissionDataRequest
    {
        public int Id { set; get; }
        public int UserId { set; get; }
        public string Description { set; get; }
        public string CommandId { set; get; }
        public bool View  { set; get; }
        public bool ViewOther { set; get; }
        public bool Create { set; get; }
        public bool Edit { set; get; }
        public bool EditOther { set; get; }
        public bool Delete { set; get; }
        public bool DeleteOrther { set; get; }
        public bool Restore { set; get; }
        public bool RestoreOther { set; get; }

    }
    public class PermissionFunctionRequest
    {
        public int Id { set; get; }
        public int UserId { set; get; }
        public string Description { set; get; }
        public bool AccessApplicationPermision { set; get; }
        public bool CategoryPermision { set; get; }
        public bool ReceiptPermision { set; get; }
        public bool GeneralPermision { set; get; }
        public bool ReportPermision { set; get; }
        public bool SystemPermision { set; get; }
    }
    public class PermissionRequest
    {
        public int UserId { set; get; }
        public List<PermissionDataRequest> PermissionData{ set; get; }
        public List<PermissionFunctionRequest> PermissionFunctions { set; get; }
    }
}
