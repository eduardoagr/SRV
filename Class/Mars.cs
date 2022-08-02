namespace SRV.Class;

/* This is the class, that will construct our grid.
 * Also we should keep attention to our X, and Y bounds
 */

public class Mars
{
    public int xBound
    {
        get; set;
    }
    public int yBound
    {
        get; set;
    }

    private readonly List<Coordinate> coordinates = new();
    internal int xbound;

    public Mars(int xbound, int yBound)
    {
        xBound = xbound;
        this.yBound = yBound;
    }

    public void AddCordinates(int x, int y)
    {
        coordinates.Add(new Coordinate(x, y));
    }

    /* Now that we created our grid, we need a method, 
     * that will keep tract of the scent our robot leaves.
     */
    public bool IsScented(int x, int y)
    {
        return coordinates.Contains(new Coordinate(x, y));
    }
}
