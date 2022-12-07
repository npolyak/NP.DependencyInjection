// (c) Nick Polyak 2022 - http://awebpros.com/
// License: MIT License (https://opensource.org/licenses/MIT)
//
// short overview of copyright rules:
// 1. you can use this framework in any commercial or non-commercial 
//    product as long as you retain this copyright message
// 2. Do not blame the author of this software if something goes wrong. 
// 
// Also, please, mention this software in any documentation for the 
// products that use it.

namespace NP.DependencyInjection.Interfaces
{
    // unmodifyable IoC (DI) container that returns composed object
    public interface IDependencyInjectionContainer
    {
        // composes all the properties marked with InjectAttribute 
        // for the object
        void ComposeObject(object obj);

        // returns (and if appropriate also composes) an object
        // corresponding to (resolvingType, resolutionKey) pair
        object Resolve(Type resolvingType, object? resolutionKey = null);

        // returns (and if appropriate also composes) an object
        // corresponding to (typeof(TResolving), resolutionKey) pair
        TResolving Resolve<TResolving>(object? resolutionKey = null);
    }
}
