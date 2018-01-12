using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    private float playerSpeed = 5.0f;
    public GameObject[] Melody;
    public GameObject gameManage;
    private int score;
    private int depth;
    private int bress;
    private Animator myAnimator;
    private GameObject scoreText;
    private GameObject sinkText;
	// Use this for initialization
	void Start () {
        gameManage = GameObject.Find("GameManage");
        myAnimator = GetComponent<Animator>();
        scoreText = GameObject.Find("scoreText");
	}
	
	// Update is called once per frame
	void Update () {

        if (gameManage.GetComponent<GameManage>().gameState == GameManage.GameState.PLAYABLE)
        {
            PlayerMoves();
            PlayerRotate();
        }else if (gameManage.GetComponent<GameManage>().gameState == GameManage.GameState.CLEAR)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            myAnimator.speed = 0.3f;
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
            myAnimator.speed = 1.2f;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, upR);
            myAnimator.speed = 1.2f;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, leftR);
            scale.x = -1;
            myAnimator.speed = 1.2f;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, downR);
            myAnimator.speed = 1.2f;
        }
        else
        {
            myAnimator.speed = 0.5f;
        }
        transform.localScale = scale;

        this.scoreText.GetComponent<Text>().text = score + "pt";
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
           
           // Destroy(c.gameObject,1.0f);

            score += 10;
        }
    }
}
