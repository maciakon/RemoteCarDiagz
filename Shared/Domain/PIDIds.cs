namespace RemoteCarDiagz.Shared.Domain
{
    public static class PidIds
    {
        public const byte PID_ENGINE_LOAD = 0x04;
        public const byte PID_COOLANT_TEMP = 0x05;
        public const byte PID_SHORT_TERM_FUEL_TRIM_1 = 0x06;
        public const byte PID_LONG_TERM_FUEL_TRIM_1 = 0x07;
        public const byte PID_SHORT_TERM_FUEL_TRIM_2 = 0x08;
        public const byte PID_LONG_TERM_FUEL_TRIM_2 = 0x09;
        public const byte PID_FUEL_PRESSURE = 0x0A;
        public const byte PID_INTAKE_MAP = 0x0B;
        public const byte PID_ENGINE_RPM  = 0x0C;
        public const byte PID_VEHICLE_SPEED = 0x0D;
        public const byte PID_TIMING_ADVANCE = 0x0E;
        public const byte PID_INTAKE_TEMP = 0x0F;
        public const byte PID_MAF_FLOW = 0x10;
        public const byte PID_THROTTLE = 0x11;
        public const byte PID_AUX_INPUT = 0x1E;
        public const byte PID_RUNTIME = 0x1F;
        public const byte PID_DISTANCE_WITH_MIL = 0x21;
        public const byte PID_COMMANDED_EGR = 0x2C;
        public const byte PID_EGR_ERROR = 0x2D;
        public const byte PID_COMMANDED_EVAPORATIVE_PURGE = 0x2E;
        public const byte PID_FUEL_LEVEL = 0x2F;
        public const byte PID_WARMS_UPS = 0x30;
        public const byte PID_DISTANCE = 0x31;
        public const byte PID_EVAP_SYS_VAPOR_PRESSURE = 0x32;
        public const byte PID_BAROMETRIC = 0x33;
        public const byte PID_CATALYST_TEMP_B1S1 = 0x3C;
        public const byte PID_CATALYST_TEMP_B2S1 = 0x3D;
        public const byte PID_CATALYST_TEMP_B1S2 = 0x3E;
        public const byte PID_CATALYST_TEMP_B2S2 = 0x3F;
        public const byte PID_CONTROL_MODULE_VOLTAGE = 0x42;
        public const byte PID_ABSOLUTE_ENGINE_LOAD = 0x43;
        public const byte PID_AIR_FUEL_EQUIV_RATIO = 0x44;
        public const byte PID_RELATIVE_THROTTLE_POS = 0x45;
        public const byte PID_AMBIENT_TEMP = 0x46;
        public const byte PID_ABSOLUTE_THROTTLE_POS_B = 0x47;
        public const byte PID_ABSOLUTE_THROTTLE_POS_C = 0x48;
        public const byte PID_ACC_PEDAL_POS_D = 0x49;
        public const byte PID_ACC_PEDAL_POS_E = 0x4A;
        public const byte PID_ACC_PEDAL_POS_F = 0x4B;
        public const byte PID_COMMANDED_THROTTLE_ACTUATOR = 0x4C;
        public const byte PID_TIME_WITH_MIL = 0x4D;
        public const byte PID_TIME_SINCE_CODES_CLEARED = 0x4E;
        public const byte PID_ETHANOL_FUEL = 0x52;
        public const byte PID_FUEL_RAIL_PRESSURE = 0x59;
        public const byte PID_HYBRID_BATTERY_PERCENTAGE = 0x5B;
        public const byte PID_ENGINE_OIL_TEMP = 0x5C;
        public const byte PID_FUEL_INJECTION_TIMING = 0x5D;
        public const byte PID_ENGINE_FUEL_RATE = 0x5E;
        public const byte PID_ENGINE_TORQUE_DEMANDED = 0x61;
        public const byte PID_ENGINE_TORQUE_PERCENTAGE = 0x62;
        public const byte PID_ENGINE_REF_TORQUE = 0x63;
    }
}
