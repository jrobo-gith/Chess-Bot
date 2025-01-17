using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FENTRANSLATE : MonoBehaviour
{
    public int[] translateFENtoBoard(string fenString)
    {
        int[] posList = new int[64];
        int posList_counter = 0;

        List<string> validPieces = new List<string> { "K", "k", "Q", "q", "B", "b", "N", "n", "R", "r", "P", "p" };

        int Bishop_C = 0;
        int bishop_C = 0;
        int Knight_C = 0;
        int knight_C = 0;
        int Rook_C = 0;
        int rook_C = 0;
        int Pawn_C = 0;
        int pawn_C = 0;

        for (int i=0; i < fenString.Length; i++) {

                
            bool isNumeric = int.TryParse(fenString[i].ToString(), out int number);

            if (isNumeric)
            {
                for (int j = 0; j < number; j++)
                {
                    posList[posList_counter + j] = 0;
                }
                posList_counter += number;
                //Debug.Log("Number! " + posList_counter);
            }

            if (validPieces.Contains(fenString[i].ToString()))
            {
                int identity = 0;
                int pieceColor = (char.IsUpper(fenString[i])) ? 1 : 2;

                switch (char.ToLower(fenString[i]))
                {
                    case 'k':
                        number = 1; // King
                        break;
                    case 'q':
                        number = 2; // Queen
                        break;
                    case 'b':
                        number = 3; // Bishop
                        identity = (pieceColor == 1) ? ++Bishop_C : ++bishop_C;
                        break;
                    case 'n':
                        number = 4; // Knight
                        identity = (pieceColor == 1) ? ++Knight_C : ++knight_C;
                        break;
                    case 'r':
                        number = 5; // Rook
                        identity = (pieceColor == 1) ? ++Rook_C : ++rook_C;
                        break;
                    case 'p':
                        number = 6; // Pawn
                        identity = (pieceColor == 1) ? ++Pawn_C : ++pawn_C;
                        break;
                    default:
                        number = 0;
                        break;
                }
                //Debug.Log(identity);
                posList[posList_counter] = (pieceColor << 6) | (number << 3) | identity;
                posList_counter += 1;
                //Debug.Log("Valid Letter! " + fenString[i] + " " + posList_counter);
            }

        }

        return posList;

    }
}
