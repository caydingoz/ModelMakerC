using System.Collections.ObjectModel;

namespace WpfApp.Infrastructure
{
    public static class PropertyTypes
    {
        public static ObservableCollection<string> Types { get; private set; }

        public static void InitializeDataTypes()
        {
            Types = new();
            Types.Add("int");
            Types.Add("string");
            Types.Add("double");
            Types.Add("float");
            Types.Add("long");
            Types.Add("bool");
            Types.Add("char");
            Types.Add("decimal");
            Types.Add("byte");
            Types.Add("Guid");
            Types.Add("DateTime");
        }
        public static void AddDataTypes(string dataType)
        {
            Types.Add(dataType);
        }
        public static void RemoveDataTypes(string dataType)
        {
            Types.Remove(dataType);
        }
    }
}
