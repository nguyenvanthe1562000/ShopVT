using Model.Command;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Command.Interface
{
    public interface IDataExploreService
    {

        //get không phân theo nhóm,có phân trang
        public Task<IList<T>> GetData<T>(string table, int PageSize, int PageIndex, bool DataIsActive, string filterColumn, FilterType filterType, string filterValue, string OrderBy, bool OrderDesc, int userId);

        //lấy dữ liệu theo nhóm, có phân trang
        public Task<IList<T>> GetDataByGroup<T>(string table, int idGroup, int PageSize, int PageIndex, string filterColumn, FilterType filterType, string filterValue, string OrderBy, bool OrderDesc, int userId);

        // lấy dữ liệu 1 bảng duy nhất
        public Task<T> GetDataByIdOneTable<T>(string table, int rowId, int userId);

        // lấy dữ liệu chỉ nhóm
        public Task<IList<T>> GetGroup<T>(string table, string ColumnCaption, string OrderBy, bool OrderDesc, int userId);

        //lấy dữ liệu theo kiêu cha con 1 cha nhiều con dùng cho xem chi tiết.
        public Task<T> GetDataByIdMultipleTable<T>(string table, int RowId, string keyParent, string foreignKey, string OrderBy, bool OrderDesc, int userId);
    }
}
