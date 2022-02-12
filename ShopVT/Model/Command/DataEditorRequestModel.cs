namespace Model.Command
{
    public class DataEditorAddRequestModel:BaseData
    {
        public string ColumnArray { get; set; }
        public string ColumnValue { get; set; }
        public int Condition { get; set; }
        public string ConditionString { get; set; }
    } 

      public class DataEditorUpdateRequestModel:BaseData
    {
        public string QueryUpdateData { get; set; }
        public int RowId { get; set; }
        public int Condition { get; set; }
        public string ConditionString { get; set; }
    } 
}