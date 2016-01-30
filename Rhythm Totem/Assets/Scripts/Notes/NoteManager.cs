using UnityEngine;
using System.Collections.Generic;

public class NoteManager : MonoBehaviour 
{
	private List<Note> notes = new List<Note>();
	private string[] NotesText;
	private string[] MusicListText;
	private char[] splitters = { ',' };

	Note newnote = null;

	void Start()
	{
		LoadNotes();
		LoadMusic();
		CheckNotes();
	}

	/// <summary>
	/// Loads Notes from resource file
	/// Stores them in an array and  Cleans the array of unnessesary strings
	/// Stores the length of the note depending on the number of "-" dashes on them
	/// Converts string to int to set as buttontype for the note to be stored for future use
	/// </summary>
	void LoadNotes()
	{
		int charindex = 0;
		TextAsset notesList = Resources.Load<TextAsset>("Levels_Notes/Notes_Level1");
		NotesText = notesList.ToString().Split(splitters,System.StringSplitOptions.RemoveEmptyEntries);
		for(int i = 0; i < NotesText.Length - 1; i++)
		{
			if(NotesText[i].Contains(":"))
			{
				charindex = NotesText[i].IndexOf(':');
				NotesText[i] = NotesText[i].Remove(0, charindex + 1);
			}
			//How to use addcomponent as it is Monobehavior 
			newnote = new Note();
			newnote.SetLength(NotesText[i].Length);
			notes[i].SetButtonType(System.Convert.ToInt32(NotesText[i].Substring(0, 1)));
			notes.Add(newnote);
//			Debug.Log(NotesText[i]);
		}
//		Debug.Log(NotesText.Length);
	}

	/// <summary>
	/// Loads Music from resource file
	/// Stores them in an array
	/// Cleans the array of unnessesary strings
	/// Converts string to int to set as buttontype for the note to be stored for future use
	/// </summary>
	void LoadMusic()
	{
		int charindex = 0;
		TextAsset musicList = Resources.Load<TextAsset>("Levels_Music/Music_Level1");
		MusicListText = musicList.ToString().Split(splitters,System.StringSplitOptions.RemoveEmptyEntries);
		for(int i = 0; i < MusicListText.Length - 1; i++)
		{
			if(MusicListText[i].Contains(":"))
			{
				charindex = MusicListText[i].IndexOf(':');
				MusicListText[i] = MusicListText[i].Remove(0, charindex + 1);
			}
			newnote.SetBeat(SoundController.soundcontroller.GetBeatfromList(MusicListText[i].Substring(0, 1)));
//			Debug.Log(MusicListText[i]);
		}
//		Debug.Log(MusicListText.Length); 
	}

	/// <summary>
	/// For debugging the what the list of notes contain
	/// </summary>
	void CheckNotes()
	{
		foreach(Note curnote in notes)
		{
			Debug.Log("Lenght:"+curnote.GetLength());
			Debug.Log("Beat:"+curnote.GetBeat());
			Debug.Log("Button:"+curnote.GetButtonType());
		}
	}
}
