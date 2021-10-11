using Common;
using Common.Helper;
using Data.Repository.Interface;
using Model.ExtensionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class LoginAdminRepository : ILoginAdminRepository
    {
        private IDatabaseHelper _dbHelper;
        public LoginAdminRepository(IDatabaseHelper databaseHelper)
        {
            _dbHelper = databaseHelper;
        }
        /// <summary>
        /// Add a new records into the table B10Product
        /// </summary>
        /// <param name="model">The record added </param>
        /// <returns></returns>
        public async Task<IdentityModel> Login(LoginRequest model)
        {
            string msgError = "";

           
            try
            {
                IdentityModel identity = new IdentityModel();
                await Task.Run(() =>
               {
                   var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "usp_Login", "@userName",
                      model.UserName, "@passWord",
                       model.PassWord);
                   if (!string.IsNullOrEmpty(msgError))
                   {
                       throw new Exception(msgError);
                   }
                   identity = dt.ConvertTo<IdentityModel>().ToList().FirstOrDefault();
               });
                return identity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
