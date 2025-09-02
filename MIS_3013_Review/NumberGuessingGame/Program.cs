//generate a random integer between 1 and 5
using System;

Console.WriteLine("Welcome to our game!");

Console.WriteLine("Please input the lower bound value (lowest value that could be guessed)? <<");
string answer = Console.ReadLine();
int lowerBound = ValidateInput(answer, "Invalid number, please input a proper lower bound >>");





//try
//{
//    lowerBound = int.Parse(answer);
//}
//catch (FormatException ex)
//{

//    Console.WriteLine("Sorry, invalid input"); 
//}
//catch(Exception ex)
//{
//    Console.WriteLine($"No one knows what went wrong\n {ex.Message}");
//}

Console.WriteLine("Please input the upper bound value (highest value that could be guessed)? <<");
answer = Console.ReadLine();
int upperBound = ValidateInput(answer, "Invalid number, please input a proper upper bound >>");

for (int i = 0; i < int.MaxValue; i++)
{
    //Datatype variable = value;
    Random rand = new Random();
    int randomNumber = rand.Next(lowerBound, upperBound + 1); // generates a number between 1 and 5

    Console.WriteLine("We generated the random number " + randomNumber + ".");
    int guess;

    int numberOfGuesses = 0;

    do
    {
        Console.WriteLine($"Please guess a number between {lowerBound.ToString("N0")} and {upperBound.ToString("N0")} <<");
        string usersGuess = Console.ReadLine();
        guess = ValidateInput(answer, "Invalid number, please input a proper guess >>");
        //guess = Convert.ToInt32(guess);
        numberOfGuesses++;
        //numberOfGuesses = numberOfGuesses + 1;
        //numberOfGuesses += 1;

        Console.WriteLine($"You guessed {usersGuess}");


        //if (randomNumber == guess)
        //{
        //    Console.WriteLine("Congratulations, you guessed correctly!");
        //}
        //else
        //{
        //    Console.WriteLine("Sorry, you guessed wrong.");
        //}

        if (randomNumber != guess)
        {
            if (randomNumber > guess)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You guessed too low! Try again.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("You guessed too high! Try again.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }


    } while (randomNumber != guess);

    Console.WriteLine($"Congratulations, you guessed correctly in {numberOfGuesses} attempts!");

    Console.WriteLine("Do you want to play again? yes or no");
    answer = Console.ReadLine();

    if (answer != "yes") // (answer == "no")
    {
        break;
    }
}


///<summary>This function takes a string and validates that it is an integer.  If it is not, it will display the message</summary>
///
///
int ValidateInput(string? a, string message)
{
    int convertedValue = 0;
    while (int.TryParse(a, out convertedValue) == false)
    {
        Console.WriteLine(message);
        a = Console.ReadLine();

    }

    return convertedValue;
}
