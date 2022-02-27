//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using Data.Reponsitory.Interface;
//using Model.Model;
//using Service.Admin.Service.Interface;

//namespace Service.Admin.Service
//{
//    public class B10ProductInformationService :IB10ProductInformationService
//  {
//        private IB10ProductInformationRepository _B10ProductInformationRepository;
//        public B10ProductInformationService (  IB10ProductInformationRepository  B10ProductInformation  )
//        {
//            _B10ProductInformationRepository =   B10ProductInformation   ;
//       }
	
//        public async Task<bool> Insert ( B10ProductInformationModel model, int userId)
//        {
//	B10ProductInformationModel b10productinformationModel= new B10ProductInformationModel(){;
//};
//            return await _B10ProductInformationRepository.Insert(model,userId);
//        }



	
//        public async Task<bool> Update(B10ProductInformationModel model, int userId);
//        { 
//            return await _B10ProductInformationRepository.Update(model,  userId);
//        }

	
	
//        public async List<B10ProductInformationModel> GetAll()
//        {
//            var result = _B10ProductInformationRepository.GetAll();
//            return await result;
//        }

	
//        public async Task<List<B10ProductInformationModel>> Search( string name)
//        {
//            return await _B10ProductInformationRepository.Search(name);
//        }

//	   public async Task<PagedResultBase> Paging(PagingRequestBase pagingRequest)
//        {
//            return await _B10ProductInformationRepository.Paging(pagingRequest);
//        }






	
	
//         public  async Task<B10ProductInformationModel> GetById(string code)
//        {
//            var result = _B10ProductInformationRepository.GetById(code);
//            return await result;
//        }


	
//   }
//}










