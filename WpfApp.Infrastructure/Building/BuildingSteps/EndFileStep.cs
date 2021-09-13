using System;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Infrastructure.Building.BuildingSteps
{
    public class EndFileStep : IPipelineStep
    {
        public async Task Execute(BuildingContext context)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\t");
            sb.Append("}");
            sb.Append(Environment.NewLine);
            sb.Append("}");
            sb.Append(Environment.NewLine);
            await context.AddToTextContent(sb);
        }
    }
}
