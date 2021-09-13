using System.Threading.Tasks;

namespace WpfApp.Infrastructure.Building
{
    public interface IPipelineStep
    {
        Task Execute(BuildingContext context);
    }
}
