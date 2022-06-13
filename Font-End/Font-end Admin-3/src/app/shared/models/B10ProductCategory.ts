import { B10ProductCategoryInf } from "./B10ProductCategoryInf";

export class B10ProductCategory {
  
        
    iD : number;    
    isGroup : boolean ;     
    parentId : number;  
    code : string;  
    name : string;  
    alias : string;     
    description : string;   
    displayOrder : number;  
    isActive : boolean ;    
    createdBy : number;     
    createdAt : Date;   
    modifiedBy : number;    
    modifiedAt : Date
    b10ProductCategoryInf_Json: Array<any>[];
    }
    