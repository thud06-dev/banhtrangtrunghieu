﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using KoK_Source.Areas.Admin.Models;
using KoK_Source.Areas.Admin.Models.Banner;
using KOKService;
using System.Data;
using System.Linq;
using KoK_Source.Common;

namespace KoK_Source.Areas.Admin.Com
{
    public class GalleryCom
    {
        private KOK_DATAEntities _kokDataEntities = new KOK_DATAEntities();
        private CommonCnv _commonCnv = new CommonCnv();
        public List<BannerModel> getAll()
        {
            List<BannerModel> model = new List<BannerModel>();
            var dt = _kokDataEntities.KOK_BANNER.OrderByDescending(m => m.UPDATE_DATE);
            if (dt != null)
            {
                foreach (var item in dt)
                {
                    BannerModel mod = new BannerModel();
                    mod.BANNER_ID = item.BANNER_ID.ToString();
                    mod.BANNER_NAME = item.BANNER_NAME;
                    mod.BANNER_DESC = item.BANNER_DESC == null ? string.Empty : item.BANNER_DESC;
                    mod.BANNER_FILE = item.BANNER_FILE == null ? string.Empty : item.BANNER_FILE;
                    mod.CREATE_DATE = item.CREATE_DATE == null ? string.Empty : item.CREATE_DATE.ToString();
                    mod.CREATE_USER = item.CREATE_USER == null ? string.Empty : item.CREATE_USER;
                    mod.UPDATE_DATE = item.UPDATE_DATE == null ? string.Empty : item.UPDATE_DATE.ToString();
                    mod.UPDATE_USER = item.UPDATE_USER == null ? string.Empty : item.UPDATE_USER;
                    mod.ACTIVE = _commonCnv.CnvBool(item.ACTIVE);
                    model.Add(mod);
                }
            }
            return model;
        }
        public BannerModel GetModelByID(int id)
        {
            BannerModel model = new BannerModel();
            var dt = _kokDataEntities.KOK_BANNER.Where(m => m.BANNER_ID == id);
            foreach (var item in dt)
            {
                model.BANNER_ID = item.BANNER_ID.ToString();
                model.BANNER_NAME = item.BANNER_NAME == null ? string.Empty : item.BANNER_NAME;
                model.BANNER_DESC = item.BANNER_DESC == null ? string.Empty : item.BANNER_DESC;
                model.BANNER_FILE = item.BANNER_FILE == null ? string.Empty : item.BANNER_FILE;
                model.CREATE_DATE = item.CREATE_DATE == null ? string.Empty : item.CREATE_DATE.ToString();
                model.CREATE_USER = item.CREATE_USER == null ? string.Empty : item.CREATE_USER;
                model.UPDATE_DATE = item.UPDATE_DATE == null ? string.Empty : item.UPDATE_DATE.ToString();
                model.UPDATE_USER = item.UPDATE_USER == null ? string.Empty : item.UPDATE_USER;
                model.ACTIVE = _commonCnv.CnvBool(item.ACTIVE);
            }
            return model;
        }
        public void Save(BannerModel model)
        {
            KOK_BANNER banner = new KOK_BANNER();
            var dt_old = _kokDataEntities.KOK_BANNER.Where(m => m.BANNER_FILE.Contains(model.BANNER_FILE)).ToList();
            if (dt_old.Count == 0)
            {
                banner.BANNER_NAME = model.BANNER_NAME;
                banner.BANNER_DESC = model.BANNER_DESC;
                banner.BANNER_FILE = model.BANNER_FILE;
                banner.BANNER_TYPE = 0;//Gallery
                banner.ACTIVE = true;
                banner.CREATE_DATE = DateTime.Now;
                banner.UPDATE_DATE = DateTime.Now;
                _kokDataEntities.KOK_BANNER.Add(banner);
                _kokDataEntities.SaveChanges();
            }
        }
        public void DeleteByID(string id)
        {
            int pid = int.Parse(id);
            var item = _kokDataEntities.KOK_BANNER.SingleOrDefault(m => m.BANNER_ID == pid);
            _kokDataEntities.KOK_BANNER.Remove(item);
            _kokDataEntities.SaveChanges();
        }
    }
}