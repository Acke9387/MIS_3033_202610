//generate a random integer between 1 and 5
using System;

//Datatype variable = value;
Random rand = new Random();
int randomNumber = rand.Next(1, 5 + 1); // generates a number between 1 and 5

Console.WriteLine("We generated the random number " + randomNumber + ".");
int guess;

int numberOfGuesses = 0;

do
{
    Console.WriteLine("Please guess a number between 1 and 5 <<");
    string usersGuess = Console.ReadLine();
    guess = int.Parse(usersGuess);
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

