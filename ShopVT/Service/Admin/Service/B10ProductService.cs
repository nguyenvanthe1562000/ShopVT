﻿using Common;
using Data.Reponsitory.Interface;
using Model.Model;

using Service.Admin.Service.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Admin.Service
{
    public class B10ProductService : IB10ProductService
    {
        private IB10ProductRepository _B10ProductRepository;
        public B10ProductService(IB10ProductRepository B10Product)
        {
            _B10ProductRepository = B10Product;
        }

        public  Task<bool> Insert(B10ProductModel model,int userId)
        {
            return  _B10ProductRepository.Insert(model, userId);
        }


        public  Task<bool> Update(B10ProductModel model, int userId)
        {
            return  _B10ProductRepository.Update(model, userId);
        }

        /// <summary>
        /// Delete records in the table Employee 
        /// </summary>
        /// <param name="json_list_id">List id want to delete</param>
        /// <param name="updated_by">User made the deletion</param>
        /// <returns></returns>
        public  Task<bool> Delete(string code, int userId)
        {
            return  _B10ProductRepository.Delete(code, userId);
        }

        public  Task<PagedResultBase> Paging(PagingRequestBase pagingRequest)
        {
            return  _B10ProductRepository.Paging(pagingRequest);
        }
        public  Task<List<B10ProductModel>> GetAll()
        {
            var result =  _B10ProductRepository.GetAll();
            return result;
        }


        public  Task<List<B10ProductModel>> Search(string Name)
        {
            return  _B10ProductRepository.Search(Name);
        }

        /// <summary>
        /// Get information from the table UomRef and push it into a list of type DropdownOptionModel
        /// </summary>
        /// <param name="lang">Language used to display data</param> 
        /// <returns></returns>


        public  Task<B10ProductModel> GetById(string code)
        {
            var result = _B10ProductRepository.GetById(code);
            return result;
        }


    }
}





