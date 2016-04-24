using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using miRobotEditor.Interfaces;

namespace miRobotEditor.Classes
{
    public sealed class PositionBase : IPosition
    {
        private readonly ReadOnlyObservableCollection<PositionValue> _positionalValues = null;
        private ObservableCollection<PositionValue> _values = new ObservableCollection<PositionValue>();

        public PositionBase(string value)
        {
            RawValue = value;
            ParseValues();
        }

        public string Type { get; set; }
        public string RawValue { get; set; }
        public string Scope { get; set; }
        public string Name { get; set; }

        public IEnumerable<PositionValue> PositionalValues
        {
            get { return _positionalValues ?? new ReadOnlyObservableCollection<PositionValue>(_values); }
        }

        public void ParseValues()
        {
            try
            {
                _values = new ObservableCollection<PositionValue>();
                var array = RawValue.Split('=');
                var source = array[1].Substring(1, array[1].Length - 2).Split(',');
                foreach (var current in
                    from s in source
                    select s.Split(' '))
                {
                    _values.Add(new PositionValue
                    {
                        Name = current[0],
                        Value = current[1]
                    });
                }
            }
            catch
            {
            }
        }

        [Localizable(false)]
        public string ExtractFromMatch()
        {
            var text = string.Empty;
            string result;
            try
            {
                text = PositionalValues.Aggregate(text,
                    (current, v) => current + string.Format("{0} {1},", v.Name, v.Value));
                result = text.Substring(0, text.Length - 1);
            }
            catch
            {
                result = string.Empty;
            }
            return result;
        }

        public override string ToString()
        {
            return RawValue;
        }

        private string ConvertFromHex(string value)
        {
            var value2 = double.Parse(value.Substring(1, value.Length - 2), NumberStyles.HexNumber);
            return Convert.ToString(value2, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Function to test if value is numeric
        /// <remarks>Value will fail within try/catch if not numeric</remarks>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool IsNumeric(string value)
        {
            bool result;
            try
            {

                // ReSharper disable once UnusedVariable
                var num = Convert.ToDouble(value);
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }
    }
}