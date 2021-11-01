using Common;
using Model.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Admin.Service.Interface

{
    public interface IB00ContactService
    {
        Task<bool> Insert(B00ContactModel model, int userId);

        Task<bool> Update(B00ContactModel model, int userId);

        Task<bool> Delete(string code, int userId);


        Task<List<B00ContactModel>> GetAll();




        Task<PagedResultBase> Paging(PagingRequestBase pagingRequest);




        Task<B00ContactModel> GetById( string code);


    }
}











