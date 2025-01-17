using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    public GameObject Square;
    public List<GameObject> chessSquares = new List<GameObject>();

    public Color lightCol;
    public Color darkCol;

    public float squareSize = 3.5f;

    public void DrawChessBoard()
    {
        chessSquares.Clear();

        for (int rank=0; rank < 8; rank++)
        {
            for(int file=0; file < 8; file++)
            {
                bool isLightSquare = (file + rank) % 2 != 0;

                var squareColor = (isLightSquare) ? lightCol : darkCol;
                var position = new Vector2(-squareSize + file, squareSize - rank);

                GameObject square = Instantiate(Square, position, Quaternion.identity);
                Renderer squareRenderer = square.GetComponent<Renderer>();

                squareRenderer.material.color = squareColor;
                chessSquares.Add(square);

            }
        }

    }

        
}
