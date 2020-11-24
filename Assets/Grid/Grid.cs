using UnityEngine;

public class Grid
{

    private int _Width;

    private int _Height;
    private int _CellSize;
    private int[,] _Grid;

    public int width => _Width;
    public int height => _Height;
    public int[,] grid => _Grid;

    public Grid(int width, int height, int cellSize)
    {
        _Width = width;
        _Height = height;
        _CellSize = cellSize;
        
        _Grid = new int[_Width, _Height];
    }

    public Vector3 GetWorldPosition(int x, int z)
    {
        return new Vector3(x, 0, z) * _CellSize;
    }
}
