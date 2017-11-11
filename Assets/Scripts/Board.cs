using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board {

    /*
     *  PIECE COLOUR
     *  1 - WHITE
     *  2 - BLACK
     * 
     *  PIECE TYPE
     *  1 - ROOK
     *  2 - KNIGHT
     *  3 - BISHOP
     *  4 - QUEEN
     *  5 - KING
     *  6 - PAWN
     *  
     *  BOARD [ COL , ROW ]
     *  
     *  FORMAT ON BOARD:
     *  {COLOUR}{PIECE}
     *  EXAMPLE:
        BOARD[0,0] IS EQUAL TO 11 AT THE START
    */


    const int BOARD_SIZE = 8;

    int[,] board = new int[BOARD_SIZE, BOARD_SIZE];

    public Board()
    {
        for(int col = 0; col < BOARD_SIZE; col++)
        {
            for(int row=0; row < BOARD_SIZE; row++)
            {
                int team = 0;
                if (row < 2) team = (int)PieceColour.WHITE;
                else team = (int)PieceColour.BLACK;
                if (row == 0 || row == 7)
                {
                    if (col == 0 || col == 7) board[col, row] = team * 10 + (int)Pieces.ROOK;
                    if (col == 1 || col == 6) board[col, row] = team * 10 + (int)Pieces.KNIGHT;
                    if (col == 2 || col == 5) board[col, row] = team * 10 + (int)Pieces.BISHOP;
                    if (col == 3) board[col, row] = team * 10 + (int)Pieces.QUEEN;
                    if (col == 4) board[col, row] = team * 10 + (int)Pieces.KING;
                }
                else if (row == 1 || row ==6)
                {
<<<<<<< HEAD
                    board[col, row] = team * 10 + (int)Pieces.PAWN;
=======
                    board[row, col] = team * 10 + (int)Pieces.PAWN;
>>>>>>> 64c25d079c35a06c763bfa92572918f66396854f
                }
                else
                {
                    board[col, row] = 0;
                }
            }
        }
    }

    public int[,] getBoard()
    {
        return board;
    }

    public enum Pieces : int {ROOK=1, KNIGHT=2, BISHOP=3, QUEEN=4, KING=5, PAWN=6 };
    public enum PieceColour : int {WHITE=1, BLACK=2 };

    public struct Move {
        public int col;
        public int row;
        public int destCol;
        public int destRow;
    }
    public bool movePiece(Move move, PieceColour turn)
    {
<<<<<<< HEAD
        board[move.destCol, move.destRow] = board[move.col, move.row];
        board[move.col, move.row] = 0;
        return true;
=======
        
>>>>>>> 64c25d079c35a06c763bfa92572918f66396854f

        return false;
    }

    bool isAValidMove(Move move, PieceColour turn)
    {
        return false;
    }

}
