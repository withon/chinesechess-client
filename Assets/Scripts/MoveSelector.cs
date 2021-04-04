using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSelector : MonoBehaviour
{
    private MoveSelectorHandler mshSp;
    private MoveSelectorHandler mshRp;
    private MoveSelectorHandler mshMp;
    private MoveSelectorHandler mshCp;
    private MoveSelectorHandler mshDp;

    private GameObject selectedPiece;


    // Start is called before the first frame update
    void Start()
    {
        mshSp = new SelectPiece();

        mshRp = new ReselectPiece();
        mshSp.SetNextHandler(mshRp);

        mshMp = new MovePiece();
        mshRp.SetNextHandler(mshMp);

        mshCp = new CapturePiece();
        mshMp.SetNextHandler(mshCp);

        mshDp = new DeselectPiece();
        mshCp.SetNextHandler(mshDp);

        selectedPiece = null;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                Vector2Int gridPoint = Geometry.GridFromPoint(hit.point);
                selectedPiece = mshSp.process(gridPoint, selectedPiece);
            }
        }
    }

}

abstract class MoveSelectorHandler
{
    protected MoveSelectorHandler nextHandler;
    public void SetNextHandler(MoveSelectorHandler nextHandler)
    {
        this.nextHandler = nextHandler;
    }
    public abstract GameObject process(Vector2Int gridPoint, GameObject selectedPiece);
}

class SelectPiece : MoveSelectorHandler
{
    public override GameObject process(Vector2Int gridPoint, GameObject selectedPiece)
    {
        if (!selectedPiece && ChessManager.instance.currentPlayer.pieces.Contains(ChessManager.instance.PieceAtGrid(gridPoint)))
        {
            selectedPiece = ChessManager.instance.PieceAtGrid(gridPoint);
            if (selectedPiece)
            {
                ChessManager.instance.SelectPiece(selectedPiece);
                return selectedPiece;
            }
            else
            {
                return null;
            }
        }
        else
        {
            return nextHandler.process(gridPoint, selectedPiece);
        }
    }
}

class ReselectPiece : MoveSelectorHandler
{
    public override GameObject process(Vector2Int gridPoint, GameObject selectedPiece)
    {
        if (selectedPiece && selectedPiece != ChessManager.instance.PieceAtGrid(gridPoint) && ChessManager.instance.currentPlayer.pieces.Contains(ChessManager.instance.PieceAtGrid(gridPoint)))
        {
            ChessManager.instance.DeselectPiece(selectedPiece);
            selectedPiece = ChessManager.instance.PieceAtGrid(gridPoint);
            if (selectedPiece)
            {
                ChessManager.instance.SelectPiece(selectedPiece);
                return selectedPiece;
            }
            else
            {
                return null;
            }
        }
        else
        {
            return nextHandler.process(gridPoint, selectedPiece);
        }
    }
}

class MovePiece : MoveSelectorHandler
{
    public override GameObject process(Vector2Int gridPoint, GameObject selectedPiece)
    {
        if (selectedPiece && ChessManager.instance.MovesForPiece(selectedPiece).Contains(gridPoint) && !ChessManager.instance.otherPlayer.pieces.Contains(ChessManager.instance.PieceAtGrid(gridPoint)))
        {
            ChessManager.instance.Move(selectedPiece, gridPoint);
            return null;
        }
        else
        {
            return nextHandler.process(gridPoint, selectedPiece);
        }
    }
}

class CapturePiece : MoveSelectorHandler
{
    public override GameObject process(Vector2Int gridPoint, GameObject selectedPiece)
    {
        if (selectedPiece && ChessManager.instance.MovesForPiece(selectedPiece).Contains(gridPoint) && ChessManager.instance.otherPlayer.pieces.Contains(ChessManager.instance.PieceAtGrid(gridPoint)))
        {
            ChessManager.instance.CapturePieceAt(gridPoint);
            ChessManager.instance.Move(selectedPiece, gridPoint);
            return null;
        }
        else
        {
            return nextHandler.process(gridPoint, selectedPiece);
        }
    }
}

class DeselectPiece : MoveSelectorHandler
{
    public override GameObject process(Vector2Int gridPoint, GameObject selectedPiece)
    {
        if (selectedPiece && selectedPiece == ChessManager.instance.PieceAtGrid(gridPoint))
        {
            ChessManager.instance.DeselectPiece(selectedPiece);
            return null;
        }
        else
        {
            return selectedPiece;
        }
    }
}