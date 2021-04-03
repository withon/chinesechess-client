using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pao : Piece
{
    public override List<Vector2Int> MoveLocations(Vector2Int gridPoint)
    {
        List<Vector2Int> locations = new List<Vector2Int>();

        foreach (Vector2Int dir in RowcolDirections)
        {
            for (int i = 1; i < 10; i++)
            {
                Vector2Int nextGridPoint = Geometry.GridPoint(gridPoint.x + i * dir.x, gridPoint.y + i * dir.y);
                if (ChessManager.instance.PieceAtGrid(nextGridPoint))
                {
                    for (int j = i + 1; j < 10; j++)
                    {
                        Vector2Int endGridPoint = Geometry.GridPoint(gridPoint.x + j * dir.x, gridPoint.y + j * dir.y);
                        if (ChessManager.instance.PieceAtGrid(endGridPoint))
                        {
                            locations.Add(endGridPoint);
                            break;
                        }
                    }
                    break;
                }
                locations.Add(nextGridPoint);
            }
        }


        return locations;
    }
}
