using System.Text;

namespace CryptoLab4.Algorithms;

public class SimpleChange: ICryptoAlgorithm
{
	private string _alphabet;
	private int[] _key;

	public SimpleChange(string alphabet, int[] key)
	{
		_alphabet = alphabet;
		_key = key;
	}

	private char CodeSymbol(char c)
	{
		var position = _alphabet.IndexOf(c, StringComparison.OrdinalIgnoreCase);
		if (position < 0)
		{
			return '*';
		}
		var codedPosition = _key[position];
		return _alphabet[codedPosition];
	}

	private char DecodeSymbol(char c)
	{
		var position = _alphabet.IndexOf(c, StringComparison.OrdinalIgnoreCase);
		if (position < 0)
		{
			throw new ArgumentException("target alphabet dp not contain character from this text");
		}
		var decodePosition = _key.ToList().IndexOf(position);
		return _alphabet[decodePosition];
	}

	public static int[] CreateKey(int size)
	{
		int[] arr = Enumerable.Range(0, size).ToArray();
		Random rnd = new Random();
		return arr.OrderBy(x => rnd.Next()).ToArray(); 
	}
	
	public string EncryptString(string text)
	{
		var normalizedText = Helper.NormalizeText(text);
		var builder = new StringBuilder("");
		foreach (var c in normalizedText)
		{
			builder.Append(CodeSymbol(c));
		}

		return builder.ToString();
	}

	public string DecryptString(string text)
	{
		var normalizedText = Helper.NormalizeText(text);
		var builder = new StringBuilder("");
		foreach (var c in normalizedText)
		{
			builder.Append(DecodeSymbol(c));
		}

		return builder.ToString();
	}
}