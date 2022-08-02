using System.Text;

using SRV.Class;
using SRV.Enums;
using SRV.RobotInstructions;

namespace SRV;
internal class Program
{
    static void Main(string[] args)
    {
        var input = UserInput.GetInput();
        List<Robot> robots;
        List<List<Command>> commands;
        UserInput.GetRobotAndConmnds(input, out robots,
                       out commands);

        var Station = new Station(robots);
        var maxRobots = Station.robots.Count;
        for (var i = 0; i < maxRobots; ++i)
        {
            Station.TransmitCommands(i, commands[i]);
        }

        var robotReport = ScreenHelper.GetRobotReport(robots);
        Console.Write(robotReport);

        Console.Write("Press any key to exit...");
        Console.ReadKey();
    }
}

internal class ScreenHelper
{
    public static string GetRobotReport(List<Robot> robots)
    {
        var s = new StringBuilder();

        foreach (var robot in robots)
        {
            var line = $"{robot.X} {robot.Y} {GetOrientation(robot.Orientation)}";
            if (robot.IsLost)
                line += " LOST";
            s.AppendLine(line);
        }

        return s.ToString();
    }

    private static char GetOrientation(Orientation orientation)
    {
        switch (orientation)
        {
            case Orientation.north:
                return 'N';
            case Orientation.south:
                return 'S';
            case Orientation.east:
                return 'E';
            case Orientation.west:
                return 'W';
            default:
                throw new ArgumentException($"orientation {orientation} has no defined char equivalent");
        }
    }
}