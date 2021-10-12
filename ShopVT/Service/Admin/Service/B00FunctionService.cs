using System;
using System.Collections.Generic;
using Data.Repository.Interface;
using Model.Model;
using Model.Reponsitory;
using Service.Admin.Service.Interface;

namespace Service.Admin.Service
{
    public class B00FunctionService : IB00FunctionService
    {
        private IB00FunctionRpository _B00FunctionRepository;
        public B00FunctionService(IB00FunctionRpository B00Function)
        {
            _B00FunctionRepository = B00Function;
        }

        public bool Insert(B00FunctionModel model, int userId)
        {
            return _B00FunctionRepository.Insert(model,userId);
        }


        public bool Update(B00FunctionModel model)
        {
            return _B00FunctionRepository.Update(model);
        }

        /// <summary>
        /// Delete records in the table Employee 
        /// </summary>
        /// <param name="json_list_id">List id want to delete</param>
        /// <param name="updated_by">User made the deletion</param>
        /// <returns></returns>
        public bool Delete(string Code)
        {
            return _B00FunctionRepository.Delete(Code);
        }


        public List<B00FunctionModel> GetAll()
        {
            var result = _B00FunctionRepository.GetAll();
            return result;
        }


        public List<B00FunctionModel> Search(string Code)
        {
            return _B00FunctionRepository.Search(Code);
        }






        public B00FunctionModel GetById(string Code)
        {
            var result = _B00FunctionRepository.GetById(Code);
            return result;
        }

        public List<B00FunctionModel> GetFunctionAdminByTree()
        {
            var result = _B00FunctionRepository.GetFunctionAdminByTree();
            return result;
        }
    }
}







