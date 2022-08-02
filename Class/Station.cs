
using SRV.RobotInstructions;

namespace SRV.Class;

/* From here, we can send instructions to our robots.
 * To make this easier, I created an enumeration (Enum),
 * that contains the instructions we can send to our robots.
 * 
 * Is important to remember, that we could have multiple robots
 */

public class Station
{
    public List<Robot> robots
    {
        get; set;
    }

    public Station(List<Robot> robots)
    {
        this.robots = robots;
    }

    //Sending the command to the robot.
    public void TransmitCommands(int robotIndex, List<Command> sequence)
    {
        foreach (var command in sequence)
        {
            robots[robotIndex].ExecuteCommand(command);

        }
    }
}
