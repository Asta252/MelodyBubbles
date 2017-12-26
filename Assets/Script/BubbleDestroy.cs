using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "bubble")
        {
            Destroy(c.gameObject);
        }
    }
}
