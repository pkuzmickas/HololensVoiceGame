using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testing : MonoBehaviour {
    public int startCol, startRow, destCol, destRow;
    public bool go = false;
    Board board = new Board();
    int[,] b = new int[8, 8];
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		if(go)
        {
            b = board.getBoard();
            Debug.Log("BOARD start: " + b[startCol,startRow]);
            Debug.Log("BOARD dest: " + b[destCol, destRow]);
            Debug.Log("START: " + startCol + " " + startRow);
            Debug.Log("END: " + destCol + " " + destRow);
            Board.Move m;
            m.col = startCol;
            m.row = startRow;
            m.destCol = destCol;
            m.destRow = destRow;
            Board.PieceColour t = Board.PieceColour.WHITE;
            board.movePiece(m, t);
            b = board.getBoard();
            Debug.Log("BOARD start: " + b[startCol, startRow]);
            Debug.Log("BOARD dest: " + b[destCol, destRow]);
            go = false;
        }
	}
}
