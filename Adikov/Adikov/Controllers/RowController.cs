using System;
using System.Linq;
using System.Web.Mvc;
using Adikov.Domain.Commands.Rows;
using Adikov.Domain.Models;
using Adikov.Domain.Queries.Forms;
using Adikov.Domain.Queries.Products;
using Adikov.Domain.Queries.Rows;
using Adikov.ViewModels.Forms;
using Adikov.ViewModels.Rows;

namespace Adikov.Controllers
{
    public class RowController : LayoutController
    {
        [HttpGet]
        public ActionResult Index(int productId, int? rowId = null)
        {
            GenerateFormQueryResult result = Query.For<GenerateFormQueryResult>().ById(productId);
            GetProductTableByIdQueryResult productTable = Query.For<GetProductTableByIdQueryResult>().ById(productId);

            if (result == null)
            {
                // TODO: Redirect to not found page.
                return null;
            }

            RowIndexViewModel vm = new RowIndexViewModel
            {
                Table = productTable.Table
            };

            if (rowId.HasValue)
            {
                FindRowByIdQueryResult row = Query.For<FindRowByIdQueryResult>().ById(rowId.Value);
 
                if (row != null)
                {
                    vm.Form = ToEditViewModel(result, row.Row);
                    vm.IsEdittingMode = true;
                    ViewBag.ProductId = productId;
                }
            }

            if (vm.Form == null)
            {
                vm.Form = ToViewModel(result);
            }

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

        [HttpPost]
        public ActionResult Edit(FormViewModel vm, int productId)
        {
            Command.Execute(new EditRowCommand
            {
                RowId = vm.Id,
                Cells = vm.Controls.Select(ToEditCell).ToList()
            });

            return RedirectToAction("Index", new { productId });
        }

        public ActionResult Delete(int id, int productId)
        {
            Command.Execute(new DeleteRowCommand
            {
                Id = id
            });

            return RedirectToAction("Index", new {productId});
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

        protected FormViewModel ToEditViewModel(GenerateFormQueryResult form, Row row)
        {
            FormViewModel vm = new FormViewModel
            {
                Id = row.Id,
                Name = form.Product.Name,
                Controls = form.Columns.Select(c => ToEditViewModel(c, row.Cells.FirstOrDefault(cell => cell.ColumnId == c.Id))).ToList()
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

        protected FormControlViewModel ToEditViewModel(Column column, Cell cell)
        {
            return new FormControlViewModel
            {
                Id = cell?.Id ?? 0,
                AditionalId = column.Id,
                Label = column.Name,
                Type = column.Type,
                Value = cell?.Value
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

        protected EditCell ToEditCell(FormControlViewModel control)
        {
            return new EditCell
            {
                CellId = control.Id,
                ColumnId = control.AditionalId,
                Value = control.Value
            };
        }
    }
}