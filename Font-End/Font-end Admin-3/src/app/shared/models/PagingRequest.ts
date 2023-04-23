export class PagingRequest {
    ParentId: number;
    PageIndex : number;    
    PageSize : number;     
    OrderBy : string;   
    OrderDesc : boolean;  
    FilterColumn : string;     
    FilterType : FilterType;  
    FilterValue : string
    DataIsActive: boolean;
    constructor (){
        this.DataIsActive=true;
        this.PageSize = 100;
    }
   
}
    
export enum FilterType {
    NotEmpty,
    Empty,
    Contains,
    StartsWith,
    EndsWith,
    Equals,
    GreaterThan,
    LessThan
 }

 export class lookupRequest {
    LookupKey : string;     
    LookupValue: string;
    LoadFilterExpr : string;  
    NumberRow : string
    OrderBy: string;
   
 }