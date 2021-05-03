using System;

namespace LabFirst
{
	class Program
	{
		static void Check(int[] playerCards)
		{
			Random x = new Random();

			for (int i = 0; i < 36; i++)
			{
				for (int j = 0; j < i; j++)
				{
					if (playerCards[i] == playerCards[j])
					{
						playerCards[i] = x.Next(36);

						Check(playerCards);
					}
				}
			}
		}
		
		static void SayCard(int[] playerCards, int[] deck, int num)
		{
			switch (num)
			{
				case 1:
					Console.WriteLine("Card: Ace");
					break;
				case 2:
					Console.WriteLine("Card: Jack");
					break;
				case 3:
					Console.WriteLine("Card: Lady");
					break;
				case 4:
					Console.WriteLine("Card: king");
					break;
				case 6:
					Console.WriteLine("Card: six");
					break;
				case 7:
					Console.WriteLine("Card: seven");
					break;
				case 8:
					Console.WriteLine("Card: eight");
					break;
				case 9:
					Console.WriteLine("Card: nine");
					break;
				case 10:
					Console.WriteLine("Card: ten");
					break;
				case 11:
					Console.WriteLine("Card: Ace");
					break;
				default:
					Console.WriteLine("There was some kind of error");
					break;
			}
		}
			
		static void Points(int score, string name)
		{
			Console.WriteLine(name + ": " + score + " points");
		}
		
		static void Main(string[] args)
		{
			int scoreOne = 0, scoreTwo = 0, scorePlayer = 2, scoreSave;
			
			string name, reaction = "да", bot = "Bot", ace = "11"; 
			
			int[] playerCards = new int[36];
			int[] deck = new int[]
			{
				6, 6, 6, 6,
				7, 7, 7, 7,
				8, 8, 8, 8,
				9, 9, 9, 9,
				10, 10, 10, 10,
				2, 2, 2, 2,
				3, 3, 3, 3,
				4, 4, 4, 4,
				11, 11, 11, 11
			};
			
			// the introductory part of the game
			
			Console.WriteLine("Game \"21 points\"\n");
			Console.WriteLine("Rules of the game:\n");
			Console.WriteLine("1. At the first hand, the player receives 2 cards");
			Console.WriteLine("2. Each player has the opportunity to collect cards after the hand is dealt");
			Console.WriteLine("3. Who is the closest of the players to reach 21, he won");
			Console.WriteLine("4. The player who scores more than 21 automatically loses");
			Console.Write("How many points to take an ace for? ( 11 / 1 ) : ");
			
			ace = Console.ReadLine();
			int aceInt = Convert.ToInt32(ace);
			
			Console.WriteLine("\n\nNumber of points per card:\n");
			Console.Write(
				"Card: six - 6 points\n" +
				"Card: seven - 7 points\n" +
				"Card: eight - 8 points\n" +
				"Card: nine - 9 points\n" +
				"Card: ten - 10 points\n" +
				"Card: Jack - 2 points\n" +
				"Card: Lady - 3 points\n" +
				"Card: king - 4 points\n"
			);
			
			if (aceInt == 11)
			{
				Console.Write("Card: Ace - 11 points\n");
			}
			else
			{
				Console.Write("Card: Ace - 1 point\n");
			}
			
			Console.Write("\nEnter the player's name: ");
			name = Console.ReadLine();

			// issuing a random card to a player
			
			Random x = new Random();
			
			for (int i = 0; i < 36; i++)
			{
				playerCards[i] = x.Next(36);
			}

			Check(playerCards);

			// distribution of points

			Console.WriteLine("\nThe game has begun!\n");
			Console.WriteLine("When you dealt, you received two cards:\n");
			
			SayCard(playerCards, deck, deck[playerCards[0]]);
			SayCard(playerCards, deck, deck[playerCards[1]]);
			
			scoreOne += deck[playerCards[0]];
			scoreOne += deck[playerCards[1]];
			
			if (aceInt == 1)
			{
				if (deck[playerCards[0]] == 11)
				{
					scoreOne -= 10;
				}
				if (deck[playerCards[1]] == 11)
				{
					scoreOne -= 10;
				}
			}

			Console.WriteLine("\nYour current number of points: " + scoreOne);

			// interaction with the player

			Console.Write("\nDo you want to collect another card? ( yes / no ) : ");
			reaction = Console.ReadLine();

			while (reaction == "yes")
			{
				SayCard(playerCards, deck, deck[playerCards[scorePlayer]]);
				
				scoreOne += deck[playerCards[scorePlayer]];
				
				if (aceInt == 1 && deck[playerCards[scorePlayer]] == 11)
				{
					scoreOne -= 10;
				}

				Console.WriteLine("\nYour current number of points: " + scoreOne);
				scorePlayer++;
				Console.Write("\nDo you want to collect another card? ( yes / no ) : ");
				reaction = Console.ReadLine();
			}

			scoreSave = scorePlayer;

			// the logic of the bot
			
			scoreTwo += deck[playerCards[scorePlayer]];

			if (aceInt == 1 && deck[playerCards[scorePlayer]] == 11)
			{
				scoreTwo -= 10;
			}

			scoreTwo += deck[playerCards[++scorePlayer]];

			if (aceInt == 1 && deck[playerCards[scorePlayer]] == 11)
			{
				scoreTwo -= 10;
			}

			scorePlayer++;

			while (scoreTwo < 17)
			{
				scoreTwo += deck[playerCards[scorePlayer]];

				if (aceInt == 1 && deck[playerCards[scorePlayer]] == 11)
				{
					scoreTwo -= 10;
				}
                
				scorePlayer++;
			}

			// total

			Console.WriteLine("\nAs a result, the players scored:\n");

			Points(scoreOne, name);
			Points(scoreTwo, bot);

			Console.WriteLine("\nThe bot has the cards:\n");

			for (int i = scoreSave; i < scorePlayer; i++)
			{
				SayCard(playerCards, deck, deck[playerCards[i]]);
			}

			if (scoreOne < 22 && scoreOne > scoreTwo)
			{
				Console.WriteLine("\nWon: " + name);
			}
			else if (scoreOne < 22 && scoreOne == scoreTwo)
			{
				Console.WriteLine("\nTie");
			}
			else if (scoreOne < 22 && scoreOne < scoreTwo && scoreTwo < 22)
			{
				Console.WriteLine("\nWon: " + bot);
			}
			else if (scoreOne < 22 && scoreTwo > 21)
			{
				Console.WriteLine("\nWon: " + name);
			}
			else if (scoreTwo < 22 && scoreOne > 21)
			{
				Console.WriteLine("\nWon: " + bot);
			}
			else
			{
				Console.WriteLine("\nNo one won");
			}
		}
	}
}
