﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.1.
// 
#pragma warning disable 1591

namespace MvcWrench.MonkeyWrench.Public {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="PublicSoap", Namespace="http://tempuri.org/")]
    public partial class Public : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetRecentDataOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetCompletedStepsOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetBuildLogOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetRevisionByRevisionOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetProductLatestRevisionsOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetLatestBugCountsOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public Public() {
            this.Url = global::MvcWrench.Properties.Settings.Default.MvcWrench_MonkeyWrench_Public_Public;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event GetRecentDataCompletedEventHandler GetRecentDataCompleted;
        
        /// <remarks/>
        public event GetCompletedStepsCompletedEventHandler GetCompletedStepsCompleted;
        
        /// <remarks/>
        public event GetBuildLogCompletedEventHandler GetBuildLogCompleted;
        
        /// <remarks/>
        public event GetRevisionByRevisionCompletedEventHandler GetRevisionByRevisionCompleted;
        
        /// <remarks/>
        public event GetProductLatestRevisionsCompletedEventHandler GetProductLatestRevisionsCompleted;
        
        /// <remarks/>
        public event GetLatestBugCountsCompletedEventHandler GetLatestBugCountsCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetRecentData", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public BuildRevision[] GetRecentData(string product) {
            object[] results = this.Invoke("GetRecentData", new object[] {
                        product});
            return ((BuildRevision[])(results[0]));
        }
        
        /// <remarks/>
        public void GetRecentDataAsync(string product) {
            this.GetRecentDataAsync(product, null);
        }
        
        /// <remarks/>
        public void GetRecentDataAsync(string product, object userState) {
            if ((this.GetRecentDataOperationCompleted == null)) {
                this.GetRecentDataOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetRecentDataOperationCompleted);
            }
            this.InvokeAsync("GetRecentData", new object[] {
                        product}, this.GetRecentDataOperationCompleted, userState);
        }
        
        private void OnGetRecentDataOperationCompleted(object arg) {
            if ((this.GetRecentDataCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetRecentDataCompleted(this, new GetRecentDataCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetCompletedSteps", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public CompletedBuildStep[] GetCompletedSteps(long buildRevisionID) {
            object[] results = this.Invoke("GetCompletedSteps", new object[] {
                        buildRevisionID});
            return ((CompletedBuildStep[])(results[0]));
        }
        
        /// <remarks/>
        public void GetCompletedStepsAsync(long buildRevisionID) {
            this.GetCompletedStepsAsync(buildRevisionID, null);
        }
        
        /// <remarks/>
        public void GetCompletedStepsAsync(long buildRevisionID, object userState) {
            if ((this.GetCompletedStepsOperationCompleted == null)) {
                this.GetCompletedStepsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetCompletedStepsOperationCompleted);
            }
            this.InvokeAsync("GetCompletedSteps", new object[] {
                        buildRevisionID}, this.GetCompletedStepsOperationCompleted, userState);
        }
        
        private void OnGetCompletedStepsOperationCompleted(object arg) {
            if ((this.GetCompletedStepsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetCompletedStepsCompleted(this, new GetCompletedStepsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetBuildLog", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetBuildLog(int completedStepID) {
            object[] results = this.Invoke("GetBuildLog", new object[] {
                        completedStepID});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetBuildLogAsync(int completedStepID) {
            this.GetBuildLogAsync(completedStepID, null);
        }
        
        /// <remarks/>
        public void GetBuildLogAsync(int completedStepID, object userState) {
            if ((this.GetBuildLogOperationCompleted == null)) {
                this.GetBuildLogOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetBuildLogOperationCompleted);
            }
            this.InvokeAsync("GetBuildLog", new object[] {
                        completedStepID}, this.GetBuildLogOperationCompleted, userState);
        }
        
        private void OnGetBuildLogOperationCompleted(object arg) {
            if ((this.GetBuildLogCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetBuildLogCompleted(this, new GetBuildLogCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetRevisionByRevision", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Revision GetRevisionByRevision(int revision) {
            object[] results = this.Invoke("GetRevisionByRevision", new object[] {
                        revision});
            return ((Revision)(results[0]));
        }
        
        /// <remarks/>
        public void GetRevisionByRevisionAsync(int revision) {
            this.GetRevisionByRevisionAsync(revision, null);
        }
        
        /// <remarks/>
        public void GetRevisionByRevisionAsync(int revision, object userState) {
            if ((this.GetRevisionByRevisionOperationCompleted == null)) {
                this.GetRevisionByRevisionOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetRevisionByRevisionOperationCompleted);
            }
            this.InvokeAsync("GetRevisionByRevision", new object[] {
                        revision}, this.GetRevisionByRevisionOperationCompleted, userState);
        }
        
        private void OnGetRevisionByRevisionOperationCompleted(object arg) {
            if ((this.GetRevisionByRevisionCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetRevisionByRevisionCompleted(this, new GetRevisionByRevisionCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetProductLatestRevisions", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Revision[] GetProductLatestRevisions(int productID, int limit) {
            object[] results = this.Invoke("GetProductLatestRevisions", new object[] {
                        productID,
                        limit});
            return ((Revision[])(results[0]));
        }
        
        /// <remarks/>
        public void GetProductLatestRevisionsAsync(int productID, int limit) {
            this.GetProductLatestRevisionsAsync(productID, limit, null);
        }
        
        /// <remarks/>
        public void GetProductLatestRevisionsAsync(int productID, int limit, object userState) {
            if ((this.GetProductLatestRevisionsOperationCompleted == null)) {
                this.GetProductLatestRevisionsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetProductLatestRevisionsOperationCompleted);
            }
            this.InvokeAsync("GetProductLatestRevisions", new object[] {
                        productID,
                        limit}, this.GetProductLatestRevisionsOperationCompleted, userState);
        }
        
        private void OnGetProductLatestRevisionsOperationCompleted(object arg) {
            if ((this.GetProductLatestRevisionsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetProductLatestRevisionsCompleted(this, new GetProductLatestRevisionsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetLatestBugCounts", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] GetLatestBugCounts(int limit) {
            object[] results = this.Invoke("GetLatestBugCounts", new object[] {
                        limit});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public void GetLatestBugCountsAsync(int limit) {
            this.GetLatestBugCountsAsync(limit, null);
        }
        
        /// <remarks/>
        public void GetLatestBugCountsAsync(int limit, object userState) {
            if ((this.GetLatestBugCountsOperationCompleted == null)) {
                this.GetLatestBugCountsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetLatestBugCountsOperationCompleted);
            }
            this.InvokeAsync("GetLatestBugCounts", new object[] {
                        limit}, this.GetLatestBugCountsOperationCompleted, userState);
        }
        
        private void OnGetLatestBugCountsOperationCompleted(object arg) {
            if ((this.GetLatestBugCountsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetLatestBugCountsCompleted(this, new GetLatestBugCountsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class BuildRevision {
        
        private long idField;
        
        private int productRevisionIDField;
        
        private int platformIDField;
        
        private string platformNameField;
        
        private int builderIDField;
        
        private int statusField;
        
        private string revisionNumberField;
        
        private string authorField;
        
        /// <remarks/>
        public long Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        public int ProductRevisionID {
            get {
                return this.productRevisionIDField;
            }
            set {
                this.productRevisionIDField = value;
            }
        }
        
        /// <remarks/>
        public int PlatformID {
            get {
                return this.platformIDField;
            }
            set {
                this.platformIDField = value;
            }
        }
        
        /// <remarks/>
        public string PlatformName {
            get {
                return this.platformNameField;
            }
            set {
                this.platformNameField = value;
            }
        }
        
        /// <remarks/>
        public int BuilderID {
            get {
                return this.builderIDField;
            }
            set {
                this.builderIDField = value;
            }
        }
        
        /// <remarks/>
        public int Status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
            }
        }
        
        /// <remarks/>
        public string RevisionNumber {
            get {
                return this.revisionNumberField;
            }
            set {
                this.revisionNumberField = value;
            }
        }
        
        /// <remarks/>
        public string Author {
            get {
                return this.authorField;
            }
            set {
                this.authorField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Revision {
        
        private int idField;
        
        private int productIdField;
        
        private int revisionNumberField;
        
        private System.DateTime timeField;
        
        private string authorField;
        
        private int statusField;
        
        private string svnLogField;
        
        private string fileDiffField;
        
        /// <remarks/>
        public int Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        public int ProductId {
            get {
                return this.productIdField;
            }
            set {
                this.productIdField = value;
            }
        }
        
        /// <remarks/>
        public int RevisionNumber {
            get {
                return this.revisionNumberField;
            }
            set {
                this.revisionNumberField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime Time {
            get {
                return this.timeField;
            }
            set {
                this.timeField = value;
            }
        }
        
        /// <remarks/>
        public string Author {
            get {
                return this.authorField;
            }
            set {
                this.authorField = value;
            }
        }
        
        /// <remarks/>
        public int Status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
            }
        }
        
        /// <remarks/>
        public string SvnLog {
            get {
                return this.svnLogField;
            }
            set {
                this.svnLogField = value;
            }
        }
        
        /// <remarks/>
        public string FileDiff {
            get {
                return this.fileDiffField;
            }
            set {
                this.fileDiffField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CompletedBuildStep {
        
        private long idField;
        
        private long buildRevisionIdField;
        
        private int buildStepIdField;
        
        private long elapsedTimeField;
        
        private int exitCodeField;
        
        private int completionStatusField;
        
        private string logField;
        
        private string stepNameField;
        
        private string publishFileField;
        
        /// <remarks/>
        public long Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        public long BuildRevisionId {
            get {
                return this.buildRevisionIdField;
            }
            set {
                this.buildRevisionIdField = value;
            }
        }
        
        /// <remarks/>
        public int BuildStepId {
            get {
                return this.buildStepIdField;
            }
            set {
                this.buildStepIdField = value;
            }
        }
        
        /// <remarks/>
        public long ElapsedTime {
            get {
                return this.elapsedTimeField;
            }
            set {
                this.elapsedTimeField = value;
            }
        }
        
        /// <remarks/>
        public int ExitCode {
            get {
                return this.exitCodeField;
            }
            set {
                this.exitCodeField = value;
            }
        }
        
        /// <remarks/>
        public int CompletionStatus {
            get {
                return this.completionStatusField;
            }
            set {
                this.completionStatusField = value;
            }
        }
        
        /// <remarks/>
        public string Log {
            get {
                return this.logField;
            }
            set {
                this.logField = value;
            }
        }
        
        /// <remarks/>
        public string StepName {
            get {
                return this.stepNameField;
            }
            set {
                this.stepNameField = value;
            }
        }
        
        /// <remarks/>
        public string PublishFile {
            get {
                return this.publishFileField;
            }
            set {
                this.publishFileField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void GetRecentDataCompletedEventHandler(object sender, GetRecentDataCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetRecentDataCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetRecentDataCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public BuildRevision[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((BuildRevision[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void GetCompletedStepsCompletedEventHandler(object sender, GetCompletedStepsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetCompletedStepsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetCompletedStepsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public CompletedBuildStep[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((CompletedBuildStep[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void GetBuildLogCompletedEventHandler(object sender, GetBuildLogCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetBuildLogCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetBuildLogCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void GetRevisionByRevisionCompletedEventHandler(object sender, GetRevisionByRevisionCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetRevisionByRevisionCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetRevisionByRevisionCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Revision Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Revision)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void GetProductLatestRevisionsCompletedEventHandler(object sender, GetProductLatestRevisionsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetProductLatestRevisionsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetProductLatestRevisionsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Revision[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Revision[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void GetLatestBugCountsCompletedEventHandler(object sender, GetLatestBugCountsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetLatestBugCountsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetLatestBugCountsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string[])(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591