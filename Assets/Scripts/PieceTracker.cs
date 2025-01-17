using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceTracker : MonoBehaviour
{
    public FENTRANSLATE FT;
    public RenderPieces RP;
    public ChessBoard CB;

    //public const int None = 0;
    //public const int King = 1;
    //public const int Queen = 2;
    //public const int Bishop = 3;
    //public const int Knight = 4;
    //public const int Rook = 5;
    //public const int Pawn = 6;

    //public const int white = 8;
    //public const int black = 16;

    public static int[] posList;


    public void updatePieces(string fenString)
    {
        posList = FT.translateFENtoBoard(fenString);

        //foreach (KeyValuePair<int, GameObject> kvp in RP.pieces)
        //{
        //    Debug.Log(kvp.Key);
        //}

        for (int i = 0; i < 64; i++)
        {
            Debug.Log(posList[i]);
            Debug.Log(RP.pieces.TryGetValue(posList[i], out _));
            //bool l = RP.pieces.TryGetValue(posList[i], out GameObject peece);
            //Debug.Log(l);
            //Debug.Log("Square " + i + " has a " +peece.name + " on its square.");
            float squarePosX = CB.chessSquares[i].transform.position.x;
            float squarePosY = CB.chessSquares[i].transform.position.y;

            int pieceKey = posList[i];
            if (pieceKey != 0 && RP.pieces.TryGetValue(pieceKey, out GameObject piece)) // Check if square is not empty and has a corresponding GameObject
            {
                piece.transform.position = new Vector3(squarePosX, squarePosY, -1);
            }
        }
    }

    //public void updatePieces(string fenString)
    //{
    //    posList = FT.translateFENtoBoard(fenString);

    //    for (int i=0; i < 64; i++)
    //    {
    //        Vector2 squarePos = CB.chessSquares[i].transform.position;

    //        int color = posList[i] & 24; // 24 (11000) isolates the color bits
    //        int type = posList[i] & 7;  // 7 (00111) isolates the type bits

    //        string colorName = color == 8 ? "w" : "b";
    //        string pieceName = type switch
    //        {
    //            0 => "empty",
    //            1 => "k",
    //            2 => "q",
    //            3 => "q",
    //            4 => "q",
    //            5 => "r",
    //            6 => "p",
    //            _ => "Blank"
    //        };

    //        GameObject piece = GameObject.Find(colorName + pieceName);
           
    //        if (piece != null)
    //        {
    //            piece.transform.position = squarePos;
    //        }
    //        else
    //        {
    //            Debug.Log("Couldn't find piece! " + colorName + pieceName);
    //        }
    //        //Debug.Log("On Square: " + i + " is a " + colorName + " " + pieceName);

    //    }

    //}
}
