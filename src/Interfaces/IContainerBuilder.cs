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

using System.ComponentModel;
using System.Reflection;
using System.Text.RegularExpressions;

namespace NP.DependencyInjection.Interfaces
{
    public interface IContainerBuilder
    {
        void RegisterType(Type resolvingType, Type typeToResolve, object? resolutionKey = null);

        void RegisterType<TResolving, TToResolve>(object? resolutionKey = null)
            where TToResolve : TResolving;

        void RegisterSingletonInstance
        (
            Type resolvingType,
            object instance,
            object? resolutionKey = null);

        void RegisterSingletonInstance<TResolving>(object instance, object? resolutionKey = null);

        void RegisterSingletonType<TResolving, TToResolve>(object? resolutionKey = null)
             where TToResolve : TResolving;

        void RegisterSingletonFactoryMethod<TResolving>(
            Func<TResolving> resolvingFunc,
            object? resolutionKey = null
        );

        void RegisterFactoryMethod<TResolving>
        (
            Func<TResolving> resolvingFunc,
            object? resolutionKey = null
        );

        void RegisterSingletonFactoryMethodInfo
        (
            MethodInfo factoryMethodInfo,
            Type? resolvingType = null,
            object? resolutionKey = null);

        void RegisterSingletonFactoryMethodInfo<TToResolve>
        (
            MethodInfo factoryMethodInfo,
            object? resolutionKey = null);


        void RegisterFactoryMethodInfo
        (
            MethodInfo factoryMethodInfo,
            Type? resolvingType = null,
            object? resolutionKey = null);

        public void RegisterFactoryMethodInfo<TResolving>
        (
            MethodInfo factoryMethodInfo,
            object? resolutionKey = null);

        void RegisterAttributedType(Type resolvingType);

        void RegisterAssembly(Assembly assembly);

        void RegisterDynamicAssemblyByFullPath(string assemblyPath);

        void RegisterPluginsFromFolder
        (
            string assemblyFolderPath,
            Regex? matchingFileName = null
        );

        void RegisterPluginsFromSubFolders
        (
            string baseFolderPath,
            Regex? matchingFileName = null);

        void UnRegister(Type resolvingType, object? resolutionKey = null);

        IDependencyInjectionContainer Build();
    }
}
