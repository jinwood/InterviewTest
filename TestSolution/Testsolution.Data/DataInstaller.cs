
namespace Testsolution.Data
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    public class DataInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                .Where(type => type.Name.EndsWith("Repository"))
                .LifestylePerWebRequest()
                .WithServiceDefaultInterfaces());

            container.Register(Classes.FromThisAssembly()
                .Where(type => type.Name.EndsWith("Provider"))
                .LifestylePerWebRequest()
                .WithServiceDefaultInterfaces());
        }
    }
}
