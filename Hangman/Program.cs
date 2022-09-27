// Hangman game
using System.Text;

static string GenSecret(string[] secrets)
{
    var random = new Random();
    var randomNumber = random.Next(secrets.Length);
    string secret = secrets[randomNumber];
    //Console.WriteLine(secret);
    return secret;
}

static string BuildAnswer(string secret, string guesses)
{
    StringBuilder sb = new StringBuilder();
    foreach (char c in secret)
    {
        if (guesses.Contains(c))
            sb.Append(c);
        else
            sb.Append("_");
    }
    return sb.ToString();
}

static void Formater(string text)
{
    StringBuilder sb = new StringBuilder();
    foreach (char c in text)
    {
        if (c == char.Parse("_"))
            sb.Append($"{c} ");
        else
            sb.Append($"{c}");
    }
    Console.WriteLine($"Your secret looks like: {sb.ToString()}");
}

static void AnnounceWin(string secret)
{
    Console.WriteLine($"You win.\nThe secret is: {secret}");
}

static void AnnounceLost(string secret)
{
    Console.WriteLine($"Game Over.\nThe secret was {secret}");
}

string[] secrets = new string[] { "philosophy", "Right", "Wrong", "Screen", "TEST", "Bottle" };
StringBuilder wrongGuesses = new StringBuilder();
StringBuilder guesses = new StringBuilder();
char[] rightGuesses = new char[10];
string guess = "";
string secret = GenSecret(secrets);
int numOfGuesses = 10;
string ans;


while (true)
{
    ans = BuildAnswer(secret, string.Join("", rightGuesses));
    if (guess == secret)
    {
        AnnounceWin(secret);
        break;
    }
    else if (ans == secret)
    {
        AnnounceWin(secret);
        break;
    }
    else if (numOfGuesses == 0)
    {
        AnnounceLost(secret);
        break;
    }
    else if (guess == "")
    {
        Formater(ans);
        Console.WriteLine($"Your wrong guess are: {wrongGuesses.ToString()}");
        Console.WriteLine($"Please input your {11 - numOfGuesses} guess of 10:");
        guess = Console.ReadLine()!;
        continue;
    }
    else if (guesses.ToString().Contains(guess))
    {
        guess = "";
        continue;
    }
    else if (guess.Length > 1)
    {
        numOfGuesses--;
        guess = "";
    }
    else if (!secret.Contains(guess))
    {
        wrongGuesses.Append(guess);
        guesses.Append(guess);
        guess = "";
        numOfGuesses--;
    }
    else if (secret.Contains(guess))
    {
        rightGuesses[numOfGuesses] = char.Parse(guess);
        guesses.Append(guess);
        guess = "";
        numOfGuesses--;
    }   
}
