using System;
using System.Collections.Generic;
namespace Model.Model
{
     public class vB10SlideModel 
     {
        
    public int ID { set; get; }
    public bool IsGroup { set; get; }
    public int ParentId { set; get; }
    public string Code { set; get; }
    public string Name { set; get; }
    public string Description { set; get; }
    public string Image { set; get; }
    public string Url { set; get; }
    public int DisplayOrder { set; get; }
    public bool Show { set; get; }
    public string Type { set; get; }
    public bool IsActive { set; get; }
    public int CreatedBy { set; get; }
    public DateTime CreatedAt { set; get; }
    public int ModifiedBy { set; get; }
    public DateTime ModifiedAt { set; get; }
    public string TypeName { set; get; }
    

     }
}



