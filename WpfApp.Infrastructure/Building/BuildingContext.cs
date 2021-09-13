using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Infrastructure.Dtos;

namespace WpfApp.Infrastructure.Building
{
    public class BuildingContext
    {
        public string Path { get; private set; }
        public StringBuilder Content { get; private set; }
        public string ProjectName { get; private set; }
        public string ModelName { get; private set; }
        public List<PropertyModelDto> ModelProperties { get; private set; }
        public List<FunctionModelDto> ModelFunctions { get; private set; }

        public BuildingContext(string projectName, string path, ModelItemDto model)
        {
            Path = path;
            Content = new();
            ProjectName = projectName;
            ModelName = model.ModelName;
            ModelProperties = model.ModelProperties;
            ModelFunctions = model.ModelFunctions;
        }

        public async Task AddToTextContent(StringBuilder sb)
        {
            await Task.Run(() => Content.Append(sb));
        }

    }
}
