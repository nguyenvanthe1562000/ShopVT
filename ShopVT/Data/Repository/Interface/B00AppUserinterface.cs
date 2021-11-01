using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common;
using Model.Model;
namespace Data.Reponsitory.Interface

{
    public interface IB00AppUserRepository
    {
    	Task<bool> Insert( B00AppUserModel model, int userId);            

	Task<bool> Update( B00AppUserModel model, int userId);         

	 Task<bool>  Delete( string code, int userId);


	Task<List<B00AppUserModel>> GetAll();

	Task<List<B00AppUserModel>> Search();
  


	  Task<PagedResultBase> Paging(PagingRequestBase pagingRequest);

	Task<B00AppUserModel> GetById(string code);


    }
}





