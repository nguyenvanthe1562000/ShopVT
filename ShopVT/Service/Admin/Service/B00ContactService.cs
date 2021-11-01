using Common;
using Data.Reponsitory.Interface;
using Model.Model;
using Service.Admin.Service.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Admin.Service
{
    public class B00ContactService : IB00ContactService
    {
        private IB00ContactRepository _B00ContactRepository;
        public B00ContactService(IB00ContactRepository B00Contact)
        {
            _B00ContactRepository = B00Contact;
        }

        public async Task<bool> Insert(B00ContactModel model, int userId)
        {
            return await _B00ContactRepository.Insert(model, userId);
        }


        public async Task<bool> Update(B00ContactModel model, int userId)
        {
            return await _B00ContactRepository.Update(model, userId);
        }


        public async Task<bool> Delete(string code, int userId)
        {
            return await _B00ContactRepository.Delete(code, userId);
        }


        public async Task<List<B00ContactModel>> GetAll()
        {
            var result =  _B00ContactRepository.GetAll();
            return await result;
        }


        public async Task<PagedResultBase> Paging(PagingRequestBase pagingRequest)
        {
            return await _B00ContactRepository.Paging(pagingRequest);
        }



        public async Task<B00ContactModel> GetById(string code)
        {
            var result = await _B00ContactRepository.GetById(code);
            return result;
        }


    }
}








