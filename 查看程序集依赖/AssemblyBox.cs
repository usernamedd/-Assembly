using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace 查看程序集依赖
{
    public class AssemblyBox:ContentControl
    {
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            "Text", typeof(string), typeof(AssemblyBox), new PropertyMetadata(default(string)));

        public string Text
        {
            get { return (string) GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
    }
}