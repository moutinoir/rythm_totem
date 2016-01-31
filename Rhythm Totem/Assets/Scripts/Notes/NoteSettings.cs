using UnityEngine;
using System.Collections;

public class NoteSettings
{
	buttonType Button
	{
		get 
		{
			return button;
		}
		set 
		{
			button = value;
		}
	}

	beatList Beat
	{
		get 
		{
			return beat;
		}
		set 
		{
			beat = value;
		}
	}

	int Length
	{
		get 
		{
			return length;
		}
		set 
		{
			length = value;
		}
	}

	private int length = 1;
	private beatList beat = beatList.dum1;
	private buttonType button = buttonType.greenbtn;

	NoteSettings (int length, beatList beat, buttonType button)
	{
		Length = length;
		Beat = beat;
		Button = button;
	}
}
