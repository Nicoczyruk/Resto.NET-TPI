using System;
using System.ComponentModel;
using System.Globalization;

namespace Resto.NET_TPI 
{
    public class SiNoConverter : BooleanConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (value is bool boolValue)
            {
                return boolValue ? "Si" : "No";
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            string strValue = value as string;
            if (strValue != null)
            {
                return strValue.ToLower() == "si";
            }
            return base.ConvertFrom(context, culture, value);
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(new string[] { "Si", "No" });
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }
    }
}
