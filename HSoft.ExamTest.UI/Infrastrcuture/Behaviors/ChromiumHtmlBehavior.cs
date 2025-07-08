using System.Windows;
using CefSharp;
using CefSharp.Wpf;
using Microsoft.Xaml.Behaviors;

namespace HSoft.ExamTest.UI.Infrastrcuture.Behaviors
{
    public class ChromiumHtmlBehavior : Behavior<ChromiumWebBrowser>
    {
        // Propiedad para enlazar el HTML
        public static readonly DependencyProperty HtmlProperty =
            DependencyProperty.Register(
                "Html",
                typeof(string),
                typeof(ChromiumHtmlBehavior),
                new PropertyMetadata(null, OnHtmlChanged));

        public string Html
        {
            get => (string)GetValue(HtmlProperty);
            set => SetValue(HtmlProperty, value);
        }

        // Cuando el Behavior se asocia al ChromiumWebBrowser
        protected override void OnAttached()
        {
            base.OnAttached();
            if (!string.IsNullOrEmpty(Html))
            {
                AssociatedObject.LoadHtml(Html);
            }
        }

        // Cuando cambia la propiedad Html
        private static void OnHtmlChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var behavior = (ChromiumHtmlBehavior)d;
            if (behavior.AssociatedObject != null && e.NewValue is string html)
            {
                behavior.AssociatedObject.LoadHtml(html);
            }
        }
    }
}
