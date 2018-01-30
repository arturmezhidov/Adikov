using System.Linq;
using System.Web.Mvc;
using Adikov.Domain.Commands.Columns;
using Adikov.Domain.Models;
using Adikov.Domain.Queries.Columns;
using Adikov.Infrastructura.Criterion;
using Adikov.ViewModels.Columns;

namespace Adikov.Controllers
{
    public class ColumnController : LayoutController
    {
        public ActionResult Index(int? id)
        {
            var result = Query.For<FindAllColumnQueryResult>().With(new EmptyCriterion());

            var vm = new ColumnIndexViewModel
            {
                ActiveColumns = result.ActiveColumns.Select(ToViewModel),
                DeletedColumns = result.DeletedColumns.Select(ToViewModel)
            };

            if (id == null)
            {
                vm.NewColumn = new ColumnViewModel();
            }
            else
            {
                var edit = result.ActiveColumns.FirstOrDefault(i => i.Id == id) ??
                                   result.DeletedColumns.FirstOrDefault(i => i.Id == id);

                if (edit == null)
                {
                    return RedirectToAction("Index");
                }

                vm.EditColumn = ToViewModel(edit);
            }

            return View(vm);
        }

        [HttpPost]
        public ActionResult Add(AddColumnCommand vm)
        {
            Command.Execute(new AddColumnCommand
            {
                Name = vm.Name,
                Type = vm.Type
            });

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(ColumnViewModel vm)
        {
            Command.Execute(new EditColumnCommand
            {
                Id = vm.Id ?? 0,
                Name = vm.Name
            });

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Command.Execute(new DeleteColumnCommand(id));

            return RedirectToAction("Index");
        }

        public ActionResult Clear()
        {
            Command.Execute(new ClearColumnCommand());

            return RedirectToAction("Index");
        }

        public ActionResult Recovery(int id)
        {
            Command.Execute(new RecoveryColumnCommand(id));

            return RedirectToAction("Index");
        }

        public ActionResult RecoveryAll()
        {
            Command.Execute(new RecoveryAllColumnCommand());

            return RedirectToAction("Index");
        }

        protected ColumnViewModel ToViewModel(Column column)
        {
            return new ColumnViewModel
            {
                Id = column.Id,
                Name = column.Name,
                Type = column.Type,
                IsDeleted = column.IsDeleted
            };
        }
    }
}