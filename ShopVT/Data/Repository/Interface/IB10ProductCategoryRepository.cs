using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common;
using Model.Model;

namespace Data.Reponsitory.Interface

{
    public interface IB10ProductCategoryRepository
    {
        Task<bool> Insert(B10ProductCategoryModel model, int userId);

        Task<bool> Update(B10ProductCategoryModel model, int userId);

        Task<bool> Delete(string code, int userId);


        Task<List<B10ProductCategoryModel>> GetAll();

        Task<List<B10ProductCategoryModel>> Search(string Name);



        Task<PagedResultBase> Paging(PagingRequestBase pagingRequest);

        Task<B10ProductCategoryModel> GetById(string code);


    }
}




