import { B10ProductInformation } from 'src/app/shared/models/B10ProductInformation';
export class vB10Product {
  
        
    iD : number;    
    isGroup : boolean ;     
    parentId : number;  
    code : string;  
    name : string;  
    alias : string;     
    unit0 : string;     
    convertRate0 : number;     
    unit : string;  
    convertRate : number;  
    manufacturerCode : string;  
    productCategoryCode : string;   
    productCategoryName : string;   

    unitCost : number;     
    unitPrice : number;    
    minCloseQty : number;   
    maxCloseQty : number;   
    warranty : number;  
    description : string;   
    content : string;   
    information : string;   
    isActive : boolean ;    
    createdBy : number;     
    createdAt : Date;   
    modifiedBy : number;    
    modifiedAt : Date;  
    image : string;     
    imageCation : string
        
b10ProductInformation_Json:Array<any>;
b10ProductImg_Json:Array<any>;
    }
  