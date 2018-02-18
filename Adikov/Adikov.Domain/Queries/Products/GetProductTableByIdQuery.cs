using System;
using System.Collections.Generic;
using System.Linq;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Criterion;

namespace Adikov.Domain.Queries.Products
{
    public class TableColumn
    {
        public int ColumnId { get; set; }

        public string Name { get; set; }

        public ColumnType Type { get; set; }
    }

    public class TableRow
    {
        public int RowId { get; set; }

        public Dictionary<int, string> Cells { get; set; }
    }

    public class ProductTable
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public List<TableColumn> Columns { get; set; }

        public List<TableRow> Rows { get; set; }
    }

    public class GetProductTableByIdQueryResult
    {
        public ProductTable Table { get; set; }
    }

    public class GetProductTableByIdQuery : Query<IdCriterion, GetProductTableByIdQueryResult>
    {
        protected override GetProductTableByIdQueryResult OnExecuting(IdCriterion criterion)
        {
            Product product = DataContext.Products.Find(criterion.Id);

            if (product == null)
            {
                return null;
            }

            List<Column> allColumns = DataContext.Columns.Where(i => !i.IsDeleted).ToList();
            List<int> columns = product.Table.TableColumns.OrderBy(i => i.SortNumber).Select(i => i.ColumnId).ToList();

            GetProductTableByIdQueryResult result = new GetProductTableByIdQueryResult
            {
                Table = new ProductTable
                {
                    ProductId = (int)criterion.Id,
                    ProductName = product.Name,
                    Columns = columns.Select(col =>
                    {
                        Column column = allColumns.FirstOrDefault(i => i.Id == col);

                        if (column == null)
                        {
                            return null;
                        }

                        TableColumn tColumn = new TableColumn
                        {
                            ColumnId = column.Id,
                            Name = column.Name,
                            Type = column.Type
                        };
                        return tColumn;
                    }).Where(i => i != null).ToList(),
                    Rows = product.Rows.Select(r => new TableRow
                    {
                        RowId = r.Id,
                        Cells = r.Cells.ToDictionary(cell => cell.ColumnId, cell => cell.Value)
                    }).ToList()
                }
            };

            foreach (TableColumn column in result.Table.Columns)
            {
                foreach (TableRow row in result.Table.Rows)
                {
                    if (!row.Cells.ContainsKey(column.ColumnId))
                    {
                        if (column.Type == ColumnType.Status)
                        {
                            row.Cells.Add(column.ColumnId, ProductStatus.None.ToString());
                        }
                        else
                        {
                            row.Cells.Add(column.ColumnId, String.Empty);
                        }
                    }
                }
            }

            return result;
        }
    }
}