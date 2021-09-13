using System;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Infrastructure.Building.BuildingSteps
{
    public class AddFunctionsStep : IPipelineStep
    {
        public async Task Execute(BuildingContext context)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var function in context.ModelFunctions)
            {
                sb.Append("\t\t");
                sb.Append("public");
                sb.Append(" ");
                sb.Append(function.FunctionType);
                sb.Append(" ");
                sb.Append(function.FunctionName);
                sb.Append("()");
                sb.Append(Environment.NewLine);
                sb.Append("\t\t");
                sb.Append("{");
                sb.Append(Environment.NewLine);
                sb.Append("\t\t");
                sb.Append("}");
                sb.Append(Environment.NewLine);
                sb.Append(Environment.NewLine);
            }

            await context.AddToTextContent(sb);
        }
    }
}
