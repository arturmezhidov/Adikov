using System.Linq;
using Adikov.Domain.Criterion;

namespace Adikov.Domain.Queries
{
    public class FindByEmailQuery : SingleQuery<EmailCriterion, ApplicationUser>
    {
        protected override ApplicationUser OnExecuting(EmailCriterion criterion)
        {
            return Entities.FirstOrDefault(i => i.Email == criterion.Email);
        }
    }
}