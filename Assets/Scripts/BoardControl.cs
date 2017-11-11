using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardControl : MonoBehaviour {

    public GameObject board;
    public float startX, startZ, startY, addZ, addX;
    public GameObject pawn_black, pawn_white, rook_black, rook_white, bishop_white, bishop_black, knight_white, knight_black, king_black, king_white, queen_white, queen_black;
    Board boardObject = new Board();
    int whiteAlive=16, blackAlive=16;
    // Use this for initialization
    public Dictionary<int, GameObject> pieces = new Dictionary<int, GameObject>();

    void initDic
    {
        colDic ["A"] = 0;
        colDic ["B"] = 1;
        colDic ["C"] = 2;
        colDic ["D"] = 3;
        colDic ["E"] = 4;
        colDic ["F"] = 5;
        colDic ["G"] = 6;
        colDic ["H"] = 7;
        colDic ["a"] = 0;
        colDic ["b"] = 1;
        colDic ["c"] = 2;
        colDic ["d"] = 3;
        colDic ["e"] = 4;
        colDic ["f"] = 5;
        colDic ["g"] = 6;
        colDic ["h"] = 7;
    }

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

    public bool movePiece(string start, string dest)
    {
        Board.Move m;
        m.col = colDic[start[0].ToString()];
        m.row = (int)(start[1] - '0') - 1;
        m.destCol = colDic[dest[0].ToString()];
        m.destRow = (int)(dest[1] - '0') - 1;
        Board.PieceColour t = Board.PieceColour.WHITE;
        GetComponent<BoardControl>().movePiece(m, t);
    }

    public int getCol // padaryk kad keistu A5 i col row

    public bool movePiece(Board.Move move, Board.PieceColour turn)
    {
        int[,] b = boardObject.getBoard();
        int key = b[move.col, move.row];
        boardObject.movePiece(move, turn);

        pieces[key].transform.position = new Vector3(startX + addX * move.destRow, startY, startZ + addZ * move.destCol);
        
        return true;


    }

    public int getWhiteAlive()
    {
        return whiteAlive;
    }
    public int getBlackAlive()
    {
        return blackAlive;
    }
}
