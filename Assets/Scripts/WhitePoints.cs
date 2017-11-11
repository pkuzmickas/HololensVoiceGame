using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhitePoints : MonoBehaviour {

    int points = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<TextMesh>().text = points.ToString();
	}

    public void AddPointsForWhite(int piece)
    {
        switch (piece)
        {
            case 1:
                points += 5;
                break;
            case 2:
                points += 3;
                break;
            case 3:
                points += 3;
                break;
            case 4:
                points += 9;
                break;
            case 6:
                points += 1;
                break;
        }
    }
}
