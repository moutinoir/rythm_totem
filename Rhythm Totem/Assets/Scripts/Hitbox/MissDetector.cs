using UnityEngine;
using System.Collections;
using InControl;

public class MissDetector : MonoBehaviour 
{
	private NoteManager noteManager;

	void Start()
	{
		noteManager = GameObject.FindWithTag("NoteManager").GetComponent<NoteManager> ();
	}

	void OnTriggerEnter(Collider note)
	{
		if(note.gameObject.tag == "TargetNote")
		{
			Note noteComponent = note.transform.parent.GetComponent<Note> ();
			if(!noteComponent.Played)
				noteComponent.Miss ();
		}
	}
}
