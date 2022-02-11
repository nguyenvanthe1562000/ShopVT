//using API.Interfaces;
//using Common.Helper;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Data
//{
//    public class ExploreRepository :  IDisposable
//    {
//        private IDatabaseHelper _dbHelper;
//        private ILogger _logger;

//        public ExploreRepository(IDatabaseHelper databaseHelper)
//        {
//            _dbHelper = databaseHelper;
//        }
        
//        public async Task<DataTable> GetDataByGroup(string table, string order, bool desc)
//        {
//            try
//            {
//                string msgError = "";
//                var data =await _dbHelper.ExecuteSProcedureReturnDataTableAsync("");
//                return data;
//            }
//            catch (Exception ex)
//            {
//                _logger.Log(LogType.Error, ex.Message, (new StackTrace(ex, true)).GetFrames().Last(), new { Query = Query });
//                return null;
//            }
           
//        }
//        public DataTable GetDataGroup(string Query)
//        {
//            try
//            {
//                string msgError = "";
//                var data = _dbHelper.ExecuteQueryToDataTable(Query, out msgError);
//            }
//            catch (Exception ex)
//            {

//                _logger.Log(LogType.Error, ex.Message, (new StackTrace(ex, true)).GetFrames().Last(), new { Query = Query });
//                return null;
//            }
//        }
//        public DataTable GetData()
//        {
//            try
//            {
//                string msgError = "";
//                var data = _dbHelper.ExecuteQueryToDataTable(Query, out msgError);
//            }
//            catch (Exception ex)
//            {

//                _logger.Log(LogType.Error, ex.Message, (new StackTrace(ex, true)).GetFrames().Last(), new { Query = Query });
//                return null;
//            }
//        }
//        public DataTable FilterData(string )
//        {

//        }
//        public DataTable GetHistory(string )
//        {

//        }


//        private bool disposed = false;
//        public void Dispose()
//        {
//            Dispose(true);
//            GC.SuppressFinalize(this);
//        }
//        protected virtual void Dispose(bool disposing)
//        {
//            if (!disposed)
//            {

//                if (_dbHelper != null)
//                {
//                    _dbHelper = null;

//                    //GC.Collect();
//                }
//                disposed = true;
//            }

//        }
//        ~B00AppUserRepository()
//        {
//            Dispose(false);

//        }
//    }
//}
