Console.Title = "Countdown";

CountDown(10);

/// <summary>
/// Counts down from 10 to 1
/// </summary>
void CountDown(int number)
{
    if (number < 1)
        return;
    Console.WriteLine(number);
    CountDown(number - 1);
}
