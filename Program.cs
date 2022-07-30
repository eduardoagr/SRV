using SRV.Class;

namespace SRV;
internal class Program
{
    int[,]? grid;

    Robot? robot;

    char[][] inputStream = new char[][] {
            new char[] { '5', '3'},
            new char[] { '1','1','E'},
            new char[] { 'R','F','R','F','R','F','R','F' }
        };

    private static void Main(string[] args)
    {

    }

    void CreateGrid(int x, int y)
    {
        grid = new int[x, y];
    }

    void PlaceRobot(int row, int column,
        char orientation)
    {
        robot = new Robot
        {
            row = row,
            column = column,
            orientation = orientation
        };

    }

    void RobotMovement()
    {
    }

    void ParseInput()
    {
        CreateGrid(Convert.ToInt32(inputStream[0][0]),
            Convert.ToInt32(inputStream[0][1]));

        PlaceRobot(Convert.ToInt32(inputStream[1][0]),
             Convert.ToInt32(inputStream[1][1]),
            inputStream[1][2]);
    }
}