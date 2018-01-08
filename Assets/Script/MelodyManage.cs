using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MelodyManage : MonoBehaviour {
    public AudioClip melody;
    private AudioSource audioSource;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = melody;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void PlayMelody()
    {
        audioSource.Play();
    }
    
}
