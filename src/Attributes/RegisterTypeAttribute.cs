// (c) Nick Polyak 2018 - http://awebpros.com/
// License: MIT License (https://opensource.org/licenses/MIT)
//
// short overview of copyright rules:
// 1. you can use this framework in any commercial or non-commercial 
//    product as long as you retain this copyright message
// 2. Do not blame the author of this software if something goes wrong. 
// 
// Also, please, mention this software in any documentation for the 
// products that use it.

namespace NP.DependencyInjection.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class RegisterTypeAttribute : RegisterBaseAttribute
    {
        public RegisterTypeAttribute
        (
            bool isSingleton = false,
            object? resolutionKey = null,
            bool isMultiCell = false)
            :
            base(isSingleton, resolutionKey, isMultiCell)
        {

        }

        public RegisterTypeAttribute
        (
            Type typeToResolveBy, 
            bool isSingleton = false,
            object? resolutionKey = null,
            bool isMultiCell = false) 
            : 
            base(typeToResolveBy, isSingleton, resolutionKey, isMultiCell)
        {

        }
    }
}
