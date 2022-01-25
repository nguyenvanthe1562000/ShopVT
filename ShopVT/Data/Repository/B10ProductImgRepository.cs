using Common;
using Common.Helper;
using Data.Reponsitory.Interface;
using Model.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Data.Reponsitory
{
    public class B10ProductImgRepository : IB10ProductImgRepository, IDisposable
    {
        private IDatabaseHelper _dbHelper;
        public B10ProductImgRepository(IDatabaseHelper databaseHelper)
        {
            _dbHelper = databaseHelper;
        }

        public async Task<bool> Insert(B10ProductImgModel model, int userId)
        {
            try
            {
                model = await SetObjectValueDefault.SetValueDefault<B10ProductImgModel>(model);
                var result = await _dbHelper.ExecuteScalarSProcedureWithTransactionAsync("B10ProductImg_create", "@IsGroup", model.IsGroup, "@ParentId", model.ParentId, "@ProductCode", model.ProductCode, "@ImagePath", model.ImagePath, "@Caption", model.Caption, "@SortOrder", model.SortOrder, "@ImglengthSize", model.ImglengthSize, "@IsActive", model.IsActive, "@ImageDefault", model.ImageDefault, "@user_id", userId);
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











        public async Task<bool> Update(B10ProductImgModel model, int userId)
        {

            try
            {
                model = await SetObjectValueDefault.SetValueDefault<B10ProductImgModel>(model);
                var result = await _dbHelper.ExecuteScalarSProcedureWithTransactionAsync("B10ProductImg_update", "@IsGroup", model.IsGroup, "@ParentId", model.ParentId, "@ProductCode", model.ProductCode, "@ImagePath", model.ImagePath, "@Caption", model.Caption, "@SortOrder", model.SortOrder, "@ImglengthSize", model.ImglengthSize, "@IsActive", model.IsActive, "@CreatedBy", model.CreatedBy, "@CreatedAt", model.CreatedAt, "@ModifiedBy", model.ModifiedBy, "@ModifiedAt", model.ModifiedAt, "@ImageDefault", model.ImageDefault
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


        public async Task<bool> Delete(int ID, int userId)
        {

            try
            {
                var result = await _dbHelper.ExecuteScalarSProcedureWithTransactionAsync("B10ProductImg_delete", "@ID", ID, "@user_id", userId);
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




        public async Task<List<B10ProductImgModel>> GetAll(string code)
        {
            try
            {
                var dt = await _dbHelper.ExecuteSProcedureReturnDataTableAsync("B10ProductImg_get_all", "@ProductCode",code);
                if (!string.IsNullOrEmpty(dt.message))
                {
                    throw new Exception(dt.message);
                }
                var list = await dt.Item2.ConvertToAsync<B10ProductImgModel>();
                return list.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task<bool> SaveFormList(List<B10ProductImgModel> b10ProductImgModels, int userId)
        {
            try
            {
                var dt = await _dbHelper.ExecuteScalarSProcedureWithTransactionAsync("B10ProductImg_save_from_list", "@listjson_B10ProductImg", JsonConvert.SerializeObject(b10ProductImgModels), "@user_id", userId);
                if (!string.IsNullOrEmpty(dt.message.ToString()))
                {
                    return false;
                    throw new Exception(dt.message);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task<bool> UpdateFormList(List<B10ProductImgModel> b10ProductImgModels, int userId)
        {
            try
            {
                var dt = await _dbHelper.ExecuteScalarSProcedureWithTransactionAsync("B10ProductImg_update_from_list", "@listjson_B10ProductImg", JsonConvert.SerializeObject(b10ProductImgModels), "@user_id", userId);
                if (!string.IsNullOrEmpty(dt.message.ToString()))
                {
                    return false;
                    throw new Exception(dt.message);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public async Task<PagedResultBase> Paging(PagingRequestBase pagingRequest)
        {
            try
            {

                var dt = await _dbHelper.ExecuteSProcedureReturnDataTableAsync("usp_sys_PagingForTable", "@PageSize", pagingRequest.PageSize, "@PageIndex", pagingRequest.PageIndex, "@orderby", pagingRequest.OrderBy, "@table", "B10ProductImg");
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





        public async Task<B10ProductImgModel> GetById(int ID, string ProductCode)
        {
            string msgError = "";
            try
            {
                var dt = await _dbHelper.ExecuteSProcedureReturnDataTableAsync("B10ProductImg_get_by_id", "@ID", ID, "@ProductCode", ProductCode);
                if (!string.IsNullOrEmpty(dt.message))
                {
                    throw new Exception(dt.message);
                }
                var list = await dt.Item2.ConvertToAsync<B10ProductImgModel>();
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
        ~B10ProductImgRepository()
        {
            Dispose(false);

        }
    }
}



















