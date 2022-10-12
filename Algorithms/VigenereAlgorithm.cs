using System.Text;

namespace CryptoLab4.Algorithms;

public class VigenereAlgorithm: ICryptoAlgorithm
{
	private string _alphabet;
	private string _key;

	public VigenereAlgorithm(string alphabet, string key)
	{
		_alphabet = alphabet;
		_key = key;
	}

	private string Process(string text, bool isEncrypt = true)
	{
		int index = 0;
		var builder = new StringBuilder("");
		foreach (var c in text)
		{
			var position = _alphabet.IndexOf(c, StringComparison.OrdinalIgnoreCase);
			var keyPos = _alphabet.IndexOf(_key[index % _key.Length]);
			builder.Append(_alphabet[(_alphabet.Length + position + keyPos * (isEncrypt ? 1 : -1)) % _alphabet.Length]);
			index++;
		}

		return builder.ToString();
	}
	
	public string EncryptString(string text)
	{
		return Process(Helper.NormalizeText(text));
	}

	public string DecryptString(string text)
	{
		return Process(Helper.NormalizeText(text), false);
	}
}