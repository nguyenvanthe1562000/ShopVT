using Common;
using Model.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Service.Admin.Service.Interface

{
    public interface IB00AppUserService
    {
        Task<bool> Insert(B00AppUserModel model, int userId);

        Task<bool> Update(B00AppUserModel model, int userId);

        Task<bool> Delete(string code, int userId);


        Task<List<B00AppUserModel>> GetAll();





        Task<PagedResultBase> Paging(PagingRequestBase pagingRequest);




        Task<B00AppUserModel> GetById(string code);


    }
}












