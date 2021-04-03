using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessManager : MonoBehaviour
{
    public static ChessManager instance;
    public Board board;

    private GameObject[,] pieces;
    private Player red;
    private Player black;
    public Player currentPlayer;
    public Player otherPlayer;

    public GameObject b_j;
    public GameObject b_s;
    public GameObject b_x;
    public GameObject b_m;
    public GameObject b_c;
    public GameObject b_p;
    public GameObject b_z;

    public GameObject r_j;
    public GameObject r_s;
    public GameObject r_x;
    public GameObject r_m;
    public GameObject r_c;
    public GameObject r_p;
    public GameObject r_z;



    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        pieces = new GameObject[9, 10];

        red = new Player("red", true);
        black = new Player("black", false);

        currentPlayer = red;
        otherPlayer = black;

        InitialSetup();
        
    }

    private void InitialSetup()
    {
        AddPiece(r_c, red, 0, 0);
        AddPiece(r_m, red, 1, 0);
        AddPiece(r_x, red, 2, 0);
        AddPiece(r_s, red, 3, 0);
        AddPiece(r_j, red, 4, 0);
        AddPiece(r_s, red, 5, 0);
        AddPiece(r_x, red, 6, 0);
        AddPiece(r_m, red, 7, 0);
        AddPiece(r_c, red, 8, 0);
        AddPiece(r_p, red, 1, 2);
        AddPiece(r_p, red, 7, 2);
        AddPiece(r_z, red, 0, 3);
        AddPiece(r_z, red, 2, 3);
        AddPiece(r_z, red, 4, 3);
        AddPiece(r_z, red, 6, 3);
        AddPiece(r_z, red, 8, 3);

        AddPiece(b_c, black, 0, 9);
        AddPiece(b_m, black, 1, 9);
        AddPiece(b_x, black, 2, 9);
        AddPiece(b_s, black, 3, 9);
        AddPiece(b_j, black, 4, 9);
        AddPiece(b_s, black, 5, 9);
        AddPiece(b_x, black, 6, 9);
        AddPiece(b_m, black, 7, 9);
        AddPiece(b_c, black, 8, 9);
        AddPiece(b_p, black, 1, 7);
        AddPiece(b_p, black, 7, 7);
        AddPiece(b_z, black, 0, 6);
        AddPiece(b_z, black, 2, 6);
        AddPiece(b_z, black, 4, 6);
        AddPiece(b_z, black, 6, 6);
        AddPiece(b_z, black, 8, 6);

    }

    private void AddPiece(GameObject prefab, Player player, int col, int row)
    {
        GameObject pieceObject = board.AddPiece(prefab, col, row);
        player.pieces.Add(pieceObject);
        pieces[col, row] = pieceObject;
    }

    public List<Vector2Int> MovesForPiece(GameObject pieceObject)
    {
        Piece piece = pieceObject.GetComponent<Piece>();
        Vector2Int gridPoint = GridForPiece(pieceObject);
        List<Vector2Int> locations = piece.MoveLocations(gridPoint);

        // filter out offboard locations
        locations.RemoveAll(gp => gp.x < 0 || gp.x > 8 || gp.y < 0 || gp.y > 9);

        // filter out locations with friendly piece
        locations.RemoveAll(gp => FriendlyPieceAt(gp));

        return locations;
    }

    public Vector2Int GridForPiece(GameObject piece)
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (pieces[i, j] == piece)
                {
                    return new Vector2Int(i, j);
                }
            }
        }

        return new Vector2Int(-1, -1);
    }

    public GameObject PieceAtGrid(Vector2Int gridPoint)
    {
        if (gridPoint.x > 8 || gridPoint.y > 9 || gridPoint.x < 0 || gridPoint.y < 0)
        {
            return null;
        }
        return pieces[gridPoint.x, gridPoint.y];
    }

    public bool FriendlyPieceAt(Vector2Int gridPoint)
    {
        GameObject piece = PieceAtGrid(gridPoint);

        if (piece == null)
        {
            return false;
        }

        if (otherPlayer.pieces.Contains(piece))
        {
            return false;
        }

        return true;
    }

    public void NextPlayer()
    {
        Player tempPlayer = currentPlayer;
        currentPlayer = otherPlayer;
        otherPlayer = tempPlayer;
    }

    public void SelectPiece(GameObject piece)
    {
        board.SelectPiece(piece);
        List<Vector2Int> locations = MovesForPiece(piece);
        foreach (Vector2Int location in locations)
        {
            board.AddDot(location);
        }
    }

    public void DeselectPiece(GameObject piece)
    {
        board.DeselectPiece(piece);
        board.DeleteDots();
    }

    public void Move(GameObject piece, Vector2Int gridPoint)
    {
        Vector2Int startGridPoint = GridForPiece(piece);
        pieces[startGridPoint.x, startGridPoint.y] = null;
        pieces[gridPoint.x, gridPoint.y] = piece;
        board.MovePiece(piece, gridPoint);
        DeselectPiece(piece);
        NextPlayer();
    }

    public void CapturePieceAt(Vector2Int gridPoint)
    {
        GameObject pieceToCapture = PieceAtGrid(gridPoint);
        if (pieceToCapture.GetComponent<Piece>().type == PieceType.Jiang)
        {
            Debug.Log(currentPlayer.name + " wins!");
        }
        //currentPlayer.capturedPieces.Add(pieceToCapture);
        pieces[gridPoint.x, gridPoint.y] = null;
        Destroy(pieceToCapture);
    }
}
