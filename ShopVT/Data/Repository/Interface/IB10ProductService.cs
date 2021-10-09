using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Model.Model;

namespace Data.Reponsitory.Interface

{
    public interface IB10ProductRepository
    {
       Task<bool> Insert(B10ProductModel model);



        bool Update(B10ProductModel model);



        bool Delete(string code);

        List<B10ProductModel> GetAll();

        List<B10ProductModel> Search(string Name);

        B10ProductModel GetById(string code);


    }
}







