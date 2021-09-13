using System.Collections.Generic;

namespace WpfApp.Infrastructure.Dtos
{
    public class ModelItemDto
    {
        public string ModelName { get; set; }
        public List<PropertyModelDto> ModelProperties { get; set; }
        public List<FunctionModelDto> ModelFunctions { get; set; }
    }
}
