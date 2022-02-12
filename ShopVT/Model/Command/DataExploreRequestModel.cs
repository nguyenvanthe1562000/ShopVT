namespace Model.Command
{
    public class DataExploreRequestModel:BaseData
    {
        public string ColumnArray { get; set; }
        public string ColumnValue { get; set; }
        public bool Condition { get; set; }
        public string ConditionString { get; set; }
    } 
}