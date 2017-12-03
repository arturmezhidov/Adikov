using Adikov.Infrastructura.Criterion;

namespace Adikov.Domain.Criterion
{
    public class StringSizeCriterion : ICriterion
    {
        public string Size { get; }

        public StringSizeCriterion(string size)
        {
            Size = size;
        }
    }
}