// See https://aka.ms/new-console-template for more information
using TimeNumericalDifferentiator;

var time = Console.ReadLine();
var split = time.Split(':');
var hours = int.Parse(split[0]);
var minutes = int.Parse(split[1]);

Console.WriteLine($"{TimeDifferential.GetClosestNumerical(hours, minutes)}");
