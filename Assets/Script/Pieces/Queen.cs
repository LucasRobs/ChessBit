using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : Piece
{
    public void OnMouseDown()
    {
        ((Piece)this).board.pieceSelected = this.gameObject;
        ((Piece)this).board.CleanBoard();
        ShowMoves();
    }

    public void ShowMoves()
    {
        //x
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

        //+
        for (int x = ((Piece)this).x + 1; x <= 8; x++)
        {
            print(x + "" + y);
            if (EndMark(x, ((Piece)this).y))
            {
                break;
            };
        }
        for (int x = ((Piece)this).x - 1; x > 0; x--)
        {
            if (EndMark(x, ((Piece)this).y))
            {
                break;
            };
        }
        for (int y = ((Piece)this).y + 1; y <= 8; y++)
        {
            if (EndMark(((Piece)this).x, y))
            {
                break;
            };
        }
        for (int y = ((Piece)this).y - 1; y > 0; y--)
        {
            if (EndMark(((Piece)this).x, y))
            {
                break;
            };
        }
    }
}
