using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Model.Auth
{
    /*
    * Nếu đặt giá trị permission theo tăng từ 1,2,3... thì sau này muốn chèn thêm permission vào giữa k được => phải đẩy ra cuối => loạn
    * 
    * Quy tắc đặt giá trị cho value: dd.dd.dd.dd.dd.dd
    * 10 chữ số = 5 level * 2 chữ số mỗi level
    * => api tối đa 5 level, mỗi level tối đa 99 giá trị
    * => đủ đáp ứng số lượng api endpoint
    * 
    * Ví dụ: 
    * 
    * api                          | permission                    | permission value
    * _____________________________|_______________________________|____________________
    * authorization                | Authorization                 | 01.00.00.00.00
    * authorization/role           | Authorization_Role            | 01.01.00.00.00
    * GET:authorization/role       | Authorization_Role_Get        | 01.01.01.00.00
    * POST:authorization/role      | Authorization_Role_Add        | 01.01.02.00.00
    * authorization/permission     | Authorization_Permission      | 01.02.00.00.00
    * 
   */
    public enum PermissionFunction
    {
        //viết 1 enum
        //
        AccessApplication = 0,
        Category = 0100000000,//danh mục
        Receipt = 0200000000,//chứng từ - hóa đơn
        General = 0300000000,//tổng hợp -các thông tin tồn hàng hóa đầu kì.
        Report = 0400000000,// báo cáo.
        System = 0500000000,// hệ thống : lịch sử ,tài khoản,......
        ApplicationAdmin = 999900000
    }
    //danh mục sản phẩm -403 thông báo ko có quyền
    // -- có quyền 2 api 
    //    1 api lấy danh sách dữ liệu 

    //    2 là api lấy nhóm dữ liệu
    //    nếu danh mục sản phẩm ko có nhóm dữ liệu
    //    thì api lấy danh sách dữ liệu
    //    3 loại api
    // lấy dữ liệu có 6 loại
    //    1 goup
    //    2 lấy tất cả dữ liệu ko phân nhóm
    //    3 lấy theo nhóm
    // 1 là lấy chỉ duy nhất 1 bảng getbyid-> hóa đơn chỉ đầu hóa đơn
    // 2 là lấy dữ liệu theo 1 cha nhiều con-> đầu hóa và chi tiết hóa đơn 
    // lookup => ấn vào thêm sản phầm vào hóa đơn sẽ hiển thị 1 danh sách như combobox, khi cick 1 cái sản phẩm thì sẽ lấy gán dữ liệu sản phẩm vào các ô khác trong hóa đơn
    // thao 5 tác dữ liệu
    // thêm cho 1 bảng
    // thêm nhiều bảng
    // sửa nhiều bảng => sửa thằng con có 3 cái 1 2 3 => 1 3 4=>  1 3 4 
    // đâu 
    // xóa cha => thằng con liên kết thằng cha 
    // khôi phục phục dữ liệu đã xóa              
    // báo cáo-thống kê
    //    1 đăng nhập 
    //    2 lấy permiiosn function
    //    3 lấy cây chức năng theo permiiosn function

    public enum PermissionData
    {
        View = 0000010000,//xem dữ liệu
        ViewOther = 0000010100,//xem dữ liệu người khác +  của mình
        Create = 0000020000,//Tạo dữ liệu
        Edit = 0000030000,//sửa dữ liệu
        EditOther = 0000030100,//sửa dữ liệu người khác +  của mình
        Delete = 0000040000,//Xóa dữ liệu 
        DeleteOrther = 0000040100,//Xóa dữ liệu người khác +  của mình
        Restore = 0000050000,//khôi phục dữ liệu 
        RestoreOther = 0000050100,//khôi phục dữ liệu người khác +  của mình

        ApplicationAdmin= 999900000
    }
}
