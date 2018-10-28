using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Numiteq.BusinessLogic.BusinessContracts;
using Numiteq.BusinessLogic.BusinessContracts.Models;
using Numiteq.ViewModels.ContactUs;

namespace Numiteq.Controllers
{
    public class ContactUsController : BaseController
    {
        private const string contactUsPageDataKey = "ContactUsPageData";
        private IMessageService messageService;

        public ContactUsController(IServiceProvider serviceProvider, IMessageService messageService) : base(serviceProvider)
        {
            this.messageService = messageService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            AddContactsToPage();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(FormViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                AddContactsToPage();
                return View(vm);
            }

            try
            {
                await messageService.SendMessageAsync(new FeedbackMessage
                {
                    Name = vm.Name,
                    Company = vm.Company,
                    Email = vm.Email,
                    Message = vm.Message,
                    Phone = vm.Phone
                });
            }
            catch(Exception e)
            {
                return RedirectToAction(nameof(Error));
            }

            return RedirectToAction(nameof(Success));
        }

        [HttpGet]
        public IActionResult Success()
        {
            SuccessViewModel vm = new SuccessViewModel
            {
                Contacts = GetContacts()
            };

            return View(vm);
        }

        [HttpGet]
        public IActionResult Error()
        {
            ErrorViewModel vm = new ErrorViewModel
            {
                Contacts = GetContacts()
            };

            return View(vm);
        }

        private void AddContactsToPage()
        {
            ViewData.Add(contactUsPageDataKey, GetContacts());
        }

        private ContactsViewModel GetContacts()
        {
            return SettingService.GetSettings<ContactsViewModel>();
        }
    }
}
