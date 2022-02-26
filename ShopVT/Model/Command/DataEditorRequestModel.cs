namespace Model.Command
{
    public class DataEditorAddRequestModel: BaseCommand
    {
        public string ColumnArray { get; set; }
        public string ColumnValue { get; set; }
        public int Condition { get; set; }
        public string ConditionString { get; set; }
    }
    public class DataEditorAddRangeRequestModel : BaseCommand
    {
        public string ColumnArray { get; set; }
        public string ColumnValue { get; set; }
        public int Condition { get; set; }
        public string ConditionString { get; set; }
        public string CommandInsertTableChild { get; set; }
    }
    public class DataEditorUpdateRequestModel: BaseCommand
    {
        public string QueryUpdateData { get; set; }
        public int RowId { get; set; }
        public int Condition { get; set; }
        public string ConditionString { get; set; }
    }
    public class DataEditorDeleteRequestModel : BaseCommand
    {
        public int RowId { get; set; }
        public int Condition { get; set; }
        public string ConditionString { get; set; }
    }
    public class DataEditorRestoreRequestModel : BaseCommand
    {
        public int RowId { get; set; }
        public int Condition { get; set; }
        public string ConditionString { get; set; }
    }


    public class DataEditorUpdateRangeRequestModel : BaseCommand
    {
        public string QueryUpdateData { get; set; }
        public int RowId { get; set; }
        public int Condition { get; set; }
        public string ConditionString { get; set; }
        public string JsonTableChild { get; set; }
        public string QueryUpdate { get; set; }
        public string QueryDelete { get; set; }
        public string QueryInsert { get; set; }
        public string TempTable { get; set; }
        public string QueryDropTempTable { get; set; }

    }
}