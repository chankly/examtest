using HSoft.ExamTest.UI.ViewModels;
using System.Windows;

namespace HSoft.ExamTest.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {            
            InitializeComponent();
            this.DataContextChanged += (s, e) => 
            {
                if (DataContext is QuizViewModel viewModel)
                {
                    viewModel.WebBrowser = myWebBrowser;
                }
            };
            this.DataContext = new QuizViewModel();
        }
    }
}