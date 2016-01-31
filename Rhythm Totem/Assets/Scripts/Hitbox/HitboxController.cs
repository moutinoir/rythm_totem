using UnityEngine;
using System.Collections;
using InControl;

public class HitboxController : MonoBehaviour 
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
		else if(note.gameObject.tag == "Miss")
		{
			Debug.Log("Miss!!!!");
		}
//		gameObject.SetActive(false);
	}

	void OnTriggerStay(Collider note)
	{
		if(note.gameObject.tag == "TargetNote")
		{
			InputDevice inputDevice = InputManager.ActiveDevice;
			// if the pressed button is buttontype

			Note noteComponent = note.transform.parent.GetComponent<Note> ();
			//(noteComponent.GetButtonType() == button)

		}
	}
}
