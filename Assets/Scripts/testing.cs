using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testing : MonoBehaviour {
    public string start, dest;
    public bool go = false;
    Board board = new Board();
    int[,] b = new int[8, 8];
    Dictionary<string, int> colDic = new Dictionary<string, int>();
    // Use this for initialization
    void Start () {
        colDic["A"] = 0;
        colDic["B"] = 1;
        colDic["C"] = 2;
        colDic["D"] = 3;
        colDic["E"] = 4;
        colDic["F"] = 5;
        colDic["G"] = 6;
        colDic["H"] = 7;
        colDic["a"] = 0;
        colDic["b"] = 1;
        colDic["c"] = 2;
        colDic["d"] = 3;
        colDic["e"] = 4;
        colDic["f"] = 5;
        colDic["g"] = 6;
        colDic["h"] = 7;
    }
	
	// Update is called once per frame
	void Update () {
		if(go)
        {
            b = board.getBoard();
            
            Board.Move m;
            m.col = colDic[start[0].ToString()];
            m.row = (int)(start[1] - '0') - 1;
            m.destCol = colDic[dest[0].ToString()];
            m.destRow = (int)(dest[1] - '0') - 1;
            Board.PieceColour t = Board.PieceColour.WHITE;
            GetComponent<BoardControl>().movePiece(m, t);
            go = false;
        }
	}
}
