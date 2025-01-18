using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class master : MonoBehaviour
{
    public ChessBoard chessBoard;
    public RenderPieces renderPieces;
    public PieceTracker pT;

    string StartingFEN = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR";
    //string FIEN = "8/8/8/4p1K1/2k1P3/8/8/8";

    void Start()
    {
        Debug.Log("Reached Master Script!");
        chessBoard.DrawChessBoard();
        renderPieces.DrawPieces();
        pT.updatePieces(StartingFEN);
    }
}
