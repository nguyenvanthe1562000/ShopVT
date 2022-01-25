using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common;
using Model.Model;
using ViewModel.catalog.Product;
using ViewModel.Common;

namespace Service.Admin.Service.Interface

{
    public interface IB10ProductService
    {
        Task<bool> Insert(ProductCreateRequest model, int userId);

        Task<PagedResultAdmin<B10ProductModel>> Paging(PagingRequestBase pagingRequest);

        Task<bool> Update(ProductUpdateRequest model, int userId);

        Task<bool> Delete(string code, int userId);

        Task<List<B10ProductModel>> GetAll();

        Task<List<ProductViewModel>> Search(string Name);

        Task<ProductViewModel> GetById(string code);

    }
}







