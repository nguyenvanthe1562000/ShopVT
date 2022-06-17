using Common;
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
        /// <summary>
        /// lấy dữ liệu không phân theo nhóm,có phân trang
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="O"></typeparam>
        /// <param name="table"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="DataIsActive"></param>
        /// <param name="filterColumn"></param>
        /// <param name="filterType"></param>
        /// <param name="filterValue"></param>
        /// <param name="OrderBy"></param>
        /// <param name="OrderDesc"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Task<T> GetData<T,O>(string table, PagingRequest pagingRequest, int userId);
        public Task<T> GetData<T, O>(string table, int PageSize, int PageIndex, bool DataIsActive, int ParentId, string filterColumn, FilterType filterType, string filterValue, string OrderBy, bool OrderDesc, int userId);
        //
        /// <summary>
        /// lấy dữ liệu theo nhóm, có phân trang
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="O"></typeparam>
        /// <param name="table"></param>
        /// <param name="idGroup"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="filterColumn"></param>
        /// <param name="filterType"></param>
        /// <param name="filterValue"></param>
        /// <param name="OrderBy"></param>
        /// <param name="OrderDesc"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Task<T> GetDataByGroup<T, O>(string table, int idGroup, int PageSize, int PageIndex, string filterColumn, FilterType filterType, string filterValue, string OrderBy, bool OrderDesc, int userId);

        // 
        /// <summary>
        /// lấy dữ liệu 1 bảng duy nhất
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <param name="rowId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Task<T> GetDataByIdOneTable<T>(string table, int rowId, int userId);

        //
        /// <summary>
        ///  lấy dữ liệu chỉ nhóm
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <param name="ColumnCaption"></param>
        /// <param name="OrderBy"></param>
        /// <param name="OrderDesc"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Task<IList<T>> GetGroup<T>(string table, string ColumnCaption, string OrderBy, bool OrderDesc, int userId);

  
        /// <summary>
        /// lấy dữ liệu theo kiêu cha con 1 cha nhiều con dùng cho xem chi tiết.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <param name="RowId"></param>
        /// <param name="keyParent"></param>
        /// <param name="foreignKey"></param>
        /// <param name="OrderBy"></param>
        /// <param name="OrderDesc"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Task<T> GetDataByIdMultipleTable<T>(string table, int RowId, string keyParent, string foreignKey, string OrderBy, bool OrderDesc, int userId);
        //
        /// <summary>
        /// lookup table 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <param name="filterColumn"></param>
        /// <param name="filterValue"></param>
        /// <param name="RowsTotal"></param>
        /// <param name="OrderBy"></param>
        /// <param name="OrderDesc"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Task<IList<T>> Lookup<T>(string table, string filterColumn, string filterValue , int RowsTotal, string OrderBy, bool OrderDesc, int userId, bool isAbsolute = false, string filterKey="", bool AndOrFilterKey = true);
    }
}
