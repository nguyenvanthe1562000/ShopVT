using Common;
using Common.Helper;
using Data.Reponsitory.Interface;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Data.Reponsitory
{
    class B10EmployeeRepository : IB10EmployeeRepository, IDisposable
    {
        private IDatabaseHelper _dbHelper;
        public B10EmployeeRepository(IDatabaseHelper databaseHelper)
        {
            _dbHelper = databaseHelper;
        }

        public async Task<bool> Insert(B10EmployeeModel model, int userId)
        {
            try
            {
                var result = await _dbHelper.ExecuteScalarSProcedureWithTransactionAsync("B10Employee_create", "@code", model.code, "@Name", model.Name, "@Name2", model.Name2, "@BirthDate", model.BirthDate, "@Address", model.Address, "@IdCardNo", model.IdCardNo, "@IdCardDate", model.IdCardDate, "@IdCardIssuePlace", model.IdCardIssuePlace, "@BankAccount", model.BankAccount, "@BankName", model.BankName, "@Tel1", model.Tel1, "@Tel2", model.Tel2, "@MarriageStatus", model.MarriageStatus, "@Email", model.Email, "@Gender", model.Gender, "@user_id", userId);
                if (!string.IsNullOrEmpty(result.message.ToString()))
                {
                    return false;
                    throw new Exception(result.message);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }











        public async Task<bool> Update(B10EmployeeModel model, int userId)
        {

            try
            {
                var result = await _dbHelper.ExecuteScalarSProcedureWithTransactionAsync("B10Employee_update", "@code", model.code, "@Name", model.Name, "@Name2", model.Name2, "@BirthDate", model.BirthDate, "@Address", model.Address, "@IdCardNo", model.IdCardNo, "@IdCardDate", model.IdCardDate, "@IdCardIssuePlace", model.IdCardIssuePlace, "@BankAccount", model.BankAccount, "@BankName", model.BankName, "@Tel1", model.Tel1, "@Tel2", model.Tel2, "@MarriageStatus", model.MarriageStatus, "@Email", model.Email, "@Gender", model.Gender, "@IsActive", model.IsActive
                , "@user_id", userId);
                if (!string.IsNullOrEmpty(result.message.ToString()))
                {
                    return false;
                    throw new Exception(result.message);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<bool> Delete(string code, int userId)
        {

            try
            {
                var result = await _dbHelper.ExecuteScalarSProcedureWithTransactionAsync("B10Employee_delete", "@code", code, "@user_id", userId);
                if (!string.IsNullOrEmpty(result.message.ToString()))
                {
                    return false;
                    throw new Exception(result.message);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public async Task<List<B10EmployeeModel>> GetAll()
        {
            try
            {
                var dt = await _dbHelper.ExecuteSProcedureReturnDataTableAsync("B10Employee_get_all");
                if (!string.IsNullOrEmpty(dt.message))
                {
                    throw new Exception(dt.message);
                }
                var list = await dt.Item2.ConvertToAsync<B10EmployeeModel>();
                return list.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task<List<B10EmployeeModel>> Search(string Name)
        {
            try
            {
                var dt = await _dbHelper.ExecuteSProcedureReturnDataTableAsync("B10Employee_search", "@Name", Name);
                if (!string.IsNullOrEmpty(dt.message))
                {
                    throw new Exception(dt.message);
                }
                var list = await dt.Item2.ConvertToAsync<B10EmployeeModel>();
                return list.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task<PagedResultBase> Paging(PagingRequestBase pagingRequest)
        {
            try
            {

                var dt = await _dbHelper.ExecuteSProcedureReturnDataTableAsync("usp_sys_PagingForTable", "@PageSize", pagingRequest.PageSize, "@PageIndex", pagingRequest.PageIndex, "@orderby", pagingRequest.OrderBy, "@table", "B10Employee");
                if (!string.IsNullOrEmpty(dt.message))
                {
                    throw new Exception(dt.message);
                }
                var list = await dt.Item2.ConvertToAsync<PagedResultBase>();
                return list.ToList().FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        public async Task<B10EmployeeModel> GetById(string code)
        {
            string msgError = "";
            try
            {
                var dt = await _dbHelper.ExecuteSProcedureReturnDataTableAsync("B10Employee_get_by_id", "@code", code);
                if (!string.IsNullOrEmpty(dt.message))
                {
                    throw new Exception(dt.message);
                }
                var list = await dt.Item2.ConvertToAsync<B10EmployeeModel>();
                return list.ToList().FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {

                if (_dbHelper != null)
                {
                    _dbHelper = null;

                    //GC.Collect();
                }
                disposed = true;
            }

        }
        ~B10EmployeeRepository()
        {
            Dispose(false);

        }
    }
}


















