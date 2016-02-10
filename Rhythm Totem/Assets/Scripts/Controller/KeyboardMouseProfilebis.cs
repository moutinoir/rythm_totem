﻿using System;
using System.Collections;
using UnityEngine;
using InControl;

// This custom profile is enabled by adding it to the Custom Profiles list
// on the InControlManager component, or you can attach it yourself like so:
// InputManager.AttachDevice( new UnityInputDevice( "KeyboardAndMouseProfile" ) );
// 
public class KeyboardMouseProfilebis : UnityInputDeviceProfile
{
    public KeyboardMouseProfilebis()
    {
        Name = "Keyboard/Mouse";
        Meta = "A keyboard and mouse combination profile appropriate for FPS.";

        // This profile only works on desktops.
        SupportedPlatforms = new[]
        {
            "Windows",
            "Mac",
            "Linux"
        };

        Sensitivity = 1.0f;
        LowerDeadZone = 0.0f;
        UpperDeadZone = 1.0f;

        ButtonMappings = new[]
        {
            new InputControlMapping
            {
                Handle = "Fire - Mouse",
                Target = InputControlType.Action1,
                Source = MouseButton0
            },
            new InputControlMapping
            {
                Handle = "Fire - Keyboard",
                Target = InputControlType.Action1,
				// KeyCodeButton fires when any of the provided KeyCode params are down.
				Source = KeyCodeButton( KeyCode.F, KeyCode.Return, KeyCode.E )
            },
            new InputControlMapping
            {
                Handle = "AltFire",
                Target = InputControlType.Action2,
                Source = MouseButton2
            },
            new InputControlMapping
            {
                Handle = "AltFire",
                Target = InputControlType.Action2,
                Source = KeyCodeButton( KeyCode.Space, KeyCode.Q )
            },
            new InputControlMapping
            {
                Handle = "Middle",
                Target = InputControlType.Action3,
                Source = MouseButton1
            },
            new InputControlMapping
            {
                Handle = "Jump",
                Target = InputControlType.Action4,
                Source = KeyCodeButton( KeyCode.Space )
            },
			new InputControlMapping
			{
				Handle = "LeftB",
				Target = InputControlType.LeftTrigger,
				Source = KeyCodeButton( KeyCode.F )
			},
			new InputControlMapping
			{
				Handle = "LeftMiddleB",
				Target = InputControlType.LeftBumper,
				Source = KeyCodeButton( KeyCode.G )
			},
			new InputControlMapping
			{
				Handle = "RightMiddleB",
				Target = InputControlType.RightBumper,
				Source = KeyCodeButton( KeyCode.H )
			},
			new InputControlMapping
			{
				Handle = "RightB",
				Target = InputControlType.RightTrigger,
				Source = KeyCodeButton( KeyCode.J )
			},
        };

        AnalogMappings = new[]
        {
            new InputControlMapping
            {
                Handle = "Move X",
                Target = InputControlType.LeftStickX,
				// KeyCodeAxis splits the two KeyCodes over an axis. The first is negative, the second positive.
				Source = KeyCodeAxis( KeyCode.A, KeyCode.D )
            },
            new InputControlMapping
            {
                Handle = "Move Y",
                Target = InputControlType.LeftStickY,
				// Notes that up is positive in Unity, therefore the order of KeyCodes is down, up.
				Source = KeyCodeAxis( KeyCode.S, KeyCode.W )
            },
            new InputControlMapping {
                Handle = "Move X Alternate",
                Target = InputControlType.LeftStickX,
                Source = KeyCodeAxis( KeyCode.LeftArrow, KeyCode.RightArrow )
            },
            new InputControlMapping {
                Handle = "Move Y Alternate",
                Target = InputControlType.LeftStickY,
                Source = KeyCodeAxis( KeyCode.DownArrow, KeyCode.UpArrow )
            },
            new InputControlMapping
            {
                Handle = "Look X",
                Target = InputControlType.RightStickX,
                Source = MouseXAxis,
                Raw    = true,
                Scale  = 0.1f
            },
            new InputControlMapping
            {
                Handle = "Look Y",
                Target = InputControlType.RightStickY,
                Source = MouseYAxis,
                Raw    = true,
                Scale  = 0.1f
            },
            new InputControlMapping
            {
                Handle = "Look Z",
                Target = InputControlType.ScrollWheel,
                Source = MouseScrollWheel,
                Raw    = true,
                Scale  = 0.1f
            },
			new InputControlMapping
			{
				Handle = "LeftB",
				Target = InputControlType.LeftTrigger,
				Source = KeyCodeButton( KeyCode.F )
			},
			new InputControlMapping
			{
				Handle = "LeftMiddleB",
				Target = InputControlType.LeftBumper,
				Source = KeyCodeButton( KeyCode.G )
			},
			new InputControlMapping
			{
				Handle = "RightMiddleB",
				Target = InputControlType.RightBumper,
				Source = KeyCodeButton( KeyCode.H )
			},
			new InputControlMapping
			{
				Handle = "RightB",
				Target = InputControlType.RightTrigger,
				Source = KeyCodeButton( KeyCode.J )
			},
        };
    }
}

