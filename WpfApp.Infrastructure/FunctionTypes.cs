using System.Collections.ObjectModel;

namespace WpfApp.Infrastructure
{
    public static class FunctionTypes
    {
        public static ObservableCollection<string> Types { get; private set; }

        public static void InitializeFunctionTypes()
        {
            Types = new();
            Types = PropertyTypes.Types;
            Types.Add("void");
            Types.Add("Task");
        }
    }
}
