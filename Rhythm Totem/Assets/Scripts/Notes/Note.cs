using UnityEngine;
using System.Collections;

public enum buttonType{
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

public class Note : MonoBehaviour {

	private int Length = 1;
	private beatList beatlisttarget = beatList.dum1;
	private buttonType buttontarget = buttonType.greenbtn;
	[SerializeField]
	private GameObject note_gmobj;
	[SerializeField]
	private GameObject[] button_gmobj;

	#region Getters and Setter

	public void SetButtonType (int thisbutton) { buttontarget = (buttonType)thisbutton;  ActivateButton(thisbutton);}
	public buttonType GetButtonType() { return buttontarget; }
	public void SetBeat (int beat) { beatlisttarget = (beatList)beat; }
	public beatList GetBeat() { return beatlisttarget; }
	public void SetLength (int beatlength) { Length = beatlength; }
	public int GetLength() { return Length; }
	public GameObject GetNote_gmobj() { return note_gmobj; }

	#endregion

	void ActivateButton(int boxindex) { button_gmobj[boxindex].SetActive(true); }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void GetHit()
	{
		
	}

	void Miss()
	{
		
	}
}
