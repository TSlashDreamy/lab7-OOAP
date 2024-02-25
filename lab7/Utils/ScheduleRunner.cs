using lab7.Commands;
using lab7.Props;
using System.Timers;

namespace lab7.Utils;

internal class ScheduleRunner
{
    List<Appliance> appliances;
    RemoteControl remoteControl;
    HashSet<TimeSpan> scheduleHistory;

    public ScheduleRunner(List<Appliance> appliances, RemoteControl remoteControl)
    {
        this.appliances = appliances;
        this.remoteControl = remoteControl;
        this.scheduleHistory = new HashSet<TimeSpan>();
    }

    void LoadScheduleFromFile(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        foreach (var line in lines)
        {
            var parts = line.Split('-');
            var name = parts[0].Trim();
            var state = parts[1].Trim() == "on";
            var time = TimeSpan.Parse(parts[2].Trim());

            var appliance = new Appliance { Name = name, IsOn = false, ScheduleOn = state, ScheduledTime = time };
            appliances.Add(appliance);
        }
    }

    public void Initialize(string filePath)
    {
        LoadScheduleFromFile(filePath);

        var timer = new System.Timers.Timer(5000); // update every 5 seconds
        timer.Elapsed += TimerElapsedHandler;
        timer.AutoReset = true;
        timer.Start();
    }

    void TimerElapsedHandler(object sender, ElapsedEventArgs e)
    {
        var currentTime = DateTime.Now.TimeOfDay;
        var currentTimeSpan = new TimeSpan(currentTime.Hours, currentTime.Minutes, 0);

        foreach (var appliance in appliances)
        {
            var scheduledTimeSpan = new TimeSpan(appliance.ScheduledTime.Hours, appliance.ScheduledTime.Minutes, 0);
            if (scheduledTimeSpan == currentTimeSpan && !scheduleHistory.Contains(scheduledTimeSpan))
            {
                Console.WriteLine($"\n\nSchedule for {appliance.Name} triggered in {appliance.ScheduledTime}");
                remoteControl.ExecuteCommand(appliance.ScheduleOn ? new TurnOnCommand(appliance) : new TurnOffCommand(appliance));

                scheduleHistory.Add(scheduledTimeSpan);
            }
        }
    }
}
