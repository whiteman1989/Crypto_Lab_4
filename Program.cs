// See https://aka.ms/new-console-template for more information

using CryptoLab4;
using CryptoLab4.Algorithms;

ICryptoAlgorithm atabash = new AtabashAlgorithm("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
ICryptoAlgorithm password = new PassWordAlgorithm("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "WORLD");
ICryptoAlgorithm cesar = new CesarAlgorithm("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 5);
Console.Write("Enter text for encrypt: ");
var text = Console.ReadLine();
Console.WriteLine("Atabash --->>");
ProcessText(text, atabash);
Console.WriteLine("Password --->>");
ProcessText(text, password);
Console.WriteLine("Cesar --->>");
ProcessText(text, cesar);


void ProcessText(string text, ICryptoAlgorithm algorithm)
{
	Console.Write("Encrypting -->> ");
	var res = algorithm.EncryptString(text);
	Console.WriteLine(res);
	Console.Write("Decrypting -->> ");
	var decrRes = algorithm.DecryptString(res);
	Console.WriteLine(decrRes);
}
