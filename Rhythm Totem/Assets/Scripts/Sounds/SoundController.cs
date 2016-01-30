﻿using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {

	public AudioSource[] soundSource; 
	public AudioClip[] soundList;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		if(Input.GetKeyDown(KeyCode.A))
			PlaySFX(0);
		else if(Input.GetKeyDown(KeyCode.S))
			PlaySFX(1);
		else if(Input.GetKeyDown(KeyCode.D))
			PlaySFX(2);
			
	}

	void PlaySFX(int button_index)
	{
		soundSource[button_index].clip = soundList[button_index];
		soundSource[button_index].PlayOneShot(soundList[button_index]);
	}
}
