using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleGenelator : MonoBehaviour {
    
    public GameObject bubbleItem;
   
    // Use this for initialization
    IEnumerator Start () {
        while (true)
        {
            Instantiate(bubbleItem, transform.position, transform.rotation);


            yield return new WaitForSeconds(3.0f);
        }
        
       
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    
}
