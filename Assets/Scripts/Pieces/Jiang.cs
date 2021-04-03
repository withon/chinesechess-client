using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jiang : Piece
{
    public override List<Vector2Int> MoveLocations(Vector2Int gridPoint)
    {
        List<Vector2Int> locations = new List<Vector2Int>
        {
            Geometry.GridPoint(gridPoint.x + 1, gridPoint.y),
            Geometry.GridPoint(gridPoint.x - 1, gridPoint.y),
            Geometry.GridPoint(gridPoint.x, gridPoint.y - 1),
            Geometry.GridPoint(gridPoint.x, gridPoint.y - 1)
        };

        locations.RemoveAll(gp => gp.x < 3 || gp.x > 5 || (gp.y > 2 && gp.y < 7));
        return locations;
    }
}
