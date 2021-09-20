using Caliburn.Micro;
using System.Linq;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using WpfApp.Domain.Models;
using System.Text.Json;
using System.Diagnostics;
using System;
using System.ComponentModel;
using Microsoft.Win32;
using AutoMapper;
using WpfApp.Infrastructure.Dtos;
using WpfApp.Infrastructure.Building;
using WpfApp.Infrastructure.Building.BuildingSteps;
using System.Threading.Tasks;
using WpfApp.GUI.CustomControls;

namespace WpfApp.GUI
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private BindableCollection<ModelItem> _modelList { get; set; }
        public BindableCollection<ModelItem> ModelList
        {
            get
            {
                return _modelList;
            }
            set
            {
                if (!ReferenceEquals(_modelList, value))
                {
                    _modelList = value;
                    NotifyChanged("ModelList");
                }
            }
        }
        public MainWindow()
        {
            WindowState = WindowState.Maximized;
            DataContext = this;
            ModelList = new BindableCollection<ModelItem>();

            InitializeComponent();
        }
        private void NotifyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        private void AddNewModel(object sender, RoutedEventArgs e)
        {
            int NextModelID = 0;
            if (ModelList.Count > 0)
            {
                NextModelID = ModelList.Select(x => x.ID).Max() + 1;
            }

            ModelList.Add(new ModelItem()
            {
                ID = NextModelID,
                ModelName = "Model Name.."
            });
        }
        private void RemoveModel(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).Tag;
            ModelItem removedModel = ModelList.SingleOrDefault(x => x.ID == id);
            ModelList.Remove(removedModel);
        }
        private void SaveModel(object sender, RoutedEventArgs e)
        {
            if (ModelList.Count > 0)
            {
                SaveFileDialog dialog = new();
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                dialog.Title = "Save Model as Json";
                dialog.DefaultExt = "json";
                dialog.Filter = "json files (*.json)|*.json";
                dialog.ShowDialog();
                string filePath = dialog.FileName;

                if (!String.IsNullOrEmpty(filePath))
                {
                    try
                    {
                        string jsonString = JsonSerializer.Serialize(ModelList);
                        File.WriteAllText(filePath, jsonString);
                    }
                    catch
                    {
                        MessageBox.Show($"Saving failed!", "File Error!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Model empty!", "Saving Error!");
            }
        }
        private void LoadModel(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new();
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dialog.Title = "Select a json file";
            dialog.DefaultExt = "json";
            dialog.Filter = "json files (*.json)|*.json";
            dialog.ShowDialog();
            string filePath = dialog.FileName;

            if (!String.IsNullOrEmpty(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                try
                {
                    ModelList = JsonSerializer.Deserialize<BindableCollection<ModelItem>>(jsonString);
                }
                catch
                {
                    MessageBox.Show($"Please choose a suitable file.\n{filePath}", "File Error!");
                }
            }
        }
        private void ExtractModel(object sender, RoutedEventArgs e)
        {
            if (ModelList.Count == 0)
            {
                MessageBox.Show("Model empty!", "Extracting Error!");
                return;
            }
            CustomDialog namespaceDialog = new CustomDialog("Namespace");
            namespaceDialog.Show();
        }
        public async void Extract(string projectName)
        {
            MapperConfiguration config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ModelItem, ModelItemDto>()
                .ForMember(s => s.ModelName, c => c.MapFrom(m => m.ModelName))
                .ForMember(s => s.ModelProperties, c => c.MapFrom(m => m.ModelProperties))
                .ForMember(s => s.ModelFunctions, c => c.MapFrom(m => m.ModelFunctions));
                cfg.CreateMap<PropertyModel, PropertyModelDto>();
                cfg.CreateMap<FunctionModel, FunctionModelDto>();
            });

            IMapper mapper = config.CreateMapper();

            foreach (ModelItem model in ModelList)
            {
                ModelItemDto dto = mapper.Map<ModelItemDto>(model);
                BuildingContext context = new(projectName, @"C:\Users\Cemil\source\repos\WpfApp", dto);
                Builder builder = new(context);

                builder.AddStep(new AddNamespaceStep());

                builder.AddStep(new AddClassnameStep());

                if (model.ModelProperties.Count > 0)
                {
                    builder.AddStep(new AddPropertiesStep());
                }

                if (model.ModelFunctions.Count > 0)
                {
                    builder.AddStep(new AddFunctionsStep());
                }

                builder.AddStep(new EndFileStep());

                builder.AddStep(new CreateFileStep());

                await builder.StartBuilding();
            }
        }
    }
}
