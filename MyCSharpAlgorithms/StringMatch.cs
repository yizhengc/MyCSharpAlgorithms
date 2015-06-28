using System;

public class StringMatch {
	public static int StrStr(string haystack, string needle) {
		if (haystack == null || needle == null || haystack.Length < needle.Length)
		{
			return -1;
		}

		for(int i = 0; i <= haystack.Length - needle.Length; i++)
		{
			if (Match(haystack, i, needle))
			{
				return i;
			}
		}

		return -1;
	}

	public static bool Match(string haystack, int offset, string needle)
	{
		if (needle == string.Empty)
		{
			return true;
		}

		for (int i = 0; i < needle.Length; i++)
		{
			if (haystack[offset + i] != needle[i])
			{
				return false;
			}
		}

		return true;
	}
}

