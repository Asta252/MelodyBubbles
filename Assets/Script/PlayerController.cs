using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private float playerSpeed = 5.0f; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        PlayerMoves();
        PlayerRotate();
	}

    void PlayerMoves()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(x, y).normalized;
        GetComponent<Rigidbody2D>().velocity = playerSpeed * direction;
    }

    void PlayerRotate()
    {
        float rightR = -90;
        float downR = 180;
        float leftR = 90;
        float upR = 0;
        Vector2 scale = transform.localScale;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rightR);
            scale.x = 1;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, upR);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, leftR);
            scale.x = -1;
        }else if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, downR);
        }
        transform.localScale = scale;
    }
}
