namespace Adikov.Infrastructura.Commands
{
    public interface ICommandResult
    {
        CommandResultCode ResultCode { get; set; }
    }
}