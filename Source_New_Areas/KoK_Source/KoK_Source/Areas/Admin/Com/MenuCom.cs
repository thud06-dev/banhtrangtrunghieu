using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using KOKService;
using KoK_Source.Common;
using KoK_Source.Areas.Admin.Models.Menu;

namespace KoK_Source.Areas.Admin.Com
{
    public class MenuCom
    {
        private KOK_DATAEntities _db = new KOK_DATAEntities();
        private CommonCnv _commonCnv = new CommonCnv();

        public List<MenuModels> GetAllMenu()
        {
            var data = _db.KOK_CATEGORIES.Where(x => x.ACTIVE == true).OrderBy(x => x.CAT_ORDER).ToList();
            List<MenuModels> menu = new List<MenuModels>();
            foreach (var item in data)
            {
                menu.Add(new MenuModels
                {
                    Id = item.CAT_ID.ToString(),
                    MenuName = item.CAT_NAME ?? string.Empty,
                    MenuLink = item.CAT_URL ?? string.Empty,
                    MenuRank = item.CAT_RANK?.ToString() ?? string.Empty,
                    MenuParentId = item.CAT_PARENT_ID?.ToString() ?? string.Empty,
                    MenuOrder = item.CAT_ORDER?.ToString() ?? string.Empty,
                    CreateDate = item.CREATE_DATE?.ToString() ?? string.Empty,
                    CreateUser = item.CREATE_USER ?? string.Empty,
                    UpdateDate = item.UPDATE_DATE?.ToString() ?? string.Empty,
                    UpdateUser = item.UPDATE_USER ?? string.Empty,
                    Active = _commonCnv.CnvBool(item.ACTIVE)
                });
            }
            Console.WriteLine(menu);


            return menu;
        }

        public MenuModels GetMenuModelById(int id)
        {
            MenuModels menu = new MenuModels();
            var dt = _db.KOK_CATEGORIES.Where(x => x.CAT_ID == id);
            foreach (var item in dt)
            {
                menu.Id = item.CAT_ID.ToString();
                menu.MenuName = item.CAT_NAME ?? string.Empty;
                menu.MenuLink = item.CAT_URL ?? string.Empty;
                menu.MenuRank = item.CAT_RANK?.ToString() ?? string.Empty;
                menu.MenuParentId = item.CAT_PARENT_ID?.ToString() ?? string.Empty;
                menu.MenuOrder = item.CAT_ORDER?.ToString() ?? string.Empty;
                menu.CreateDate = item.CREATE_DATE?.ToString() ?? string.Empty;
                menu.CreateUser = item.CREATE_USER ?? string.Empty;
                menu.UpdateDate = item.UPDATE_DATE?.ToString() ?? string.Empty;
                menu.UpdateUser = item.UPDATE_USER ?? string.Empty;
                menu.Active = _commonCnv.CnvBool(item.ACTIVE);
            }
            return menu;
        }

        public void Create(MenuModels menu)
        {
            menu.CreateUser = " ";
            menu.CreateDate = DateTime.Now.ToString();
            menu.UpdateUser = " ";
            menu.UpdateDate = DateTime.Now.ToString();
            MENU dbMenu = new MENU()
            {
                MENU_NAME = menu.MenuName,
                MENU_LINK = menu.MenuLink,
                MENU_RANK = int.Parse(menu.MenuRank),
                MENU_PARENT_ID = int.Parse(menu.MenuParentId),
                ACTIVE = menu.Active,
                CREATE_USER = menu.CreateUser,
                CREATE_DATE = DateTime.Parse(menu.CreateDate),
                UPDATE_USER = menu.UpdateUser,
                UPDATE_DATE = DateTime.Parse(menu.UpdateDate)
            };
            _db.MENU.Add(dbMenu);
            _db.SaveChanges();

        }
    }
}