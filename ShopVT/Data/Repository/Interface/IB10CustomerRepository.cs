using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common;
using Model.Model;

namespace Data.Reponsitory.Interface

{
    public interface IB10CustomerRepository
    {
        Task<bool> Insert(B10CustomerModel model, int userId);

        Task<bool> Update(B10CustomerModel model, int userId);

        Task<bool> Delete(int ID, int userId);


        Task<List<B10CustomerModel>> GetAll();

        Task<List<B10CustomerModel>> Search(string Name);



        Task<PagedResultBase> Paging(PagingRequestBase pagingRequest);

        Task<B10CustomerModel> GetById(int ID);


    }
}




