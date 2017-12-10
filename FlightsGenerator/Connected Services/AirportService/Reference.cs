﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FlightsGenerator.AirportService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ControlTower", Namespace="http://schemas.datacontract.org/2004/07/AirportEntities")]
    [System.SerializableAttribute()]
    public partial class ControlTower : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PlaneManager", Namespace="http://schemas.datacontract.org/2004/07/AirportEntities")]
    [System.SerializableAttribute()]
    public partial class PlaneManager : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<FlightsGenerator.AirportService.Plane> AircraftField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.List<FlightsGenerator.AirportService.Plane> Aircraft {
            get {
                return this.AircraftField;
            }
            set {
                if ((object.ReferenceEquals(this.AircraftField, value) != true)) {
                    this.AircraftField = value;
                    this.RaisePropertyChanged("Aircraft");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Plane", Namespace="http://schemas.datacontract.org/2004/07/AirportEntities")]
    [System.SerializableAttribute()]
    public partial class Plane : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool AvialableField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private FlightsGenerator.AirportService.Flow FlowField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private FlightsGenerator.AirportService.PassengersState PassengersStateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PlaneIDField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Avialable {
            get {
                return this.AvialableField;
            }
            set {
                if ((this.AvialableField.Equals(value) != true)) {
                    this.AvialableField = value;
                    this.RaisePropertyChanged("Avialable");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public FlightsGenerator.AirportService.Flow Flow {
            get {
                return this.FlowField;
            }
            set {
                if ((this.FlowField.Equals(value) != true)) {
                    this.FlowField = value;
                    this.RaisePropertyChanged("Flow");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public FlightsGenerator.AirportService.PassengersState PassengersState {
            get {
                return this.PassengersStateField;
            }
            set {
                if ((this.PassengersStateField.Equals(value) != true)) {
                    this.PassengersStateField = value;
                    this.RaisePropertyChanged("PassengersState");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PlaneID {
            get {
                return this.PlaneIDField;
            }
            set {
                if ((this.PlaneIDField.Equals(value) != true)) {
                    this.PlaneIDField = value;
                    this.RaisePropertyChanged("PlaneID");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Flow", Namespace="http://schemas.datacontract.org/2004/07/AirportEntities")]
    public enum Flow : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        LandStatus = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        TakeoffStatus = 1,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PassengersState", Namespace="http://schemas.datacontract.org/2004/07/AirportEntities")]
    public enum PassengersState : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Full = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Empty = 1,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Flight", Namespace="http://schemas.datacontract.org/2004/07/AirportEntities")]
    [System.SerializableAttribute()]
    public partial class Flight : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int FlightNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private FlightsGenerator.AirportService.Flow FlowField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private FlightsGenerator.AirportService.Plane PlaneField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int FlightNumber {
            get {
                return this.FlightNumberField;
            }
            set {
                if ((this.FlightNumberField.Equals(value) != true)) {
                    this.FlightNumberField = value;
                    this.RaisePropertyChanged("FlightNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public FlightsGenerator.AirportService.Flow Flow {
            get {
                return this.FlowField;
            }
            set {
                if ((this.FlowField.Equals(value) != true)) {
                    this.FlowField = value;
                    this.RaisePropertyChanged("Flow");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public FlightsGenerator.AirportService.Plane Plane {
            get {
                return this.PlaneField;
            }
            set {
                if ((object.ReferenceEquals(this.PlaneField, value) != true)) {
                    this.PlaneField = value;
                    this.RaisePropertyChanged("Plane");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AirportService.IAirportService")]
    public interface IAirportService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAirportService/GetControlTower", ReplyAction="http://tempuri.org/IAirportService/GetControlTowerResponse")]
        FlightsGenerator.AirportService.ControlTower GetControlTower();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAirportService/GetControlTower", ReplyAction="http://tempuri.org/IAirportService/GetControlTowerResponse")]
        System.Threading.Tasks.Task<FlightsGenerator.AirportService.ControlTower> GetControlTowerAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAirportService/GetPlaneManager", ReplyAction="http://tempuri.org/IAirportService/GetPlaneManagerResponse")]
        FlightsGenerator.AirportService.PlaneManager GetPlaneManager();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAirportService/GetPlaneManager", ReplyAction="http://tempuri.org/IAirportService/GetPlaneManagerResponse")]
        System.Threading.Tasks.Task<FlightsGenerator.AirportService.PlaneManager> GetPlaneManagerAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAirportService/GetPlane", ReplyAction="http://tempuri.org/IAirportService/GetPlaneResponse")]
        FlightsGenerator.AirportService.Plane GetPlane();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAirportService/GetPlane", ReplyAction="http://tempuri.org/IAirportService/GetPlaneResponse")]
        System.Threading.Tasks.Task<FlightsGenerator.AirportService.Plane> GetPlaneAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAirportService/GetFlight", ReplyAction="http://tempuri.org/IAirportService/GetFlightResponse")]
        FlightsGenerator.AirportService.Flight GetFlight();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAirportService/GetFlight", ReplyAction="http://tempuri.org/IAirportService/GetFlightResponse")]
        System.Threading.Tasks.Task<FlightsGenerator.AirportService.Flight> GetFlightAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAirportService/UpdateDataBase", ReplyAction="http://tempuri.org/IAirportService/UpdateDataBaseResponse")]
        void UpdateDataBase();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAirportService/UpdateDataBase", ReplyAction="http://tempuri.org/IAirportService/UpdateDataBaseResponse")]
        System.Threading.Tasks.Task UpdateDataBaseAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAirportService/GetValue", ReplyAction="http://tempuri.org/IAirportService/GetValueResponse")]
        string GetValue();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAirportService/GetValue", ReplyAction="http://tempuri.org/IAirportService/GetValueResponse")]
        System.Threading.Tasks.Task<string> GetValueAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAirportServiceChannel : FlightsGenerator.AirportService.IAirportService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AirportServiceClient : System.ServiceModel.ClientBase<FlightsGenerator.AirportService.IAirportService>, FlightsGenerator.AirportService.IAirportService {
        
        public AirportServiceClient() {
        }
        
        public AirportServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AirportServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AirportServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AirportServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public FlightsGenerator.AirportService.ControlTower GetControlTower() {
            return base.Channel.GetControlTower();
        }
        
        public System.Threading.Tasks.Task<FlightsGenerator.AirportService.ControlTower> GetControlTowerAsync() {
            return base.Channel.GetControlTowerAsync();
        }
        
        public FlightsGenerator.AirportService.PlaneManager GetPlaneManager() {
            return base.Channel.GetPlaneManager();
        }
        
        public System.Threading.Tasks.Task<FlightsGenerator.AirportService.PlaneManager> GetPlaneManagerAsync() {
            return base.Channel.GetPlaneManagerAsync();
        }
        
        public FlightsGenerator.AirportService.Plane GetPlane() {
            return base.Channel.GetPlane();
        }
        
        public System.Threading.Tasks.Task<FlightsGenerator.AirportService.Plane> GetPlaneAsync() {
            return base.Channel.GetPlaneAsync();
        }
        
        public FlightsGenerator.AirportService.Flight GetFlight() {
            return base.Channel.GetFlight();
        }
        
        public System.Threading.Tasks.Task<FlightsGenerator.AirportService.Flight> GetFlightAsync() {
            return base.Channel.GetFlightAsync();
        }
        
        public void UpdateDataBase() {
            base.Channel.UpdateDataBase();
        }
        
        public System.Threading.Tasks.Task UpdateDataBaseAsync() {
            return base.Channel.UpdateDataBaseAsync();
        }
        
        public string GetValue() {
            return base.Channel.GetValue();
        }
        
        public System.Threading.Tasks.Task<string> GetValueAsync() {
            return base.Channel.GetValueAsync();
        }
    }
}
