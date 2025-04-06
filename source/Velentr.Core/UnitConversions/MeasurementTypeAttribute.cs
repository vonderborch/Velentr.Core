namespace Velentr.Core.UnitConversions;
    
    /// <summary>
    /// An attribute to specify a class as part of a measurement system.
    /// </summary>
    /// <param name="scaleName">The name of the scale.</param>
    /// <param name="measurementType">The type of the measurement.</param>
    /// <param name="isMetricScale">Indicates whether the scale is metric.</param>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class MeasurementTypeAttribute(string scaleName, MeasurementTypes measurementType, bool isMetricScale) : Attribute
    {
        /// <summary>
        /// Gets the name of the scale.
        /// </summary>
        public string ScaleName { get; } = scaleName;
    
        /// <summary>
        /// Gets the type of the measurement.
        /// </summary>
        public MeasurementTypes MeasurementType { get; } = measurementType;
    
        /// <summary>
        /// Gets a value indicating whether the scale is metric.
        /// </summary>
        public bool IsMetricScale { get; } = isMetricScale;
    }
