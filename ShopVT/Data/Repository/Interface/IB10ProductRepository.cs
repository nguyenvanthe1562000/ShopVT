using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common;
using Model.Model;

namespace Data.Reponsitory.Interface

{
    public interface IB10ProductRepository
    {
        Task<bool> Insert(B10ProductModel model,int userId);

        Task<PagedResultBase> Paging(PagingRequestBase pagingRequest);

        Task<bool> Update(B10ProductModel model, int userId);

        Task<bool> Delete(string code, int userId);

        Task<List<B10ProductModel>> GetAll();

        Task<List<B10ProductModel>> Search(string Name);

        Task<B10ProductModel> GetById(string code);


    }
}







