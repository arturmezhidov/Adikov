using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Adikov.Domain.Commands.File;
using Adikov.Infrastructura.Commands;
using Adikov.Infrastructura.Queries;
using Adikov.Infrastructura.Security;

namespace Adikov.Controllers
{
    public abstract class BaseController : Controller
    {
        protected IQueryBuilder Query { get; }

        protected ICommandBuilder Command { get; }

        protected IUserContext UserContext { get; }

        protected BaseController()
        {
            Query = new QueryBuilder(DependencyResolver.Current);
            Command = new CommandBuilder(DependencyResolver.Current);
            UserContext = new UserContext();
        }

        protected AddFileCommandResult SaveAs(HttpPostedFileBase file, string folderName)
        {
            if (file == null || file.ContentLength <= 0)
            {
                return null;
            }

            var result = Command.For<AddFileCommandResult>().Execute(new AddFileCommand
            {
                FileName = file.FileName,
                ContentLength = file.ContentLength,
                ContentType = file.ContentType
            });

            if (result.ResultCode == CommandResultCode.Success)
            {
                try
                {
                    string path = Path.Combine(Server.MapPath(folderName), result.File.PhysicalName);
                    file.SaveAs(path);
                }
                catch(Exception e)
                {
                    Command.Execute(new DeleteFileCommand
                    {
                        Id = result.File.Id
                    });

                    throw;
                }
            }

            return result;
        }

        protected string GetUrl(string fileName, string folderPath)
        {
            return String.Format("{0}/{1}", folderPath, fileName);
        }
    }
}