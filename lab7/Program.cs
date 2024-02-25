using lab7.Utils;
using lab7.Props;

class Program
{
    // Data
    static List<Appliance> appliances = new List<Appliance>();
    static RemoteControl remoteControl = new RemoteControl();

    // Functionality
    static UI ui = new UI(appliances, remoteControl);
    static ScheduleRunner scheduleRunner = new ScheduleRunner(appliances, remoteControl);

    static void Main(string[] args)
    {
        scheduleRunner.Initialize("schedule.txt");
        ui.Initialize();

        Console.WriteLine("\n\nScheduleRunner is still running.\nPress any key to exit.");
        Console.ReadKey();
    }
}
