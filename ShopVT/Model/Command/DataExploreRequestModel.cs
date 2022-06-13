namespace Model.Command
{
    public class DataExploreRequestModel:BaseCommand
    {
        public string ColumnArray { get; set; }
        public string ColumnValue { get; set; }
        public bool Condition { get; set; }
        public string ConditionString { get; set; }
    }
    public class DataExploreLookupRequestModel : BaseCommand
    {
        public string Filter { get; set; }
        public string OrderBy { get; set; }
        public bool OrderDesc { get; set; }
        public int RowsTotal { get; set; }
    }
    public class DataExploreGetDataRequestModel : BaseCommand
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public bool DataIsActive { get; set; }
        public string Filter { get; set; }
        public string OrderBy { get; set; }
        public bool OrderDesc { get; set; }
    }
    public class DataExploreGetDataByGroupRequestModel : BaseCommand
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int IdGroup { get; set; }
        public string Filter { get; set; }
        public string OrderBy { get; set; }
        public string OrderDesc { get; set; }
    }
    public class DataExploreGetDataByIdRequestModel : BaseCommand
    {
        public int RowId { get; set; }
    }
    public class DataExploreGetGroupRequestModel : BaseCommand
    {
        public string ColumnCaption { get; set; }
        public string OrderBy { get; set; }
        public bool OrderDesc { get; set; }
    }
    public class DataExploreGetMultipleDataByIdRequestModel : BaseCommand
    {
        public int RowId { get; set; }
        public string SubTable { get; set; }
       
    }
    public enum FilterType
    {
        NotEmpty,
        Empty,
        Contains,
        StartsWith,
        EndsWith,
        Equals,
        GreaterThan,
        LessThan,
        Other,
    }
}