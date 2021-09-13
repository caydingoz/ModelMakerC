using System.Collections.Generic;
using System.Threading.Tasks;

namespace WpfApp.Infrastructure.Building
{
    public class Builder
    {
        private BuildingContext _context { get; set; }
        
        private List<IPipelineStep> _steps { get; set; }

        public Builder(BuildingContext context)
        {
            _context = context;
            _steps = new List<IPipelineStep>();
        }
        public void AddStep(IPipelineStep step)
        {
            _steps.Add(step);
        }

        public async Task StartBuilding()
        {
            foreach (IPipelineStep step in _steps)
            {
                await step.Execute(_context);
            }
        }

    }
}
