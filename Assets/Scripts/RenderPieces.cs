using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderPieces : MonoBehaviour
{
    public List<GameObject> pieces = new List<GameObject>();

    public GameObject King;
    public GameObject king;

    public GameObject Queen;
    public GameObject queen;

    public GameObject Rook;
    public GameObject rook;

    public GameObject Bishop;
    public GameObject bishop;

    public GameObject Knight;
    public GameObject knight;

    public GameObject Pawn;
    public GameObject pawn;

    public ChessBoard CB;

    Vector3 renderPos = new Vector3(0, 0, -1);


    public void DrawPieces()
    {
        Debug.Log("Reached Render Pieces Script!");
        GameObject white_King = Instantiate(King, renderPos, Quaternion.identity);
        GameObject black_King = Instantiate(king, renderPos, Quaternion.identity);

        GameObject white_Queen = Instantiate(Queen, renderPos, Quaternion.identity);
        GameObject black_Queen = Instantiate(queen, renderPos, Quaternion.identity);

        GameObject white_Rook = Instantiate(Rook, renderPos, Quaternion.identity);
        GameObject black_Rook = Instantiate(rook, renderPos, Quaternion.identity);

        GameObject white_Bishop = Instantiate(Bishop, renderPos, Quaternion.identity);
        GameObject black_Bishop = Instantiate(bishop, renderPos, Quaternion.identity);

        GameObject white_Knight = Instantiate(Knight, renderPos, Quaternion.identity);
        GameObject black_Knight = Instantiate(knight, renderPos, Quaternion.identity);

        GameObject white_Pawn = Instantiate(Pawn, renderPos, Quaternion.identity);
        GameObject black_Pawn = Instantiate(pawn, renderPos, Quaternion.identity);


        pieces.Add(white_King);
        pieces.Add(white_Queen);

        for (int i=0; i < 2; i++)
        {
            pieces.Add(white_Bishop);
            pieces.Add(white_Knight);
            pieces.Add(white_Rook);
        }
        for (int i=0; i < 8; i++)
        {
            pieces.Add(white_Pawn);
        }

        pieces.Add(black_King);
        pieces.Add(black_Queen);

        for (int i = 0; i < 2; i++)
        {
            pieces.Add(black_Bishop);
            pieces.Add(black_Knight);
            pieces.Add(black_Rook);
        }
        for (int i = 0; i < 8; i++)
        {
            pieces.Add(black_Pawn);
        }

    }

    public void loadStartingPos()
    {
        //for (int i=0; i < 16; i++)
        //{
        //    Vector2 squarePos = CB.chessSquares[i].transform.position;
        //    GameObject piece = pieces[i];

        //    piece.transform.position = squarePos;
        //}

        //for (int i = 16; i < 32; i++)
        //{
        //    Vector2 squarePos = CB.chessSquares[i].transform.position;
        //    GameObject piece = pieces[i];

        //    piece.transform.position = squarePos;
        //}
    }
}
