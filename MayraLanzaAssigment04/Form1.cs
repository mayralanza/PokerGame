using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/******************************************************************************************************
 * Program Name: Poker Hand                           Class: COP - 4365 Software System Development   *
 *                                                                                                    *
 * Purpose: This program simulates a pokr game while it displays the type of hand drawn. The user     *
 *          has the options to get a new hand, to clear and to exit the program. In order to make     *
 *          the simulation a double array is initialized and passed through functions to determine    *
 *          type of hand.                                                                             *
 *                                                                                                    *
 * Author: Mayra Lanza                                                                                *
 ******************************************************************************************************/


namespace MayraLanzaAssigment04
{
    public partial class PokerHand : Form
    {
        // Form's constrcutor function call
        public PokerHand()
        {
            InitializeComponent();
        }

        /*********************** Methods of Poker Hand Form *********************/

        /*************************************************************************
         * Flush : Determines if the five cards drawn have the same suit.        *
         * Parameter: 2D array that hold the mathix of the deck with ones stored *
         *           on the cards drawn.                                         *
         ************************************************************************/
        private bool Flush(int[,] cards)
        {
            bool flush = false;         // Boolean expresion to determine flush
            int[] arr = new int[4];     // Array that will hold the number of cards of each suit
            int k;                      // Auxiliar variable to hold the number of cards

            for (int i = 0; i < cards.GetLength(0); i++) // Iterating through the suits 
            {
                k = 0; // will be zero each time the for loop finishes looping for each suit
                for (int j = 0; j < cards.GetLength(1); j++) // Iterating through ranks 
                {
                    // Searching for the cards drwan with the same suit
                    if (cards[i, j] == 1) 
                    {
                        // Increasing the value, which is the number of cards:
                        arr[i] = k++; 
                    }
                }
            }//----> end of for loop 

            // array now hold the number of cards for each suit
            foreach(int val in arr)
            {
                // If number of cards is 5 means that five cards drawn have the same suit
                if (val == 5)
                    // The type of hand is a Flush
                    flush = true;
            }
            // Return value if not located it sends false
            return flush;
        }

        /*************************************************************************
         * Straight: Determines if the five cards drawn have consecutive ranks,  *
         *           where A can be either before 2 or after a King.             *
         * Parameter: 2D array that hold the mathix of the deck with ones stored *
         *           on the cards drawn.                                         *
         ************************************************************************/
        private bool Straight(int[,] cards)
        {
            bool straight = false;      // Bool expession to determine if straight 
            int[] arr = new int[13];    // Array to store 1 if there is a card on that rank

            // Looping through suits of the deck
            for (int i = 0; i < cards.GetLength(0); i++)
            {
                // Looping through ranks of the deck
                for (int j = 0; j < cards.GetLength(1); j++)
                {
                    // If there is a card store 1 on the array of ranks
                    if (cards[i, j] == 1)
                    {
                        // array length is 13 where its index is the rank of the drawn card
                        arr[j] = 1;
                    }
                }
            }

            /* Situations when the cards draw contains A where a Straight happens */
            // If in the five drawn cards, an A was drawn:
            if (arr[0] == 1)
            {
                // other cards drawn are: 10, J, Q, and K 
                if (arr[9] == 1 && arr[10] == 1 && arr[11]==1 && arr[12] == 1)
                   straight = true;
                // other cards drawn are: J, Q, K, and 2
                if (arr[10] == 1 && arr[11] == 1 && arr[12] == 1 && arr[1] == 1)
                    straight = true;
                // other cards drawn are: Q, K, 2 and 3
                if (arr[11] == 1 && arr[12] == 1 && arr[1] == 1 && arr[2] == 1)
                    straight = true;
                // other cards drawn are: K, 2, 3, and 4
                if (arr[12] == 1 && arr[1] == 1 && arr[2] == 1 && arr[3] == 1)
                    straight = true;
            }

            // Checking if consecuitve cards were drawn
            int num_cards = 0;      // number of card and to be Straight has to be 5

            // Loopoing through the array of ranks with no consideration of the suits
            for (int k = 0; k < 12; k++)
            {
                // if there is a card and a next one straight is true
                if (arr[k] == 1 && arr[k + 1] == 1)
                {
                    straight = true;
                    num_cards++; // number of cards increases 
                }
                else
                { // if not consecutive false and break the for loop 
                    straight = false;
                    break;
                }
            }
            // Return bool value if straight is either located or not 
            return straight;
        }

        /*************************************************************************
         * Four_of_a_Kind: Determines if from five cards drawn, 4 cards have the *
         *                 the same rank.                                        *
         * Parameter: 2D array that hold the mathix of the deck with ones stored *
         *           on the cards drawn.                                         *
         ************************************************************************/
        private bool Four_of_a_Kind(int[,] cards)
        {
            bool kind = false;          // Bool expression to determine if Four_of_a_Kind happens
            int[] arr = new int[13];    // Array that holds how many cards there are on each rank

            // Looping through suits of the deck
            for (int i = 0; i < cards.GetLength(0); i++)
            {
                // Looping through ranks of the deck
                for (int j = 0; j < cards.GetLength(1); j++)
                {
                    if (cards[i, j] == 1) // if there is a card increase value of array
                    {
                        arr[j]++; // where j is the index of a rank
                    }
                }
            }//----> end of for loop. Deack is checked completely 

            // Looping through the array that hold the number of cards of each rank
            foreach (int val in arr)
            {
                if (val == 4) // if value is four means that there a 4 cards of the same rank
                    kind = true; // Four of a kind is true 
            }

            // Return bool value if Four_of_a_Kind is either true or not 
            return kind; 
        }

        /*************************************************************************
         * Full_House: Determines if from five cards drawn, three cards have the *
         *             same rank, and the other two of another rank.             *
         * Parameter: 2D array that hold the mathix of the deck with ones stored *
         *           on the cards drawn.                                         *
         ************************************************************************/
        private bool Full_House(int[,] cards)
        {
            bool kind = false;              // Bool expression to determine if Full_House happens
            int[] arr = new int[13];        // Array that holds how many cards there are on each rank

            // Looping through suits of the deck
            for (int i = 0; i < cards.GetLength(0); i++)
            {
                // Looping through ranks of the deck
                for (int j = 0; j < cards.GetLength(1); j++)
                {
                    if (cards[i, j] == 1) // if there is a card increase value of array
                    {
                        arr[j]++; // where j is the index of a rank
                    }
                }
            } //----> end of for loop. Deack is checked completely 

            bool rank1 = false;         // true if 3 cards have the same rank 
            bool rank2 = false;         // true if 5 cards have the same rank

            // Looping through the array that hold the number of cards of each rank
            foreach (int val in arr)
            {
                if (val == 3)   // if three cards have the same rank thenk rank1 = true
                    rank1 = true;
                if (val == 2)   // if five cards have the same rank thenk rank1 = true
                    rank2 = true;
            }
            
            // If there are 3 cards of the same rank and 2 of another rank, kind = true
            if (rank1 && rank2)
                kind = true; 

            /// retruning boolean expression that holds whether a full house has happened
            return kind;
        }

        /**************************************************************************
         * Three_of_a_Kind: Determines if from five cards drawn, 3 cards have the *
         *                 the same rank.                                         *
         * Parameter: 2D array that hold the mathix of the deck with ones stored  *
         *           on the cards drawn.                                          *
         **************************************************************************/
        private bool Three_of_a_Kind(int[,] cards)
        {
            bool kind = false;              // Bool expression to determine if Three_of_a_Kind happens
            int[] arr = new int[13];        // Array that holds how many cards there are on each rank

            // Looping through suits of the deck
            for (int i = 0; i < cards.GetLength(0); i++)
            {
                // Looping through ranks of the deck
                for (int j = 0; j < cards.GetLength(1); j++)
                {
                    if (cards[i, j] == 1) // if there is a card increase value of array on rank index
                    {
                        arr[j]++; // where j is the index of a rank
                    }
                }
            } //----> end of for loop. Deack is checked completely 

            // Looping through the array that hold the number of cards of each rank
            foreach (int val in arr)
            {
                if (val == 3) // if value is three means that there a 3 cards of the same rank
                    kind = true; // Three of a kind is true 
            }

            // Return bool value if Three_of_a_Kind is either true or not 
            return kind;
        }

        /*************************************************************************
         * Two_Pairs: Determines if from five cards drawn: two cards have the    *
         *            same rank, two cards have same rank but its diferent form  *
         *            the first pair, and one card that can be any other card.   *
         * Parameter: 2D array that hold the mathix of the deck with ones stored *
         *           on the cards drawn.                                         *
         ************************************************************************/
        private bool Two_Pairs(int[,] cards)
        {
            bool kind = false;          // Bool expression to determine if Two_Pairs happens
            int[] arr = new int[13];    // Array that holds how many cards there are on each rank

            // Looping through suits of the deck
            for (int i = 0; i < cards.GetLength(0); i++)
            {
                // Looping through ranks of the deck
                for (int j = 0; j < cards.GetLength(1); j++)
                {
                    if (cards[i, j] == 1) // if there is a card increase value of array on rank index
                    {
                        arr[j]++; // where j is the index of a rank
                    }
                }
            } //----> end of for loop. Deack is checked completely

            int pair = 0;       // Number of pairs

            // Looping through the array that hold the number of cards of each rank
            foreach (int val in arr)
            {
                if (val == 2) // if val is equal to 2, means that there a 2 cards of the same rank
                    pair++; // increasing number of pairs
            }

            if (pair == 2) // if number of pairs is equal to two 
                kind = true;  // Two pairs type of hand is true 

            // Return bool value if two pairs were detected 
            return kind;
        }

        /*************************************************************************
         * One_Pair: Determines if from five cards drawn: two cards have the     *
         *            same rank, and the other three cards have different ranks  *
         * Parameter: 2D array that hold the mathix of the deck with ones stored *
         *           on the cards drawn.                                         *
         ************************************************************************/
        private bool One_Pair(int[,] cards)
        {
            bool kind = false;          // Bool expression to determine if One_Pair happens
            int[] arr = new int[13];    // Array that holds how many cards there are on each rank

            // Looping through suits of the deck
            for (int i = 0; i < cards.GetLength(0); i++)
            {
                // Looping through ranks of the deck
                for (int j = 0; j < cards.GetLength(1); j++)
                {
                    if (cards[i, j] == 1) // if there is a card increase value of array on rank index
                    {
                        arr[j]++; // where j is the index of a rank
                    }
                }
            } //----> end of for loop. Deack is checked completely

            int other = 0;        // will hold the number of cards that have only one card on its rank

            // Looping through the array that hold the number of cards of each rank
            foreach (int val in arr)
            {
                if (val == 2) // if there is a pair then kind is true
                    kind = true;
                if (val == 1) // if there is a card on the rank then other cards increase by one 
                    other++;
            }

            if (other == 2 && kind) // 1 pair has the same and the other cards have unmatched cards
                kind = true;  // Two pairs type of hand is true
            else
                kind = false; // else there is no one pair

            // Return bool value if one pair was detected 
            return kind;
        }

        /*********************** Click funtions of Poker Hand Form *********************/

        /************************************************************************
        * Calculate button: Displays a new hand and the type of hand on a label *
        ************************************************************************/
        private void Display_b_Click(object sender, EventArgs e)
        {
            int[,] hand = new int[4, 13];          // declaring the two dimensional array
            int suit_card;                         // suit_card holds the suit of the card
            int rank_card;                         // rank_card hold the rank of the card 
            char[] suits = { 'H', 'C', 'D', 'S' }; // Array holding the characters of each suit
            Random random_n = new Random();        // Creating a random object

            /* Placing ones on ramdom places of the card matrix */
            int numberCards = 0;                   // Number of drawn cards

            // Get a ramdon till there are different cards (to simuate one deck)
            while (numberCards < 5)     
            {
                // Random Suit from 0 to 3
                suit_card = random_n.Next(4); 
                // Random rank from 0 to 12
                rank_card = random_n.Next(13);
                // Placing 1 in matrix correspond to the card
                hand[suit_card, rank_card] = 1;
                // Number of cards set to zero to count again and make sure there are five different card drawn
                numberCards = 0;

                // Looping through suits of the deck
                for (int i = 0; i < hand.GetLength(0); i++)
                {
                    // Looping through ranks of the deck
                    for (int j = 0; j < hand.GetLength(1); j++)
                    {
                        if (hand[i, j] == 1) // A card has been located 
                            numberCards++;   // increasing number of cards 
                    }
                }
            } //----> while loop that will mak sure that the 5 cards draw are different 

            int tmp = 1;        // temporay variable counter for the five poker cards

                                    /*** PLACING IMAGES ON IMAGE BOXES ***/
            // Looping through suits of the deck
            for (int i = 0; i < hand.GetLength(0) ; i++)
            {
                // Looping through ranks of the deck
                for (int j = 0; j < hand.GetLength(1) ; j++)
                {
                    // Go inside the if staement if a card is found
                    if (hand[i, j] == 1)
                    {
                        // Formula used to located index of the card having the row and column index 
                        int idx = j + 12 * i + i; 
                        // Go inside the if statement if the card is the first card
                        if(tmp == 1)
                        {
                            int rank = j + 1; // Rank of the card to be displayed
                            //Placing the image of the card on corresponding picture box 
                            card1_pb.Image = poker_List.Images[idx];
                            // Displaying info on text boxes 
                            suit1_tb.Text = char.ToString(suits[i]);
                            rank1_tb.Text = rank.ToString();
                            tmp++;      // Card 1 has been displayed 
                        }else
                        // Go inside the if statement if the card is the first card
                        if (tmp == 2){
                            int rank = j + 1;  // Rank of the card to be displayed
                            //Placing the image of the card on corresponding picture box 
                            card2_pb.Image = poker_List.Images[idx];
                            // Displaying info on text boxes
                            suit2_tb.Text = char.ToString(suits[i]);
                            rank2_tb.Text = rank.ToString();
                            tmp++; // Card 2 has been displayed 
                        }
                        else if (tmp == 3)
                        {
                            int rank = j + 1;  // Rank of the card to be displayed
                            //Placing the image of the card on corresponding picture box 
                            card3_pb.Image = poker_List.Images[idx];
                            // Displaying info on text boxes
                            suit3_tb.Text = char.ToString(suits[i]);
                            rank3_tb.Text = rank.ToString();
                            tmp++; // Card 3 has been displayed 
                        }
                        else if (tmp == 4)
                        {
                            int rank = j + 1;  // Rank of the card to be displayed
                            //Placing the image of the card on corresponding picture box 
                            card4_pb.Image = poker_List.Images[idx];
                            // Displaying info on text boxes
                            suit4_tb.Text = char.ToString(suits[i]);
                            rank4_tb.Text = rank.ToString();
                            tmp++;  // Card 4 has been displayed 
                        }
                        else
                        {
                            int rank = j + 1;  // Rank of the card to be displayed
                            //Placing the image of the card on corresponding picture box 
                            card5_pb.Image = poker_List.Images[idx];
                            suit5_tb.Text = char.ToString(suits[i]);
                            rank5_tb.Text = rank.ToString();
                            // Card 5 has been displayed 
                        }
                    }
                }
            } //----> end of for loop. Deack is checked completely

                            /*** CHECKING IF THERE IS A TYPE OF HAND ***/
            if (Flush(hand) && Straight(hand))
            {
                output_lb.Text = "The hand is a Straight flush";
            }
            else
            if (Flush(hand))
            {
                output_lb.Text = "The hand is a flush";
            }
            else
            if (Straight(hand))
            {
                output_lb.Text = "The hand is a Straight";
            }
            else
            if (Four_of_a_Kind(hand))
            {
                output_lb.Text = "The hand is a Four-of-a-Kind";
            }
            else
            if (Full_House(hand))
            {
                output_lb.Text = "The hand is a Full House";
            }
            else
            if (Three_of_a_Kind(hand))
            {
                output_lb.Text = "The hand is a Three-of-a-Kind";
            }
            else
            if (Two_Pairs(hand))
            {
                output_lb.Text = "The hand is a Two Pairs";
            }
            else if (One_Pair(hand))
            {
                output_lb.Text = "The hand is a One Pairs";
            }
            else
                output_lb.Text = "No type of hand. Try again.";

        }

        /*** Clearing text from text-boxes and checked boxes from the form ***/
        private void Clear_b_Click(object sender, EventArgs e)
        {
            // Clearing text from picture-boxes of the form
            card1_pb.Image = null;
            card2_pb.Image = null;
            card3_pb.Image = null;
            card4_pb.Image = null;
            card5_pb.Image = null;
            // Reseting checked boxes from the form
            rank1_tb.Text = "";
            rank2_tb.Text = "";
            rank3_tb.Text = "";
            rank4_tb.Text = "";
            rank5_tb.Text = "";
            suit1_tb.Text = "";
            suit2_tb.Text = "";
            suit3_tb.Text = "";
            suit4_tb.Text = "";
            suit5_tb.Text = "";
            // Clearinh Output label 
            output_lb.Text = "";
        }

        /*** Exit Button: Terminates the program form ***/
        private void Exit_b_Click(object sender, EventArgs e)
        {
            // Closing the program
            this.Close();
        }

    }
}
