using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common;
using Model.Model;
namespace Data.Reponsitory.Interface

{
    public interface IB10PostCategoryRepository
    {
    	Task<bool> Insert( B10PostCategoryModel model, int userId);            

	Task<bool> Update( B10PostCategoryModel model, int userId);         

	 Task<bool>  Delete( string code, int userId);


	Task<List<B10PostCategoryModel>> GetAll();

	Task<List<B10PostCategoryModel>> Search(string Name);
  


	  Task<PagedResultBase> Paging(PagingRequestBase pagingRequest);

	Task<B10PostCategoryModel> GetById(string code);


    }
}





