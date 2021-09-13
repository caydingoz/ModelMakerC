using System;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Infrastructure.Building.BuildingSteps
{
    public class AddPropertiesStep : IPipelineStep
    {
        public async Task Execute(BuildingContext context)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var property in context.ModelProperties)
            {
                sb.Append("\t\t");
                sb.Append("public");
                sb.Append(" ");
                sb.Append(property.PropertyType);
                sb.Append(" ");
                sb.Append(property.PropertyName);
                sb.Append(" ");
                sb.Append("{ get; set; }");
                sb.Append(Environment.NewLine);
                sb.Append(Environment.NewLine);
            }

            await context.AddToTextContent(sb);
        }
    }
}
