// See https://aka.ms/new-console-template for more information

using CryptoLab4;
using CryptoLab4.Algorithms;

string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ_";

ICryptoAlgorithm password = new PassWordAlgorithm(alphabet, "WORLD");
var simpleChangeKey = SimpleChange.CreateKey(alphabet.Length);
ICryptoAlgorithm simpleChange = new SimpleChange(alphabet, simpleChangeKey);
var vigenereKey = "MAINPROCES";
ICryptoAlgorithm vigenere = new VigenereAlgorithm(alphabet, vigenereKey);
ICryptoAlgorithm playfairAlgorithm = new PlayfairAlgorithm();
ICryptoAlgorithm vertical = new VerticalChangesAlgorithm("SHOTQ2_JZG");

Console.Write("Enter text for encrypt: ");
var text = Console.ReadLine();
Console.WriteLine("Password --->>");
ProcessText(text, password);
Console.WriteLine($"SimpleChange --->> with key: {string.Join(",",simpleChangeKey)}");
ProcessText(text, simpleChange);
Console.WriteLine($"Vigenere --->> with key: {vigenereKey}");
ProcessText(text, vigenere);
Console.WriteLine($"Playfair --->> with key:");
(playfairAlgorithm as PlayfairAlgorithm).PrintMatrix();
ProcessText(text, playfairAlgorithm);
Console.WriteLine($"Vertical --->> with key: " + "SHOTQ2_JZG");
ProcessText("Horban Andrii PPZ-51 DUT TEST STRING", vertical);



void ProcessText(string text, ICryptoAlgorithm algorithm)
{
	Console.Write("Encrypting -> ");
	var res = algorithm.EncryptString(text);
	Console.WriteLine(res);
	Console.Write("Decrypting -> ");
	var decrRes = algorithm.DecryptString(res);
	Console.WriteLine(decrRes);
}
