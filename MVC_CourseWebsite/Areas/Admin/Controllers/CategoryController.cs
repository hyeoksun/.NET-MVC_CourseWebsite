﻿using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CourseWebsite.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        CategoryBLL bll = new CategoryBLL();
        // GET: Admin/Category
        public ActionResult CategoryList()
        {
            List<CategoryDTO> model = bll.GetCategories();
            return View(model);
        }
        public ActionResult AddCategory()
        {
            CategoryDTO dto = new CategoryDTO();
            return View(dto);
        }
        [HttpPost]
        public ActionResult AddCategory(CategoryDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.AddCategory(model))
                {
                    ViewBag.ProcessState = General.Message.AddSuccess;
                    ModelState.Clear();
                    model = new CategoryDTO();
                }
                else
                    ViewBag.ProcessState = General.Message.GeneralError;
            }
            else
                ViewBag.ProcessState = General.Message.EmptyArea;
            return View(model);
        }

        public ActionResult UpdateCategory(int ID)
        {
            CategoryDTO dto = bll.GetCategoryWithID(ID);
            return View(dto);
        }
        [HttpPost]
        public ActionResult UpdateCategory(CategoryDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.UpdateCategory(model))
                {
                    ViewBag.ProcessState = General.Message.UpdateSuccess;
                }
                else
                    ViewBag.ProcessState = General.Message.GeneralError;
            }
            else
                ViewBag.ProcessState = General.Message.EmptyArea;
            return View(model);
        }
    }
}