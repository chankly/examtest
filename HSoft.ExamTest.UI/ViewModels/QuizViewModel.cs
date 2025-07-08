using HSoft.ExamTest.UI.Infrastrcuture.Commands;
using Microsoft.Win32;
using System.IO;
using System.Windows.Input;
using System.Xml.Serialization;
using HSoft.ExamTest.UI.Model;

namespace HSoft.ExamTest.UI.ViewModels
{
    public class QuizViewModel : ViewModelBase
    {
        #region Properties
        private bool _showCorrection = false;
        private int _currentIndex = 0;
        private int _maxIndex = 59;
        private string _currentFileToChange;
        private System.Windows.Controls.WebBrowser _webBrowser;

        QuestionListModel _questions;
        QuestionModel _currentQuiz;

        public QuestionListModel Questions
        {
            get => _questions;
            set
            {
                _questions = value;
                OnPropertyChanged();
            }
        }

        public QuestionModel CurrentQuiz
        {
            get => _currentQuiz;
            set
            {
                _currentQuiz = value;
                OnPropertyChanged();
            }
        }
        
        public bool ShowCorrection
        {
            get => _showCorrection;
            set
            {
                _showCorrection = value;
                OnPropertyChanged();
            }
        }

        public System.Windows.Controls.WebBrowser WebBrowser
        {
            get;
            set;
        }
        #endregion

        #region Commands
        public ICommand OpenCommand => new RelayCommand((s) =>
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == true)
            {
                _currentFileToChange = $"{openFileDialog.FileName}";

                Questions = GetQuestionListModelFromFile(openFileDialog.FileName);
                CurrentQuiz = Questions.QuestionList[_currentIndex];
            }
        });

        public ICommand SaveCommand => new RelayCommand((s) =>
        {
            var serializer = new XmlSerializer(typeof(QuestionListModel));
            using(var writer = new StreamWriter(_currentFileToChange))
            {
                serializer.Serialize(writer, Questions);
            }
        });

        public ICommand PreviousQuestionCommand => new RelayCommand((s) =>
        {
            if (_currentIndex > 0)
            {
                _currentIndex--;
                CurrentQuiz = Questions.QuestionList[_currentIndex];
            }
        });

        public ICommand NextQuestionCommand => new RelayCommand((s) =>
        {
            if(_currentIndex < _maxIndex)
            {
                _currentIndex++;
                CurrentQuiz = Questions.QuestionList[_currentIndex];
            }
        });

        public ICommand ShowCorrectionCommand => new RelayCommand((s) =>
        {
            ShowCorrection = !ShowCorrection;
            if (ShowCorrection)
            {
                WebBrowser.NavigateToString(CurrentQuiz.Explain?.Replace("![CDATA[", string.Empty).Replace("]]", string.Empty));
            }
            else
            {
                WebBrowser.NavigateToString(".");
            }
        });
        #endregion

        #region Implementation
        private QuestionListModel GetQuestionListModelFromFile(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(QuestionListModel));
            using (var reader = new StreamReader(filePath))
            {
                return (QuestionListModel)serializer.Deserialize(reader);
            }
        }
    }
    #endregion
}