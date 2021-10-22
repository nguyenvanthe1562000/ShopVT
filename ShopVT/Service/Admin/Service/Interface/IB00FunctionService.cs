using System;
using System.Collections.Generic;
using Model.Model;
namespace Service.Admin.Service.Interface

{
    public interface IB00FunctionService
    {
        bool Insert(B00FunctionModel model, int userId);



        bool Update(B00FunctionModel model);



        bool Delete(string Code);

        List<B00FunctionModel> GetAll();

        List<B00FunctionModel> Search(string Code);


        List<B00FunctionModel> GetFunctionAdminByTree();



        B00FunctionModel GetById(string Code);

    }
}








