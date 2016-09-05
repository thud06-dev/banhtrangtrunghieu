using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KOKService;
using banhtrangtrunghieu.Models;

namespace banhtrangtrunghieu.Com
{
    public class PostCom
    {
        private KOK_DATAEntities _kokDataEntities = new KOK_DATAEntities();
        public NewsModel detailNews(string id_menu, string id_post)
        {
            int p_id = 0;
            int m_id = 0;
            if (!string.IsNullOrEmpty(id_menu))
            {
                m_id = int.Parse(id_menu);
            }
            if (!string.IsNullOrEmpty(id_post))
            {
                p_id = int.Parse(id_post);
            }
            NewsModel md = new NewsModel();
            var dt = _kokDataEntities.KOK_PRODUCTS.Where(a => a.NEWS_TYPE == 0
            && a.NEWS_ID == p_id
            
            ).OrderBy(m => m.UPDATE_DATE).FirstOrDefault();
            if (dt != null)
            {
                md.NEWS_ID = dt.NEWS_ID.ToString();
                md.NEWS_TITLE = dt.NEWS_TITLE;
                md.NEWS_SEO_TITLE = dt.NEWS_SEO_TITLE;
                md.NEWS_DESC = dt.NEWS_DESC;
                md.NEWS_SEO_DESC = dt.NEWS_SEO_DESC;
                md.NEWS_URL = dt.NEWS_URL;
                md.NEWS_SEO_URL = dt.NEWS_SEO_URL;
                md.NEWS_SEO_KEYWORD = dt.NEWS_SEO_KEYWORD;
                md.NEWS_ORDER = dt.NEWS_ORDER;
                md.NEWS_KEYWORD_ASCII = dt.NEWS_KEYWORD_ASCII;
                md.POST_HTML = dt.POST_HTML;
                md.THANH_PHAN = dt.THANH_PHAN;
                md.GIA = dt.GIA.GetValueOrDefault();
                md.NOTE = dt.NOTE;
                md.LIST_ANH = dt.LIST_ANH;
                md.ANH = dt.ANH;
                md.BAO_QUAN = dt.BAO_QUAN;
                md.CREATE_DATE = dt.CREATE_DATE;
                md.UPDATE_DATE = dt.UPDATE_DATE;
                md.CREATE_USER = dt.CREATE_USER;
                md.UPDATE_USER = dt.UPDATE_USER;
                md.ACTIVE = dt.ACTIVE.GetValueOrDefault();
            }
            return md;
        }

        public List<NewsModel> getListProducts(int take)
        {
            if (take == null)
            {
                take = 4;
            }
            List<NewsModel> model = new List<NewsModel>();
            var dt = _kokDataEntities.KOK_PRODUCTS.Where(a => a.NEWS_TYPE == 0).Take(take).OrderBy(o => o.UPDATE_DATE);
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