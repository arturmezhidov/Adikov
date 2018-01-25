using System.Collections.Generic;
using System.Linq;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Criterion;

namespace Adikov.Domain.Queries.Forms
{
    public class GenerateFormQueryResult
    {
        public Product Product { get; set; }

        public IEnumerable<Column> Columns { get; set; }
    }

    public class GenerateFormQuery : Query<IdCriterion, GenerateFormQueryResult>
    {
        protected override GenerateFormQueryResult OnExecuting(IdCriterion criterion)
        {
            Product product = DataContext.Products.Find(criterion.Id);

            if (product == null)
            {
                return null;
            }

            List<int> columns = product.Table.TableColumns.Select(i => i.ColumnId).ToList();

            GenerateFormQueryResult result = new GenerateFormQueryResult
            {
                Product = product,
                Columns = DataContext.Columns.Where(i => !i.IsDeleted && columns.Contains(i.Id)).ToList()
            };

            return result;
        }
    }
}