﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EF.Core.Model;
using EF.Data;
using EFUnitOfWork.Models.Dto;

namespace EFUnitOfWork.Controllers
{
    public class BookController : Controller
    {
        private static object _lock=new object();
        private UnitOfWork unitOfWork=new UnitOfWork();

        private Repository<Book> bookRepository;

        public BookController()
        {
            bookRepository = unitOfWork.Repository<Book>();
        }
        // GET: Book
        public ActionResult Index()
        {
            var books = bookRepository.Table.ProjectTo<BookDTO>().ToList();
            return View(books);
        }

        public ActionResult CreateEditBook(int? id)
        {
            var bookDto=new BookDTO();
            if (id.HasValue)
            {
                var entity = bookRepository.GetById(id.Value);
                bookDto = Mapper.Map<Book, BookDTO>(entity);
            }

            return View(bookDto);
        }
        [HttpPost]
        public ActionResult CreateEditBook(BookDTO bookDTO)
        {
            if (bookDTO.ID==0)
            {
                var model = Mapper.Map<BookDTO, Book>(bookDTO);
                model.ModifiedTime=DateTime.Now;
                model.CreatedTime=DateTime.Now;
                model.Url = string.Empty;
                model.IP = Request.UserHostAddress;

                bookRepository.Insert(model);
                unitOfWork.Commit();

            }
            else
            {
                var editModel = bookRepository.GetById(bookDTO.ID);
                Mapper.Map(editModel, bookDTO);
                bookRepository.Update(editModel);
                unitOfWork.Commit();
            }

            if (bookDTO.ID>0)
            {
                return View("Upload", bookDTO);
            }

            return RedirectToAction("Index");
        }

    }
}