using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderPieces : MonoBehaviour
{
    public Dictionary<int, GameObject> pieces = new Dictionary<int, GameObject>();

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

    public const int None = 0 << 3;
    public const int King_ = 1 << 3;
    public const int Queen_ = 2 << 3;
    public const int Bishop_ = 3 << 3;
    public const int Knight_ = 4 << 3;
    public const int Rook_ = 5 << 3;
    public const int Pawn_ = 6 << 3;

    public const int white = 1 << 6;
    public const int black = 2 << 6;

    public ChessBoard CB;

    Vector3 renderPos = new Vector3(0, 0, -1);


    public void DrawPieces()
    {
        Debug.Log("Reached Render Pieces Script!");

        // Render pieces that only need one identities

        GameObject white_King = Instantiate(King, renderPos, Quaternion.identity);
        GameObject black_King = Instantiate(king, renderPos, Quaternion.identity);

        pieces.Add(white | King_ | 0, white_King);
        pieces.Add(black | King_ | 0, black_King);

        GameObject white_Queen = Instantiate(Queen, renderPos, Quaternion.identity);
        GameObject black_Queen = Instantiate(queen, renderPos, Quaternion.identity);

        pieces.Add(white | Queen_ | 0, white_Queen);
        pieces.Add(black | Queen_ | 0, black_Queen);


        // Render pieces that need two indentities

        for (int i = 1; i < 3; i++)
        {
            GameObject white_Rook = Instantiate(Rook, renderPos, Quaternion.identity);
            int white_rook_ID = white | Rook_ | i;
            pieces.Add(white_rook_ID, white_Rook);

            GameObject black_Rook = Instantiate(rook, renderPos, Quaternion.identity);
            int black_rook_ID = black | Rook_ | i;
            pieces.Add(black_rook_ID, black_Rook);


            GameObject white_Bishop = Instantiate(Bishop, renderPos, Quaternion.identity);
            int white_bishop_ID = white | Bishop_ | i;
            pieces.Add(white_bishop_ID, white_Bishop);

            GameObject black_Bishop = Instantiate(bishop, renderPos, Quaternion.identity);
            int black_bishop_ID = black | Bishop_ | i;
            pieces.Add(black_bishop_ID, black_Bishop);


            GameObject white_Knight = Instantiate(Knight, renderPos, Quaternion.identity);
            int white_knight_ID = white | Knight_ | i;
            pieces.Add(white_knight_ID, white_Knight);

            GameObject black_Knight = Instantiate(knight, renderPos, Quaternion.identity);
            int black_knight_ID = black | Knight_ | i;
            pieces.Add(black_knight_ID, black_Knight);
        }

        // Render Pieces that need eight identities

        for (int i = 1; i < 9; i++)
        {
            GameObject white_pawn = Instantiate(Pawn, renderPos, Quaternion.identity);
            int white_pawn_identity = white | Pawn_ | i;

            pieces.Add(white_pawn_identity, white_pawn);

            GameObject black_pawn = Instantiate(pawn, renderPos, Quaternion.identity);
            int black_pawn_identity = black | Pawn_ | i;

            pieces.Add(black_pawn_identity, black_pawn);
        }

    }
}
