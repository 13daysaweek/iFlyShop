﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ThirteenDaysAWeek.iFlyShop.Api {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Strings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Strings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ThirteenDaysAWeek.iFlyShop.Api.Strings", typeof(Strings).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cache connection string must not be null or empty.
        /// </summary>
        public static string CacheAccessor_Empty_ConnectionString_Message {
            get {
                return ResourceManager.GetString("CacheAccessor_Empty_ConnectionString_Message", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ProductId must be greater than zero.
        /// </summary>
        public static string OrderLineItemValidator_ProductId_Must_Be_Greater_Than_Zero {
            get {
                return ResourceManager.GetString("OrderLineItemValidator_ProductId_Must_Be_Greater_Than_Zero", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Quantity must be greater than zero.
        /// </summary>
        public static string OrderLineItemValidator_Quantity_Must_Be_Greater_Than_Zero {
            get {
                return ResourceManager.GetString("OrderLineItemValidator_Quantity_Must_Be_Greater_Than_Zero", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CustomerId must be greater than zero.
        /// </summary>
        public static string OrderValidator_CustomerId_Must_Be_Greater_Than_Zero {
            get {
                return ResourceManager.GetString("OrderValidator_CustomerId_Must_Be_Greater_Than_Zero", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Order must contain at least one line item.
        /// </summary>
        public static string OrderValidator_Items_Must_Not_Be_Empty {
            get {
                return ResourceManager.GetString("OrderValidator_Items_Must_Not_Be_Empty", resourceCulture);
            }
        }
    }
}
