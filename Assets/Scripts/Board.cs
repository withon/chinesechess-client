using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject r_box_current;
    public GameObject r_box_last;
    public GameObject dot;



    public GameObject AddPiece(GameObject piece, int col, int row)
    {
        Vector2Int gridPoint = Geometry.GridPoint(col, row);
        GameObject newPiece = Instantiate(piece, Geometry.PointFromGrid(gridPoint), Quaternion.identity, gameObject.transform);
        return newPiece;
    }

    public void RemovePiece(GameObject piece)
    {
        Destroy(piece);
    }

    public void MovePiece(GameObject piece, Vector2Int gridPoint)
    {
        piece.transform.position = Geometry.PointFromGrid(gridPoint);
    }

    public void SelectPiece(GameObject piece)
    {
        piece.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0.7f); 
    }

    public void DeselectPiece(GameObject piece)
    {
        piece.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
    }
}
