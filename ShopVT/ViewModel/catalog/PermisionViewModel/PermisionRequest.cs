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
        public int CommandId { set; get; }
        public bool _View  { set; get; }
        public bool _ViewOther { set; get; }
        public bool _Create { set; get; }
        public bool _Edit { set; get; }
        public bool _EditOther { set; get; }
        public bool _Delete { set; get; }
        public bool _DeleteOrther { set; get; }
        public bool _Restore { set; get; }
        public bool _RestoreOther { set; get; }

    }
    public class PermissionFunctionRequest
    {
        public int Id { set; get; }
        public int UserId { set; get; }
        public string Description { set; get; }
        public bool _AccessApplication  { set; get; }
        public bool _Category           { set; get; }
        public bool _Receipt                { set; get; }
        public bool _General                { set; get; }
        public bool _Report                 { set; get; }
        public bool _System                 { set; get; }
    }
    public class PermissionRequest
    {
        //public int UserId { set; get; }
        public int Id { set; get; }
        public bool IsGroup { set; get; }
        public int ParentId { set; get; }
        public string Code { set; get; }
        public string Username { set; get; }
        public string PassWord { set; get; }
        public string FullName { set; get; }

        public string EmployeeCode { set; get; }
        public List<PermissionDataRequest> PermissionData{ set; get; }
        public string PermissionData1{ set; get; }
        public PermissionFunctionRequest PermissionFunction { set; get; }
        public string PermissionFunction1 { set; get; }
    }
}
