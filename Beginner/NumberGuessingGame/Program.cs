using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuessing
{
    class Program
    { 
        static void Main(string[] args)
        {
            /* generating a random number 
             * ask user to guess -> console.readline
             * compare the guess with the secret random number 
             * tell the user if it/s too high or too low 
             * repeat till the guess is right
             *
             *
             *advanced - putting a score system with each fail trial reduce one 
             *
             */
            bool playAgain = true;
            while (playAgain)
            {
                Random random = new Random();
                int secretNumber = random.Next(1, 100);

                int userGuess = 0;
                int attemps = 0;
                int score = 20;

                Console.WriteLine("Welcome to the Number Guessing Game!");
                Console.WriteLine("Guess a number from 1 to 100.");
                Console.WriteLine("You start with score of 20, On each wrong guess reduces your score by 1.\n");

                do
                {
                    Console.Write("Enter your guess: ");
                    bool isValid = int.TryParse(Console.ReadLine(), out userGuess);

                    //Convert string input to integer
                    if (!isValid || userGuess < 1 || userGuess > 100)
                    {
                        Console.WriteLine("Please enter a valid a number between 1 and 100.");
                        continue;
                    }
                    if (userGuess < secretNumber)
                    {
                        Console.WriteLine("Too Low!");
                        score--;
                    }
                    else if (userGuess > secretNumber)
                    {
                        Console.WriteLine("Too High!");
                        score--;
                    }
                    else
                    {
                        Console.WriteLine($"Correct!The number is {secretNumber}");
                        Console.WriteLine($"Your final score is {score}");
                        break;
                    }
                } while (score > 0);
                    
                    if (score == 0)
                    {
                        Console.WriteLine($"You lost! The number was {secretNumber}");
                    }
                Console.Write("Do you want to play again? (y/n): ");
                string response = Console.ReadLine().ToLower();
                playAgain = response == "y" || response == "yes"; 
            }
            Console.WriteLine("Thanks for playing!!");
        }
    }
}
