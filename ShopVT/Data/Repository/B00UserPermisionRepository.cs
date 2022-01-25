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
   class B00UserPermisionRepository:IB00UserPermisionRepository,IDisposable
   {
        private IDatabaseHelper _dbHelper;
        public B00UserPermisionRepository(IDatabaseHelper databaseHelper)
        {
            _dbHelper = databaseHelper;
        }
        
 public async Task<bool> Insert(B00UserPermisionModel model, int userId)
        {
                  try
            {                  
                var result =  await _dbHelper.ExecuteScalarSProcedureWithTransactionAsync("B00UserPermision_create","@userCode", model.userCode, "@PermisionCode", model.PermisionCode,"@user_id", userId);
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
   









        
 public async Task<bool>  Update(B00UserPermisionModel model, int userId)
        {
        
            try
            {
                var result = await _dbHelper.ExecuteScalarSProcedureWithTransactionAsync("B00UserPermision_update","@userCode", model.userCode, "@PermisionCode", model.PermisionCode, "@IsActive", model.IsActive
                ,"@user_id", userId);
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

        
public async Task<bool>  Delete(string userCode, int userId)
{

        try
        {
                var result =await _dbHelper.ExecuteScalarSProcedureWithTransactionAsync( "B00UserPermision_delete","@userCode", userCode,"@user_id", userId);
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



        
        public async Task<List<B00UserPermisionModel>>GetAll()
        {
            try
            {
                var dt =await  _dbHelper.ExecuteSProcedureReturnDataTableAsync("B00UserPermision_get_all");
             if (!string.IsNullOrEmpty(dt.message))
                {
                    throw new Exception(dt.message);
                }
                var list = await dt.Item2.ConvertToAsync<B00UserPermisionModel>();
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

                var dt = await _dbHelper.ExecuteSProcedureReturnDataTableAsync("usp_sys_PagingForTable", "@PageSize", pagingRequest.PageSize, "@PageIndex", pagingRequest.PageIndex, "@orderby", pagingRequest.OrderBy, "@table", "B00UserPermision");
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




        
        public  async Task<B00UserPermisionModel> GetById(string userCode)
        {
            string msgError = "";
            try
            {
                var dt = await _dbHelper.ExecuteSProcedureReturnDataTableAsync( "B00UserPermision_get_by_id","@userCode", userCode);
               if (!string.IsNullOrEmpty(dt.message))
                {
                    throw new Exception(dt.message);
                }
 var list = await dt.Item2.ConvertToAsync<B00UserPermisionModel>();
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
        ~B00UserPermisionRepository()
        {
            Dispose(false);

        }
   }
}


















