using System.Text;

namespace CryptoLab4.Algorithms;

public class PlayfairAlgorithm: ICryptoAlgorithm
{
	private const int _h = 6;
	private const int _w = 5;
	private readonly string _originalAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ_-.,";
	private string? _keyAlphabet;
	private char[,] _alphabetMatrix;

	public string KeyAlphabet => _keyAlphabet ?? InitKey();

	public PlayfairAlgorithm()
	{
		InitKey();
		InitMatrix();
	}

	public int Mode(int a, int m)
	{
		return (m + a)  % m;
	}

	private bool CheckIfHorizontal((int x, int y) a, (int x, int y) b)
	{
		return a.x == b.x;
	}
	
	private bool CheckIfVertical((int x, int y) a, (int x, int y) b)
	{
		return a.y == b.y;
	}

	private string GetHorizontalTransformedString((int x, int y) a, (int x, int y) b, bool isEncrypt = true)
	{
		a.x = Mode(a.x + (isEncrypt ? 1 : -1), _h);
		b.x = Mode(b.x + (isEncrypt ? 1 : -1), _h);
		var res = "";
		res += _alphabetMatrix[a.x, a.y].ToString() + _alphabetMatrix[b.x, b.y].ToString();
		return res;
	}
	
	private string GetVerticalTransformedString((int x, int y) a, (int x, int y) b, bool isEncrypt = true)
	{
		a.y = Mode(a.y + (isEncrypt ? 1 : -1), _w);
		b.y = Mode(b.y + (isEncrypt ? 1 : -1), _w);
		var res = "";
		res += _alphabetMatrix[a.x, a.y].ToString() + _alphabetMatrix[b.x, b.y].ToString();
		return res;
	}
	
	private string GetRectangleTransformedString((int x, int y) a, (int x, int y) b)
	{
		var res = "";
		res += _alphabetMatrix[b.x, a.y].ToString() + _alphabetMatrix[a.x, b.y].ToString();
		return res;
	}

	private string ProcessPair(string pair, bool isEncrypted = true)
	{
		var a = Find(pair.First());
		var b = Find(pair.Last());
		if (CheckIfHorizontal(a, b))
		{
			return GetHorizontalTransformedString(a, b, isEncrypted);
		}

		if (CheckIfVertical(a, b))
		{
			return GetVerticalTransformedString(a, b, isEncrypted);
		}

		return GetRectangleTransformedString(a, b);
	}

	private string ProcessText(string text, bool isEncrypt = true)
	{
		var clearedText = DeleteDoubleChars(text.ToUpper());
		var pairs = SliceText(clearedText);
		var res = pairs.Select(p => ProcessPair(p, isEncrypt)).ToArray();
		return string.Join("", res);
	}

	private void InitMatrix()
	{
		_alphabetMatrix = new char[_h, _w];
		var index = 0;
		foreach (var c in _keyAlphabet)
		{
			_alphabetMatrix[index / _w, index % _w] = c;
			index++;
		}
	}

	private (int x, int y) Find(char c)
	{
		for (int i = 0; i < _h; i++)
		{
			for (int j = 0; j < _w; j++)
			{
				if (c == _alphabetMatrix[i, j])
				{
					return new(i, j);
				}
			}
		}

		return new(-1, -1);
	}

	private string? InitKey()
	{
		Random rnd = new Random();
		_keyAlphabet = string.Join("", _originalAlphabet.OrderBy(x => rnd.Next()).ToArray());
		return _keyAlphabet;
	}
	
	private string[] SliceText(string text)
	{
		var res = DeleteDoubleChars(text);
		if (res.Length % 2 != 0)
		{
			res += "-";
		}
		return Enumerable.Range(0, res.Length / 2)
			.Select(i => res.Substring(i * 2, 2)).ToArray();
	}

	private string DeleteDoubleChars(string text)
	{
		char? last = null;
		var res = new StringBuilder(text);
		for (int i = 0; i < res.Length; i++)
		{
			if (res[i] == last)
			{
				res = res.Remove(i,1);
			}
		}

		return res.ToString();
	}

	public string EncryptString(string text)
	{
		return ProcessText(text);
	}

	public string DecryptString(string text)
	{
		return ProcessText(text, false);
	}

	public void PrintMatrix()
	{
		for (int i = 0; i < _h; i++)
		{
			for (int j = 0; j < _w; j++)
			{
				Console.Write($"{_alphabetMatrix[i, j]} ");
			}
			Console.Write(Environment.NewLine);
		}
	}
}