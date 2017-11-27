namespace Adikov.Domain.Criterion
{
    public class EmailCriterion : ICriterion
    {
        public string Email { get; }

        public EmailCriterion(string email)
        {
            Email = email;
        }
    }
}