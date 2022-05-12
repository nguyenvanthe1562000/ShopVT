export class PagingRequest {
    PageIndex : number;    
    PageSize : number;     
    OrderBy : string;   
    OrderDesc : boolean;  
    FilterColumn : string;     
    FilterType : FilterType;  
    FilterValue : string
   
}
    
export enum FilterType {
    NotEmpty,
    Empty,
    Contains,
    StartsWith,
    EndsWith,
    Equals
 }