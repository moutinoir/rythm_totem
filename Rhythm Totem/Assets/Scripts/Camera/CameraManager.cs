using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour 
{
	public Vector3 rotationSpeed;
	GameObject RotatingCameraPivot;

	void Start()
	{
		RotatingCameraPivot = GameObject.FindWithTag ("RotatingCameraPivot");
	}

	void RotatePivot(Vector3 rotationSpeed)
	{
		RotatingCameraPivot.transform.Rotate (rotationSpeed * Time.deltaTime);
	}

	void Update()
	{
		RotatePivot (rotationSpeed);
	}
}
