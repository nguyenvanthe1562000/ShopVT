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
        
        AccessApplication = 0,
        Category = 0100000000,//danh mục
        Receipt = 0200000000,//chứng từ - hóa đơn
        General = 0300000000,// tổng hợp -các thông tin tồn hàng hóa đầu kì.
        Report = 0400000000,// báo cáo.
        System = 0500000000,// hệ thống : lịch sử ,tài khoản,......
        ApplicationAdmin = 999900000

    }
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
