using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardUpdate : MonoBehaviour
{
    public RenderPieces renderPieces;
    public PieceTracker pT;

    private string findPieceNameWithBinaryCode(int code)
    {
        string name = "Null";

        foreach (var kvp in renderPieces.pieces)
        {
            if (kvp.Key == code)
            {
                name = kvp.Value.name;
            }
        }

        return name;
    }
    public void printPieces()
    {
        for (int i = 0; i < 64; i++)
        {
            Debug.Log($"Square {i} is a {findPieceNameWithBinaryCode(pT.posList[i])}");
        }
    }

    public void checkForCaptures()
    {

    }
}
