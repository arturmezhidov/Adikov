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
        public Dictionary<int, string> Cells { get; set; }
    }

    public class ProductTable
    {
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


            GetProductTableByIdQueryResult result = new GetProductTableByIdQueryResult
            {
                Table = new ProductTable
                {
                    ProductName = product.Name,
                    Columns = product.Table.Columns.Select(col => new TableColumn
                    {
                        ColumnId = col.Id,
                        Name = col.Name,
                        Type = col.Type
                    }).ToList(),
                    Rows = product.Rows.Select(r => new TableRow
                    {
                        Cells = r.Cells.ToDictionary(cell => cell.ColumnId, cell => cell.Value)
                    }).ToList()
                }
            };

            return result;
        }
    }
}