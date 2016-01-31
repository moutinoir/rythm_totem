using UnityEngine;
using System.Collections.Generic;

public class NotePool : MonoBehaviour 
{
	GameObject rotatingCameraPivot;
	public float behindPoleBegin = 170.0f;
	public float behindPoleEnd = 190.0f;

	public List<Note> AvailableNotes = new List<Note> ();
	public List<Note> Notes = new List<Note> ();

	void Start()
	{
		rotatingCameraPivot = GameObject.FindWithTag ("RotatingCameraPivot");
	}

	float GetCurrentAngle()
	{
		return rotatingCameraPivot.transform.rotation.eulerAngles.y;
	}

	private Note note;

	void Update()
	{
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
}
