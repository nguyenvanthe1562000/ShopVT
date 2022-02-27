using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class GenerateId
    {
        public static Task<string> NewId(int userid)
        {
            return Task.Run(() =>
            {
                return userid.ToString() + DateTime.Now.ToString("yyyyMMdd") + Guid.NewGuid().ToString().Split('-').ToList()[4]; 
            });
        }
    }
}
