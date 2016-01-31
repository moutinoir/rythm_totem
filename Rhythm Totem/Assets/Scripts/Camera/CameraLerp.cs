using UnityEngine;
using System.Collections;

public class CameraLerp : MonoBehaviour {

	public GameObject Camera;
	public Transform StartCameraPos;
	public Transform GameCameraPos;
	public bool GotoGame;
	public bool LerpDone = false;
	private Vector3 StartPos;
	private Quaternion StartRot;

	public float speed;
	private float journeyLength;
	private float distCovered;
	private float fracJourney;
	private float startTime;

	void SetLerp()
	{
		StartPos = Camera.transform.position;
		StartRot = Camera.transform.rotation;

		startTime = Time.time;

		if(GotoGame)
			journeyLength = Vector2.Distance(StartPos, GameCameraPos.position);
		else if(!GotoGame)
			journeyLength = Vector2.Distance(StartPos, StartCameraPos.position);
	}

	void LerpCameraGamePos()
	{
		distCovered = (Time.time - startTime) * speed;
		fracJourney = distCovered / journeyLength;
		Camera.transform.position = Vector3.Lerp(StartPos, GameCameraPos.position, fracJourney);
		Camera.transform.rotation = Quaternion.Lerp(StartRot, GameCameraPos.rotation, fracJourney);
	}

	IEnumerator CallLerpGamePos()
	{
		SetLerp();

		while (Vector3.Distance(Camera.transform.position, GameCameraPos.position) > 0.1f && !LerpDone)
		{
			LerpCameraGamePos();
			yield return new WaitForEndOfFrame();
		}
		LerpDone = true;
		Camera.transform.position = GameCameraPos.position;
	}

	void LerpCameraStartPos()
	{
		distCovered = (Time.time - startTime) * speed;
		fracJourney = distCovered / journeyLength;
		Camera.transform.position = Vector3.Lerp(StartPos, StartCameraPos.position, fracJourney);
		Camera.transform.rotation = Quaternion.Lerp(StartRot, StartCameraPos.rotation, fracJourney);
	}

	IEnumerator CallLerpStartPos()
	{
		SetLerp();
		while (Vector2.Distance(Camera.transform.position, StartCameraPos.position) > 0.1f && !LerpDone)
		{
			LerpCameraGamePos();
			yield return new WaitForEndOfFrame();
		}
		LerpDone = true;
		Camera.transform.position = StartCameraPos.position;
	}

	void Start()
	{
		if(GotoGame && !LerpDone)
		{
			StartCoroutine(CallLerpGamePos());	
		}
		else
		{
			StartCoroutine(CallLerpStartPos());	
		}
			
	}
}
