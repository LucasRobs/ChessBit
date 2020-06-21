using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class Piece : MonoBehaviour
{
    public int id;
    public Home onHome;
    private Vector3 lastTransform;
    public Board board;
    public string tiem;
    public bool markedPiece;
    public bool fistMove = true;
    public int x, y;

    public void Start()
    {
        AlocarPeca();
        board = GameObject.Find("Board").GetComponent<Board>();
        InitPos();
    }

    void InitPos()
    {
        int aux = Int32.Parse(this.name);
        x = aux / 10;
        y = aux % 10;
    }

    public void AlocarPeca()
    {
        onHome = GameObject.Find(this.name).GetComponent<Home>();
        transform.position = onHome.transform.position;
        lastTransform = transform.position;
        transform.SetParent(onHome.transform);
        onHome.havePiece = true;
    }

    public void marcarPeca()
    {
        Piece[] piece = FindObjectsOfType<Piece>();
        for (int i = 0; i < piece.Length; i++)
        {
            if (piece[i].markedPiece == true)
            {
                markedPiece = false;
            }
        }
        markedPiece = true;
    }

    public bool EndMark(int x, int y)
    {
        int aux = board.checkHouses(this.gameObject, x, y);
        if (aux == 0 || aux == 2)
        {
            return true;
        }else if(aux == -1)
        {
            board.MarckHouse(x, y, aux);
            return true;
        }
        board.MarckHouse(x, y, aux);
        return false;
    }

    public void SetColliderPiece(bool set)
    {
        this.GetComponent<BoxCollider2D>().enabled = set;
    }

   
}
