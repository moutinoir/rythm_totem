using UnityEngine;
using System.Collections;
using InControl;

public enum Pressedbutton{
	leftBumperPressed,
	leftTriggerPressed,
	rightTriggerPressed,
	rightBumperPressed,
	invalid,
}

public class ControllerManager : MonoBehaviour {

	public static ControllerManager controllermanager { get; private set; }

	bool leftTriggerPressed;
	bool rightTriggerPressed;
	bool leftBumperPressed;
	bool rightBumperPressed;

	Pressedbutton currentPressedbutton;

	void Awake() 
	{
		if(controllermanager != null && controllermanager != this)
		{
			Destroy(gameObject);
		}

		controllermanager = this;

		DontDestroyOnLoad(gameObject);
	}

	void Update()
	{
		InputDevice inputDevice = InputManager.ActiveDevice;
		if (!inputDevice.LeftTrigger.IsPressed) 
		{
			leftTriggerPressed = false;
		}
		if(!inputDevice.LeftBumper.IsPressed)
		{
			leftBumperPressed = false;
		}
		if(!inputDevice.RightBumper.IsPressed)
		{
			rightBumperPressed = false;
		}
		if(!inputDevice.RightTrigger.IsPressed)
		{
			rightTriggerPressed = false;
		}		

		if (inputDevice.LeftTrigger.IsPressed && !leftTriggerPressed) 
		{
			leftTriggerPressed = true;
			currentPressedbutton = Pressedbutton.leftTriggerPressed;
		}
		else if(inputDevice.LeftBumper.IsPressed && !leftBumperPressed)
		{
			leftBumperPressed = true;
			currentPressedbutton = Pressedbutton.leftBumperPressed;
		}
		else if(inputDevice.RightBumper.IsPressed && !rightBumperPressed)
		{
			rightBumperPressed = true;
			currentPressedbutton = Pressedbutton.rightBumperPressed;
		}
		else if(inputDevice.RightTrigger.IsPressed && !rightTriggerPressed)
		{
			rightTriggerPressed = true;
			currentPressedbutton = Pressedbutton.rightTriggerPressed;
		}	
		else
		{
			currentPressedbutton = Pressedbutton.invalid;
		}

		//Debug.Log(currentPressedbutton);
	}

	public int GetCurrentPressed()
	{
		return (int)currentPressedbutton;
	}
}
