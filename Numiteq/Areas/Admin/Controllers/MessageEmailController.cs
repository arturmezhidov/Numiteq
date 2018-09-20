﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Numiteq.Areas.Admin.ViewModels.MessageEmails;
using Numiteq.BusinessLogic.BusinessContracts;
using Numiteq.Controllers;

namespace Numiteq.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MessageEmailController : BaseController
    {
        private readonly IMessageEmailService messageEmailService;

        public MessageEmailController(IServiceProvider serviceProvider, IMessageEmailService messageEmailService) : base(serviceProvider)
        {
            this.messageEmailService = messageEmailService;
        }

        public IActionResult Index()
        {
            IndexViewModel vm = new IndexViewModel
            {
                Emails = messageEmailService.GetAll()
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Add(AddMessageEmailViewModel vm)
        {
            messageEmailService.Add(new Common.Entities.MessageEmail {
                Email = vm.Email
            });

            return RedirectToIndex();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            messageEmailService.Remove(id);

            return RedirectToIndex();
        }
    }
}