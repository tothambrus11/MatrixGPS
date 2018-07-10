using System;

public class Map
{
    private Boolean[,] map;
    public Size2D size;
    /**
     * Constructor of the Map class
     */
	public Map(Boolean[,] map)
	{
        this.map = map;
        this.size = new Size2D(map.GetLength(0), map.GetLength(1));
	}

    public Boolean getField(int x, int y)
    {
        if(x < 0 || y < 0 || x > size.width || y > size.height)
        {
            return false;
        }
        return map[x, y];
    }

}
