using System;
using System.IO;

namespace gameWithScores
{
	class mainMenu
	{
		public static void Main()
		{
			string choice = "";
			bool exitGame = false;
			
			while (!exitGame)
			{
				Console.Clear();
				Console.WriteLine("Type play to play a game.");
				Console.WriteLine("Type scores to see the scores.");
				Console.WriteLine("Type exit to quit.");
				while (choice.ToLower() != "play" && choice.ToLower() != "scores" && choice.ToLower() != "exit")
				{	
					Console.Write("play, scores or exit: ");
					choice = Console.ReadLine();
				}
					
				if (choice.ToLower() == "exit")
				{
					exitGame = true;
				}
				else if (choice.ToLower() == "play")
				{
					PlayGame();
				}
				else if (choice.ToLower() == "scores")
				{
					Scores();
				}
				choice = "";
			}
		}
		public static void PlayGame()
		{
			Console.Clear();
			Console.WriteLine("In this game you get a random card from 1 to 10 and so does the PC.");
			Console.WriteLine("Then you have to say higher or lower.");
			Console.WriteLine("You can not get the same card.");
			Console.WriteLine("If you guessed right you get a point.");
			Console.WriteLine("If you guessed wrong you lose a point.");
			Console.WriteLine("Get as high as you can and set a High Score!!!");
			Console.WriteLine("Press enter to start.");
			Console.ReadKey();
			int points = 0;
			string playerName = "";
			bool keepPlaying = true;
			while (keepPlaying)
			{
				Random rnd = new Random();
				int PCCard = rnd.Next(1, 10);
				int playerCard = rnd.Next(1, 10);
				if (PCCard == playerCard)
					playerCard = rnd.Next(1, 10);
				
				Console.Clear();
				Console.WriteLine("Points: " + points);
				Console.WriteLine("You have Number: " + playerCard);
				Console.WriteLine("Do you think the PC has Higher or Lower?");
				string higherLower = "";
				while (higherLower != "higher" && higherLower != "lower")
				{
					Console.Write("Higher or Lower : ");
					higherLower = Console.ReadLine().ToLower();
				}
				Console.Clear();
				if ((higherLower == "lower" && playerCard > PCCard)|| (higherLower == "higher" && playerCard < PCCard))
				{
					points++;
					Console.WriteLine("You had card number "+ playerCard+ " and the PC had card number " + PCCard + " and you said " + higherLower);
					Console.WriteLine("So you gaind a point!");
					Console.WriteLine("You now have " + points + " points."); 
				}
				else
				{
					points--;
					Console.WriteLine("So you lost a point!");
					Console.WriteLine("You now have " + points + " points."); 
				}
				Console.WriteLine("Play again?");
				string playAgain = "";
				while (playAgain  != "yes" && playAgain  != "no")
				{
					Console.Write("Yes or No : ");
					playAgain  = Console.ReadLine().ToLower();
				}
				if (playAgain == "no")
					keepPlaying = false;
				
				
			}
			
		}
		public static void Scores()
		{
			Console.WriteLine("Scores!");
			Console.ReadKey();
		}
	}
}