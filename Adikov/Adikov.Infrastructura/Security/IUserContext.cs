namespace Adikov.Infrastructura.Security
{
    public interface IUserContext
    {
        string UserId { get; }

        string Email { get; }

        bool IsAuth { get; }

        string Avatar { get; }

        bool IsAdmin { get; }
    }
}