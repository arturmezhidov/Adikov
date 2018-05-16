using System;
using System.Data.Entity;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Shares
{
    public class EditShareCommand : CommandBase
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? EndDate { get; set; }

        public string RibbonText { get; set; }

        public string RibbonColor { get; set; }

        public bool IsRibbonDisplayed { get; set; }

        public int FileId { get; set; }

        public bool IsFileChanged { get; set; }
    }

    public class EditShareCommandHandler : CommandHandler<EditShareCommand>
    {
        protected override void OnHandling(EditShareCommand command, CommandResult result)
        {
            var item = DataContext.Shares.Find(command.Id);

            if (item == null)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            item.Title = command.Title;
            item.Description = command.Description;
            item.RibbonColor = command.RibbonColor;
            item.RibbonText = command.RibbonText;
            item.IsRibbonDisplayed = command.IsRibbonDisplayed;

            if (command.EndDate.HasValue)
            {
                item.EndDate = command.EndDate.Value;
            }

            if (command.IsFileChanged)
            {
                item.FileId = command.FileId;
            }

            DataContext.Entry(item).State = EntityState.Modified;
        }
    }
}