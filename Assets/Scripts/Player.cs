using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public List<GameObject> pieces;
    public List<GameObject> capturedPieces;

    public string name;
    public int forward;
    public Player(string name, bool positiveYMovement)
    {
        this.name = name;
        pieces = new List<GameObject>();
        if (positiveYMovement == true)
        {
            this.forward = 1;
        }
        else
        {
            this.forward = -1;
        }
    }
}
