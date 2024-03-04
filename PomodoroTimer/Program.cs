using System;
using System.Threading;

class PomodoroTimer
{
    private int workDurationMinutes;
    private int breakDurationMinutes;

    public PomodoroTimer(int workMinutes, int breakMinutes)
    {
        workDurationMinutes = workMinutes;
        breakDurationMinutes = breakMinutes;
    }

    public void StartPomodoro()
    {
        Console.WriteLine("Pomodoro Started!");

        Work();  // Encapsulation: Internal details are hidden inside the Work method

        Console.WriteLine("Time for a break!");
        Beep();  // Beep when work duration is completed
        Thread.Sleep(1000);  // Simulating a short pause
        Break();  // Encapsulation: Internal details are hidden inside the Break method

        Console.WriteLine("Pomodoro Completed!");
    }

    private void Work()
    {
        Timer(workDurationMinutes, "Working");
        Beep();  // Beep when work duration is completed
    }

    private void Break()
    {
        Timer(breakDurationMinutes, "Taking a break");
        Beep();  // Beep when break duration is completed
    }

    private void Timer(int durationMinutes, string activity)
    {
        int durationSeconds = durationMinutes * 60;
        for (int seconds = durationSeconds; seconds > 0; seconds--)
        {
            Console.Clear();
            Console.WriteLine($"{activity} - Time remaining: {seconds / 60} minutes {seconds % 60} seconds");
            Thread.Sleep(1000);
        }
    }

    private void Beep()
    {
        Console.Beep();  // Beep sound
    }
}

class Program
{
    static void Main()
    {
        PomodoroTimer pomodoroTimer = new PomodoroTimer(workMinutes: 25, breakMinutes: 5);  // Reduced durations for testing
        pomodoroTimer.StartPomodoro();
    }
}