namespace RemoteCarDiagz.Shared.Mqtt
{
    public static class MqttTopic
    {
        public const string BaseTopic = "remotecardiagz/";
        public const string ActiveMeasurementsTopic = BaseTopic + "activemeasurements";
        public const string InitialConfigurationTopic = BaseTopic + "initialconfiguration";
        public const string DeviceReadyTopic = BaseTopic + "deviceready";
    }
}
