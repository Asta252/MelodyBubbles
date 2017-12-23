using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinMoves : MonoBehaviour {
    public float width = 0.2f;
    UpMoves upMove;
    public float flSpeed = 1.0f;
    private Rigidbody2D myRigid2D;
    private float preX;
    private float preY;
	// Use this for initialization
	void Start () {
        //myRigid2D = GetComponent<Rigidbody2D>();
        upMove = GetComponent<UpMoves>();

        preX = Random.Range(-6, 6);
        preY = Random.Range(-50, 0);
        transform.position = new Vector2(preX, preY);
    }
	
	// Update is called once per frame
	void Update () {

       
        transform.position = new Vector2(preX+Mathf.PingPong(Time.time,width), transform.position.y);
        upMove.Move(transform.up * flSpeed);
        
    }
    
}
