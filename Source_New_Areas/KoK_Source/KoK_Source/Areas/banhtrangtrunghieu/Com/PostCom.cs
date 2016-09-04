using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KOKService;
using KoK_Source.Areas.banhtrangtrunghieu.Models;

namespace KoK_Source.Areas.banhtrangtrunghieu.Com
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
    }
}