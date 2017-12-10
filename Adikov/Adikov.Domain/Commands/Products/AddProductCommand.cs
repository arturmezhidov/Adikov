﻿using Adikov.Domain.Models;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Products
{
    public class AddProductCommand : CommandBase
    {
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public int TableId { get; set; }
    }

    public class AddProductCommandResult : CommandResult
    {
        public Product Product { get; set; }
    }

    public class AddProductCommandHandler : CommandHandler<AddProductCommand, AddProductCommandResult>
    {
        protected override void OnHandling(AddProductCommand command, AddProductCommandResult result)
        {
            Category category = DataContext.Categories.Find(command.CategoryId);

            if (category == null)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            if (category.Type == CategoryType.Single && category.Products.Count > 0)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            Table table = DataContext.Tables.Find(command.TableId);

            if (table == null)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            Product product = new Product
            {
                Name = command.Name,
                CategoryId = command.CategoryId,
                TableId = command.TableId
            };

            DataContext.Products.Add(product);

            result.Product = product;
        }
    }
}