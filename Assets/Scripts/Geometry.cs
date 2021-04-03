using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geometry
{
    static float scaleFactor = 0.57125f;
    static float xFactor = -2.31f;
    static float yFactor = -2.54f;
    static public Vector3 PointFromGrid(Vector2Int gridPoint)
    {
        float x = scaleFactor * gridPoint.x + xFactor;
        float y = scaleFactor * gridPoint.y + yFactor;
        return new Vector2(x, y);
    }

    static public Vector2Int GridPoint(int col, int row)
    {
        return new Vector2Int(col, row);
    }

    static public Vector2Int GridFromPoint(Vector2 point)
    {
        int col = Mathf.FloorToInt((point.x - xFactor) / scaleFactor + 0.5f);
        int row = Mathf.FloorToInt((point.y - yFactor) / scaleFactor + 0.5f);
        return new Vector2Int(col, row);
    }
}
