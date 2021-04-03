using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ma : Piece
{
    public override List<Vector2Int> MoveLocations(Vector2Int gridPoint)
    {
        List<Vector2Int> locations = new List<Vector2Int>();
        if (!ChessManager.instance.PieceAtGrid(new Vector2Int(gridPoint.x, gridPoint.y + 1)))
        {
            locations.Add(new Vector2Int(gridPoint.x + 1, gridPoint.y + 2));
            locations.Add(new Vector2Int(gridPoint.x - 1, gridPoint.y + 2));
        }
        if (!ChessManager.instance.PieceAtGrid(new Vector2Int(gridPoint.x, gridPoint.y - 1)))
        {
            locations.Add(new Vector2Int(gridPoint.x + 1, gridPoint.y - 2));
            locations.Add(new Vector2Int(gridPoint.x - 1, gridPoint.y - 2));
        }
        if (!ChessManager.instance.PieceAtGrid(new Vector2Int(gridPoint.x + 1, gridPoint.y)))
        {
            locations.Add(new Vector2Int(gridPoint.x + 2, gridPoint.y + 1));
            locations.Add(new Vector2Int(gridPoint.x + 2, gridPoint.y - 1));
        }
        if (!ChessManager.instance.PieceAtGrid(new Vector2Int(gridPoint.x - 1, gridPoint.y)))
        {
            locations.Add(new Vector2Int(gridPoint.x - 2, gridPoint.y + 1));
            locations.Add(new Vector2Int(gridPoint.x - 2, gridPoint.y - 1));
        }

        return locations;
    }
}
