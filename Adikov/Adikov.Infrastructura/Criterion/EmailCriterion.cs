namespace Adikov.Infrastructura.Criterion
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