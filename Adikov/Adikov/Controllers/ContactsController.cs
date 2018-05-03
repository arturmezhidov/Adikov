using System;
using System.Web.Mvc;
using Adikov.Domain.Commands.Contacts;
using Adikov.Domain.Queries.Contacts;
using Adikov.Infrastructura.Criterion;
using Adikov.Platform.Configuration;
using Adikov.Platform.Settings;
using Adikov.Services;
using Adikov.ViewModels.Contacts;

namespace Adikov.Controllers
{
    public class ContactsController : LayoutController
    {
        public ActionResult Index()
        {
            GetContactsMapQueryResult map = Query.For<GetContactsMapQueryResult>().With(new EmptyCriterion());
            GetQuestionQueryResult question = Query.For<GetQuestionQueryResult>().With(new EmptyCriterion());
            GetDocumentsQueryResult documents = Query.For<GetDocumentsQueryResult>().With(new EmptyCriterion());
            GetKeepInTouchQueryResult keepInTouch = Query.For<GetKeepInTouchQueryResult>().With(new EmptyCriterion());

            IndexViewModel vm = new IndexViewModel
            {
                Map = ToViewModel(map.Map),
                Documents = ToViewModel(documents),
                Question = ToViewModel(question.Question),
                GetKeepInTouch = ToViewModel(keepInTouch.KeepInTouch)
            };

            return View(vm);
        }

        [HttpGet]
        public ActionResult Map()
        {
            GetContactsMapQueryResult result = Query.For<GetContactsMapQueryResult>().With(new EmptyCriterion());
            MapViewModel vm = ToViewModel(result.Map);
            return View(vm);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Map(MapViewModel vm)
        {
            Command.Execute(new EditContactsMapCommand
            {
                Map = ToModel(vm)
            });

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Question()
        {
            GetQuestionQueryResult result = Query.For<GetQuestionQueryResult>().With(new EmptyCriterion());
            QuestionViewModel vm = ToViewModel(result.Question);
            return View(vm);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Question(QuestionViewModel vm)
        {
            Command.Execute(new EditContactsQuestionCommand
            {
                Question = ToModel(vm)
            });

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult KeepInTouch()
        {
            GetKeepInTouchQueryResult result = Query.For<GetKeepInTouchQueryResult>().With(new EmptyCriterion());
            KeepInTouchViewModel vm = ToViewModel(result.KeepInTouch);
            return View(vm);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult KeepInTouch(KeepInTouchViewModel vm)
        {
            Command.Execute(new EditContactsKeepInTouchCommand
            {
                KeepInTouch = ToModel(vm)
            });

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Documents()
        {
            GetDocumentsQueryResult result = Query.For<GetDocumentsQueryResult>().With(new EmptyCriterion());
            DocumentsViewModel vm = ToViewModel(result);
            return View(vm);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Documents(DocumentsViewModel vm)
        {
            var result = SaveAs(vm.File, PlatformConfiguration.DocumentsPath);

            Command.Execute(new EditContactsDocumentsCommand
            {
                Documents = ToModel(vm),
                File = result?.File
            });

            return RedirectToAction("Index");
        }

        protected MapViewModel ToViewModel(ContactsMap model)
        {
            MapViewModel vm = Mapper.Map<MapViewModel>(model);
            return vm;
        }

        protected QuestionViewModel ToViewModel(ContactsQuestion model)
        {
            QuestionViewModel vm = Mapper.Map<QuestionViewModel>(model);
            return vm;
        }

        protected DocumentsViewModel ToViewModel(GetDocumentsQueryResult model)
        {
            DocumentsViewModel vm = Mapper.Map<DocumentsViewModel>(model.Documents);
            vm.FileUrl = model.DocumentsLink;
            vm.FileName = model.FileName;
            vm.UpdatedAt = DateTime.TryParse(vm.UpdatedAt, out DateTime date)
                ? date.ToShortDateString()
                : null;
            return vm;
        }

        protected KeepInTouchViewModel ToViewModel(ContactsKeepInTouch model)
        {
            KeepInTouchViewModel vm = Mapper.Map<KeepInTouchViewModel>(model);
            return vm;
        }

        protected ContactsMap ToModel(MapViewModel vm)
        {
            ContactsMap model = Mapper.Map<ContactsMap>(vm);
            return model;
        }

        protected ContactsQuestion ToModel(QuestionViewModel vm)
        {
            ContactsQuestion model = Mapper.Map<ContactsQuestion>(vm);
            return model;
        }

        protected ContactsKeepInTouch ToModel(KeepInTouchViewModel vm)
        {
            ContactsKeepInTouch model = Mapper.Map<ContactsKeepInTouch>(vm);
            return model;
        }

        protected ContactsDocuments ToModel(DocumentsViewModel vm)
        {
            ContactsDocuments model = Mapper.Map<ContactsDocuments>(vm);
            return model;
        }
    }
}