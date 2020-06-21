using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King :Piece
{
    public void OnMouseDown()
    {
        board.pieceSelected = this.gameObject;
        board.TargetHouse();
        board.CleanBoardKing();
        ShowMoves();
    }

    public void ShowMoves()
    {
        if (board.checkHousesKing(x + 1, y) == true)
        {
            print(board.checkHousesKing(x + 1, y) + "asdasdasd");
            EndMark(x + 1, y);
        }
        if (board.checkHousesKing(x + 1, y + 1))
            EndMark(x + 1, y + 1);
        if (board.checkHousesKing(x, y + 1))
            EndMark(x, y + 1);
        if (board.checkHousesKing(x - 1, y + 1))
            EndMark(x - 1, y + 1);
        if (board.checkHousesKing(x - 1, y))
            EndMark(x - 1, y);
        if (board.checkHousesKing(x - 1, y - 1))
            EndMark(x - 1, y - 1);
        if (board.checkHousesKing(x, y - 1))
            EndMark(x, y - 1);
        if (board.checkHousesKing(x + 1, y - 1))
            EndMark(x + 1, y - 1);
    }

}
