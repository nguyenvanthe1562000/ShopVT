using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common;
using Model.Model;
namespace Data.Reponsitory.Interface

{
    public interface IB10EmployeeRepository
    {
    	Task<bool> Insert( B10EmployeeModel model, int userId);            

	Task<bool> Update( B10EmployeeModel model, int userId);

		Task<bool> Delete(string code, int userId);


		Task<List<B10EmployeeModel>> GetAll();

	Task<List<B10EmployeeModel>> Search(string Name);
  


	  Task<PagedResultBase> Paging(PagingRequestBase pagingRequest);

	Task<B10EmployeeModel> GetById(string code);


    }
}





