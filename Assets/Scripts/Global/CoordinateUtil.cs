using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinateUtil 
{
	public static Quaternion TurnToDir(Vector2 target, Vector2 self)
	{
		float y = target.y - self.y;
		float x = target.x - self.x;
		float a = Mathf.Atan2(y, x) * Mathf.Rad2Deg + 90;
		Quaternion angle = Quaternion.Euler(0f, 0f, a);
		return angle;
	}

	public static Vector2 GetNormalLine(Vector2 a, Vector2 b)
	{
		Vector2 temp = b - a;
		float x = temp.x;
		temp.x = temp.y;
		temp.y = -x;
		return temp;
	}
}
