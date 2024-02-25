using lab7.Commands;
using lab7.Props;

namespace lab7.Utils;

class UI
{
    List<Appliance> appliances;
    RemoteControl remoteControl;

    public UI(List<Appliance> appliances, RemoteControl remoteControl)
    {
        this.appliances = appliances;
        this.remoteControl = remoteControl;
    }

    public void Initialize()
    {

        bool exit = false;
        while (!exit)
        {
            ShowCommands();
            Console.Write("Enter the number: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    TurnOnAppliance();
                    break;
                case "2":
                    Console.Clear();
                    TurnOffAppliance();
                    break;
                case "3":
                    Console.Clear();
                    UndoLastAction();
                    break;
                case "0":
                    exit = true;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    void ShowCommands()
    {
        Console.WriteLine("\nFor selecting the option, type:\n" +
          "1 - turn on appliance\n" +
          "2 - turn off appliance\n" +
          "3 - undo last action\n" +
          "0 - exit");
    }

    void TurnOnAppliance()
    {
        ShowAppliances();

        Console.Write("Type the number of appliance to turn it on: ");
        int index = int.Parse(Console.ReadLine());
        if (index >= 0 && index < appliances.Count)
        {
            remoteControl.ExecuteCommand(new TurnOnCommand(appliances[index]));
        }
        else
        {
            Console.WriteLine("Invalid number.");
        }
    }

    void TurnOffAppliance()
    {
        ShowAppliances();

        Console.Write("Type the number of appliance to turn it off: ");
        int index = int.Parse(Console.ReadLine());
        if (index >= 0 && index < appliances.Count)
        {
            remoteControl.ExecuteCommand(new TurnOffCommand(appliances[index]));
        }
        else
        {
            Console.WriteLine("Invalid number.");
        }
    }

    void UndoLastAction()
    {
        remoteControl.UndoLastCommand();
    }

    void ShowAppliances()
    {
        Console.WriteLine("Appliances list:");
        for (int i = 0; i < appliances.Count; i++)
        {
            Console.WriteLine($"{i}: {appliances[i].Name}");
        }
    }
}
