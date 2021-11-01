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
  public  class B00ContactRepository : IB00ContactRepository, IDisposable
    {
        private IDatabaseHelper _dbHelper;
        public B00ContactRepository(IDatabaseHelper databaseHelper)
        {
            _dbHelper = databaseHelper;
        }

        public async Task<bool> Insert(B00ContactModel model, int userId)
        {
            try
            {
                var result = await _dbHelper.ExecuteScalarSProcedureWithTransactionAsync("B00Contact_create", "@code", model.code, "@Name", model.Name, "@Email", model.Email, "@PhoneNumber", model.PhoneNumber, "@Facebook", model.Facebook, "@address", model.address, "@user_id", userId);
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











        public async Task<bool> Update(B00ContactModel model, int userId)
        {

            try
            {
                var result = await _dbHelper.ExecuteScalarSProcedureWithTransactionAsync("B00Contact_update", "@code", model.code, "@Name", model.Name, "@Email", model.Email, "@PhoneNumber", model.PhoneNumber, "@Facebook", model.Facebook, "@address", model.address, "@IsActive", model.IsActive, "@CreatedBy", model.CreatedBy, "@CreatedAt", model.CreatedAt, "@ModifiedBy", model.ModifiedBy, "@ModifiedAt", model.ModifiedAt
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
                var result = await _dbHelper.ExecuteScalarSProcedureWithTransactionAsync("B00Contact_delete", "@code", code, "@user_id", userId);
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




        public async Task<List<B00ContactModel>> GetAll()
        {
            try
            {
                var dt = await _dbHelper.ExecuteSProcedureReturnDataTableAsync("B00Contact_get_all");
                if (!string.IsNullOrEmpty(dt.message))
                {
                    throw new Exception(dt.message);
                }
                var list = await dt.Item2.ConvertToAsync<B00ContactModel>();
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

                var dt = await _dbHelper.ExecuteSProcedureReturnDataTableAsync("usp_sys_PagingForTable", "@PageSize", pagingRequest.PageSize, "@PageIndex", pagingRequest.PageIndex, "@orderby", pagingRequest.OrderBy, "@table", "B00Contact");
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





        public async Task<B00ContactModel> GetById(string code)
        {
            string msgError = "";
            try
            {
                var dt = await _dbHelper.ExecuteSProcedureReturnDataTableAsync("B00Contact_get_by_id", "@code", code);
                if (!string.IsNullOrEmpty(dt.message))
                {
                    throw new Exception(dt.message);
                }
                var list = await dt.Item2.ConvertToAsync<B00ContactModel>();
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
        ~B00ContactRepository()
        {
            Dispose(false);

        }
    }
}


















