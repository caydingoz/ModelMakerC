using System.Linq;
using System.Windows;
using System.Diagnostics;
using System.Windows.Controls;
using Caliburn.Micro;
using WpfApp.Domain.Models;
using WpfApp.Infrastructure;

namespace WpfApp.GUI.CustomControls
{
    public partial class ModelControl : UserControl
    {
        public static readonly DependencyProperty ModelNameProperty = DependencyProperty.Register("ModelName", typeof(string), typeof(ModelControl), new PropertyMetadata(OnModelNamePropertyChanged));
        public static readonly DependencyProperty PropertyListProperty = DependencyProperty.Register("PropertyList", typeof(BindableCollection<PropertyModel>), typeof(ModelControl), new PropertyMetadata(OnPropertyChanged));
        public static readonly DependencyProperty FunctionListProperty = DependencyProperty.Register("FunctionList", typeof(BindableCollection<FunctionModel>), typeof(ModelControl), new PropertyMetadata(OnPropertyChanged));
        public string ModelName
        {
            get { return (string)GetValue(ModelNameProperty); }
            set { SetValue(ModelNameProperty, value); }
        }
        public BindableCollection<PropertyModel> PropertyList
        {
            get { return (BindableCollection<PropertyModel>)GetValue(PropertyListProperty); }
            set { SetValue(PropertyListProperty, value); }
        }
        public BindableCollection<FunctionModel> FunctionList
        {
            get { return (BindableCollection<FunctionModel>)GetValue(FunctionListProperty); }
            set { SetValue(FunctionListProperty, value); }
        }

        public ModelControl()
        {
            InitializeComponent();
        }

        private void AddNewProperty(object sender, RoutedEventArgs e)
        {
            int NextPropID = 0;
            if (PropertyList.Count > 0)
            {
                NextPropID = PropertyList.Select(x => x.ID).Max() + 1;
            }
            
            PropertyList.Add(new PropertyModel()
            {
                ID = NextPropID,
                PropertyName = "Property Name..",
                PropertyType = "string"
            });
        }
        private void AddNewFunction(object sender, RoutedEventArgs e)
        {
            int NextFuncID = 0;
            if (FunctionList.Count > 0)
            {
                NextFuncID = FunctionList.Select(x => x.ID).Max() + 1;
            }

            FunctionList.Add(new FunctionModel()
            {
                ID = NextFuncID,
                FunctionName = "Function Name..",
                FunctionType = "void"
            });
        }
        private void RemoveProperty(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).Tag;
            PropertyModel removedProp = PropertyList.SingleOrDefault(x => x.ID == id);
            PropertyList.Remove(removedProp);
        }
        private void RemoveFunction(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).Tag;
            FunctionModel removedFunc = FunctionList.SingleOrDefault(x => x.ID == id);
            FunctionList.Remove(removedFunc);
        }
        private static void OnModelNamePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(e.OldValue is not null)
            {
                PropertyTypes.RemoveDataTypes(e.OldValue.ToString());
            }
            PropertyTypes.AddDataTypes(e.NewValue.ToString());
        }
        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            return;
        }
    }
}
