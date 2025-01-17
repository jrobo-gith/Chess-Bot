using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class master : MonoBehaviour
{
    public ChessBoard chessBoard;
    public RenderPieces renderPieces;

    void Start()
    {
        Debug.Log("Reached Master Script!");
        chessBoard.DrawChessBoard();
        renderPieces.DrawPieces();
        renderPieces.loadStartingPos();
    }

    void Update()
    {
        
    }
}
