using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Piece
{
    public void OnMouseDown()
    {
        ((Piece)this).board.pieceSelected = this.gameObject;
        ((Piece)this).board.CleanBoard();
        ShowMoves();
    }

    public void ShowMoves()
    {
        for (int x = ((Piece)this).x + 1; x <= 8; x++)
        {
            print(x +""+ y);
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