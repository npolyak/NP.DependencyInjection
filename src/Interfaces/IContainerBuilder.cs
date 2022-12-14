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
        // register a non-singleton cell producing objects of type 'typeToResolve'
        // to be composed and returned by (resolvingType, resolutionKey) pair. 
        void RegisterType(Type resolvingType, Type typeToResolve, object? resolutionKey = null);

        // register a non-singleton cell producing objects of type 'TToResolve'
        // to be composed and returned by (typeof(TResolving), resolutionKey) pair. 
        void RegisterType<TResolving, TToResolve>(object? resolutionKey = null)
            where TToResolve : TResolving;

        // register a singleton cell returning the object instance
        // by (resolvingType, resolutionKey) pair.
        void RegisterSingletonInstance
        (
            Type resolvingType,
            object instance,
            object? resolutionKey = null);

        // register a singleton cell returning the object instance
        // by (typeof(TResolving), resolutionKey) pair.
        void RegisterSingletonInstance<TResolving>(object instance, object? resolutionKey = null);

        // register a singleton cell producing objects of type 'typeToResolve'
        // to be composed and returned by (resolvingType, resolutionKey) pair. 
        void RegisterSingletonType<TResolving, TToResolve>(object? resolutionKey = null)
             where TToResolve : TResolving;

        // register a singleton cell using resolvingFunc to produce
        // an object to be returned by (typeof(TResolving), resolutionKey) pair
        void RegisterSingletonFactoryMethod<TResolving>(
            Func<TResolving> resolvingFunc,
            object? resolutionKey = null
        );


        // register a non-singleton cell using resolvingFunc to produce
        // an object to be returned by (typeof(TResolving), resolutionKey) pair
        void RegisterFactoryMethod<TResolving>
        (
            Func<TResolving> resolvingFunc,
            object? resolutionKey = null
        );


        // register a singleton cell using resolving method given by its MethodInfo to produce
        // an object to be returned by (resolvingType, resolutionKey) pair
        void RegisterSingletonFactoryMethodInfo
        (
            MethodBase factoryMethodInfo,
            Type? resolvingType = null,
            object? resolutionKey = null);

        // register a singleton cell using resolving method given by its MethodInfo to produce
        // an object to be returned by (typeof(TToResolve), resolutionKey) pair
        void RegisterSingletonFactoryMethodInfo<TToResolve>
        (
            MethodBase factoryMethodInfo,
            object? resolutionKey = null);

        // register a non-singleton cell using resolving method given by its MethodInfo to produce
        // an object to be returned by (resolvingType, resolutionKey) pair
        void RegisterFactoryMethodInfo
        (
            MethodBase factoryMethodInfo,
            Type? resolvingType = null,
            object? resolutionKey = null);


        // register a non-singleton cell using resolving method given by its MethodInfo to produce
        // an object to be returned by (typeof(TResolving), resolutionKey) pair
        public void RegisterFactoryMethodInfo<TResolving>
        (
            MethodBase factoryMethodInfo,
            object? resolutionKey = null);

        // register a type that has RegisterType class level attribute. This attribute
        // should provide the resolvingType (if not - resolving type is
        // assumed to be the one from which the current type is derived),
        // also resolutionKey (if needed) and flag indication whether it is a singleton or not
        // (by default it is not a singleton)
        void RegisterAttributedType(Type resolvingType);

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
        void UnRegister(Type resolvingType, object? resolutionKey = null);

        // create the unmodifyable DI container
        IDependencyInjectionContainer Build();
    }
}
