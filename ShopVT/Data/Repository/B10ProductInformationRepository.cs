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
    class B10ProductInformationRepository : IB10ProductInformationRepository, IDisposable
    {
        private IDatabaseHelper _dbHelper;
        public B10ProductInformationRepository(IDatabaseHelper databaseHelper)
        {
            _dbHelper = databaseHelper;
        }

        public async Task<bool> Insert(B10ProductInformationModel model, int userId)
        {
            try
            {
                var result = await _dbHelper.ExecuteScalarSProcedureWithTransactionAsync("B10ProductInformation_create", "@IsGroup", model.IsGroup, "@ParentId", model.ParentId, "@code", model.code, "@name", model.name, "@DisplayOrder", model.DisplayOrder, "@user_id", userId);
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











        public async Task<bool> Update(B10ProductInformationModel model, int userId)
        {

            try
            {
                var result = await _dbHelper.ExecuteScalarSProcedureWithTransactionAsync("B10ProductInformation_update", "@IsGroup", model.IsGroup, "@ParentId", model.ParentId, "@code", model.code, "@name", model.name, "@DisplayOrder", model.DisplayOrder, "@IsActive", model.IsActive
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
                var result = await _dbHelper.ExecuteScalarSProcedureWithTransactionAsync("B10ProductInformation_delete", "@code", code, "@user_id", userId);
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




        public async Task<List<B10ProductInformationModel>> GetAll()
        {
            try
            {
                var dt = await _dbHelper.ExecuteSProcedureReturnDataTableAsync("B10ProductInformation_get_all");
                if (!string.IsNullOrEmpty(dt.message))
                {
                    throw new Exception(dt.message);
                }
                var list = await dt.Item2.ConvertToAsync<B10ProductInformationModel>();
                return list.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task<List<B10ProductInformationModel>> Search(string name)
        {
            try
            {
                var dt = await _dbHelper.ExecuteSProcedureReturnDataTableAsync("B10ProductInformation_search", "@name", name);
                if (!string.IsNullOrEmpty(dt.message))
                {
                    throw new Exception(dt.message);
                }
                var list = await dt.Item2.ConvertToAsync<B10ProductInformationModel>();
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

                var dt = await _dbHelper.ExecuteSProcedureReturnDataTableAsync("usp_sys_PagingForTable", "@PageSize", pagingRequest.PageSize, "@PageIndex", pagingRequest.PageIndex, "@orderby", pagingRequest.OrderBy, "@table", "B10ProductInformation");
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





        public async Task<B10ProductInformationModel> GetById(string code)
        {
            string msgError = "";
            try
            {
                var dt = await _dbHelper.ExecuteSProcedureReturnDataTableAsync("B10ProductInformation_get_by_id", "@code", code);
                if (!string.IsNullOrEmpty(dt.message))
                {
                    throw new Exception(dt.message);
                }
                var list = await dt.Item2.ConvertToAsync<B10ProductInformationModel>();
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
        ~B10ProductInformationRepository()
        {
            Dispose(false);

        }
    }
}


















