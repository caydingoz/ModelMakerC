using System.Collections.Generic;

namespace WpfApp.Infrastructure
{
    public static class FunctionTypes
    {
        public static List<string> Types { get; private set; }

        public static void InitializeFunctionTypes()
        {
            Types = new();
            Types = PropertyTypes.Types;
            Types.Add("void");
            Types.Add("Task");
        }
        public static void AddFunctionTypes(string functionType)
        {
            Types.Add(functionType);
        }
    }
}
