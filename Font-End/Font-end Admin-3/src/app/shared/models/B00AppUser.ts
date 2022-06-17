export class B00AppUser {   
    id : number;    
    isGroup : boolean ;     
    parentId : number;  
    code : string;  
    username : string;  
    passWord : string;  
    fullName : string;  
    isActive : boolean ;    
    createdBy : number;     
    createdAt : Date;   
    modifiedBy : number;    
    modifiedAt : Date;  
    employeeCode : string;
    PermissionData : Array<any>;
    PermissionFunction: any;
 }
    