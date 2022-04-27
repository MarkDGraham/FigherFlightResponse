using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
	static float EPSILON = 0.05f;
	public static bool Approximation(float a, float b)
	{
		return Mathf.Abs(a - b) < EPSILON;
	}

	public static float Clamp(float value, float min, float max)
	{
		if (value < min)
			value = min;
		else if (value > max)
			value = max;
		return value;
	}

	public static float DegreeClamp(float angle)
	{
		if (angle >= 360)
			angle -= 360;
		else if (angle < 0)
			angle += 360;

		return angle;
	}

	public static float AngleDiffPosNeg(float a, float b)
	{
		float diff = a - b;
		if (diff > 180)
			return diff - 360;
		else if (diff < -180)
			return diff + 360;

		return diff;
	}

}
