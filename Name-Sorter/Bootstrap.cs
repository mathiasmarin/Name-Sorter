using Name_Sorter.Services;
using SimpleInjector;

namespace Name_Sorter
{
    /// <summary>
    /// Static bootstrapper suitable for console apps. 
    /// </summary>
    public class Bootstrap
    {
        public static Container Container { get; private set; }

        public static void Start() // Register all types
        {
            Container = new Container();

            Container.Register<IPersonFactory,PersonFactory>();
            Container.Register(typeof(ISorter<>),typeof(SorterBase<>));
            Container.Register(typeof(IFileSerializer<>),new []{typeof(TextSerializer).Assembly});

            Container.Verify();
        }
    }
}