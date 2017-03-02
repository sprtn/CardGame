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

        public MainWindow()
        {
            InitializeComponent();
        }

        private void sortButton_Click(object sender, RoutedEventArgs e)
        {
            // Sorts the deck, arranging the cards by value and color. Ace (1) -> King (13).
        }

        private void pullCardButton_Click(object sender, RoutedEventArgs e)
        {
            // Pulls out the topmost card and takes it out of the stack
            deck.DealCard();
        }

        private void shuffleStackButton_Click(object sender, RoutedEventArgs e)
        {
            // Code that shuffles the stack, placing the cards randomly
            deck.Shuffle();
        }
    }
}
