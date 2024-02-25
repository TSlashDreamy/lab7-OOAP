using lab7.Commands.Interfaces;

namespace lab7.Props;

// Invoker
class RemoteControl
{
    private readonly Stack<ICommand> _commands = new Stack<ICommand>();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        _commands.Push(command);
    }

    public void UndoLastCommand()
    {
        if (_commands.Count > 0)
        {
            var lastCommand = _commands.Pop();
            lastCommand.Undo();
        }
        else
        {
            Console.WriteLine("No more commands to undo.");
        }
    }
}
