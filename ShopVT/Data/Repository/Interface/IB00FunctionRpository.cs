using System;
using System.Collections.Generic;
using Model.Model;
namespace Data.Repository.Interface

{
    public interface IB00FunctionRpository
    {
        bool Insert(B00FunctionModel model ,int userId);



        bool Update(B00FunctionModel model);



        bool Delete(string Code);

        List<B00FunctionModel> GetAll();
        List<B00FunctionModel> GetFunctionAdminByTree();

        List<B00FunctionModel> Search(string Code);




        B00FunctionModel GetById(string Code);

    }
}








