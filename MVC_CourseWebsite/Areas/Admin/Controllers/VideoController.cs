﻿using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CourseWebsite.Areas.Admin.Controllers
{
    public class VideoController : Controller
    {
        VideoBLL bll = new VideoBLL();
        // GET: Admin/Video
        public ActionResult VideoList()
        {
            List<VideoDTO> dtolist = new List<VideoDTO>();
            dtolist = bll.GetVideos();
            return View(dtolist);
        }
        public ActionResult AddVideo()
        {
            VideoDTO dto = new VideoDTO();
            return View(dto);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddVideo(VideoDTO model)
        {
            //< iframe width = "560" height = "315" src = "https://www.youtube.com/embed/gfkTfcpWqAY" title = "YouTube video player" frameborder = "0" allowfullscreen ></ iframe >
            // https://www.youtube.com/watch?v=gfkTfcpWqAY
            if (ModelState.IsValid)
            {
                string path = model.OriginalVideoPath.Substring(32);
                string mergelink = "https://www.youtube.com/embed/";
                mergelink += path;
                model.VideoPath = string.Format(@"< iframe width = ""300"" height = ""200"" src = ""{0}"" frameborder = ""0"" allowfullscreen ></ iframe >",mergelink);
                if (bll.AddVideo(model))
                {
                    ViewBag.ProcessState = General.Message.AddSuccess;
                    ModelState.Clear();
                    model = new VideoDTO();
                }
            }
            else
            {
                ViewBag.ProcessState = General.Message.EmptyArea;
            }
            return View(model);
        }
        public ActionResult UpdateVideo(int ID)
        {
            VideoDTO dto = bll.GetVideoWithID(ID);
            return View(dto);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdateVideo(VideoDTO model)
        {
            if (ModelState.IsValid)
            {
                string path = model.OriginalVideoPath.Substring(32);
                string mergelink = "https://www.youtube.com/embed/";
                mergelink += path;
                model.VideoPath = string.Format(@"< iframe width = ""300"" height = ""200"" src = ""{0}"" frameborder = ""0"" allowfullscreen ></ iframe >", mergelink);
                if (bll.UpdateVideo(model))
                {
                    ViewBag.ProcessState = General.Message.UpdateSuccess;
                }
                else
                    ViewBag.ProcessState = General.Message.GeneralError;
            }
            else
            {
                ViewBag.ProcessState = General.Message.EmptyArea;
            }
            return View(model);
        }
    }
}