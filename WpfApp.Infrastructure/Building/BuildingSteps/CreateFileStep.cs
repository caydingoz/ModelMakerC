using System.IO;
using System.Threading.Tasks;

namespace WpfApp.Infrastructure.Building.BuildingSteps
{
    public class CreateFileStep : IPipelineStep
    {
        public async Task Execute(BuildingContext context)
        {
            string fileName = context.Path + "\\" + context.ModelName + ".cs";

            if (!File.Exists(fileName))
            {
                using (StreamWriter file = new StreamWriter(fileName))
                {
                    await file.WriteLineAsync(context.Content.ToString());
                }
            }
        }
    }
}
