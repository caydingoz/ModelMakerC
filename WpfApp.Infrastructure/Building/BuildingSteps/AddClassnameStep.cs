using System;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Infrastructure.Building.BuildingSteps
{
    public class AddClassnameStep : IPipelineStep
    {
        public async Task Execute(BuildingContext context)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\t");
            sb.Append("public ");
            sb.Append("class ");
            sb.Append(context.ModelName);
            sb.Append(Environment.NewLine);
            sb.Append("\t");
            sb.Append("{");
            sb.Append(Environment.NewLine);
            await context.AddToTextContent(sb);
        }
    }
}
