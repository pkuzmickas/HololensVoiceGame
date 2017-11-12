using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnimation : MonoBehaviour {

    
    public GameObject test;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(9, 7, -13);
        test.transform.position = new Vector3(-30, 7, -13);
        float step = 2 * Time.deltaTime;
        test.transform.position = Vector3.MoveTowards(transform.position, test.transform.position, step);
    }

    public void Select()
    { 
        
    }

    public void MoveAnimate(int startX, int startY, int endX, int endY)
    {

    }

}