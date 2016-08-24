using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using KoK_Source.Models;
using KoK_Source.Models.Post;
using KOKService;
using System.Data;
using System.Linq;
using KoK_Source.Common;

namespace KoK_Source.Com
{
    public class PostCom
    {
        private KOK_DATAEntities _kokDataEntities = new KOK_DATAEntities();
        private CommonCnv _commonCnv = new CommonCnv();
        public List<PostModel> GetAllPost()
        {
            List<PostModel> model = new List<PostModel>();
            var dt = _kokDataEntities.KOK_NEWS;
            if (dt != null)
            {
                foreach (var item in dt)
                {
                    PostModel md = new PostModel();
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
        public PostModel GetPostByID(int id)
        {
            PostModel md = new PostModel();
            var dt = _kokDataEntities.KOK_NEWS.Where(m => m.NEWS_ID == id).FirstOrDefault();
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
            md.CREATE_DATE = dt.CREATE_DATE;
            md.UPDATE_DATE = dt.UPDATE_DATE;
            md.CREATE_USER = dt.CREATE_USER;
            md.UPDATE_USER = dt.UPDATE_USER;
            md.ACTIVE = dt.ACTIVE.GetValueOrDefault();
            return md;
        }
        public void CreatePost(PostModel model)
        {
            KOK_NEWS item = new KOK_NEWS();
            item.NEWS_TITLE = model.NEWS_TITLE;
            item.NEWS_SEO_TITLE = model.NEWS_SEO_TITLE;
            item.NEWS_DESC = model.NEWS_DESC;
            item.NEWS_SEO_DESC = model.NEWS_SEO_DESC;
            item.NEWS_URL = model.NEWS_URL;
            item.NEWS_SEO_URL = model.NEWS_SEO_URL;
            item.NEWS_SEO_KEYWORD = model.NEWS_SEO_KEYWORD;
            item.NEWS_ORDER = model.NEWS_ORDER;
            item.NEWS_KEYWORD_ASCII = model.NEWS_KEYWORD_ASCII;
            item.POST_HTML = model.POST_HTML;
            item.CREATE_DATE = model.CREATE_DATE;
            item.CREATE_USER = model.CREATE_USER;
            item.ACTIVE = model.ACTIVE;
            _kokDataEntities.KOK_NEWS.Add(item);
            _kokDataEntities.SaveChanges();
        }
        public void UpdatePost(PostModel model)
        {
            int id = int.Parse(model.NEWS_ID);
            KOK_NEWS item = _kokDataEntities.KOK_NEWS.Where(m=>m.NEWS_ID == id).FirstOrDefault();
            item.NEWS_TITLE = model.NEWS_TITLE;
            item.NEWS_SEO_TITLE = model.NEWS_SEO_TITLE;
            item.NEWS_DESC = model.NEWS_DESC;
            item.NEWS_SEO_DESC = model.NEWS_SEO_DESC;
            item.NEWS_URL = model.NEWS_URL;
            item.NEWS_SEO_URL = model.NEWS_SEO_URL;
            item.NEWS_SEO_KEYWORD = model.NEWS_SEO_KEYWORD;
            item.NEWS_ORDER = model.NEWS_ORDER;
            item.NEWS_KEYWORD_ASCII = model.NEWS_KEYWORD_ASCII;
            item.POST_HTML = model.POST_HTML;
            item.UPDATE_DATE = model.UPDATE_DATE;
            item.UPDATE_USER = model.UPDATE_USER;
            item.ACTIVE = model.ACTIVE;
            _kokDataEntities.SaveChanges();
        }
    }
}