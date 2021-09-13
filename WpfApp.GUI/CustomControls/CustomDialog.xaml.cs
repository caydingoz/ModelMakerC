using System.Windows;

namespace WpfApp.GUI.CustomControls
{
    public partial class CustomDialog : Window
    {
        public CustomDialog(string label)
        {
            InitializeComponent();
            labelName.Text = label;
        }
        private void ExtractModel(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).Extract(GetDialogInput());
            Close();
        }
        public string GetDialogInput()
        {
            return dialogInput.Text;
        }
    }
}
