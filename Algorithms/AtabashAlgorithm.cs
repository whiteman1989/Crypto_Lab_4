using System.Text;

namespace CryptoLab4.Algorithms;

public class AtabashAlgorithm: ICryptoAlgorithm
{

	#region Fields: private

	private string _alphabet;
	private string _revertedAlphabet;

	#endregion
	
	#region Constructors: Public

	public AtabashAlgorithm(string alphabet)
	{
		_alphabet = alphabet;
		_revertedAlphabet = new string(alphabet.Reverse().ToArray());
	}

	#endregion

	#region Methods Public

	public string EncryptString(string text)
	{
		return Helper.TransformText(text, _alphabet, _revertedAlphabet);
	}

	public string DecryptString(string text)
	{
		return Helper.TransformText(text, _revertedAlphabet, _alphabet);
	}

	#endregion

}