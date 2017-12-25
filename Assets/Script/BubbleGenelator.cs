using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleGenelator : MonoBehaviour {
    
    public GameObject[] bubbleItem;
   
    // Use this for initialization
    IEnumerator Start () {
        while (true)
        {

            Vector2 pos = GetRandomPosition();

            int item = Random.Range(1, 6);
            if (item >= 1 && item <= 3)
            {
                Instantiate(bubbleItem[0], pos, Quaternion.identity);

            }
            else
            {
                Instantiate(bubbleItem[1], pos, Quaternion.identity);
            }
            yield return new WaitForSeconds(3.0f);
        }
        
       
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    Vector2 GetRandomPosition()
    {
        return new Vector2(Random.Range(-6, 6), Random.Range(-50, 0));
    }
}
