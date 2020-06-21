using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn :Piece
{
    public void OnMouseDown()
    {
        ((Piece)this).board.pieceSelected = this.gameObject;
        ((Piece)this).board.CleanBoard();
        ShowMoves();
    }

    public void ShowMoves()
    {
        int dir = 1;
        if (((Piece)this).tiem == "black")
            dir *= -1;
        if ((((Piece)this).board.checkHouses(this.gameObject, x + dir, y) == 1))
        {
            EndMark(x + dir, y);
            if (((Piece)this).fistMove)
            {
                EndMark(x + dir * 2, y);
                ((Piece)this).fistMove = false;
            }
        }

        if (((Piece)this).board.checkHouses(this.gameObject, x + dir, y + dir) == -1)
            EndMark(x + dir, y + dir);
        if (((Piece)this).board.checkHouses(this.gameObject, x + dir, y - dir) == -1)
            EndMark(x + dir, y - dir);
    }
    public void ShowMovesKing()
    {
        int dir = 1;
        if (((Piece)this).tiem == "black")
            dir *= -1;
        EndMark(x + dir, y + dir);
        EndMark(x + dir, y - dir);
    }
}
