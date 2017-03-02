using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        private void sortButton_Click(object sender, RoutedEventArgs e)
        {
            // Sorts the deck, arranging the cards by value and color. Ace (1) -> King (13).
            deck = new Deck();
            removeText();
        }

        private void pullCardButton_Click(object sender, RoutedEventArgs e)
        {
            // Pulls out the topmost card and takes it out of the stack
            currentCard = deck.DealCard();
            writeToCardBox(currentCard);
        }

        private void writeToCardBox(Card currentCard)
        {
            if (currentCard != null)
            {
                CardsBox.AppendText(currentCard.ToString() + Environment.NewLine);
                CardsBox.ScrollToEnd();
            } else
                CardsBox.AppendText("You are out of cards. Please sort or shuffle." + Environment.NewLine);
        }

        private void shuffleStackButton_Click(object sender, RoutedEventArgs e)
        {
            // Code that shuffles the stack, placing the cards randomly
            deck.Shuffle();
            removeText();
        }

        private void removeText()
        {
            CardsBox.Text = null;
        }
    }
}
