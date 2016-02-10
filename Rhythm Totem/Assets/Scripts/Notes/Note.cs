using UnityEngine;
using System.Collections;

public enum buttonType
{
	greenbtn = 0,
	redbtn = 1,
	yellowbtn = 2,
	bluebtn = 3,
}

public enum beatList{
//	drumC,
//	drumD,
//	drumE,
//	drumF,
//	drumG,
//	drumA,
//	drumB,
//	fluteC,
//	fluteD,
//	fluteE,
//	fluteF,
//	fluteG,
//	fluteA,
//	fluteB,
	dum1,
	dum2,
	tang1,
	tung1,
	ting1,
	ting2,
	flute1c,
	flute1cSH,
	flute2d,
	flute2dSH,
	flute3e,
	flute4f,
	flute4fSH,
	flute5g,
	flute5gSH,
	flute6a,
	flute6aSH,
	flute7b,
	flute8c,
}

public class Note : MonoBehaviour 
{
	private NoteSettings noteSetting;

	public NoteSettings NoteSetting
	{
		get 
		{
			return noteSetting;
		}
		set 
		{
			noteSetting = value;
			Setup ();
		}
	}

	public bool Played
	{
		get 
		{
			return played;
		}
	}

	private int Length = 1;
	private beatList beatlisttarget = beatList.dum1;
	private buttonType buttontarget = buttonType.greenbtn;
	private bool played = false;
	[SerializeField]
	private GameObject note_gmobj;
	[SerializeField]
	private GameObject[] button_gmobj;

	#region Getters and Setter

	public buttonType GetButtonType() { return buttontarget; }
	public beatList GetBeat() { return beatlisttarget; }
	public int GetLength() { return Length; }
	public GameObject GetNote_gmobj() { return note_gmobj; }

	#endregion

	void ActivateButton(int boxindex) 
	{ 
		foreach (GameObject obj in button_gmobj) {
			obj.SetActive (false);
		}
		button_gmobj[boxindex].SetActive(true); 
	}

	void Setup()
	{
		beatlisttarget = noteSetting.Beat;
		buttontarget = noteSetting.Button;
		Length = noteSetting.Length;
		ActivateButton((int) noteSetting.Button);
		played = false;
	}

	public float GetAngle()
	{
		return transform.rotation.eulerAngles.y;
	}

	public void GetHit()
	{
		played = true;
		SoundController.soundcontroller.PlayCorrectSound ((int)buttontarget, (int)beatlisttarget);
	}

	public void Miss()
	{
		played = true;
		Debug.Log ("Miss");
	}
}
