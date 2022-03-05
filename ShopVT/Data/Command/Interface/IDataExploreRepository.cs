using Model.Command;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Command
{
    public interface IDataExploreRepository
    {
        //get không phân theo nhóm,có phân trang
        public Task<DataTable> GetData(DataExploreGetDataRequestModel model);
        //lấy dữ liệu theo nhóm, có phân trang
        public Task<DataTable> GetDataByGroup(DataExploreGetDataByGroupRequestModel model);
        // lấy dữ liệu 1 bảng duy nhất
        public Task<DataTable> GetDataByIdOneTable(DataExploreGetDataByIdRequestModel model);
        // lấy dữ liệu chỉ nhóm
        public Task<DataTable> GetGroup(DataExploreGetGroupRequestModel model);
        //lấy dữ liệu theo kiêu cha con 1 cha nhiều con dùng cho xem chi tiết.
        public Task<DataTable> GetDataByIdMultipleTable(DataExploreGetMultipleDataByIdRequestModel model);
        public Task<DataTable> GetDataLookUp(DataExploreLookupRequestModel model);
    }
}
