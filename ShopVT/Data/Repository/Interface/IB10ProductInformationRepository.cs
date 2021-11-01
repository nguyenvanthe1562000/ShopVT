using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common;
using Model.Model;
namespace Data.Reponsitory.Interface

{
    public interface IB10ProductInformationRepository
    {
        Task<bool> Insert(B10ProductInformationModel model, int userId);

        Task<bool> Update(B10ProductInformationModel model, int userId);

        Task<bool> Delete(string code, int userId);


        Task<List<B10ProductInformationModel>> GetAllParent();
        Task<List<B10ProductInformationModel>> GetChild(string code);

        Task<List<B10ProductInformationModel>> Search(string name);



        Task<PagedResultBase> Paging(PagingRequestBase pagingRequest);

        Task<B10ProductInformationModel> GetById(string code);


    }
}





