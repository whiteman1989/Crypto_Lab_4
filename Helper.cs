using System.Text;

namespace CryptoLab4;

public static class Helper
{
	public static int FindCharPosition(char c, string alphabet)
	{
		var position = alphabet.IndexOf(c, StringComparison.OrdinalIgnoreCase);
		if (position < 0)
		{
			throw new ArgumentException("target alphabet dp not contain character from this text");
		}

		return position;
	}
	
	public static string TransformText(string text, string fromAlphabet, string toAlphabet)
	{
		var builder = new StringBuilder("");
		foreach (var c in text)
		{
			var pos = FindCharPosition(c, fromAlphabet);
			builder.Append(toAlphabet[pos]);
		}

		return builder.ToString();
	}
}