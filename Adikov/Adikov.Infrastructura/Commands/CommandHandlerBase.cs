using System;
using Adikov.Infrastructura.Security;

namespace Adikov.Infrastructura.Commands
{
    public abstract class CommandHandlerBase<TCommand, TResult> : ICommandHandler<TCommand, TResult> 
        where TCommand : ICommand
        where TResult : ICommandResult, new()
    {
        private UserContext userContext;

        protected UserContext UserContext => userContext ?? (userContext = new UserContext());

        public TResult Handle(TCommand command)
        {
            TResult result = new TResult
            {
                ResultCode = CommandResultCode.Success
            };

            try
            {
                OnHandling(command, result);
            }
            catch(Exception e)
            {
                result.ResultCode = CommandResultCode.Fail;
                return result;
            }

            try
            {
                OnHandled(command, result);
            }
            catch (Exception e)
            {
                result.ResultCode = CommandResultCode.Fail;
                return result;
            }

            return result;
        }

        protected abstract void OnHandling(TCommand command, TResult result);

        protected abstract void OnHandled(TCommand command, TResult result);
    }
}