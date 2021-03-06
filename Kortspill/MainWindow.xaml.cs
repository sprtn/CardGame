﻿using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

/// <summary>
/// TBD:
/// 
/// Unit Testing
/// Bilder for alle kort
/// </summary>

namespace Kortspill

{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Deck deck = new Deck();
        private Card currentCard;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Click event of the Sort Deck button.
        /// Replaces the current Deck with a new one, 
        /// and removes the text from the textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sortButton_Click(object sender, RoutedEventArgs e)
        {
            // Sorts the deck, arranging the cards by value and color. Ace (1) -> King (13).
            deck.Sort();
            removeText();
        }

        /// <summary>
        /// Click event of the Pull Card button. 
        /// Deals a card from the deck and calls the writeToCardBox method,
        /// which writes in the values into the textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pullCardButton_Click(object sender, RoutedEventArgs e)
        {
            // Pulls out the topmost card and takes it out of the stack
            currentCard = deck.DealCard();
            if (currentCard != null)
                Card.Source = (ImageSource) new BitmapImage(currentCard.path);
            writeToCardBox(currentCard);
        }

        /// <summary>
        /// Uses the overwritten ToString method from Card to paste
        /// information about the card drawn into the TextBox.
        /// </summary>
        /// <param name="currentCard"></param>
        private void writeToCardBox(Card currentCard)
        {
            if (currentCard != null)
                CardsBox.AppendText(currentCard.ToString() + Environment.NewLine);
            else
            {
                CardsBox.AppendText("You are out of cards. Please sort or shuffle.");
                CanPullCards(false);
            }
            CardsBox.ScrollToEnd();
        }

        private void CanPullCards(bool v)
        {
            if (pullCardButton.IsEnabled != v)
                pullCardButton.IsEnabled = v;
        }

        /// <summary>
        /// Click event of the shuffle button. Calls the Shuffle function
        /// from the deck and clears the CardsBox from text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void shuffleStackButton_Click(object sender, RoutedEventArgs e)
        {
            // Code that shuffles the stack, placing the cards randomly
            deck.Shuffle();
            removeText();
        }

        /// <summary>
        /// Resets the CardsBox textbox, and enables cards to be pulled out of the stack.
        /// </summary>
        private void removeText()
        {
            CardsBox.Text = null;
            Card.Source = null;
            CanPullCards(true);
        }
    }
}
