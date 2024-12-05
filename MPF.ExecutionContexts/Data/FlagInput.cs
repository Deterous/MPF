using System.Text;

namespace MPF.ExecutionContexts.Data
{
    /// <summary>
    /// Represents a boolean flag without a trailing value
    /// </summary>
    public class FlagInput : Input<bool>
    {
        #region Constructors

        /// <inheritdoc/>
        public FlagInput(string name)
            : base(name) { }

        /// <inheritdoc/>
        public FlagInput(string name, bool required)
            : base(name, required) { }

        /// <inheritdoc/>
        public FlagInput(string shortName, string longName)
            : base(shortName, longName) { }

        /// <inheritdoc/>
        public FlagInput(string shortName, string longName, bool required)
            : base(shortName, longName, required) { }

        #endregion

        /// <inheritdoc/>
        public override string Format(bool useEquals)
        {
            // Do not output if there is no value
            if (Value == false)
                return string.Empty;

            // Build the output format
            var builder = new StringBuilder();

            // Flag name
            builder.Append(Name);

            return builder.ToString();
        }

        /// <inheritdoc/>
        public override bool Process(string[] parts, ref int index)
        {
            // Check the parts array
            if (index < 0 || index >= parts.Length)
                return false;

            // Check the name
            if (parts[index] == Name || (_shortName != null && parts[index] == _shortName))
            {
                Value = true;
                return true;
            }

            return false;
        }
    }
}