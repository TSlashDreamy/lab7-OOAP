namespace lab7.Commands.Interfaces;

interface ICommand
{
    void Execute();
    void Undo();
}
