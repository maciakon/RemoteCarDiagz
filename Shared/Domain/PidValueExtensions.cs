namespace RemoteCarDiagz.Shared.Domain
{
    public static class PidValueExtensions
    {
        public static string GetFriendlyName(this PidIdsEnum pidId)
        {
            return pidId switch
            {
                PidIdsEnum.PID_ENGINE_LOAD => "Engine load",
                PidIdsEnum.PID_COOLANT_TEMP => "Coolant temperature",
                PidIdsEnum.PID_ENGINE_RPM => "Engine RPM",
                PidIdsEnum.PID_MAF_FLOW => "Mass air flow sensor air flow rate",
                PidIdsEnum.PID_INTAKE_MAP => "Intake manifold absolute pressure",
                PidIdsEnum.PID_FUEL_PRESSURE => "Fuel pressure",
                PidIdsEnum.PID_THROTTLE => "Throttle position",
                PidIdsEnum.PID_INTAKE_TEMP => "Intake air temperature",
                PidIdsEnum.PID_VEHICLE_SPEED => "Vehicle speed",
                _ => pidId.ToString(),
            };
        }
    }
}
