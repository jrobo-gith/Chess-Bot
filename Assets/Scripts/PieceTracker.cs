using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceTracker : MonoBehaviour
{
    public FENTRANSLATE FT;
    public RenderPieces RP;
    public ChessBoard CB;

    public static int[] posList;


    public void updatePieces(string fenString)
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
        }

        foreach (KeyValuePair<int, GameObject> kvp in RP.pieces)
        {
            if (System.Array.Exists(posList, element => element == kvp.Key)) {

            }
            else
            {
                Destroy(kvp.Value);
            }
        }
    }

}
