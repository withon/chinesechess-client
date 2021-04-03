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
            Geometry.GridPoint(gridPoint.x, gridPoint.y + 1),
            Geometry.GridPoint(gridPoint.x, gridPoint.y - 1)
        };
        locations.RemoveAll(gp => gp.x < 3 || gp.x > 5 || (gp.y > 2 && gp.y < 7));
        for (int i = 0; i < 10; i++)
        {
            Vector2Int nextGridPoint = new Vector2Int(gridPoint.x, gridPoint.y + i);
            if (ChessManager.instance.PieceAtGrid(gridPoint))
            {
                if (ChessManager.instance.PieceAtGrid(gridPoint).GetComponent<Piece>().type == PieceType.Jiang)
                {
                    locations.Add(gridPoint);
                }
                break;
            }
        }
        for (int i = 0; i < 10; i++)
        {
            Vector2Int nextGridPoint = new Vector2Int(gridPoint.x, gridPoint.y - i);
            if (ChessManager.instance.PieceAtGrid(gridPoint))
            {
                if (ChessManager.instance.PieceAtGrid(gridPoint).GetComponent<Piece>().type == PieceType.Jiang)
                {
                    locations.Add(gridPoint);
                }
                break;
            }
        }
        return locations;
    }
}
