using System;
using System.Collections.Generic;
namespace Model.Model
{
     public class vB00PermissionDataModel 
     {
        
        public int CommandId { set; get; }
        public string Description { set; get; }
        public int FunctionType { set; get; }
        public string FunctionName { set; get; }
        public int UserId { set; get; }
        public bool _View            { set; get; }
        public bool _ViewOther           { set; get; }
        public bool _Create               { set; get; }
        public bool _Edit            { set; get; }
        public bool _EditOther           { set; get; }
        public bool _Delete          { set; get; }
        public bool _DeleteOrther            { set; get; }
        public bool _Restore             { set; get; }
        public bool _RestoreOther         { set; get; }
        public bool IsActive            { set; get; }
        public int CreatedBy            { set; get; }
        public DateTime CreatedAt { set; get; }
        public int ModifiedBy { set; get; }
        public DateTime ModifiedAt { set; get; }


    }


    public class vB00PermissionFunctionModel
    {

        public int Id { set; get; }
        public int UserId { set; get; }
        public string Description { set; get; }
        public string CommandTypeId { set; get; }
        public bool _AccessApplication { set; get; }
        public bool _Category { set; get; }
        public bool _Receipt { set; get; }
        public bool _General { set; get; }
        public bool _Report { set; get; }
        public bool _System { set; get; }
    }
}



