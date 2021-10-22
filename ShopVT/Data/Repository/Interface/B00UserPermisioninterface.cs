using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common;
using Model.Model;
namespace Data.Reponsitory.Interface

{
    public interface IB00UserPermisionRepository
    {
    	Task<bool> Insert( B00UserPermisionModel model, int userId);            

	Task<bool> Update( B00UserPermisionModel model, int userId);         

	 Task<bool>  Delete( string userCode, int userId);


	Task<List<B00UserPermisionModel>> GetAll();

	


	  Task<PagedResultBase> Paging(PagingRequestBase pagingRequest);

	Task<B00UserPermisionModel> GetById(string userCode);


    }
}





