// Hangman game
using System;
using System.Text;

StringBuilder rightGuesses = new StringBuilder();
StringBuilder wrongGuesses = new StringBuilder();
StringBuilder guesses = new StringBuilder();
string guess;
//string[] listOfSecrets = new string[5] { "test", "philosophy", "something", "better", "why" };

static string GenSecret()
{
    string chars = "abcdefghijklmnopqrstuvwxyz";
    var output = new StringBuilder();
    var random = new Random();
    for (int i = 0; i < 10; i++)
    {
        var randomNumber = random.Next(chars.Length);
        var randomChar = chars[randomNumber];
        output.Append(randomChar);
    }
    Console.WriteLine(output.ToString());
    return output.ToString();
}

string secret = GenSecret();

static string ShowSecret(string secret, string revealed)
{
    StringBuilder sb = new StringBuilder();
    foreach (char c in secret)
    {
        if (revealed.Contains(c))
        {
            sb.Append(c);
        }
        else
        {
            sb.Append("_");
        }
    }
    string sbb = sb.ToString();
    Console.WriteLine($"The Secret: {sbb}");
    return sbb;
}


static void OneTimeGuess(string guess, string secret)
{
    if (guess == secret)
        Console.WriteLine("Win");
    else
        Console.WriteLine("loose");
}

int numOfGuesses = 10;
string ans = "";
do
{
    Console.Write($"This is your {11 - numOfGuesses} guess, left {numOfGuesses} guess: ");
    guess = Console.ReadLine();
    if (guesses.ToString().Contains(guess))
    {
        continue;
    }
    else if (! secret.Contains(guess))
    {
        wrongGuesses.Append(guess);
        guesses.Append(guess);
    }
    else
    {
        rightGuesses.Append(guess);
        guesses.Append(guess);
    }
    Console.WriteLine($"Your wrong are: {wrongGuesses.ToString()}");
    numOfGuesses--;
    ans = ShowSecret(secret, rightGuesses.ToString());
    if (! ans.Contains("_"))
        break;
}
while (numOfGuesses > 0);


if (ans.Contains("_"))
{
    Console.WriteLine("Loser");
}
else
    Console.WriteLine("Winner");

