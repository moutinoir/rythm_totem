using UnityEngine;
using System.Collections;
using InControl;

public class HitboxController : MonoBehaviour 
{
	public buttonType button;

	[SerializeField]
	private NoteManager notemanager;

	void OnTriggerEnter(Collider note)
	{
		if(note.gameObject.tag == "TargetNote")
		{
			notemanager.NoteHit();
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

			Note noteComponent = note.gameObject.GetComponent<Note> ();
			//(noteComponent.GetButtonType() == button)



		}
	}
}
