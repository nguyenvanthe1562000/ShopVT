using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common;
using Model.Model;
namespace Data.Reponsitory.Interface

{
    public interface IB10ProductImgRepository
    {
        Task<bool> Insert(B10ProductImgModel model, int userId);

        Task<bool> Update(B10ProductImgModel model, int userId);

        Task<bool> Delete(int ID, int userId);
        Task<bool> SaveFormList(List<B10ProductImgModel> b10ProductImgModels, int userId);
        Task<bool> UpdateFormList(List<B10ProductImgModel> b10ProductImgModels, int userId);


        Task<List<B10ProductImgModel>> GetAll(string code);

        Task<B10ProductImgModel> GetById(int ID, string ProductCode);


    }
}





