using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MyEvent
{
	PAUSE,
	RESUME,
	PLAYER_DEATH,
	LEVEL_CLEAR
}

public class UEvent
{
	public MyEvent eventType;

	public object eventParams;

	public object target;

	public UEvent(MyEvent eventType, object eventParams = null)
	{
		this.eventType = eventType;
		this.eventParams = eventParams;
	}
}