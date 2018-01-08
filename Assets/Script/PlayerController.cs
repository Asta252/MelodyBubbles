using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private float playerSpeed = 5.0f;
    public GameObject[] Melody;
    public GameObject gameManage;
	// Use this for initialization
	void Start () {
        gameManage = GameObject.Find("GameManage");
	}
	
	// Update is called once per frame
	void Update () {

        if (gameManage.GetComponent<GameManage>().gameState == GameManage.GameState.PLAYABLE)
        {
            PlayerMoves();
            PlayerRotate();
        }
        
	}

    void PlayerMoves()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(x, y).normalized;
        GetComponent<Rigidbody2D>().velocity = playerSpeed * direction;
        Clamp();
    }
    void Clamp()
    {
        float minX = -6.0f;
        float maxX = 6.0f;
        float minY = -58.0f;
        float maxY = 3.0f;

        Vector2 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
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

    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "bubble")
        {
            Destroy(c.gameObject);
        }
        if (c.gameObject.tag == "melody")
        {
            c.gameObject.GetComponent<MelodyManage>().PlayMelody();
            c.gameObject.layer = 11;
            Destroy(c.gameObject,1.0f);
        }
    }
}
