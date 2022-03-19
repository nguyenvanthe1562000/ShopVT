import { Role } from "./role";
export class NguoiDung {
    Id: number;
    HoTen: string;
    NgaySinh: any;
    DiaChi: string;
    GioiTinh: string;
    Email: string;
    TaiKhoan: string;
    MatKhau: string;
    role: Role;
    anh: string;
    token?: string;
}