using System;
using System.Collections.Generic;
namespace Model.Model
{
     public class B10ProductImgModel 
     {
       	
		public int ID { set; get; }
		public bool		IsGroup			{ set; get; }
		public int		ParentId		{ set; get; }
		public string	ProductCode			{ set; get; }
		public string	ImagePath		 { set; get; }
		public string	Caption			 { set; get; }
		public int		SortOrder		{ set; get; }
		public long		ImglengthSize		{ set; get; }
		public bool		IsActive		{ set; get; }
		public int		CreatedBy { set; get; }
		public DateTime CreatedAt { set; get; }
		public int ModifiedBy { set; get; }
		public DateTime ModifiedAt { set; get; }
		public bool ImageDefault { set; get; }

     }
}


