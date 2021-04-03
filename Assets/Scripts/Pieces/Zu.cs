using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zu : Piece
{
    public override List<Vector2Int> MoveLocations(Vector2Int gridPoint)
    {
        List<Vector2Int> locations = new List<Vector2Int>();

        if(ChessManager.instance.currentPlayer.forward == 1)
        {
            locations.Add(new Vector2Int(gridPoint.x, gridPoint.y + 1));
            if(gridPoint.y > 4)
            {
                locations.Add(new Vector2Int(gridPoint.x - 1, gridPoint.y));
                locations.Add(new Vector2Int(gridPoint.x + 1, gridPoint.y));
            }
        }
        else
        {
            locations.Add(new Vector2Int(gridPoint.x, gridPoint.y - 1));
            if (gridPoint.y < 5)
            {
                locations.Add(new Vector2Int(gridPoint.x - 1, gridPoint.y));
                locations.Add(new Vector2Int(gridPoint.x + 1, gridPoint.y));
            }
        }


        return locations;
    }
}
