using UnityEngine;
using System.Collections.Generic;

public class NoteManager : MonoBehaviour 
{
	private List<NoteSettings> noteSettings = new List<NoteSettings> ();
	private string[] NotesText = new string[100];
	private string[] MusicListText = new string[100];
	private GameObject Hitbox;
	private int nextnote = 0;

	Note newnote = null;

	void Start()
	{
		LoadNotes();
		LoadMusic();
	}

	/// <summary>
	/// Loads Notes from resource file
	/// Stores them in an array and  Cleans the array of unnessesary strings
	/// </summary>
	void LoadNotes()
	{
		int charindex = 0;
		int currentinsertindex = 0;
		int currentNotesindex = 0;
		char[] tempCharArray;
		TextAsset notesList = Resources.Load<TextAsset>("Levels_Notes/Notes_Level1");
		tempCharArray = notesList.ToString().ToCharArray();
		//NotesText = notesList.ToString().Split(splitters,System.StringSplitOptions.RemoveEmptyEntries);
		for(int i = 0; i < tempCharArray.Length; i++)
		{
			if(tempCharArray[i].CompareTo('-') == 0)
			{
				NotesText[currentNotesindex - 1]+= "-";
//				Debug.Log("dash HERE");
			}
			else if(tempCharArray[i].CompareTo('\n') == 0)
			{
//				Debug.Log("space HERE");
			}
			else if((int)tempCharArray[i] == 13)
			{
//				Debug.Log("blank HERE");
			}
			else
			{
				charindex = i;
				currentinsertindex = 0;
				NotesText[currentNotesindex] = tempCharArray[i].ToString();
				currentNotesindex++;
//				Debug.Log("letter/number HERE");
			}
			//Debug.Log(NotesText[i]);
		}
		for(int i = 0; i < currentNotesindex; i++)
		{
			Debug.Log(NotesText[i]);
		}
//		Debug.Log(NotesText.Length);
	}

	/// <summary>
	/// Loads Music from resource file
	/// Stores them in an array and cleans the array of unnessesary strings
	/// </summary>
	void LoadMusic()
	{
		int charindex = 0;
		int currentMusicindex = 0;
		char[] tempCharArray;
		TextAsset musicList = Resources.Load<TextAsset>("Levels_Music/Music_Level1");
		tempCharArray = musicList.ToString().ToCharArray();
		for(int i = 0; i < tempCharArray.Length; i++)
		{
			if(tempCharArray[i].CompareTo('-') == 0) { }
			else if(tempCharArray[i].CompareTo('\n') == 0) { }
			else if((int)tempCharArray[i] == 13) { }
			else
			{
				charindex = i;
				MusicListText[currentMusicindex] = tempCharArray[i].ToString();
				currentMusicindex++;
				//				Debug.Log("letter/number HERE");
			}
			//Debug.Log(NotesText[i]);
		}
		for(int i = 0; i < currentMusicindex; i++)
		{
			StoreNotes(i);
		}
//		Debug.Log(MusicListText.Length); 
	}

	/// <summary>
	/// For debugging the what the list of notes contain
	/// </summary>
//	void CheckNotes()
//	{
//		foreach(Note curnote in notes)
//		{
//			Debug.Log("Lenght:"+curnote.GetLength());
//			Debug.Log("Beat:"+curnote.GetBeat());
//			Debug.Log("Button:"+curnote.GetButtonType());
//		}
//	}

//	void SetNote(int currentnoteindex, int replacementnoteindex)
//	{
//		newnote = new Note();
//		newnote.SetLength(NotesText[replacementnoteindex].Length);
//		newnote.SetButtonType(System.Convert.ToInt32(NotesText[replacementnoteindex].Substring(0, 1)));
//		newnote.SetBeat(SoundController.soundcontroller.GetBeatfromList(MusicListText[replacementnoteindex].Substring(0, 1)));
//		notes[currentnoteindex] = newnote;
//	}

	void StoreNotes(int index)
	{
		NoteSettings note = new NoteSettings(NotesText[index].Length,
			(beatList)SoundController.soundcontroller.GetBeatfromList(MusicListText[index].Substring(0, 1)),
			(buttonType)System.Convert.ToInt32(NotesText[index].Substring(0, 1)));
		noteSettings.Add(note);
	}

	public void NoteHit()
	{
		Debug.Log("NOTE HIT!");
	}
}
