using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<ActionResult> Price(int id)
        {
            GetPriceListLinkByIdQueryResult result = Query.For<GetPriceListLinkByIdQueryResult>().ById(id);

            if (!result.IsFound)
            {
                return Redirect("/");
            }

            PriceListLinkViewModel vm = ToViewModel(result.Link);

            vm.HtmlContent = await GetDocument(vm.Url);

            return View(vm);
        }

        public async Task<ActionResult> Load(int id)
        {
            GetPriceListLinkByIdQueryResult result = Query.For<GetPriceListLinkByIdQueryResult>().ById(id);

            if (!result.IsFound)
            {
                return HttpNotFound();
            }

            string document = await GetDocument(result.Link.Url);

            return Content(document);
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

        public ActionResult Delete(int id)
        {
            Command.Execute(new DeletePriceListLinkCommand
            {
                Id = id
            });

            return RedirectToAction("Index");
        }

        public ActionResult Recovery(int id)
        {
            Command.Execute(new RecoveryPriceListLinkCommand
            {
                Id = id
            });

            return RedirectToAction("Index");
        }

        public ActionResult SortUp(int id)
        {
            Command.Execute(new SortUpPriceListLinkCommand
            {
                Id = id
            });

            return RedirectToAction("Index");
        }

        public ActionResult SortDown(int id)
        {
            Command.Execute(new SortDownPriceListLinkCommand
            {
                Id = id
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

        protected async Task<string> GetDocument(string url)
        {
            HttpWebResponse response = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    return  await reader.ReadToEndAsync();

                    //Encoding iso = Encoding.GetEncoding("windows-1251");

                    //return Convert(iso, Encoding.Unicode, text);
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                if(response != null)
                {
                    response.Close();
                }
            }

            return null;
        }

        protected string Convert(Encoding from, Encoding to, string text)
        {
            byte[] fromBytes = from.GetBytes(text);
            byte[] toBytes = Encoding.Convert(from, to, fromBytes);
            string convertedText = to.GetString(toBytes);
            return convertedText;
        }
    }
}