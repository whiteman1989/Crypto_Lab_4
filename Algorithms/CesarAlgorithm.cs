using System.Text;

namespace CryptoLab4.Algorithms;

public class CesarAlgorithm: ICryptoAlgorithm
{
	#region Fields: Private

	private string _alphabet;
	private string _shiftedAlphabet;

	#endregion

	#region Construcotrs: Pubclic

	public CesarAlgorithm(string alphabet, int shift)
	{
		_alphabet = alphabet;
		_shiftedAlphabet = GetShiftedAlphabet(alphabet, shift);
	}

	#endregion

	#region Methods: Private

	private string GetShiftedAlphabet(string alphabet, int shift)
	{
		return alphabet.Remove(0, shift) + alphabet.Substring(0, shift);
	}

	#endregion
	
	#region Methods: Public

	public string EncryptString(string text)
	{
		return Helper.TransformText(text, _alphabet, _shiftedAlphabet);
	}

	public string DecryptString(string text)
	{
		return Helper.TransformText(text, _shiftedAlphabet, _alphabet);
	}

	#endregion
	
}