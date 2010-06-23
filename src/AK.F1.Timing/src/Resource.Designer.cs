﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AK.F1.Timing {
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
    internal class Resource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("AK.F1.Timing.Resource", typeof(Resource).Assembly);
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
        ///   Looks up a localized string similar to Expected non-empty string..
        /// </summary>
        internal static string ArgEmptyString {
            get {
                return ResourceManager.GetString("ArgEmptyString", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Expected non-empty collection..
        /// </summary>
        internal static string ArgNonEmptyCollection {
            get {
                return ResourceManager.GetString("ArgNonEmptyCollection", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to deserialize the next object as the object type code is invalid (&apos;{0}&apos;)..
        /// </summary>
        internal static string DecoratedObjectReader_InvalidObjectTypeCode {
            get {
                return ResourceManager.GetString("DecoratedObjectReader_InvalidObjectTypeCode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to deserailize the next object as no property with an identifier of &apos;{0}&apos; was found on type &apos;{1}&apos;..
        /// </summary>
        internal static string DecoratedObjectReader_PropertyMissing {
            get {
                return ResourceManager.GetString("DecoratedObjectReader_PropertyMissing", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to deserialize the next object as the end of the serialization stream was unexpectedly reached..
        /// </summary>
        internal static string DecoratedObjectReader_UnexpectedEndOfStream {
            get {
                return ResourceManager.GetString("DecoratedObjectReader_UnexpectedEndOfStream", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to serialize &apos;{0}&apos; (type &apos;{1}&apos;) as it has already been seen in the current graph..
        /// </summary>
        internal static string DecoratedObjectWriter_CirularReferencesAreNotSupported {
            get {
                return ResourceManager.GetString("DecoratedObjectWriter_CirularReferencesAreNotSupported", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to serialize type &apos;{0}&apos; as a root graph as it is primtive and not an object..
        /// </summary>
        internal static string DecoratedObjectWriter_RootGraphMustBeAnObject {
            get {
                return ResourceManager.GetString("DecoratedObjectWriter_RootGraphMustBeAnObject", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot compare a &apos;{0}&apos; instance to an instance of &apos;{1}&apos;..
        /// </summary>
        internal static string LapGap_InvalidCompareToArgument {
            get {
                return ResourceManager.GetString("LapGap_InvalidCompareToArgument", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The supplied credentials have been rejected by the live-timing service..
        /// </summary>
        internal static string LiveAuthenticationService_CredentialsRejected {
            get {
                return ResourceManager.GetString("LiveAuthenticationService_CredentialsRejected", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to fetch an authentication token from the live-timing service: &apos;{0}&apos;.
        /// </summary>
        internal static string LiveAuthenticationService_FailedToFetchAuthToken {
            get {
                return ResourceManager.GetString("LiveAuthenticationService_FailedToFetchAuthToken", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable parse the next driver status message as the driver status value specified in the message (&apos;{0}&apos;) is invalid..
        /// </summary>
        internal static string LiveData_UnableToConvertToDriverStatus {
            get {
                return ResourceManager.GetString("LiveData_UnableToConvertToDriverStatus", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to parse the next live-timing message as the grid column index &apos;{0}&apos; could not be converted to a GridColumn given the current session (&apos;{1}&apos;)..
        /// </summary>
        internal static string LiveData_UnableToConvertToGridColumn {
            get {
                return ResourceManager.GetString("LiveData_UnableToConvertToGridColumn", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to parse the next live-timing message as the grid column colour value specified in the message (&apos;{0}&apos;) is invalid..
        /// </summary>
        internal static string LiveData_UnableToConvertToGridColumnColour {
            get {
                return ResourceManager.GetString("LiveData_UnableToConvertToGridColumnColour", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to parse the next live-timing message as the posted time type value specified in the message (&apos;{0}&apos;) is invalid..
        /// </summary>
        internal static string LiveData_UnableToConvertToPostedTimeType {
            get {
                return ResourceManager.GetString("LiveData_UnableToConvertToPostedTimeType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable parse the next race status message as the race status value specified in the message (&apos;{0}&apos;) is invalid..
        /// </summary>
        internal static string LiveData_UnableToConvertToSessionStatus {
            get {
                return ResourceManager.GetString("LiveData_UnableToConvertToSessionStatus", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to parse the next this type message as the session type value specified in the message (&apos;{0}&apos;) is invalid..
        /// </summary>
        internal static string LiveData_UnableToConvertToSessionType {
            get {
                return ResourceManager.GetString("LiveData_UnableToConvertToSessionType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to parse the next live-timing message as it contains an incorrectly formatted Double string (&apos;{0}&apos;)..
        /// </summary>
        internal static string LiveData_UnableToParseDouble {
            get {
                return ResourceManager.GetString("LiveData_UnableToParseDouble", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to parse the next live-timing message as it contains an incorrectly formatted Int32 string (&apos;{0}&apos;)..
        /// </summary>
        internal static string LiveData_UnableToParseInt32 {
            get {
                return ResourceManager.GetString("LiveData_UnableToParseInt32", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to parse the next live-timing message as the time value specified in the message (&apos;{0}&apos;) is invalid..
        /// </summary>
        internal static string LiveData_UnableToParseTime {
            get {
                return ResourceManager.GetString("LiveData_UnableToParseTime", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to fetch the session decryption seed from the live-timing service as the user&apos;s authentication token has been rejected..
        /// </summary>
        internal static string LiveDecrypterFactory_AuthenticationTokenRejected {
            get {
                return ResourceManager.GetString("LiveDecrypterFactory_AuthenticationTokenRejected", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to fetch the session decryption seed from the live-timing service: &apos;{0}&apos;.
        /// </summary>
        internal static string LiveDecrypterFactory_FailedToFetchSessionSeed {
            get {
                return ResourceManager.GetString("LiveDecrypterFactory_FailedToFetchSessionSeed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to parse the session decryption seed from &apos;{0}&apos;..
        /// </summary>
        internal static string LiveDecrypterFactory_UnableToParseSeed {
            get {
                return ResourceManager.GetString("LiveDecrypterFactory_UnableToParseSeed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Driver.
        /// </summary>
        internal static string LiveMessageReader_MessageClassification_Driver {
            get {
                return ResourceManager.GetString("LiveMessageReader_MessageClassification_Driver", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to System.
        /// </summary>
        internal static string LiveMessageReader_MessageClassification_System {
            get {
                return ResourceManager.GetString("LiveMessageReader_MessageClassification_System", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Weather.
        /// </summary>
        internal static string LiveMessageReader_MessageClassification_Weather {
            get {
                return ResourceManager.GetString("LiveMessageReader_MessageClassification_Weather", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to read the next live-timing message as the end of the message stream was unexpectedly reached..
        /// </summary>
        internal static string LiveMessageReader_UnexpectedEndOfStream {
            get {
                return ResourceManager.GetString("LiveMessageReader_UnexpectedEndOfStream", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to read any live-timing messages from the stream as the first expected message was not an update keyframe message. The first message encountered was &apos;{0}&apos;..
        /// </summary>
        internal static string LiveMessageReader_UnexpectedFirstMessage {
            get {
                return ResourceManager.GetString("LiveMessageReader_UnexpectedFirstMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to read the next live-timing message as it is not supported.
        ///Message Header: &apos;{0}&apos;
        ///Message Classification: &apos;{1}&apos;.
        /// </summary>
        internal static string LiveMessageReader_UnsupportedMessage {
            get {
                return ResourceManager.GetString("LiveMessageReader_UnsupportedMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to download a keyframe from the live-timing service: &apos;{0}&apos;.
        /// </summary>
        internal static string LiveMessageStreamEndpoint_FailedToOpenKeyframe {
            get {
                return ResourceManager.GetString("LiveMessageStreamEndpoint_FailedToOpenKeyframe", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to open a connection with the live-timing service: &apos;{0}&apos;.
        /// </summary>
        internal static string LiveMessageStreamEndpoint_FailedToOpenStream {
            get {
                return ResourceManager.GetString("LiveMessageStreamEndpoint_FailedToOpenStream", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to open a connection with the live-timing service as the &apos;{0}&apos; hostname failed to resolve..
        /// </summary>
        internal static string LiveMessageStreamEndpoint_FailedToResolveStreamHost {
            get {
                return ResourceManager.GetString("LiveMessageStreamEndpoint_FailedToResolveStreamHost", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The format of the next timing message is invalid..
        /// </summary>
        internal static string MessageReader_InvalidMessage {
            get {
                return ResourceManager.GetString("MessageReader_InvalidMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot compare a &apos;{0}&apos; instance to an instance of &apos;{1}&apos;..
        /// </summary>
        internal static string PostedTime_InvalidCompareToArgument {
            get {
                return ResourceManager.GetString("PostedTime_InvalidCompareToArgument", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The &apos;{0}&apos; type cannot be serialized as the &apos;{1}&apos; property does not have both a get and set method. Note that either method can be private but they must be defined..
        /// </summary>
        internal static string PropertyDescriptor_PropertyHaveGetAndSetMethod {
            get {
                return ResourceManager.GetString("PropertyDescriptor_PropertyHaveGetAndSetMethod", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The &apos;{0}&apos; type cannot be serialized as the &apos;{1}&apos; property is not decorated with the &apos;{2}&apos; attribute..
        /// </summary>
        internal static string PropertyDescriptor_PropertyIsNotDecorated {
            get {
                return ResourceManager.GetString("PropertyDescriptor_PropertyIsNotDecorated", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot compare a {0} instance to an instance of {1}..
        /// </summary>
        internal static string TimeGap_InvalidCompareToArgument {
            get {
                return ResourceManager.GetString("TimeGap_InvalidCompareToArgument", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The &apos;{0}&apos; type already has a property with an identifier of &apos;{1}&apos;..
        /// </summary>
        internal static string TypeDescriptor_DuplicateProperty {
            get {
                return ResourceManager.GetString("TypeDescriptor_DuplicateProperty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A descriptor already exists with an Id of &apos;{0}&apos; for type &apos;{1}&apos; and type &apos;{2}&apos; has been decorated with the same Id..
        /// </summary>
        internal static string TypeDescriptor_DuplicateTypeId {
            get {
                return ResourceManager.GetString("TypeDescriptor_DuplicateTypeId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to deserialize the next object as no type descriptor could be located for type &apos;{0}&apos;..
        /// </summary>
        internal static string TypeDescriptor_NoDescriptorWithTypeId {
            get {
                return ResourceManager.GetString("TypeDescriptor_NoDescriptorWithTypeId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The &apos;{0}&apos; type cannot be serialized as it is not decorated with the &apos;{1}&apos; attribute..
        /// </summary>
        internal static string TypeDescriptor_TypeIsNotDecorated {
            get {
                return ResourceManager.GetString("TypeDescriptor_TypeIsNotDecorated", resourceCulture);
            }
        }
    }
}
