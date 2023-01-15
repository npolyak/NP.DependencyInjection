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
    public class RegisterBaseAttribute : Attribute
    {
        public bool IsSingleton { get; } = false;

        public Type? ResolvingType { get; }

        public object? ResolutionKey { get; } = null;

        public Type? CellType { get; protected set; } = null;

        public bool IsMultiCell => CellType != null;

        public RegisterBaseAttribute
        (
            Type? resolvingType = null, 
            bool isSingleton = false, 
            object? resolutionKey = null) 
        {
            IsSingleton = isSingleton;

            ResolutionKey = resolutionKey;

            ResolvingType = resolvingType;
        }
    }
}
