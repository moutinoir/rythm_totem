using UnityEngine;
using System.Collections;

public class HitboxController : MonoBehaviour {

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
		gameObject.transform.position += new Vector3(0, 3);
	}
}
