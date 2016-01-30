using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using InControl;

public class SoundController : MonoBehaviour 
{

	public AudioSource[] soundSource; 
	public AudioClip[] soundList;
	private AudioClip[] masterSoundList = new AudioClip[100];
	private string[] sfxNameListText;
	List<KeyValuePair<int,string>> soundlistPair = new List<KeyValuePair<int,string>>();

	bool leftTriggerPressed;
	bool rightTriggerPressed;
	bool leftBumperPressed;
	bool rightBumperPressed;


	public static SoundController soundcontroller { get; private set; }

	void Awake() 
	{
		if(soundcontroller != null && soundcontroller != this)
		{
			Destroy(gameObject);
		}

		soundcontroller = this;

		DontDestroyOnLoad(gameObject);

		//since Notemanager is being overtaken in the start sequence
		LoadSounds();
	}

	// Use this for initialization
	void Start () 
	{
		//LoadSounds();
	}

	void LoadSounds()
	{
		TextAsset soundlist = Resources.Load<TextAsset>("SoundList");
		sfxNameListText = soundlist.ToString().Split('\n');
		//sfxNameListText = sfxNameListText
		for(int i = 0; i < sfxNameListText.Length; i++)
		{
//			Debug.Log(i + sfxNameListText[i].Substring(0, 1));
			soundlistPair.Add(new KeyValuePair<int, string>(i, sfxNameListText[i].Substring(0, 1)));
			sfxNameListText[i] = sfxNameListText[i].Remove(0, 2);
			masterSoundList[i] = Resources.Load<AudioClip>("MusicList/" + sfxNameListText[i]);
//			Debug.Log(sfxNameListText[i]);
		}
		Debug.Log(sfxNameListText.Length);

	}

	// Update is called once per frame
	void Update () 
	{
		InputDevice inputDevice = InputManager.ActiveDevice;

		//pressing ASD produces a key, and pressing them multiple times play the sound effects continously 
		//making another instance until the soundclip is done
//		if(Input.GetKeyDown(KeyCode.A))
//			PlaySFX(0);
//		else if(Input.GetKeyDown(KeyCode.S))
//			PlaySFX(1);
//		else if(Input.GetKeyDown(KeyCode.D))
//			PlaySFX(2);
		if (!inputDevice.LeftTrigger.IsPressed) 
		{
			leftTriggerPressed = false;
		}
		if(!inputDevice.LeftBumper.IsPressed)
		{
			leftBumperPressed = false;
		}
		if(!inputDevice.RightBumper.IsPressed)
		{
			rightBumperPressed = false;
		}
		if(!inputDevice.RightTrigger.IsPressed)
		{
			rightTriggerPressed = false;
		}		

		if (inputDevice.LeftTrigger.IsPressed && !leftTriggerPressed) 
		{
			PlaySFX(0);
			leftTriggerPressed = true;
		}
		else if(inputDevice.LeftBumper.IsPressed && !leftBumperPressed)
		{
			PlaySFX(1);
			leftBumperPressed = true;
		}
		else if(inputDevice.RightBumper.IsPressed && !rightBumperPressed)
		{
			PlaySFX(2);
			rightBumperPressed = true;
		}
		else if(inputDevice.RightTrigger.IsPressed && !rightTriggerPressed)
		{
			PlaySFX(3);
			rightTriggerPressed = true;
		}		
	}

	void PlaySFX(int button_index)
	{
		soundSource[button_index].clip = soundList[button_index];
		soundSource[button_index].PlayOneShot(soundList[button_index]);
		//soundSource[button_index].clip = masterSoundList[button_index];
		//soundSource[button_index].PlayOneShot(masterSoundList[button_index]);
	}

	public void PlayCorrectSound(int button_index)
	{
		PlaySFX(button_index);
	}

	public void PlayWrongSound(int button_index)
	{
		StartCoroutine(PlayWrong(button_index));
	}

	IEnumerator PlayWrong(int button_index)
	{
		PlaySFX(button_index);
		yield return new WaitForSeconds(0.3f);
		PlaySFX(button_index);
	}

	public int GetBeatfromList(string beatID)
	{
		int beatindex = 0;
		foreach(KeyValuePair<int,string> beat in soundlistPair)
		{
			if(beat.Value == beatID)
			{
				beatindex = beat.Key;
			}
		}

		return beatindex;
	}
}
