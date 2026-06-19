using Microsoft.AspNetCore.Identity;
using NhaSachOnline.Const;
namespace NhaSachOnline.Data
{
    public class DataSeed
    {
        public static async Task KhoiTaoDuLieuMacDinh(IServiceProvider dichVu)
        {
            var quanLyNguoiDung = dichVu.GetService<UserManager<IdentityUser>>();
            var quanLyVaiTro = dichVu.GetService<RoleManager<IdentityRole>>();

            // Thêm 1 vai trò vào csdl
            await quanLyVaiTro.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await quanLyVaiTro.CreateAsync(new IdentityRole(Roles.User.ToString()));

            // Tạo thông tin mặc định cho tài khoản Admin 
            // bao gồm: UserName, Email, xác thực email
            var quanTri = new IdentityUser
            {
                UserName = "admin@test.xyz",
                Email = "admin@test.xyz",
                EmailConfirmed = true
            };
            var nguoiDungTrongCsdl = await quanLyNguoiDung.FindByEmailAsync(quanTri.Email);
            // Nếu tài khoản của admin không tồn tại trong csdl 
            // hoặc có thể hiểu là chưa có trong csdl
            if (nguoiDungTrongCsdl is null)
            {
                // Tạo tài khoản admin với mk Admin12345!@#$%
                var ketQua = await quanLyNguoiDung.CreateAsync(quanTri, "Admin12345!@#$%");
                //var ketQua = await quanLyNguoiDung.CreateAsync(quanTri, "123");

                // Nếu tạo thành công thì thêm vai trò người dùng 

                if (ketQua.Succeeded)
                {
                    await quanLyNguoiDung.AddToRoleAsync(quanTri, Roles.Admin.ToString());
                }
                else
                {
                    // In ra mã lỗi 
                    foreach(var error in ketQua.Errors)
                    {
                        Console.WriteLine(error.Description);
                    }
                }
            }
        }
    }
}
