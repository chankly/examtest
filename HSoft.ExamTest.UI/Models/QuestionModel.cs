using HSoft.ExamTest.UI.ViewModels;
using System.Security;
using System.Xml.Serialization;

namespace HSoft.ExamTest.UI.Model
{

    [XmlRoot("questions")]
    public class QuestionListModel : ViewModelBase
    {
        [XmlElement("question")]
        public List<QuestionModel> QuestionList { get; set; } = new List<QuestionModel>();
    }

    public class QuestionModel : ViewModelBase
    {
        string _title;
        [XmlAttribute("title")]
        public string Title
        {            
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        bool _isCheck;
        [XmlAttribute("isCheck")]
        public bool IsCheck
        {
            get => _isCheck;
            set
            {
                _isCheck = value;
                OnPropertyChanged();
            }
        }

        [XmlAttribute("imagePath")]
        public string ImagePath { get; set; } = string.Empty;

        [XmlArray("responses")]
        [XmlArrayItem("response")]
        public List<ResponseModel> Responses { get; set; } = new List<ResponseModel>();

        [XmlElement("explain")]
        public string Explain { get; set; }
    }


    public class ResponseModel : ViewModelBase
    {
        public ResponseModel() { }

        bool _responseUser;
        public bool ResponseUser
        {
            get => _responseUser;
            set
            {
                _responseUser = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsCorrect));
            }
        }

        public bool IsCorrect
        {
            get => IsValid && ResponseUser;
        }

        bool _isValid;
        [XmlAttribute("isValid")]
        public bool IsValid{
            get => _isValid;
            set
            {
                _isValid = value;
                OnPropertyChanged();
            }
        }

        string _text;
        [XmlElement("text")]
        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged();
            }
        }

        string _imagePath;
        [XmlElement("imagePath")]
        public string ImagePath
        {
            get => _imagePath;
            set
            {
                _imagePath = value;
                OnPropertyChanged();
            }
        }

        [XmlElement("explain")]
        public string Explain { get; set; }
    }
}
