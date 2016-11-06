using KoK_Source.Areas.Admin.Models.Products;
using KoK_Source.Common;
using KOKService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KoK_Source.Areas.Admin.Com
{
    public class ContactCom
    {
        private KOK_DATAEntities _kokDataEntities = new KOK_DATAEntities();
        private CommonCnv _commonCnv = new CommonCnv();
        public List<ProductsModel> GetAllPost()
        {
            List<ProductsModel> model = new List<ProductsModel>();
            var dt = _kokDataEntities.KOK_NEWS.OrderByDescending(m => m.UPDATE_DATE);
            if (dt != null)
            {
                foreach (var item in dt)
                {
                    ProductsModel md = new ProductsModel();
                    md.NEWS_ID = item.NEWS_ID.ToString();
                    md.NEWS_TITLE = item.NEWS_TITLE;
                    md.NEWS_SEO_TITLE = item.NEWS_SEO_TITLE;
                    md.NEWS_DESC = item.NEWS_DESC;
                    md.NEWS_SEO_DESC = item.NEWS_SEO_DESC;
                    md.NEWS_URL = item.NEWS_URL;
                    md.NEWS_SEO_URL = item.NEWS_SEO_URL;
                    md.NEWS_SEO_KEYWORD = item.NEWS_SEO_KEYWORD;
                    md.NEWS_ORDER = item.NEWS_ORDER;
                    md.NEWS_KEYWORD_ASCII = item.NEWS_KEYWORD_ASCII;
                    md.POST_HTML = item.POST_HTML;
                    md.ANH = item.ANH;
                    md.CREATE_DATE = item.CREATE_DATE;
                    md.UPDATE_DATE = item.UPDATE_DATE;
                    md.CREATE_USER = item.CREATE_USER;
                    md.UPDATE_USER = item.UPDATE_USER;
                    md.ACTIVE = item.ACTIVE.GetValueOrDefault();
                    model.Add(md);
                }
            }
            return model;
        }
    }
}