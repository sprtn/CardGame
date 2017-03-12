using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace TestRunner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<TestingLib.TestTheCards.UnitTestInfo> _results = new 
            ObservableCollection<TestingLib.TestTheCards.UnitTestInfo>();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = _results;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var testClass = new TestingLib.TestTheCards();
            _results.Add(testClass.DeckContains52Cards());
            _results.Add(testClass.PullAllCards());
            _results.Add(testClass.DoesDeckShuffle());
        }
    }
}
