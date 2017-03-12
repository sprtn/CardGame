using System.Collections.ObjectModel;
using System.Windows;

namespace TestRunner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Creating an observable collection to display the results
        /// of the tests using the TestTheCards class methods, showing
        /// the UnitTestInfo structs from that class in an Observable Collection.
        /// </summary>
        private ObservableCollection<TestingLib.TestTheCards.UnitTestInfo> _results = new
            ObservableCollection<TestingLib.TestTheCards.UnitTestInfo>();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = _results;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _results.Clear();
            var testClass = new TestingLib.TestTheCards();
            _results.Add(testClass.DeckContains52Cards());
            _results.Add(testClass.PullAllCards());
            _results.Add(testClass.DoesDeckShuffle());
            _results.Add(testClass.DoesDeckSort());
            _results.Add(testClass.CorrectOrder());
        }
    }
}
