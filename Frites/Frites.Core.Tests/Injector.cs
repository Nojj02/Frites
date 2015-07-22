using Ninject;

namespace Frites.Core.Tests
{
    public static class Injector
    {
        static Injector()
        {
            Kernel = new MyKernel();
        }
        public static StandardKernel Kernel { get; }

        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }
    }
}