using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xiang : Piece
{
    public override List<Vector2Int> MoveLocations(Vector2Int gridPoint)
    {
        List<Vector2Int> locations = new List<Vector2Int>
        {
            new Vector2Int(gridPoint.x + 2, gridPoint.y + 2),
            new Vector2Int(gridPoint.x + 2, gridPoint.y - 2),
            new Vector2Int(gridPoint.x - 2, gridPoint.y + 2),
            new Vector2Int(gridPoint.x - 2, gridPoint.y - 2)
        };

        if (ChessManager.instance.currentPlayer.forward == 1)
        {
            locations.RemoveAll(gp => gp.y > 4);
        }
        else
        {
            locations.RemoveAll(gp => gp.y < 5);
        }

        locations.RemoveAll(gp => ChessManager.instance.PieceAtGrid(new Vector2Int((gp.x + gridPoint.x) / 2, (gp.y + gridPoint.y) / 2)));


        return locations;
    }
}
