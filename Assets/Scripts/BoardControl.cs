using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardControl : MonoBehaviour {

    public GameObject board;
    public float startX, startZ, startY, addZ, addX;
    public GameObject pawn_black, pawn_white, rook_black, rook_white, bishop_white, bishop_black, knight_white, knight_black, king_black, king_white, queen_white, queen_black;
    Board boardObject = new Board();

    // Use this for initialization
    public Dictionary<int, GameObject> pieces = new Dictionary<int, GameObject>();

    void Start() {
        int[,] b = boardObject.getBoard();
        for (int row = 0; row < 8; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                GameObject piece = null;
                if (b[col, row] % 100 / 10== (int)Board.Pieces.ROOK)
                {
                    if (b[col, row] / 100 % 10 == (int)Board.PieceColour.BLACK) piece = rook_black;
                    if (b[col, row] / 100 % 10 == (int)Board.PieceColour.WHITE) piece = rook_white;
                }
                if (b[col, row] % 100 / 10 == (int)Board.Pieces.KNIGHT)
                {
                    if (b[col, row] / 100 % 10 == (int)Board.PieceColour.BLACK) piece = knight_black;
                    if (b[col, row] / 100 % 10 == (int)Board.PieceColour.WHITE) piece = knight_white;
                }
                if (b[col, row] % 100 / 10 == (int)Board.Pieces.BISHOP)
                {
                    if (b[col, row] / 100 % 10 == (int)Board.PieceColour.BLACK) piece = bishop_black;
                    if (b[col, row] / 100 % 10 == (int)Board.PieceColour.WHITE) piece = bishop_white;
                }
                if (b[col, row] % 100 / 10 == (int)Board.Pieces.QUEEN)
                {
                    if (b[col, row] / 100 % 10 == (int)Board.PieceColour.BLACK) piece = queen_black;
                    if (b[col, row] / 100 % 10 == (int)Board.PieceColour.WHITE) piece = queen_white;
                }
                if (b[col, row] % 100 / 10 == (int)Board.Pieces.KING)
                {
                    if (b[col, row] / 100 % 10 == (int)Board.PieceColour.BLACK) piece = king_black;
                    if (b[col, row] / 100 % 10 == (int)Board.PieceColour.WHITE) piece = king_white;
                }
                if (b[col, row] % 100 / 10 == (int)Board.Pieces.PAWN)
                {
                    if (b[col, row] / 100 % 10 == (int)Board.PieceColour.BLACK) piece = pawn_black;
                    if (b[col, row] / 100 % 10 == (int)Board.PieceColour.WHITE) piece = pawn_white;
                }
                if (piece) {
                    pieces[b[col,row]] = Instantiate(piece, new Vector3(startX + addX * row + board.transform.position.x, startY + board.transform.position.y, startZ + addZ * col + board.transform.position.z), Quaternion.identity);
                }

            }
        }
        //pieces[111].SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
       
	}

    public bool movePiece(Board.Move move, Board.PieceColour turn)
    {
        int[,] b = boardObject.getBoard();
        int key = b[move.col, move.row];
        boardObject.movePiece(move, turn);

        pieces[key].transform.position = new Vector3(startX + addX * move.destRow, startY, startZ + addZ * move.destCol);
        
        return true;


    }
}
