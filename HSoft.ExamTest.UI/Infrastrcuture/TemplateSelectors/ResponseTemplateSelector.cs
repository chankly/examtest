using System.Windows.Controls;
using System.Windows;
using HSoft.ExamTest.UI.Model;

namespace HSoft.ExamTest.UI.Infrastrcuture.TemplateSelectors
{
    public class ResponseTemplateSelector : DataTemplateSelector
    {
        public DataTemplate RadioTemplate { get; set; }
        public DataTemplate CheckboxTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var itemsControl = ItemsControl.ItemsControlFromItemContainer(container);
            var viewModel = itemsControl?.DataContext as QuestionModel; // Reemplaza con tu clase

            return viewModel?.IsCheck == true ? CheckboxTemplate : RadioTemplate;
        }
    }
}
