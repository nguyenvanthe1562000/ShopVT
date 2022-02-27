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
        public string OrderDesc { get; set; }
        public string DisplayMember { get; set; }
    }
}