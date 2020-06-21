using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board :MonoBehaviour
{
    public GameObject pHome; //PrefabCasa
    public GameObject pPiece;
    public GameObject pieceSelected;
    public GameObject[] homes = new GameObject[64];
    public Piece[] piecesWhite = new Piece[16];
    public Piece[] piecesBlack = new Piece[16];
    public Color[] colorHome;
    public Color[] colorMarking;
    public bool tabuMacado;
    public bool turn;
    public bool marcando;

    void Awake()
    {
        GenerateHomeAndPiece();
    }

    private void Start()
    {
        setTurn();
    }

    public void setTurn()
    {
        for (int i = 0; i < 16; i++)
        {
            piecesWhite[i].SetColliderPiece(false);
            piecesBlack[i].SetColliderPiece(false);
        }
        if (turn == true)
            for (int i = 0; i < 16; i++)
                piecesBlack[i].SetColliderPiece(true);
        else
            for (int i = 0; i < 16; i++)
                piecesWhite[i].SetColliderPiece(true);
        turn = !turn;
    }


    public void TargetHouse()
    {

        if (turn == true)
            for (int i = 0; i < 16; i++)
                ReturnScript(piecesBlack[i].gameObject, piecesBlack[i].id);
        else
            for (int i = 0; i < 16; i++)
                ReturnScript(piecesWhite[i].gameObject, piecesWhite[i].id);
    }

    public void ReturnScript(GameObject piece, int type)
    {
        /*# 1 = pawn # 2 = Rook # 3 = knight # 4 = Bishop # 5 = Queen # 6 = King #*/
        switch (type)
        {
            case 1:
            piece.GetComponent<Pawn>().ShowMovesKing();
            break;
            case 2:
            piece.GetComponent<Rook>().ShowMoves();
            break;
            case 3:
            piece.GetComponent<Knight>().ShowMoves();
            break;
            case 4:
            piece.GetComponent<Bishop>().ShowMoves();
            break;
            case 5:
            piece.GetComponent<Queen>().ShowMoves();
            break;
            case 6:
            piece.GetComponent<King>().ShowMoves();
            break;
        }

    }

    public void GenerateHomeAndPiece()
    {
        bool color = false;
        int aux = 0;
        for (int x = 1; x <= 8; x++)
        {
            for (int y = 1; y <= 8; y++)
            {
                if (color == true)
                {
                    pHome.GetComponent<Home>().color = "white";
                    pHome.GetComponent<SpriteRenderer>().color = colorHome[0];
                } else
                {
                    pHome.GetComponent<Home>().color = "black";
                    pHome.GetComponent<SpriteRenderer>().color = colorHome[1];
                }
                homes[aux] = Instantiate(pHome, new Vector2(y * 0.18f, x * 0.18f), transform.rotation, this.gameObject.transform);
                homes[aux].GetComponent<Home>().name = x + "" + y;
                color = !color;
                aux++;

            }
            color = !color;
        }
        Instantiate(pPiece, transform.position, transform.rotation);
        SeparatePieces();
    }

    protected void SeparatePieces()
    {
        Piece[] pieces = FindObjectsOfType<Piece>();
        int auxW = 0, auxB = 0;
        for (int i = 0; i < pieces.Length; i++)
        {
            if (pieces[i].tiem == "white")
            {
                piecesWhite[auxW] = pieces[i];
                auxW++;
            } else
            {
                piecesBlack[auxB] = pieces[i];
                auxB++;
            }
        }
    }

    public int checkHouses(GameObject piece, int x, int y)
    {
        /***
         * retornos
         * 0  == msm time
         * -1 == time inimigo
         * 1  == casa livre
         * 2  == casa não existe
         ***/
        if (x > 8 || x < 1 || y > 8 || y < 1)
            return 2;
        if (homes[NormalPos(x, y)].GetComponent<Home>().havePiece)
        {
            if (homes[NormalPos(x, y)].GetComponentInChildren<Piece>() != null)
            {
                if (piece.GetComponent<Piece>().tiem == homes[NormalPos(x, y)].GetComponentInChildren<Piece>().tiem)
                {
                    return 0;
                }
            } else
                return 0;
            return -1;
        }
        return 1;
    }

    public bool checkHousesKing(int x, int y)
    {
        if (x > 8 || x < 1 || y > 8 || y < 1)
            return false;
        if (homes[NormalPos(x, y)].GetComponent<Home>().target)
        {
            print(x + " falo " + y);
            return false;

        }

        return true;
    }

    public void MarckHouse(int x, int y, int markType)
    {
        if (markType == 0)
        {
            homes[NormalPos(x, y)].GetComponent<Home>().target = true;
            return;
        } else if (markType == 1)
        {
            homes[NormalPos(x, y)].GetComponent<Home>().target = true;
            homes[NormalPos(x, y)].GetComponent<Home>().checkedHouse = true;
            if (homes[NormalPos(x, y)].GetComponent<Home>().color == "white")
                homes[NormalPos(x, y)].GetComponent<SpriteRenderer>().color = colorMarking[0];
            else
                homes[NormalPos(x, y)].GetComponent<SpriteRenderer>().color = colorMarking[1];
            return;
        } else
        {
            homes[NormalPos(x, y)].GetComponent<SpriteRenderer>().color = colorMarking[2];
        }
        homes[NormalPos(x, y)].GetComponent<Home>().target = true;
    }

    private int NormalPos(int x, int y)
    {
        return y + (x * 8 - 9);
    }

    public void CleanBoard()
    {
        bool color = false;
        int aux = 0;
        for (int x = 1; x <= 8; x++)
        {
            for (int y = 1; y <= 8; y++)
            {
                if (color == true)
                {
                    homes[aux].GetComponent<SpriteRenderer>().color = colorHome[0];
                } else
                {
                    homes[aux].GetComponent<SpriteRenderer>().color = colorHome[1];
                }
                homes[aux].GetComponent<Home>().checkedHouse = false;
                homes[aux].GetComponent<Home>().target = false;
                color = !color;
                aux++;

            }
            color = !color;
        }
    }

    public void CleanBoardKing()
    {
        bool color = false;
        int aux = 0;
        for (int x = 1; x <= 8; x++)
        {
            for (int y = 1; y <= 8; y++)
            {
                if (color == true)
                {
                    homes[aux].GetComponent<SpriteRenderer>().color = colorHome[0];
                } else
                {
                    homes[aux].GetComponent<SpriteRenderer>().color = colorHome[1];
                }
                homes[aux].GetComponent<Home>().checkedHouse = false;
                color = !color;
                aux++;

            }
            color = !color;
        }
    }
}
