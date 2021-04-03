using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Che : Piece
{
    public override List<Vector2Int> MoveLocations(Vector2Int gridPoint)
    {
        List<Vector2Int> locations = new List<Vector2Int>();

        foreach (Vector2Int dir in RowcolDirections)
        {
            for (int i = 1; i < 10; i++)
            {
                Vector2Int nextGridPoint = Geometry.GridPoint(gridPoint.x + i * dir.x, gridPoint.y + i * dir.y);
                locations.Add(nextGridPoint);
                if (ChessManager.instance.PieceAtGrid(nextGridPoint))
                {
                    break;
                }
            }
        }


        return locations;
    }
}
