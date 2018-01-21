using System;
using System.Linq;
using System.Web.Mvc;
using Adikov.Domain.Commands.Rows;
using Adikov.Domain.Models;
using Adikov.Domain.Queries.Forms;
using Adikov.Domain.Queries.Products;
using Adikov.ViewModels.Forms;
using Adikov.ViewModels.Rows;

namespace Adikov.Controllers
{
    public class RowController : LayoutController
    {
        [HttpGet]
        public ActionResult Index(int productId)
        {
            GenerateFormQueryResult result = Query.For<GenerateFormQueryResult>().ById(productId);
            GetProductTableByIdQueryResult productTable = Query.For<GetProductTableByIdQueryResult>().ById(productId);

            if (result == null)
            {
                // TODO: Redirect to not found page.
                return null;
            }

            RowAddViewModel vm = new RowAddViewModel
            {
                Form = ToViewModel(result),
                Table = productTable.Table
            };

            return View(vm);
        }

        [HttpPost]
        public ActionResult Add(FormViewModel vm)
        {
            Command.Execute(new AddRowCommand
            {
                ProductId = vm.Id,
                Cells = vm.Controls.Select(ToCell).ToList()
            });

            return RedirectToAction("Index", new { productId = vm.Id });
        }

        protected FormViewModel ToViewModel(GenerateFormQueryResult form)
        {
            FormViewModel vm = new FormViewModel
            {
                Id = form.Product.Id,
                Name = form.Product.Name,
                Controls = form.Columns.Select(ToViewModel).ToList()
            };

            int index = 0;

            vm.Controls.ForEach(model =>
            {
                model.FieldNamePrefix = $"{nameof(vm.Controls)}[{index}].";
                index++;
            });

            return vm;
        }

        protected FormControlViewModel ToViewModel(Column column)
        {
            return new FormControlViewModel
            {
                Id = column.Id,
                Label = column.Name,
                Type = column.Type,
                Value = String.Empty
            };
        }

        protected NewCell ToCell(FormControlViewModel control)
        {
            return new NewCell
            {
                ColumnId = control.Id,
                ColumnType = control.Type,
                Value = control.Value
            };
        }
    }
}