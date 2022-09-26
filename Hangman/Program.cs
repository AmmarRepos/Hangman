// Hangman game
using System;
using System.Text;

StringBuilder rightGuesses = new StringBuilder();
StringBuilder wrongGuesses = new StringBuilder();
StringBuilder guesses = new StringBuilder();
string guess;

string[] secrets = new string[] { "ddafadsfa", "daadferre", "afadfd", "raewr", "adfadf", "adsfadfs" };

static string GenSecret(string[] secrets)
{
    var random = new Random();
    var randomNumber = random.Next(secrets.Length);
    string secret = secrets[randomNumber];
    Console.WriteLine(secret);
    return secret;
}

string secret = GenSecret(secrets);

static string ShowSecret(string secret, string guesses)
{
    StringBuilder sb = new StringBuilder();
    foreach (char c in secret)
    {
        if (guesses.Contains(c))
            sb.Append($"{c} ");
        else
            sb.Append($"_ ");
    }
    Console.WriteLine($"The Secret: {sb.ToString()}");
    return sb.ToString();
}


int numOfGuesses = 10;
//Console.WriteLine(ShowSecret(secret,""));
string ans = "";
do
{
    Console.Write($"This is your {11 - numOfGuesses} guess, left {numOfGuesses} guess: ");
    guess = Console.ReadLine();
    if (guess == "" || guesses.ToString().Contains(guess))
        continue;
    else if (secret == guess)
    {
        ans = ShowSecret(secret, guess);
        break;
    }
    else if (guess.Length > 1)
    {
        numOfGuesses--;
    }
    else if (!secret.Contains(guess))
    {
        wrongGuesses.Append(guess);
        guesses.Append(guess);
        numOfGuesses--;
    }
    else
    {
        rightGuesses.Append(guess);
        guesses.Append(guess);
        numOfGuesses--;
    }
    ans = ShowSecret(secret, rightGuesses.ToString());
    Console.WriteLine($"Your wrong guess are: {wrongGuesses.ToString()}");
    if (! ans.Contains("_"))
        break;
}
while (numOfGuesses > 0);


if (ans.Contains("_"))
    Console.WriteLine("Loser");
else
    Console.WriteLine($"You win.\nThe secret is: {secret}");

