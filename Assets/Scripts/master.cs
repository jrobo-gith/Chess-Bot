using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class master : MonoBehaviour
{
    public ChessBoard chessBoard;
    public RenderPieces renderPieces;
    public PieceTracker pT;

    string StartingFEN = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR";
    string FIEN = "4k2r/6r1/8/8/8/8/3R4/R3K3";

    void Start()
    {
        Debug.Log("Reached Master Script!");
        chessBoard.DrawChessBoard();
        renderPieces.DrawPieces();
        pT.updatePieces(StartingFEN);
    }

    void Update()
    {
        
    }
}
