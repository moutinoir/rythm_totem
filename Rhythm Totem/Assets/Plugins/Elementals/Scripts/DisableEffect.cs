using UnityEngine;
using System.Collections;

public class DisableEffect : MonoBehaviour {
    public void disableSprite() {
        Destroy(this.gameObject);
    }

	public void HideSprite(){
		this.gameObject.SetActive (false);
	}
}
