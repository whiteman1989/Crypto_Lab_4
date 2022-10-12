using System.Text;

namespace CryptoLab4.Algorithms;

public class VerticalChangesAlgorithm: ICryptoAlgorithm
{
	private string _key;
	private int[] _KeyNum;

	public VerticalChangesAlgorithm(string key)
	{
		_key = key;
		var sortedKey = _key.OrderBy(c => c);
		int i = 0;
		var keyWithNums = sortedKey.ToDictionary(c => c, c =>
		{
			var res = i;
			i++;
			return res;
		});
		_KeyNum = _key.Join(keyWithNums,
			k => k,
			k2 => k2.Key,
			(k, k2) => k2.Value).ToArray();
	}

	private char[,] TextToMatrix(string text)
	{
		int w = _KeyNum.Length;
		int h = text.Length / _KeyNum.Length + (((text.Length % _KeyNum.Length) > 0) ? 1 : 0);
		var res = new char[h, w];
		var chunkedText = SliceText(text, w);
		for (int i = 0; i < h; i++)
		{
			for (int j = 0; j < w && j < chunkedText[i].Length; j++)
			{
				res[i, j] = chunkedText[i][j];
			}
		}

		return res;
	}

	private string EncryptProcess(string text)
	{
		var matrix = TextToMatrix(text);
		var builder = new StringBuilder("");
		foreach (var i in _KeyNum)
		{
			for (int j = 0; j < matrix.GetLength(0); j++)
			{
				builder.Append(matrix[j, i]);
			}
		}

		return builder.ToString();
	}
	
	private string[] SliceText(string text, int size)
	{
		return ChunksUpto(text, size).ToArray();
	}
	
	static IEnumerable<string> ChunksUpto(string str, int maxChunkSize) {
		for (int i = 0; i < str.Length; i += maxChunkSize) 
			yield return str.Substring(i, Math.Min(maxChunkSize, str.Length-i));
	}

	public string EncryptString(string text)
	{
		return EncryptProcess(text);
	}

	public string DecryptString(string text)
	{
		return "-------------";
	}
}