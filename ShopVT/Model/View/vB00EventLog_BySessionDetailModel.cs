using System;
using System.Collections.Generic;
namespace Model.Model
{
    public class vB00EventLog_BySessionDetailModel
    {

        public Int64 ID { set; get; }
        public string SessionId { set; get; }
        public string LastValue { set; get; }
        public string Command { set; get; }
        public string NewValue { set; get; }
        public string TableName { set; get; }
        public DateTime LastWriteAt { set; get; }
        public int LastWriteBy { set; get; }
        public Int64 RowId { set; get; }
        public string ColumnName { set; get; }
        public string TableFullName { set; get; }
        public string CommandName { set; get; }
        public string ColumnFullName { set; get; }


    }
}



