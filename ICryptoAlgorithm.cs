namespace CryptoLab4;

public interface ICryptoAlgorithm
{
	string EncryptString(string text);
	string DecryptString(string text);
}