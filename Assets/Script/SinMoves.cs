using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinMoves : MonoBehaviour {
    public float width = 0.2f;
    UpMoves upMove;
    public float flSpeed = 1.0f;
    private Rigidbody2D myRigid2D;
	// Use this for initialization
	void Start () {
        //myRigid2D = GetComponent<Rigidbody2D>();
        upMove = GetComponent<UpMoves>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector2(Mathf.PingPong(Time.time,width), transform.position.y);
        upMove.Move(transform.up * flSpeed);
        
    }
    
}
