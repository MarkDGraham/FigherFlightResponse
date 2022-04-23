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
}
