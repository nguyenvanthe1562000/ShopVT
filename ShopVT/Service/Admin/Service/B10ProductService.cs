using Common;
using Common.Interface;
using Data.Reponsitory.Interface;
using Microsoft.AspNetCore.Http;

using Model.Model;
using Newtonsoft.Json;
using Service.Admin.Service.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ViewModel.catalog.Product;
using ViewModel.Common;

namespace Service.Admin.Service
{
    public class B10ProductService : IB10ProductService
    {
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";
        private IB10ProductRepository _B10ProductRepository;
        private IB10ProductImgRepository _b10ProductImg;

        public B10ProductService(IB10ProductRepository B10Product, IB10ProductImgRepository b10ProductImg, IStorageService storageService)
        {
            _storageService = storageService;
            _B10ProductRepository = B10Product;
            _b10ProductImg = b10ProductImg;
        }

        public async Task<bool> Insert(ProductCreateRequest model, int userId)
        {
            try
            {
                var b10ProductModel = Task.Run(() =>
                   {
                       B10ProductModel b10ProductModel = new B10ProductModel()
                       {
                           code = model.code,

                           Name = model.Name,
                           Alias = model.Alias,
                           ProductCategoryCode = model.ProductCategoryCode,
                           UnitCost = model.UnitCost,
                           UnitPrice = model.UnitPrice,
                           Warranty = model.Warranty
                       };
                       return b10ProductModel;
                   });

                var b10ProductImgModel = Task.Run(() =>
                 {
                     List<B10ProductImgModel> listImg = new List<B10ProductImgModel>();
                     B10ProductImgModel b10ProductImgModel = new B10ProductImgModel()
                     {

                         ProductCode = model.code,
                         Caption = model.Name,
                         SortOrder = 1,
                         ImagePath = this.SaveFile(model.ImageDefault).Result,
                         ImageDefault = true,
                         ImglengthSize = model.ImageDefault.Length,
                         IsActive = true,

                     };
                     listImg.Add(b10ProductImgModel);
                     if (model.ThumbnailImage != null)
                     {
                         foreach (var item in model.ThumbnailImage)
                         {
                             B10ProductImgModel b10ProductImg = new B10ProductImgModel()
                             {

                                 ProductCode = model.code,
                                 ImagePath = this.SaveFile(model.ImageDefault).Result,
                                 Caption = model.Name,
                                 SortOrder = 1,
                                 ImageDefault = false,
                                 ImglengthSize = model.ImageDefault.Length,
                                 IsActive = true,
                             };
                             listImg.Add(b10ProductImg);
                         }
                     }

                     return listImg;
                 });



                var check = await _B10ProductRepository.Insert(await b10ProductModel, userId);
                check = await _b10ProductImg.SaveFormList(await b10ProductImgModel, userId);
                //await _b10img
                return check;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }


        }
        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return "/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
        }

        public async Task<bool> Update(ProductUpdateRequest model, int userId)
        {
            try
            {
                var b10ProductModel = Task.Run(() =>
                {
                    B10ProductModel b10ProductModel = new B10ProductModel()
                    {
                        code = model.code,

                        Name = model.Name,
                        Alias = model.Alias,
                        ProductCategoryCode = model.ProductCategoryCode,
                        UnitCost = model.UnitCost,
                        UnitPrice = model.UnitPrice,
                        Warranty = model.Warranty
                    };
                    return b10ProductModel;
                });

                var b10ProductImgModel = Task.Run(() =>
                {
                    List<B10ProductImgModel> listImg = new List<B10ProductImgModel>();
                    B10ProductImgModel b10ProductImgModel = new B10ProductImgModel()
                    {

                        ProductCode = model.code,
                        Caption = model.Name,
                        SortOrder = 1,
                        ImagePath = this.SaveFile(model.ImageDefault).Result,
                        ImageDefault = true,
                        ImglengthSize = model.ImageDefault.Length,
                        IsActive = true,

                    };

                    if (model.ThumbnailImage != null)
                    {
                        foreach (var item in model.ThumbnailImage)
                        {
                            B10ProductImgModel b10ProductImg = new B10ProductImgModel()
                            {

                                ProductCode = model.code,
                                ImagePath = this.SaveFile(model.ImageDefault).Result,
                                Caption = model.Name,
                                SortOrder = 1,
                                ImageDefault = false,
                                ImglengthSize = model.ImageDefault.Length,
                                IsActive = true,
                            };
                            listImg.Add(b10ProductImg);
                        }
                        listImg.Add(b10ProductImgModel);
                    }

                    return listImg;
                });



                var check = await _B10ProductRepository.Update(await b10ProductModel, userId);
                check = await _b10ProductImg.UpdateFormList(await b10ProductImgModel, userId);
                //await _b10img
                return check;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        /// Delete records in the table Employee 
        /// </summary>
        /// <param name="json_list_id">List id want to delete</param>
        /// <param name="updated_by">User made the deletion</param>
        /// <returns></returns>
        public Task<bool> Delete(string code, int userId)
        {
            return _B10ProductRepository.Delete(code, userId);
        }

        public async Task<PagedResultAdmin<B10ProductModel>> Paging(PagingRequestBase pagingRequest)
        {
            var paging = await _B10ProductRepository.Paging(pagingRequest);
            var data = JsonConvert.DeserializeObject<List<B10ProductModel>>(paging.ListObj);
            var PagedResultAdmin = new PagedResultAdmin<B10ProductModel>()
            {
                TotalRecords = paging.TotalRecords,
                PageIndex = paging.PageIndex,
                PageSize = paging.PageSize,
                PageCount = paging.PageCount,
                Items = data
            };
            return PagedResultAdmin;
        }
        public async Task<List<B10ProductModel>> GetAll()
        {
            var result = await _B10ProductRepository.GetAll();
            return result;
        }


        public async Task<List<ProductViewModel>> Search(string Name)
        {
            var b10Products = await _B10ProductRepository.Search(Name);
            return await Task.Run(() =>
            {
                List<ProductViewModel> products = new List<ProductViewModel>();
                foreach (var model in b10Products)
                {
                    ProductViewModel productViewModel = new ProductViewModel()
                    {

                        code = model.code,
                        Name = model.Name,
                        Alias = model.Alias,
                        ProductCategoryCode = model.ProductCategoryCode,
                        UnitCost = model.UnitCost,
                        UnitPrice = model.UnitPrice,
                        Warranty = model.Warranty,
                        Description = model.Description,
                        Content = model.Content,
                        Information = model.Information,
                        IsActive = model.IsActive
                    };
                    products.Add(productViewModel);
                }
                return products;
            });
        }

        /// <summary>
        /// Get information from the table UomRef and push it into a list of type DropdownOptionModel
        /// </summary>
        /// <param name="lang">Language used to display data</param> 
        /// <returns></returns>


        public async Task<ProductViewModel> GetById(string code)
        {
            var model = await _B10ProductRepository.GetById(code);
            var img = await _b10ProductImg.GetAll(code);
            var listimg = img.Select(x => x.ImagePath).ToList();
            ProductViewModel productViewModel = new ProductViewModel()
            {

                code = model.code,
                Name = model.Name,
                Alias = model.Alias,
                ProductCategoryCode = model.ProductCategoryCode,
                UnitCost = model.UnitCost,
                UnitPrice = model.UnitPrice,
                Warranty = model.Warranty,
                Description = model.Description,
                Content = model.Content,
                Information = model.Information,
                IsActive = model.IsActive,
                Image = listimg
            };


            return productViewModel;
        }


    }
}





