using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pawnMoves : MonoBehaviour
{
    public bool twoSquares;
    public PieceTracker pT;
    public RenderPieces rP;

    int[,] positions = new int[8, 8];

    private void Start()
    {
        int[] Positions = pT.posList;
        int count = 0;
        for (int row=0; row < 8; row++)
        {
            for (int column=0; column < 8; column++)
            {
                positions[row, column] = Positions[count];
                count++;
            }
        }
    }

    private void OnMouseDown()
    {
        getLegalPossibleMoves_pawn();
    }

    private void OnMouseUp()
    {
        

    }

    private List<int[,]> getLegalPossibleMoves_pawn()
    {
        List<int[,]> moves = new List<int[,]>();
   
        int moveLength;
        if (twoSquares){moveLength = 2;}
        else {moveLength = 1;}

        int[] index = findIndexOfPiece();
        //Debug.Log(index[0, 0]);

        //for (int i=0; i < moveLength; i++)
        //{
            
        //}


        


        return moves;
    }

    private int getKeyofGameObject()
    {
        int key = 0;
        foreach (KeyValuePair<int, GameObject> kvp in rP.pieces)
        {
            if (kvp.Value == gameObject)
            {
                //Debug.Log($"Found Key of GameObject! It's {kvp.Key}!");
                key = kvp.Key;
            }
            else
            {
                Debug.Log($"Key for {gameObject.name} was not found!");
                key = 0;
            }
        }

        return key;
    }

    private int[] findIndexOfPiece()
    {
        int pieceKey = getKeyofGameObject();
        int[] index = new int[2];

        for (int row = 0; row < 8; row++)
        {
            for (int column = 0; column < 8; column++)
            {
                if (pieceKey == positions[row, column])
                {
                    index[0] = row;
                    index[1] = column;
                }
            }
        }

        return index;
    }
}
