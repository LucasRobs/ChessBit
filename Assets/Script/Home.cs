using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Home : MonoBehaviour
{
    public Board board;
    public string color;
    public bool havePiece;
    public bool target;
    public bool checkedHouse;
    public int x;
    public int y;
   
    public void Start()
    {
        board = FindObjectOfType<Board>();
        InitPos();
    }

    void InitPos()
    {
        int aux = Int32.Parse(this.gameObject.name);
        x = aux / 10;
        y = aux % 10;
    }

    public void OnMouseDown()
    {
        if(checkedHouse)
        {
            TreatOldHouse();
            MuvePiece();
        }
        board.CleanBoard();
    }

    public void TreatOldHouse()
    {
        Home OldHouse = board.pieceSelected.GetComponent<Piece>().onHome;
        OldHouse.havePiece = false;
    }

    public void MuvePiece()
    {
        GameObject selectedPiede = board.pieceSelected;
        selectedPiede.transform.position = this.transform.position;
        selectedPiede.GetComponent<Piece>().x = x;
        selectedPiede.GetComponent<Piece>().y = y;
        selectedPiede.GetComponent<Piece>().onHome = this;
        selectedPiede.name = this.gameObject.name;
        selectedPiede.transform.SetParent(this.transform);
        this.havePiece = true;
        board.setTurn();
    }
}
