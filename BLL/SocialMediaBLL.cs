﻿using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SocialMediaBLL
    {
        SocialMediaDAO dao = new SocialMediaDAO();
        public bool AddSocialMedia(SocialMediaDTO model)
        {
            SocialMedia social = new SocialMedia();
            social.Name = model.name;
            social.Link = model.Link;
            social.ImagePath = model.ImagePath;
            social.addDate = DateTime.Now;
            social.LastUpdateUserID = UserStatic.UserID;
            social.LastUpdateDate = DateTime.Now;
            int ID = dao.AddSocialMedia(social);
            LogDAO.AddLog(General.ProcessType.SocialAdd, General.TableName.Social, ID);
            return true;
        }

        public List<SocialMediaDTO> GetSocialMedias()
        {
            List<SocialMediaDTO> dtolist = new List<SocialMediaDTO>();
            dtolist = dao.GetSocialMedias();
            return dtolist;
        }

        public SocialMediaDTO GetSocialMediaWithID(int ID)
        {
            SocialMediaDTO dto = dao.GetSocialMediaWithID(ID);
            return dto;
        }

        public string UpdateSocialMedia(SocialMediaDTO model)
        {
            string oldImagePath = dao.UpdateSocialMedia(model);
            LogDAO.AddLog(General.ProcessType.SocialUpdate, General.TableName.Social, model.ID);
            return oldImagePath;
        }
    }
}
