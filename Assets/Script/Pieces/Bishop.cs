using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : Piece
{
    public void OnMouseDown()
    {
        ((Piece)this).board.pieceSelected = this.gameObject;
        ((Piece)this).board.CleanBoard();
        ShowMoves();
    }

    public void ShowMoves()
    {
        for (int x = ((Piece)this).x + 1, y = ((Piece)this).y + 1; x <= 8; x++, y++)
        {
            if (EndMark(x, y))
                break;
        }
        for (int x = ((Piece)this).x + 1, y = ((Piece)this).y - 1; x <= 8; x++, y--)
        {
            if (EndMark(x, y))
                break;
        }
        for (int x = ((Piece)this).x - 1, y = ((Piece)this).y + 1; x > 0; x--, y++)
        {
            if (EndMark(x, y))
                break;
        }
        for (int x = ((Piece)this).x - 1, y = ((Piece)this).y - 1; x > 0; x--, y--)
        {
            if (EndMark(x, y))
                break;
        }
    }
}
