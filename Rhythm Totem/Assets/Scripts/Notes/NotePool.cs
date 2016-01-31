using UnityEngine;
using System.Collections.Generic;

public class NotePool : MonoBehaviour 
{
	GameObject rotatingCameraPivot;
	public float noteLength = 22.5f;
	public float behindPoleBegin = 170.0f;
	public float behindPoleEnd = 190.0f;
	public float creationAngle = 180.0f;

	private NoteManager noteManager;
	private CameraManager cameraManager;

	public List<Note> AvailableNotes = new List<Note> ();
	public List<Note> Notes = new List<Note> ();

	void Start()
	{
		rotatingCameraPivot = GameObject.FindWithTag ("RotatingCameraPivot");
		noteManager = gameObject.GetComponent<NoteManager> ();
		cameraManager = GameObject.FindWithTag ("CameraManager").GetComponent<CameraManager>();
	}

	float GetCurrentAngle()
	{
		return rotatingCameraPivot.transform.rotation.eulerAngles.y;
	}

	private Note note;
	private Note currentNote;
	private float wait = 0.0f;
	public float waitTime = 5.0f;

	void Update()
	{
		wait += Time.deltaTime;
		if (wait < waitTime) {
			return;
		}
		// hide notes
		float currentAngle = GetCurrentAngle ();
		float disappearLimitBegin = currentAngle - behindPoleBegin;
		float disappearLimitEnd = currentAngle - behindPoleEnd;
		if (disappearLimitBegin < 0.0f) 
		{
			disappearLimitBegin += 360.0f;
		}

		if (disappearLimitEnd < 0.0f) 
		{
			disappearLimitEnd += 360.0f;
		}

		for (int i = Notes.Count - 1; i >= 0; --i) 
		{
			note = Notes [i];
			if (note.Played) 
			{
				float noteAngle = note.GetAngle ();
				if ((disappearLimitEnd > disappearLimitBegin && disappearLimitEnd < noteAngle + 360.0f && noteAngle < disappearLimitBegin) 
					|| (disappearLimitEnd < disappearLimitBegin && disappearLimitEnd < noteAngle && noteAngle < disappearLimitBegin))
				{
					note.gameObject.SetActive (false);
					Notes.RemoveAt (i);
					AvailableNotes.Add (note);
				}
			}
		}

		// create notes
		if (currentNote) 
		{
			float lengthAngleDiff = currentNote.NoteSetting.Length * noteLength;
			float currentNoteAngle = currentNote.GetAngle ();
			if (currentNoteAngle > currentAngle) 
			{
				currentNoteAngle -= 360.0f;
			}
			float currentLength = currentNoteAngle - currentAngle + creationAngle;

			if (currentLength >= lengthAngleDiff) 
			{
				currentNote = CreateNote (noteManager.GetNextNote (), currentNoteAngle - lengthAngleDiff);
			}
		} 
		else 
		{
			currentNote = CreateNote (noteManager.GetNextNote (), currentAngle + creationAngle);
		}
	}

	Note CreateNote(NoteSettings settings, float angle)
	{
		if (settings == null)
			return null;
		note = AvailableNotes [0];
		note.NoteSetting = settings;

		Quaternion rotation = note.transform.rotation;
		Vector3 eulerAngles = rotation.eulerAngles;
		eulerAngles.y = angle;
		rotation.eulerAngles = eulerAngles;
		note.transform.rotation = rotation;

		note.gameObject.SetActive (true);
		Notes.Add (note);
		AvailableNotes.RemoveAt (0);
		noteManager.currentNoteIndex++;
		return note;
	}
}
