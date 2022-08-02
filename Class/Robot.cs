﻿using SRV.Enums;
using SRV.RobotInstructions;

namespace SRV.Class;

public class Robot
{

    public int X
    {
        get; set;
    }
    public int Y
    {
        get; set;
    }
    public Orientation Orientation
    {
        get; set;
    }
    public bool IsLost
    {
        get; set;
    }
    private readonly Mars mars;

    public Robot(int x, int y, Orientation orientation, Mars mars)
    {
        X = x;
        Y = y;
        Orientation = orientation;
        this.mars = mars;
    }

    public void ExecuteCommand(Command command)
    {
        if (!IsLost)
        {
            switch (command)
            {
                case Command.forward:
                    CautiouslyMoveFoward();
                    break;
                case Command.right:
                    RotateClockwise();
                    break;
                case Command.left:
                    RotateCounterclockwise();
                    break;
                default:
                    throw new ArgumentException("No recognized");
            }
        }
    }

    private void CautiouslyMoveFoward()
    {
        var nextPosition = NextPositionIfMovedForward();

        if (OutOfGrid(nextPosition.x, nextPosition.y))
        {
            if (!mars.IsScented(X, Y))
            {
                IsLost = true;
                mars.AddCordinates(X, Y);
            }
            //ignore command if it is scented
        }
        else
        {
            X = nextPosition.x;
            Y = nextPosition.y;
        }
    }

    private void RotateClockwise()
    {
        if (Orientation == Orientation.west)
        {
            Orientation = Orientation.north;
        }
        else
        {
            Orientation++;
        }
    }

    private void RotateCounterclockwise()
    {
        if (Orientation == Orientation.north)
        {
            Orientation = Orientation.west;
        }
        else
        {
            Orientation--;
        }
    }

    private Coordinate NextPositionIfMovedForward()
    {
        var nextPosition = new Coordinate(X, Y);

        // I know that for one line, you do not need braces,
        // but is a good practice

        if (Orientation == Orientation.north)
        {
            nextPosition.y++;
        }
        else if (Orientation == Orientation.east)
        {
            nextPosition.x++;
        }
        else if (Orientation == Orientation.south)
        {
            nextPosition.y--;
        }
        else if (Orientation == Orientation.west)
        {
            nextPosition.x--;
        }

        return nextPosition;
    }

    private bool OutOfGrid(int x, int y)
    {
        return x > mars.xbound || x < 0 || y > mars.yBound || y < 0;
    }
}