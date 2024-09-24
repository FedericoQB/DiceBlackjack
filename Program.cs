namespace DiceBlackjack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Open region to see variables and to see if the github desktop
            #region Variables
            int dealeranswer = 0;
            int playerPoints = 0;
            int dealerPoints = 0;
            int money = 1000;
            int bet = 0;
            bool aceAnswer = false;

            #endregion

            // Check if player wants to play
            Console.WriteLine("Do you want to play Blackjack?");
            string play = Console.ReadLine();
            
            

            while (play.ToLower().Trim() != "no")
            {
                /* In original Blackjack, you get two cards at first
                 * But in this code we add some points, it's like a involuntary card "throw" */

                int winning = 0;
                int playing = 0;
                string answer = "";

                // Player can bet a maximum of 1000
                Console.WriteLine("You have " + money + " dollars");
                Console.WriteLine("How much money do you want to bet?");
                bet = int.Parse(Console.ReadLine());

                money -= bet;

                // Reminds the player of card points
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Cards of 12 and 13 are worth 10 points");
                Console.ResetColor();

                // Asks the player to hit or stay
                Console.WriteLine("");
                Console.WriteLine("First Roll");
                while (playing != 1)
                {
                    #region FirstRollOfDealern
                    // Rolls for the dealer
                    /* Random rand2 = new Random();
                    int dealerCard = rand2.Next(1, 14);

                    if (dealerPoints < 17)
                    {
                        if (dealerCard == 12 || dealerCard == 13) // CHECK HOW THE DEALER HANDLES ACES ON EACH FUNCTION
                        {
                            dealerPoints += 10;
                        }
                        else if (dealerCard == 11)
                        {
                            if (dealerPoints > 11)
                            {
                                dealerPoints += 1;
                            }
                            else
                            {
                                dealerPoints += 11;
                            }
                        }
                        else
                        {
                            dealerPoints += dealerCard;
                        }
                    }
                    else if (dealerPoints > 17)
                    {
                        // When dealer has over 17, it adds value to the variable which will stop the other function of playing
                        dealeranswer = 1;
                    } */
                    #endregion

                    // Checks if player answer is stay, if not, run the code, if it is, continue the loop.
                    if (answer != "stay")
                    {
                        // If player hit, run this while loop
                        do
                        {
                            // Variables
                            // Dice Throw Variable
                            Random rand = new Random();
                            int playerCard = rand.Next(1, 14);
                            if (playerCard == 12 || playerCard == 13)
                            {
                                playerPoints += 10;
                            }
                            else if (playerCard == 11) // Ace if function
                            {
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.WriteLine("You have gained an ace");
                                Console.WriteLine("Do you want to change the value to 1 or 11?");
                                int miniAnswer = int.Parse(Console.ReadLine());
                                if (miniAnswer == 1)
                                {
                                    aceAnswer = true;
                                    Console.WriteLine("You have chosen 1");
                                    playerPoints += 1;
                                }else if (miniAnswer == 11)
                                {
                                    Console.WriteLine("You have Chosen 11");
                                    playerPoints += 11;
                                }

                                Console.ResetColor();
                            }
                            else
                            {
                                playerPoints += playerCard;
                            }

                            if (aceAnswer == true)
                            {
                                Console.WriteLine("You got: 1");

                            }
                            else
                            {
                                Console.WriteLine("You got: " + playerCard);
                            }

                            if (dealerPoints < 17)
                            {
                                Random rand3 = new Random();
                                int dealerCard2 = rand3.Next(1, 14);

                                if (dealerPoints < 17)
                                {
                                    if (dealerCard2 == 12 || dealerCard2 == 13) // CHECK HOW THE DEALER HANDLES ACES ON EACH FUNCTION
                                    {
                                        dealerPoints += 10;
                                        Console.WriteLine("Dealer got: " + dealerCard2);
                                    }
                                    else if (dealerCard2 == 11)
                                    {
                                        if ((dealerPoints + dealerCard2) > 21)
                                        {
                                            dealerPoints += 1;
                                            Console.WriteLine("Dealer got an ace");
                                        }
                                        else
                                        {
                                            dealerPoints += 11;
                                            Console.WriteLine("Dealer got an ace");
                                        }
                                    }
                                    else
                                    {
                                        dealerPoints += dealerCard2;
                                        Console.WriteLine("Dealer got: " + dealerCard2);
                                    }
                                }
                                else if (dealerPoints >= 17)
                                {
                                    // When dealer has over 17, it adds value to the variable which will stop the other function of playing
                                    dealeranswer = 1;
                                    Console.WriteLine("Dealer has stayed");
                                }
                                
                            }
                            else if (dealerPoints >= 17)
                            {
                                // When dealer has over 17, it adds value to the variable which will stop the other function of playing
                                dealeranswer = 1;
                                Console.WriteLine("Dealer has stayed");
                            }

                            /*
                            Console.WriteLine("");
                            Console.WriteLine("Dealer has: " + dealerPoints);
                            */
                            if (playerPoints > 21 || dealerPoints > 21)
                            {
                                break;
                                answer = "stay";
                            } // Check how to make this work!!! over 21, break

                            // Asks the player to or stay to rerun the loop
                            Console.WriteLine("Hit or stay?");
                            answer = Console.ReadLine();

                        } while (answer.ToLower().Trim() != "stay"); // Here ends the while loop
                        
                        while (dealeranswer != 1)
                        {
                            if (dealerPoints < 17)
                            {
                                Random rand2 = new Random();
                                int dealerCard = rand2.Next(1, 14);

                                if (dealerPoints < 17)
                                {
                                    if (dealerCard == 12 || dealerCard == 13) // CHECK HOW THE DEALER HANDLES ACES ON EACH FUNCTION
                                    {
                                        dealerPoints += 10;
                                        Console.WriteLine("Dealer hits and gets: " + dealerCard);
                                    }
                                    else if (dealerCard == 11)
                                    {
                                        if ((dealerPoints + dealerCard) > 21)
                                        {
                                            dealerPoints += 1;
                                            Console.WriteLine("Dealer got an ace");
                                        }
                                        else
                                        {
                                            dealerPoints += 11;
                                            Console.WriteLine("Dealer got an ace");
                                        }
                                    }
                                    else
                                    {
                                        dealerPoints += dealerCard;
                                        Console.WriteLine("Dealer hits and gets: " + dealerCard);
                                    }
                                }
                                else if (dealerPoints >= 17)
                                {
                                    // When dealer has over or has 17, it adds value to the variable which will stop the other function of playing
                                    dealeranswer = 1;
                                    Console.WriteLine("Dealer has stayed");
                                }
                                
                            }
                            else if (dealerPoints >= 17)
                            {
                                // When dealer has over 17, it adds value to the variable which will stop the other function of playing
                                dealeranswer = 1;
                                Console.WriteLine("Dealer has stayed");
                            }
                        }

                    }
                    if (playerPoints > 21 || dealerPoints > 21)
                    {
                        break;
                        dealeranswer = 1;
                    }


                    if (answer.ToLower().Trim() == "stay" && dealeranswer == 1)
                    {
                        playing = 1;
                    }
                }

                // Writes the total of each players points
                Console.WriteLine("Player in total has: " + playerPoints);
                Console.WriteLine("Dealer in total has: " + dealerPoints);



                // Winning If functions

                // If dealer has 21, dealer wins.
                if (dealerPoints == 21)
                {
                    Console.WriteLine("You lost. Dealer has 21");
                }
                else if (dealerPoints > 21 && playerPoints > 21)
                {
                    Console.WriteLine("Both are over 21, both lost");
                }
                else if (dealerPoints > 21) // dealer has over 21, dealer lost
                {
                    Console.WriteLine("You won, dealer has over 21");
                    winning = 1;
                }
                else if (dealerPoints > playerPoints)
                {
                    Console.WriteLine("You lost, dealer has more than you");
                }
                // if player has more than dealer, check if player is over 21, if not, player wins
                else if (playerPoints > dealerPoints) 
                {
                    if (playerPoints > 21)
                    {
                        Console.WriteLine("You lost, player has over 21");
                    }
                    else
                    {
                        Console.WriteLine("You won");
                        winning = 1;
                    }
                    
                }
                else if (dealerPoints == playerPoints)
                {
                    Console.WriteLine("Dealer wins, equal hands, house gains the win");
                }

                // Bet money
                if (winning == 1)
                {
                    bet *= 2;
                    money += bet;
                }
                else
                {
                    Console.WriteLine("You lost your money, win it back again or lose it even more");
                    if (money < 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.WriteLine("You have bet more than you have, you have also been kicked and banned for life");

                        Console.ResetColor();
                        break;
                    }
                }
                Console.WriteLine("Your money in total: " + money);

                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.WriteLine("Wanna play again?");
                play = Console.ReadLine();

                Console.WriteLine("");
                Console.ResetColor();

                // Resets each value for next round
                playerPoints = 0;
                dealerPoints = 0;
                dealeranswer = 0;
            }
            
        }
    }
}
