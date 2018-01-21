using System.Linq;
using System.Web.Mvc;
using Adikov.Domain.Commands.Products;
using Adikov.Domain.Models;
using Adikov.Domain.Queries.Categories;
using Adikov.Domain.Queries.Products;
using Adikov.Domain.Queries.Tables;
using Adikov.Infrastructura.Criterion;
using Adikov.ViewModels.Products;

namespace Adikov.Controllers
{
    public class ProductController : LayoutController
    {
        // GET: Product
        public ActionResult Index(int? id, int? categoryId)
        {
            FindAllProductQueryResult result = Query.For<FindAllProductQueryResult>().With(new EmptyCriterion());
            FindActiveTableQueryResult tableResult = Query.For<FindActiveTableQueryResult>().With(new EmptyCriterion());
            FindAllCategoryCanAddProductQueryResult categoryResult = Query.For<FindAllCategoryCanAddProductQueryResult>().With(new EmptyCriterion());

            ProductIndexViewModel vm = new ProductIndexViewModel
            {
                ActiveProducts = result.ActiveProducts.Select(ToViewModel),
                DeletedProducts = result.DeletedProducts.Select(ToViewModel)
            };

            if (id == null)
            {
                vm.NewProduct = new ProductAddViewModel
                {
                    CategorySelectListItems = categoryResult.Categories.Select(ToSelectListItem).ToList(),
                    TableSelectListItems = tableResult.ActiveTables.Select(ToSelectListItem).ToList()
                };

                if (categoryId.HasValue)
                {
                    Category category = categoryResult.Categories.FirstOrDefault(i => i.Id == categoryId);

                    if (category != null)
                    {
                        string strCategoryId = categoryId.ToString();

                        vm.NewProduct.CategorySelectListItems.ForEach(i =>
                        {
                            i.Selected = i.Value == strCategoryId;
                        });

                        if (category.Type == CategoryType.Single)
                        {
                            vm.NewProduct.Name = vm.NewProduct.CategorySelectListItems.FirstOrDefault(i => i.Value == strCategoryId)?.Text;
                        }
                    }
                }
            }
            else
            {
                var edit = result.ActiveProducts.FirstOrDefault(i => i.Id == id) ??
                           result.DeletedProducts.FirstOrDefault(i => i.Id == id);

                if (edit == null)
                {
                    return RedirectToAction("Index");
                }

                categoryResult.Categories.Add(edit.Category);

                vm.EditProduct = new ProductEditViewModel
                {
                    Id = edit.Id,
                    Name = edit.Name,
                    CategoryId = edit.CategoryId,
                    TableId = edit.TableId,
                    CategorySelectListItems = categoryResult.Categories.Select(ToSelectListItem).ToList(),
                    TableSelectListItems = tableResult.ActiveTables.Select(ToSelectListItem).ToList()
                };

                vm.EditProduct.CategorySelectListItems.ForEach(i =>
                {
                    i.Selected = i.Value == edit.CategoryId.ToString();
                });

                vm.EditProduct.TableSelectListItems.ForEach(i =>
                {
                    i.Selected = i.Value == edit.TableId.ToString();
                });
            }

            return View(vm);
        }

        [HttpPost]
        public ActionResult Add(ProductAddViewModel vm)
        {
            Command.For<AddProductCommandResult>().Execute(new AddProductCommand
            {
                Name = vm.Name,
                CategoryId = vm.CategoryId,
                TableId = vm.TableId
            });

            return RedirectToAction("Index", new { categoryId = vm.CategoryId });
        }

        [HttpPost]
        public ActionResult Edit(ProductEditViewModel vm)
        {
            Command.Execute(new EditProductCommand
            {
                Id = vm.Id,
                Name = vm.Name,
                CategoryId = vm.CategoryId,
                TableId = vm.TableId
            });

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Command.Execute(new DeleteProductCommand(id));

            return RedirectToAction("Index");
        }

        public ActionResult Recovery(int id)
        {
            Command.Execute(new RecoveryProductCommand(id));

            return RedirectToAction("Index");
        }

        public ActionResult RecoveryAll()
        {
            Command.Execute(new RecoveryAllProductCommand());

            return RedirectToAction("Index");
        }

        protected SelectListItem ToSelectListItem(Category category)
        {
            return new SelectListItem
            {
                Text = category.Name,
                Value = category.Id.ToString()
            };
        }

        protected SelectListItem ToSelectListItem(Table table)
        {
            return new SelectListItem
            {
                Text = table.Name,
                Value = table.Id.ToString()
            };
        }

        protected ProductViewModel ToViewModel(Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Table = product.Table.Name,
                TableId = product.TableId,
                IsTableDeleted = product.Table.IsDeleted,
                Category = product.Category.Name,
                IsCategoryDeleted = product.Category.IsDeleted,
                IsDeleted = product.IsDeleted
            };
        }
    }
}