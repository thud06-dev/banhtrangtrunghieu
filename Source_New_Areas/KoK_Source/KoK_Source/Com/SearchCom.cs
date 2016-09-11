using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KoK_Source.Models;
using KOKService;
namespace KoK_Source.Com
{
    public class SearchCom
    {
        private KOK_DATAEntities _kokDataEntity = new KOK_DATAEntities();
        public List<NewsModel> getAllByParam(string param)
        {
            List<NewsModel> model = new List<NewsModel>();
            var dt = _kokDataEntity.KOK_PRODUCTS.Where(a => (a.POST_HTML.Contains(param) || a.NEWS_TITLE.Contains(param)) &&a.ACTIVE == false);
            if (dt != null)
            {
                foreach (var item in dt)
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
                    md.POST_HTML = item.POST_HTML;
                    md.THANH_PHAN = item.THANH_PHAN;
                    md.GIA = item.GIA.GetValueOrDefault();
                    md.NOTE = item.NOTE;
                    md.LIST_ANH = item.LIST_ANH;
                    md.ANH = item.ANH;
                    md.BAO_QUAN = item.BAO_QUAN;
                    md.NEWS_TYPE = item.NEWS_TYPE;
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