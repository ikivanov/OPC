﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18449
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OPCAddin {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
    internal sealed partial class OPCAddinSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static OPCAddinSettings defaultInstance = ((OPCAddinSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new OPCAddinSettings())));
        
        public static OPCAddinSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://localhost:1337")]
        public string ServiceUrl {
            get {
                return ((string)(this["ServiceUrl"]));
            }
        }
    }
}
