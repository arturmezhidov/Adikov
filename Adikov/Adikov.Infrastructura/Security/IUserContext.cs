namespace Adikov.Infrastructura.Security
{
    public interface IUserContext
    {
        string UserId { get; }

        bool IsAuth { get; }

        bool IsAdmin { get; }

        string Email { get; }

        string Avatar { get; }

        string FirstName { get; }

        string LastName { get; }

        string PhoneNumber { get; }

        string Occupation { get; }

        string Interests { get; }

        string About { get; }

        string Website { get; }

        void Reset();
    }
}