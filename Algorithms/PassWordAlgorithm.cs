using System.Text;

namespace CryptoLab4.Algorithms;

public class PassWordAlgorithm: ICryptoAlgorithm
{

	#region Fields: Private

	private readonly string _alphabet;
	private readonly string _alphabetWithPassword;

	#endregion

	#region Constructors: Private

	public PassWordAlgorithm(string alphabet, string password)
	{
		_alphabet = alphabet;
		_alphabetWithPassword = AddPasswordToString(alphabet, password);
	}

	#endregion

	#region Methods: Private

	private string AddPasswordToString(string alphabet, string password)
	{
		var result = alphabet;

		foreach (var c in password)
		{
			result = result.Replace(c.ToString(), String.Empty);
		}
		
		result = password + result;

		return result;
	}
	
	
	
	#endregion

	#region Methods: Public

	public string EncryptString(string text)
	{
		return Helper.TransformText(text, _alphabet, _alphabetWithPassword);
	}

	public string DecryptString(string text)
	{
		return Helper.TransformText(text, _alphabetWithPassword, _alphabet);
	}	

	#endregion

}