using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KOKService;
using banhtrangtrunghieu.Models;

namespace banhtrangtrunghieu.Com
{
    public class HomeCom
    {
        private KOK_DATAEntities _kokDataEntities = new KOK_DATAEntities();
        public List<NewsModel> getListPost()
        {
            List<NewsModel> model = new List<NewsModel>();
            var dt = _kokDataEntities.KOK_NEWS.Take(5).OrderBy(m=>m.UPDATE_DATE);
            if(dt != null)
            {
                foreach(var item in dt)
                {
                    NewsModel md = new NewsModel();
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

        public List<ProductsModel> getListProducts()
        {
            List<ProductsModel> model = new List<ProductsModel>();
            var dt = _kokDataEntities.KOK_NEWS.Take(9).OrderBy(m => m.UPDATE_DATE);
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