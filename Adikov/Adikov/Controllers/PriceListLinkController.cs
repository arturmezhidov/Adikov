using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Adikov.Domain.Commands.PriceListLinks;
using Adikov.Domain.Models;
using Adikov.Domain.Queries.PriceListLinks;
using Adikov.Services;
using Adikov.ViewModels.PriceListLinks;

namespace Adikov.Controllers
{
    public class PriceListLinkController : LayoutController
    {
        public ActionResult Index(int? id = null)
        {
            FindAllPriceListLinksQueryResult items = Query.For<FindAllPriceListLinksQueryResult>().Empty();

            IndexViewModel vm = new IndexViewModel
            {
                AddLink = new AddPriceListLinkViewModel(),
                EditLink = null,
                ActiveLinks = items.ActiveLinks.Select(ToViewModel).ToList(),
                DeletedLinks = items.DeletedLinks.Select(ToViewModel).ToList()
            };

            if (id.HasValue)
            {
                GetPriceListLinkByIdQueryResult result = Query.For<GetPriceListLinkByIdQueryResult>().ById(id.Value);

                if (result.IsFound)
                {
                    vm.EditLink = ToEditViewModel(result.Link);
                }
            }

            return View(vm);
        }

        [HttpPost]
        public ActionResult Add(AddPriceListLinkViewModel vm)
        {
            Command.Execute(new AddPriceListLinkCommand
            {
                Text = vm.Text,
                Url = vm.Url,
                Description = vm.Description
            });

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(EditPriceListLinkViewModel vm)
        {
            Command.Execute(new EditPriceListLinkCommand
            {
                Id = vm.Id,
                Text = vm.Text,
                Url = vm.Url,
                Description = vm.Description
            });

            return RedirectToAction("Index");
        }

        protected PriceListLinkViewModel ToViewModel(PriceListLink model)
        {
            PriceListLinkViewModel vm = Mapper.Map<PriceListLinkViewModel>(model);
            return vm;
        }

        protected EditPriceListLinkViewModel ToEditViewModel(PriceListLink model)
        {
            EditPriceListLinkViewModel vm = Mapper.Map<EditPriceListLinkViewModel>(model);
            return vm;
        }
    }
}