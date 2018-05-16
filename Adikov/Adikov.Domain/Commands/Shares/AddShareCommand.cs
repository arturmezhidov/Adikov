using System;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Shares
{
    public class AddShareCommand : CommandBase
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? EndDate { get; set; }

        public string RibbonText { get; set; }

        public string RibbonColor { get; set; }

        public bool IsRibbonDisplayed { get; set; }

        public int FileId { get; set; }
    }

    public class AddShareCommandHandler : CommandHandler<AddShareCommand>
    {
        protected override void OnHandling(AddShareCommand command, CommandResult result)
        {
            var newItem = new Share
            {
                Title = command.Title,
                Description = command.Description,
                EndDate = command.EndDate ?? DateTime.Now.AddDays(3),
                RibbonColor = command.RibbonColor,
                RibbonText = command.RibbonText,
                FileId = command.FileId,
                IsRibbonDisplayed = command.IsRibbonDisplayed,
                CreatedDate = DateTime.Now,
                IsDeleted = false
            };

            DataContext.Shares.Add(newItem);
        }
    }
}