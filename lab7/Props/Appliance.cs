namespace lab7.Props;

// Receiver
class Appliance
{
    public string Name { get; set; }
    public bool IsOn { get; set; }
    public bool ScheduleOn { get; set; }
    public TimeSpan ScheduledTime { get; set; }

    public void TurnOn()
    {
        if(IsOn)
        {
            Console.WriteLine($"{Name} already turned on.");
            return;
        }
        IsOn = true;
        Console.WriteLine($"{Name} turned on.");
    }

    public void TurnOff()
    {
        if (!IsOn)
        {
            Console.WriteLine($"{Name} already turned off.");
            return;
        }
        IsOn = false;
        Console.WriteLine($"{Name} turned off.");
    }
}
