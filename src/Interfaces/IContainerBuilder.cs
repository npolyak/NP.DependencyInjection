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

using System.Reflection;
using System.Text.RegularExpressions;

namespace NP.DependencyInjection.Interfaces
{
    public interface IContainerBuilder<TKey>
    {
        public void RegisterMultiCell
        (
            Type resolvingType,
            TKey resolutionKey = default
        );

        // register a non-singleton cell producing objects of type 'typeToResolve'
        // to be composed and returned by (resolvingType, resolutionKey) pair. 
        void RegisterType(Type resolvingType, Type typeToResolve, TKey resolutionKey = default);

        // register a non-singleton cell producing objects of type 'TToResolve'
        // to be composed and returned by (typeof(TResolving), resolutionKey) pair. 
        void RegisterType<TResolving, TToResolve>(TKey resolutionKey = default)
            where TToResolve : TResolving;

        // register a singleton cell returning the object instance
        // by (resolvingType, resolutionKey) pair.
        void RegisterSingletonInstance
        (
            Type resolvingType,
            object instance,
            TKey resolutionKey = default);

        // register a singleton cell returning the object instance
        // by (typeof(TResolving), resolutionKey) pair.
        void RegisterSingletonInstance<TResolving>(object instance, TKey resolutionKey = default);

        // register a singleton cell producing objects of type 'typeToResolve'
        // to be composed and returned by (resolvingType, resolutionKey) pair. 
        void RegisterSingletonType<TResolving, TToResolve>(TKey resolutionKey = default)
             where TToResolve : TResolving;

        // register a singleton cell using resolvingFunc to produce
        // an object to be returned by (typeof(TResolving), resolutionKey) pair
        void RegisterSingletonFactoryMethod<TResolving>(
            Func<TResolving> resolvingFunc,
            TKey resolutionKey = default
        );


        // register a non-singleton cell using resolvingFunc to produce
        // an object to be returned by (typeof(TResolving), resolutionKey) pair
        void RegisterFactoryMethod<TResolving>
        (
            Func<TResolving> resolvingFunc,
            TKey resolutionKey = default
        );


        // register a singleton cell using resolving method given by its MethodInfo to produce
        // an object to be returned by (resolvingType, resolutionKey) pair
        void RegisterSingletonFactoryMethodInfo
        (
            MethodBase factoryMethodInfo,
            Type? resolvingType = null,
            TKey resolutionKey = default,
            bool isMultiCell = false);

        // register a singleton cell using resolving method given by its MethodInfo to produce
        // an object to be returned by (typeof(TToResolve), resolutionKey) pair
        void RegisterSingletonFactoryMethodInfo<TToResolve>
        (
            MethodBase factoryMethodInfo,
            TKey resolutionKey = default);

        // register a non-singleton cell using resolving method given by its MethodInfo to produce
        // an object to be returned by (resolvingType, resolutionKey) pair
        void RegisterFactoryMethodInfo
        (
            MethodBase factoryMethodInfo,
            Type? resolvingType = null,
            TKey resolutionKey = default);


        // register a non-singleton cell using resolving method given by its MethodInfo to produce
        // an object to be returned by (typeof(TResolving), resolutionKey) pair
        public void RegisterFactoryMethodInfo<TResolving>
        (
            MethodBase factoryMethodInfo,
            TKey resolutionKey = default);

        // register a type that has RegisterType class level attribute. This attribute
        // should provide the resolvingType (if not - resolving type is
        // assumed to be the one from which the current type is derived),
        // also resolutionKey (if needed) and flag indication whether it is a singleton or not
        // (by default it is not a singleton)
        void RegisterAttributedClass(Type attributedClassToRegister);

        // registers static factory methods for class
        void RegisterAttributedStaticFactoryMethodsFromClass(Type classContainingStaticFactoryMethodToRegister);

        // check every public type within the assembly and register it if it has
        // RegisterTypeAttribute
        void RegisterAssembly(Assembly assembly);

        // Load the assembly and register all its public types that have 
        // RegisterTypeAttribute
        void RegisterDynamicAssemblyByFullPath(string assemblyPath);

        // Load and register all assemblies from the folder that match
        // the regex
        void RegisterPluginsFromFolder
        (
            string assemblyFolderPath,
            Regex? matchingFileName = null
        );

        // load and register all assemblies that match 
        // the regex from all the subfolders of the base folder. 
        void RegisterPluginsFromSubFolders
        (
            string baseFolderPath,
            Regex? matchingFileName = null);

        // unregister a cell by (resolvingType, resolutionKey) pair. 
        void UnRegister(Type resolvingType, TKey resolutionKey = default);

        // unregister a cell by (resolvingType, resolutionKey) pair. 
        void UnRegister<TResolving>(TKey resolutionKey = default);

        // create the unmodifyable DI container
        IDependencyInjectionContainer<TKey> Build();
    }

    public interface IContainerBuilder : IContainerBuilder<object?> { }
}
