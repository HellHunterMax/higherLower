using System;
using System.IO;

namespace gameWithScores
{
	class mainMenu
	{
		const string FilePath = @".\Scores.txt";
		public static void Main()
		{
			string choice = "";
			bool exitGame = false;
			FileInfo fileInf = new FileInfo(FilePath);
			
			if (!fileInf.Exists)
				File.Create(FilePath).Dispose();
			
			while (!exitGame)
			{
				Console.Clear();
				Console.WriteLine("Type play to play a game.");
				Console.WriteLine("Type scores to see the scores.");
				Console.WriteLine("Type exit to quit.");
				while (choice != "play" && choice != "scores" && choice != "exit")
				{	
					Console.Write("play, scores or exit: ");
					choice = Console.ReadLine().ToLower();
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
			Console.Clear();
			Console.WriteLine("I will check if you hit the highscore");
			while (playerName.Length < 2 || playerName.Length > 10)
			{	
				Console.WriteLine("I need a name between 2 and 10 letters: ");
				playerName = Console.ReadLine();
			}
			
			HighScore(points, playerName);
			//TODO: call HighScore method.		
			
		}
		public static void Scores()
		{
			Console.Clear();
			using (var reader = new StreamReader(new FileStream(FilePath, FileMode.Open)))
			{
				Console.WriteLine(reader.ReadToEnd());
			}
			Console.WriteLine("Enter to continue");
			Console.ReadKey();
		}
		public static void HighScore(int score,  string name)
		{
			Console.Clear();
			int highScorePosition = 11;
			System.Collections.Generic.List<string> newScoreBoardList = new System.Collections.Generic.List<string>();
			
			using (var reader = new StreamReader(new FileStream(FilePath, FileMode.Open)))
			{
				string scoreBoard = reader.ReadToEnd();
				string[] scoreLine = scoreBoard.Split(new[] { Environment.NewLine },StringSplitOptions.None);
				
				for (int position = 0; position < scoreLine.Length; position++)
				{
					string[] scoreAndName = scoreLine[position].Split(' ');
					if (score > int.Parse(scoreAndName[0]))
					{
						highScorePosition = position+1;
						break;
					}
					if (position == scoreLine.Length -1)
					{
						highScorePosition = position;
					}
				}
				
				for (int position = 0; position < scoreLine.Length+1; position++)
				{
					if ( position == 10)
						break;
					else if (highScorePosition == position)
					{
						newScoreBoardList.Add(score + " " + name);
					}
					else if (highScorePosition < position)
					{
						string[] scoreAndName = scoreLine[position-1].Split(' ');
						newScoreBoardList.Add(scoreAndName[0] + " " + scoreAndName[1]);
					}
					else
					{
						string[] scoreAndName = scoreLine[position].Split(' ');
						newScoreBoardList.Add(scoreAndName[0] + " " + scoreAndName[1]);
					}
				}
			}
			
			if (highScorePosition >9)
				Console.WriteLine("With " + score + " you did not make the highscore. try again!");
			else
			{
				Console.WriteLine("Congratulations you made the highscore with " + score + " points!");
				Console.WriteLine("You are on position " + (highScorePosition-1) + "!" );
			}
			using (var writer = new StreamWriter(new FileStream(FilePath, FileMode.Create)))
			{
				for ( int i = 0; i < newScoreBoardList.Count ; i++)
				{
					writer.WriteLine(newScoreBoardList[i]);
				}
			}
			Console.Write("Press Enter to Continue.");
			Console.ReadKey();
		}
	}
}