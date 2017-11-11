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
     *  {COLOUR}{PIECE}{NUMBER OF PIECE}
     *  NUMBER OF PIECE - SINCE THERE ARE TWO ROOKS FOR EXAMPLE, WE NEED TO DIFFERENTIATE WHICH ONE IS WHICH
     *  EXAMPLE:
        BOARD[0,0] IS EQUAL TO 111 AT THE START
    */


    const int BOARD_SIZE = 8;

    bool updatePending = false;

    int[,] board = new int[BOARD_SIZE, BOARD_SIZE];

    public Board()
    {
        for(int col = 0; col < BOARD_SIZE; col++)
        {
            int counter = 1;
            for (int row=0; row < BOARD_SIZE; row++)
            {
                
                int team = 0;
                if (row < 2) team = (int)PieceColour.WHITE;
                else team = (int)PieceColour.BLACK;
                if (row == 0 || row == 7)
                {
                    if (col == 0 || col == 7) board[col, row] = (team * 10 + (int)Pieces.ROOK) * 10 + 1 + col/7;
                    if (col == 1 || col == 6) board[col, row] = (team * 10 + (int)Pieces.KNIGHT) * 10 + 1 + col/6;
                    if (col == 2 || col == 5) board[col, row] = (team * 10 + (int)Pieces.BISHOP) * 10 + 1 + col/5;
                    if (col == 3) board[col, row] = (team * 10 + (int)Pieces.QUEEN) * 10 + 1;
                    if (col == 4) board[col, row] = (team * 10 + (int)Pieces.KING) * 10 + 1;
                }
                else if (row == 1 || row ==6)
                {
                    board[col, row] = (team * 10 + (int)Pieces.PAWN) * 10 + 1 + col%8;
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

        board[move.destCol, move.destRow] = board[move.col, move.row];
        board[move.col, move.row] = 0;
        return true;

        
    }

    bool isAValidMove(Move move, PieceColour turn)
    {
        return false;
    }

}
