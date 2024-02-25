using lab7.Commands.Interfaces;
using lab7.Props;

namespace lab7.Commands;

// Concrete Command - TurnOnCommand
class TurnOnCommand : ICommand
{
    private readonly Appliance _appliance;

    public TurnOnCommand(Appliance appliance)
    {
        _appliance = appliance;
    }

    public void Execute()
    {
        _appliance.TurnOn();
    }

    public void Undo()
    {
        Console.WriteLine($"Last action was undone for {_appliance.Name}.");
        _appliance.TurnOff();
    }
}
