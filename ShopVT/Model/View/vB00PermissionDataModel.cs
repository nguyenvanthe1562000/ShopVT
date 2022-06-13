using System;
using System.Collections.Generic;
namespace Model.Model
{
     public class vB00PermissionDataModel 
     {
        
    public int Id { set; get; }
    public string Description { set; get; }
    public int FunctionType { set; get; }
    public string FunctionName { set; get; }
    public int UserId { set; get; }
    public tinyint _View { set; get; }
    public tinyint _ViewOther { set; get; }
    public tinyint _Create { set; get; }
    public tinyint _Edit { set; get; }
    public tinyint _EditOther { set; get; }
    public tinyint _Delete { set; get; }
    public tinyint _DeleteOrther { set; get; }
    public tinyint _Restore { set; get; }
    public tinyint _RestoreOther { set; get; }
    

     }
}



