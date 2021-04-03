using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PieceType { Jiang, Shi, Xiang, Ma, Che, Pao, Zu };


public abstract class Piece : MonoBehaviour
{
    public PieceType type;

    protected Vector2Int[] RowcolDirections = {new Vector2Int(0,1), new Vector2Int(1, 0),
        new Vector2Int(0, -1), new Vector2Int(-1, 0)};

    public abstract List<Vector2Int> MoveLocations(Vector2Int vector2Int);

}
