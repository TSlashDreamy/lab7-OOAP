using lab7.Commands.Interfaces;
using lab7.Props;

namespace lab7.Commands;

// Concrete Command - TurnOffCommand
class TurnOffCommand : ICommand
{
    private readonly Appliance _appliance;

    public TurnOffCommand(Appliance appliance)
    {
        _appliance = appliance;
    }

    public void Execute()
    {
        _appliance.TurnOff();
    }

    public void Undo()
    {
        Console.WriteLine($"Last action was undone for {_appliance.Name}.");
        _appliance.TurnOn();
    }
}
