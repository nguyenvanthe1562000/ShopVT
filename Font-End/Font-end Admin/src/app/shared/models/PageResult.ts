export class PagedResult<T> {
    PageIndex : number;    
    PageSize : number;     
    TotalRecords : number;     
    PageCount : string;   
    Items: T[];
}
  