using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Piece
{
    public void OnMouseDown()
    {
        ((Piece)this).board.pieceSelected = this.gameObject;
        ((Piece)this).board.CleanBoard();
        ShowMoves();
    }

    public void ShowMoves()
    {
        EndMark(((Piece)this).x + 2, ((Piece)this).y + 1);
        EndMark(((Piece)this).x + 2, ((Piece)this).y - 1);
        EndMark(((Piece)this).x - 2, ((Piece)this).y + 1);
        EndMark(((Piece)this).x - 2, ((Piece)this).y - 1);
        EndMark(((Piece)this).x + 1, ((Piece)this).y + 2);
        EndMark(((Piece)this).x - 1, ((Piece)this).y + 2);
        EndMark(((Piece)this).x + 1, ((Piece)this).y - 2);
        EndMark(((Piece)this).x - 1, ((Piece)this).y - 2);
    }
}
