using Common;
using Model.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Service.Admin.Service.Interface

{
    public interface IB10ProductInformationService
    {
    	Task<bool> Insert( B10ProductInformationModel model, int userId);            

	Task<bool> Update( B10ProductInformationModel model, int userId);         

	
	Task<List<B10ProductInformationModel>> GetAll();

	Task<List<B10ProductInformationModel>> Search(string name);
  


	  Task<PagedResultBase> Paging(PagingRequestBase pagingRequest);



	
	Task<B10ProductInformationModel> GetById(string code);


    }
}












