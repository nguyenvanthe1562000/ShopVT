using System;
using System.Collections.Generic;
namespace Model.Model
{
    public class vB00EventLog_BySessionModel
    {

        public Int64 Id { set; get; }
        public string SessionId { set; get; }
        public string Date { set; get; }
        public string Hour { set; get; }
        public string CommandName { set; get; }
        public string Command { set; get; }
        public string UserIp { set; get; }
        public string AppUserCode { set; get; }
        public string UserName { set; get; }
        public string Description { set; get; }
        public List<vB00EventLog_BySessionDetailModel>  vB00EventLog_BySessionDetail_Json { get; set; }

    }
}



