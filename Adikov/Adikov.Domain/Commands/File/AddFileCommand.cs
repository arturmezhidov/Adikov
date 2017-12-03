using System;
using System.IO;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.File
{
    public class AddFileCommand : CommandBase
    {
        public string FileName { get; set; }

        public string ContentType { get; set; }

        public int ContentLength { get; set; }
    }

    public class AddFileCommandResult : CommandResult
    {
        public Models.File File { get; set; }
    }

    public class AddFileCommandHandler : CommandHandler<AddFileCommand, AddFileCommandResult>
    {
        protected override void OnHandling(AddFileCommand command, AddFileCommandResult result)
        {
            if (String.IsNullOrEmpty(command.FileName) || command.ContentLength <= 0)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            result.File = new Models.File
            {
                OriginName = command.FileName,
                ContentLength = command.ContentLength,
                ContentType = command.ContentType,
                PhysicalName = String.Format("{0}{1}", Guid.NewGuid(), Path.GetExtension(command.FileName))
            };

            DataContext.Files.Add(result.File);
        }
    }
}