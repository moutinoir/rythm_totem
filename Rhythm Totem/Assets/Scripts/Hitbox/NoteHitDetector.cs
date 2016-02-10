using UnityEngine;
using System.Collections;
using InControl;

public class NoteHitDetector : MonoBehaviour 
{
	public buttonType button;

	private NoteManager noteManager;

	void Start()
	{
		noteManager = GameObject.FindWithTag("NoteManager").GetComponent<NoteManager> ();
	}

	void OnTriggerEnter(Collider note)
	{
		if(note.gameObject.tag == "TargetNote")
		{
			noteManager.NoteHit();
			Note noteComponent = note.transform.parent.GetComponent<Note> ();
			noteComponent.GetHit ();
		}
	}
}
