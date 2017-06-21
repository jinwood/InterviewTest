namespace Testsolution.Web.Infrastructure.Windsor
{
    using System.Web.Http.Controllers;
    using System.Web.Mvc;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    public class WebInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var myClasses = Classes.FromThisAssembly();

            container.Register(myClasses
                .Where(type => type.Name.EndsWith("Controller"))
                .WithServiceDefaultInterfaces()
                .LifestylePerWebRequest());

            container.Register(myClasses.
                BasedOn<IController>().
                If(c => c.Name.EndsWith("Controller")).
                LifestyleTransient());


            container.Register(myClasses
                            .BasedOn<IHttpController>()
                            .If(c => c.Name.EndsWith("Controller"))
                            .LifestyleTransient());

        }
    }
}
