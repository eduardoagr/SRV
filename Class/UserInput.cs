using System.Text;

using SRV.Enums;
using SRV.RobotInstructions;

namespace SRV.Class;

/* I could put all of this code, in my Program,
 * but if I do that it will get to messy.
 */
public class UserInput
{
    public static string GetInput()
    {
        //By doing this, we can save time-complexity
        var userInput = new StringBuilder();
        Console.WriteLine("Por favor, ponga todo en líneas separadas");
        string? line;
        do
        {
            line = Console.ReadLine();
            if (!string.IsNullOrEmpty(line))
            {
                userInput.AppendLine(line);
            }
        } while (line != null);
        return userInput.ToString();
    }

    // I always like to see everything, without the necessity of scrolling
    public static void GetRobotAndConmnds(string input, out List<Robot> robots,
                                          out List<List<Command>> commandSequences)
    {
        var lines = input.Split(new string[]
        { Environment.NewLine },
        StringSplitOptions.None);

        robots = new List<Robot>();
        commandSequences = new List<List<Command>>();

        var mars = ParseInput(lines.First());

        var maxLines = lines.Count() - 1;

        /* We made two improvements here
         * 
         * 1. By creasing a variable, we do not have to recalculate
         * 
         * 2. Using ++i will increase our i intermediately
         */

        for (var i = 0; i < maxLines; ++i)
        {
            if (i % 2 == 0)
            {
                commandSequences.Add(ParseCommands(lines[i]));
            }
            else
            {
                robots.Add(ParseRobot(lines[i], mars));
            }
        }
    }

    public static List<Command> ParseCommands(string commands)
    {
        var Sequence = new List<Command>();

        foreach (var character in commands)
        {
            Sequence.Add(GetCommand(character));
        }

        return Sequence;
    }

    private static Command GetCommand(char character)
    {
        return character switch
        {
            'F' => Command.forward,
            'R' => Command.right,
            'L' => Command.left,
            _ => throw new ArgumentException("No recognized"),
        };
    }

    public static Robot ParseRobot(string robot, Mars mars)
    {
        var inputs = robot.Split(' ');
        var x = int.Parse(inputs[0]);
        var y = int.Parse(inputs[1]);
        var orientation = GetOrientation(inputs[2]);
        return new Robot(x,y,orientation,mars);
    }

    private static Orientation GetOrientation(string o)
    {
        return o switch
        {
            "N" => Orientation.north,
            "E" => Orientation.east,
            "S" => Orientation.south,
            "W" => Orientation.west,
            _ => throw new ArgumentException("No recognized"),
        };
    }

    private static Mars ParseInput(string str)
    {
        // 3 2
        // 30 30

        var inputs = str.Split(' ');
        var xBound = int.Parse(inputs[0]);
        var yBound = int.Parse(inputs[1]);
        return new Mars(xBound, yBound);
    }
}
