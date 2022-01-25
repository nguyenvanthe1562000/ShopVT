using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common;
using Data.Reponsitory.Interface;
using Model.Model;
using Service.Admin.Service.Interface;


namespace Service.Admin.Service
{
    public class B00AppUserService : IB00AppUserService
    {
        private IB00AppUserRepository _B00AppUserRepository;
        public B00AppUserService(IB00AppUserRepository B00AppUser)
        {
            _B00AppUserRepository = B00AppUser;

        }

        public async Task<bool> Insert(B00AppUserModel model, int userId)
        {
            return await _B00AppUserRepository.Insert(model, userId);
        }



        public async Task<bool> Update(B00AppUserModel model, int userId)
        {
            return await _B00AppUserRepository.Update(model, userId);
        }


        public async Task<bool> Delete(string code, int userId)
        {
            return await _B00AppUserRepository.Delete(code, userId);
        }


        public async Task<List<B00AppUserModel>> GetAll()
        {
            var result = _B00AppUserRepository.GetAll();
            return await result;
        }




        public async Task<B00AppUserModel> GetById(string code)
        {
            var result = _B00AppUserRepository.GetById(code);
            return await result;
        }

        public async Task<PagedResultBase> Paging(PagingRequestBase pagingRequest)
        {
            return await _B00AppUserRepository.Paging(pagingRequest);
        }
    }
}









