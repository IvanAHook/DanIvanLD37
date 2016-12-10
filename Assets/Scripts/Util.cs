public static class Util
{

	public static float RemapFloat(float value, float fromLow, float fromHigh, float toLow, float toHigh)
	{
		return toLow + (value - fromLow) * (toHigh - toLow) / (fromHigh - fromLow);
	}

}
