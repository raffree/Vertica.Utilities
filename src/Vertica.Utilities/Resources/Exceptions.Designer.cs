﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Vertica.Utilities.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Exceptions {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Exceptions() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Vertica.Utilities.Resources.Exceptions", typeof(Exceptions).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The end date has to later than the start date &apos;{0}&apos;..
        /// </summary>
        internal static string RandomDate_InvertedRangeTemplate {
            get {
                return ResourceManager.GetString("RandomDate_InvertedRangeTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value must be between {0} and {1}. That is, contained within {2}..
        /// </summary>
        internal static string Range_ArgumentAssertion_Template {
            get {
                return ResourceManager.GetString("Range_ArgumentAssertion_Template", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The generator must generate incrementing values..
        /// </summary>
        internal static string Range_NotIncrementingGenerator {
            get {
                return ResourceManager.GetString("Range_NotIncrementingGenerator", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The start value of the range ({0}) must not be greater than its end value ({1})..
        /// </summary>
        internal static string Range_UnorderedBounds_Template {
            get {
                return ResourceManager.GetString("Range_UnorderedBounds_Template", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to At least one iteration is needed. Increase the targetRuntime value..
        /// </summary>
        internal static string Time_AverageAction_OneIteration {
            get {
                return ResourceManager.GetString("Time_AverageAction_OneIteration", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to In order to set the UtcNow property, the DateTimeOffset must be UTC, but had an offset of {0} instead..
        /// </summary>
        internal static string Time_MustBeUtcTemplate {
            get {
                return ResourceManager.GetString("Time_MustBeUtcTemplate", resourceCulture);
            }
        }
    }
}
