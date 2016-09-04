using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using KoK_Source.Common;
using KoK_Source.Models.Menu;
using KOKService;

namespace KoK_Source.Models.Account
{
    public class AccountModel
    {
        [Key]
        [DisplayName("ID")]
        public int Id { get; set; }

        [DisplayName("User Name")]
        public string UserName { get; set; }

        [DisplayName("Pass Word")]
        [DataType(DataType.Password)]
        public string UserPass { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("State")]
        public bool Active { get; set; }

        [DisplayName("Create_Date")]
        public string CreateDate { get; set; }

        [DisplayName("Update Date")]
        public string UpdateDate { get; set; }

        [DisplayName("Create User")]
        public string CreateUser { get; set; }

        [DisplayName("Update User")]
        public string UpdateUser { get; set; }
        

        private KOK_DATAEntities db = new KOK_DATAEntities();
        private CommonCnv _commonCnv = new CommonCnv();

        public List<AccountModel> GetAllAccount()
        {
            var data = db.KOK_ACCOUNT.Where(x => x.ACTIVE == true).ToList();
            List<AccountModel> account = new List<AccountModel>();
            foreach (var item in data)
            {
                account.Add(new AccountModel
                {
                    Id = item.ID,
                    UserName = item.UserName ?? string.Empty,
                    UserPass = item.UserPass ?? string.Empty,
                    FirstName = item.FirstName ?? string.Empty,
                    LastName = item.LastName ?? string.Empty,
                    CreateDate = item.CREATE_DATE?.ToString() ?? string.Empty,
                    CreateUser = item.CREATE_USER ?? string.Empty,
                    UpdateDate = item.UPDATE_DATE?.ToString() ?? string.Empty,
                    UpdateUser = item.UPDATE_USER ?? string.Empty,
                    Active = _commonCnv.CnvBool(item.ACTIVE)
                });
            }
            Console.WriteLine(account);
            return account;
        }

        public KOK_ACCOUNT CheckAccount(string userName)
        {
            var acc = db.KOK_ACCOUNT.FirstOrDefault(x => x.UserName == userName);
            return acc;
        }

        public AccountModel GetAccountById(int? id)
        {
            var dt = db.KOK_ACCOUNT.FirstOrDefault(x => x.ID == id);
            AccountModel acc =  new AccountModel();
            if (dt != null)
            {
                acc.Id = dt.ID;
                acc.UserName = dt.UserName;
                acc.UserPass = dt.UserPass;
                acc.FirstName = dt.FirstName;
                acc.LastName = dt.LastName;
                acc.Active = _commonCnv.CnvBool(dt.ACTIVE);
            }
            return acc;
        }

    }
}