using Caliburn.Micro;
using System.Collections.Generic;

namespace WpfApp.Domain.Models
{
    public class ModelItem
    {
        public int ID { get; set; }
        public string ModelName { get; set; }
        public BindableCollection<PropertyModel> ModelProperties { get; set; }
        public BindableCollection<FunctionModel> ModelFunctions { get; set; }
        public List<PropertyModel> asd { get; set; }

        public ModelItem()
        {
            ModelProperties = new BindableCollection<PropertyModel>();
            ModelFunctions = new BindableCollection<FunctionModel>();

            /*
            ModelProperties.Add(new PropertyModel() { 
                ID=1,
                PropertyName="asd",
                PropertyType="prop"
            });*/
        }
    }
}
