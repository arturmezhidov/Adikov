using System;
using System.Collections.Generic;
using System.Globalization;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Commands;

namespace Adikov.Domain.Commands.Rows
{
    public class NewCell
    {
        public int ColumnId { get; set; }

        public ColumnType ColumnType { get; set; }

        public string Value { get; set; }
    }

    public class AddRowCommand : CommandBase
    {
        public int ProductId { get; set; }

        public List<NewCell> Cells { get; set; }
    }

    public class AddProductCommandHandler : CommandHandler<AddRowCommand, CommandResult>
    {
        protected override void OnHandling(AddRowCommand command, CommandResult result)
        {
            Product product = DataContext.Products.Find(command.ProductId);

            if (product == null)
            {
                result.ResultCode = CommandResultCode.Cancelled;
                return;
            }

            Row row = new Row
            {
                Product = product,
                ProductId = product.Id,
                IsDeleted = false,
                Cells = new List<Cell>()
            };

            foreach (var cell in command.Cells)
            {

                row.Cells.Add(new Cell
                {
                    Row = row,
                    ColumnId = cell.ColumnId,
                    Value = getValue(cell.ColumnType, cell.Value)
                });
            }
 
            DataContext.Rows.Add(row);
        }

        private string getValue(ColumnType type, string value)
        {
            switch (type)
            {
                case ColumnType.IntNumber:
                {
                    if (int.TryParse(value, out int intValue))
                    {
                        return intValue.ToString();
                    }
                    return "0";
                }
                case ColumnType.DoubleNumber:
                {
                    if (double.TryParse(value, out double doubleValue))
                    {
                        return doubleValue.ToString(CultureInfo.InvariantCulture);
                    }
                    return "0";
                }
                case ColumnType.String:
                {
                    if (!String.IsNullOrEmpty(value))
                    {
                        return value.Trim();
                    }
                    return String.Empty;
                }
                case ColumnType.Status:
                {
                    if (Enum.TryParse(value, out ProductStatus enumValue))
                    {
                        return enumValue.ToString();
                    }
                    return ProductStatus.InStock.ToString();
                }
            }

            return String.Empty;
        }
    }
}