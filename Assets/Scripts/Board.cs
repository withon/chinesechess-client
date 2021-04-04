using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject r_box_current;
    public GameObject r_box_last;
    public GameObject redDot;

    public List<GameObject> dots;

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

    public GameObject AddDot(Vector2Int gridPoint)
    {
        GameObject addedDot = Instantiate(redDot, Geometry.PointFromGrid(gridPoint), Quaternion.identity, gameObject.transform);
        dots.Add(addedDot);
        return addedDot;
    }

    public void DeleteDots()
    {
        foreach (GameObject dot in dots)
        {
            Destroy(dot);
        }
        dots.Clear();
    }

    public void DeselectPiece(GameObject piece)
    {
        piece.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
    }
}
