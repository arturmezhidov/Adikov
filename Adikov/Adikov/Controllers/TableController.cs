using System;
using System.Linq;
using System.Web.Mvc;
using Adikov.Domain.Commands.Tables;
using Adikov.Domain.Models;
using Adikov.Domain.Queries.Columns;
using Adikov.Domain.Queries.Tables;
using Adikov.Infrastructura.Criterion;
using Adikov.Platform.Extensions;
using Adikov.ViewModels.Columns;
using Adikov.ViewModels.Tables;

namespace Adikov.Controllers
{
    public class TableController : LayoutController
    {
        // GET: Table
        public ActionResult Index()
        {
            FindAllTableQueryResult result = Query.For<FindAllTableQueryResult>().With(new EmptyCriterion());

            TableIndexViewModel vm = new TableIndexViewModel
            {
                ActiveTables = result.ActiveTables.Select(ToViewModel),
                DeletedTables = result.DeletedTables.Select(ToViewModel)
            };

            return View(vm);
        }

        [HttpGet]
        public ActionResult Add()
        {
            FindActiveColumnQueryResult result = Query.For<FindActiveColumnQueryResult>().With(new EmptyCriterion());

            TableAddViewModel vm = new TableAddViewModel
            {
                SelectListItems = result.ActiveColumns.Select(ToSelectListItem).ToList()
            };

            return View(vm);
        }

        [HttpPost]
        public ActionResult Add(TableAddViewModel vm)
        {
            Command.Execute(new AddTableCommand
            {
                Name = vm.Name,
                Columns = vm.Columns
            });

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            FindTableDetailsQueryResult result = Query.For<FindTableDetailsQueryResult>().ById(id);
            FindActiveColumnQueryResult columns = Query.For<FindActiveColumnQueryResult>().With(new EmptyCriterion());

            TableEditViewModel vm = new TableEditViewModel
            {
                Id = result.Id,
                Name = result.Name,
                Columns = result.Columns.Select(i => i.Id).ToList(),
                SelectListItems = columns.ActiveColumns.Select(ToSelectListItem).ToList()
            };

            return View(vm);
        }

        [HttpPost]
        public ActionResult Edit(TableEditViewModel vm)
        {
            Command.Execute(new EditTableCommand
            {
                Id = vm.Id,
                Name = vm.Name,
                Columns = vm.Columns
            });

            return RedirectToAction("Details", new { id = vm.Id });
        }

        [HttpGet]
        public ActionResult Details(int id, bool? preview)
        {
            FindTableDetailsQueryResult result = Query.For<FindTableDetailsQueryResult>().ById(id);

            if (result == null)
            {
                return RedirectToAction("Index");
            }

            TableDetailsViewModel vm = new TableDetailsViewModel
            {
                Name = result.Name,
                Columns = result.Columns.Select(ToViewModel),
                IsPreview = preview
            };

            return View(vm);
        }

        public ActionResult Delete(int id)
        {
            Command.Execute(new DeleteTableCommand(id));

            return RedirectToAction("Index");
        }

        public ActionResult Clear()
        {
            Command.Execute(new ClearTableCommand());

            return RedirectToAction("Index");
        }

        public ActionResult Recovery(int id)
        {
            Command.Execute(new RecoveryTableCommand(id));

            return RedirectToAction("Index");
        }

        public ActionResult RecoveryAll()
        {
            Command.Execute(new RecoveryAllTableCommand());

            return RedirectToAction("Index");
        }

        protected TableViewModel ToViewModel(Table table)
        {
            TableViewModel vm = new TableViewModel
            {
                Id = table.Id,
                Name = table.Name,
                ColumnsCount = table.Columns.Count,
                IsDeleted = table.IsDeleted
            };

            return vm;
        }

        protected ColumnViewModel ToViewModel(Column column)
        {
            ColumnViewModel vm = new ColumnViewModel
            {
                Id = column.Id,
                Name = column.Name,
                Type = column.Type,
                IsDeleted = column.IsDeleted
            };

            return vm;
        }

        protected SelectListItem ToSelectListItem(Column c)
        {
            return new SelectListItem
            {
                Text = String.Format("{0} ({1})", c.Name, c.Type.GetDescription()),
                Value = c.Id.ToString()
            };
        }
    }
}