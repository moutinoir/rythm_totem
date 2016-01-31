using UnityEngine;
using System.Collections;

public class NoteSettings
{
	public buttonType Button
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

	public beatList Beat
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

	public int Length
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

	public NoteSettings (int length, beatList beat, buttonType button)
	{
		Length = length;
		Beat = beat;
		Button = button;
	}
}
