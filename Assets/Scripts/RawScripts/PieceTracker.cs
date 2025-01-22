using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceTracker : MonoBehaviour
{
    public FENTRANSLATE FT;
    public RenderPieces RP;
    public ChessBoard CB;

    public int[] posList;

    public void checkForDeletedPieces()
    {
        foreach (var kvp in RP.pieces)
        {
            bool existsOnBoard = false;
            for (int i=0; i<64; i++)
            {
                if (kvp.Key == posList[i])
                {
                    existsOnBoard = true;
                }
            }
            if (existsOnBoard == false)
            {
                Destroy(kvp.Value);
            }
        }
    }


    public void startPieces(string fenString)
    {
        posList = FT.translateFENtoBoard(fenString);
        for (int i = 0; i < 64; i++)
        {
            //Debug.Log(posList[i]);
            float squarePosX = CB.chessSquares[i].transform.position.x;
            float squarePosY = CB.chessSquares[i].transform.position.y;

            int pieceKey = posList[i];
            if (pieceKey != 0 && RP.pieces.TryGetValue(pieceKey, out GameObject piece)) // Check if square is not empty and has a corresponding GameObject
            {
                piece.transform.position = new Vector3(squarePosX, squarePosY, -1);
            }

            

            //foreach (var kvp in RP.pieces)
            //{
            //    if (!piecesToKeep.Contains(kvp.Key))
            //    {
            //        Destroy(kvp.Value);
            //    }
            //}
        }

        //foreach (var kvp in RP.pieces)
        //{
        //    //bool isInPlay;
        //    //if (System.Array.Exists(posList, element => element == kvp.Key)) {

        //    //}
        //    //else
        //    //{
        //    //    Destroy(kvp.Value);
        //    //}

        //    for (int i = 0; i < 64; i++)
        //    {
        //        if (kvp.Key == posList[i])
        //        {
        //            Debug.Log("BREAKING");
        //            break;
        //        }
        //        else
        //        {
        //            Destroy(kvp.Value);
        //        }
        //    }
        //}
    }
}
