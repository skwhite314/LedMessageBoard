﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LedMessageBoard.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public int Global_RefreshRate {
            get {
                return ((int)(this["Global_RefreshRate"]));
            }
            set {
                this["Global_RefreshRate"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("10")]
        public int Global_ScrollRate {
            get {
                return ((int)(this["Global_ScrollRate"]));
            }
            set {
                this["Global_ScrollRate"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Message not found")]
        public string Global_DefaultViewPortMessage {
            get {
                return ((string)(this["Global_DefaultViewPortMessage"]));
            }
            set {
                this["Global_DefaultViewPortMessage"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("3")]
        public byte Global_Brightness {
            get {
                return ((byte)(this["Global_Brightness"]));
            }
            set {
                this["Global_Brightness"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Hello World!")]
        public string CustomTextConfigurationPanel_Message {
            get {
                return ((string)(this["CustomTextConfigurationPanel_Message"]));
            }
            set {
                this["CustomTextConfigurationPanel_Message"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Collections.Specialized.StringCollection Global_ActiveDisplays {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["Global_ActiveDisplays"]));
            }
            set {
                this["Global_ActiveDisplays"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("h:mm tt")]
        public string TimeConfigurationPanel_Format {
            get {
                return ((string)(this["TimeConfigurationPanel_Format"]));
            }
            set {
                this["TimeConfigurationPanel_Format"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.DateTime CountdownConfigurationPanel_Target {
            get {
                return ((global::System.DateTime)(this["CountdownConfigurationPanel_Target"]));
            }
            set {
                this["CountdownConfigurationPanel_Target"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("c")]
        public string CountdownConfigurationPanel_Format {
            get {
                return ((string)(this["CountdownConfigurationPanel_Format"]));
            }
            set {
                this["CountdownConfigurationPanel_Format"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("5")]
        public int Global_StaticDisplayDuration {
            get {
                return ((int)(this["Global_StaticDisplayDuration"]));
            }
            set {
                this["Global_StaticDisplayDuration"] = value;
            }
        }
    }
}
