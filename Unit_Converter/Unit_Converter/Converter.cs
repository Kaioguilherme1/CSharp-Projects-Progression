using System.Globalization;
using System.Numerics;

namespace Unit_Converter;

public class Converter
{
    
    /// <summary>
    /// Convert mass from one unit to other units
    /// </summary>
    /// <param name="value"></param>
    /// <param name="unit"></param>
    /// <returns>
    /// List of lists containing converted value and unit
    /// </returns>
    public List<List<String>> Mass(double value, string unit)
    {
        double value_base = 0;
        List<List<String>> result = new List<List<String>>();
        Dictionary<string, double> units = new Dictionary<string, double>
        {   
            {"mg", 1},
            {"g", 1000},
            {"kg", 1000000},
            {"t", 1000000000},
            {"oz", 28349.5},
            {"lb", 453592},
            {"st", 6350293.18},
            {"ton", 907184740},
        };
        
        //convert value to base unit mg
        value_base = value * units[unit];
        
        //convert value from base unit to other units
        foreach (var item in units)
        {
            double convertedValue = value_base / item.Value;
            result.Add(new List<String> {convertedValue.ToString(CultureInfo.CurrentCulture), item.Key});
        }
        
        return result;
    }
    
    /// <summary>
    /// convert length from one unit to other units
    /// </summary>
    /// <param name="value"></param>
    /// <param name="unit"></param>
    /// <returns>
    /// List of lists containing converted value and unit
    /// </returns>
    public List<List<string>> Length(double value, string unit)
    {
        double value_base = 0;
        List<List<String>> result = new List<List<String>>();
        Dictionary<string, double> units = new Dictionary<string, double>
        {   
            {"mm", 1},
            {"cm", 10},
            {"m", 1000},
            {"km", 1000000},
            {"in", 25.4},
            {"ft", 304.8},
            {"yd", 914.4},
            {"mi", 1609344},
        };
        
        //convert value to base unit mm
        value_base = value * units[unit];
        
        //convert value from base unit to other units
        foreach (var item in units)
        {
            double convertedValue = value_base / item.Value;
            result.Add(new List<String> {convertedValue.ToString(CultureInfo.CurrentCulture), item.Key});
        }
        
        return result;
    }
    
    /// <summary>
    /// convert time from one unit to other units
    /// </summary>
    /// <param name="value"></param>
    /// <param name="unit"></param>
    /// <returns>
    /// list of lists containing converted value and unit
    /// </returns>
    public List<List<string>> Time(double value, string unit)
    {
        double value_base = 0;
        List<List<String>> result = new List<List<String>>();
        Dictionary<string, double> units = new Dictionary<string, double>
        {   
            {"ms", 1},
            {"s", 1000},
            {"min", 60000},
            {"h", 3600000},
            {"d", 86400000},
            {"w", 604800000},
            {"y", 31536000000},
            {"dec", 315360000000},
            {"cen", 3153600000000},
            {"mil", 31536000000000},
            {"aeon", 315360000000000}
        };
        
        //convert value to base unit s
        value_base = value * units[unit];
        
        //convert value from base unit to other units
        foreach (var item in units)
        {
            double convertedValue = value_base / item.Value;
            result.Add(new List<String> {convertedValue.ToString(CultureInfo.CurrentCulture), item.Key});
        }
        
        return result;
    }
    
    /// <summary>
    /// Convert volume from one unit to other units
    /// </summary>
    /// <param name="value"></param>
    /// <param name="unit"></param>
    /// <returns>
    /// List of lists containing converted value and unit
    /// </returns>
    public List<List<string>> Volume(double value, string unit)
    {
        double value_base = 0;
        List<List<String>> result = new List<List<String>>();
        Dictionary<string, double> units = new Dictionary<string, double>
        {   
            {"ml", 1},
            {"l", 1000},
            {"m3", 1000000},
            {"in3", 16.3871},
            {"ft3", 28316.8},
            {"yd3", 764554.9},
            {"gal", 4546.09},
            {"qt", 946.353},
            {"pt", 473.176},
            {"cup", 236.588},
            {"fl oz", 29.5735},
            {"tbsp", 14.7868},
            {"tsp", 4.92892},
        };
        
        //convert value to base unit ml
        value_base = value * units[unit];
        
        //convert value from base unit to other units
        foreach (var item in units)
        {
            double convertedValue = value_base / item.Value;
            result.Add(new List<String> {convertedValue.ToString(CultureInfo.CurrentCulture), item.Key});
        }
        
        return result;
    }

    /// <summary>
    /// Convert temperature from one unit to other units
    /// </summary>
    /// <param name="value"></param>
    /// <param name="unit"></param>
    /// <returns>
    /// list of lists containing converted value and unit
    /// </returns>
    public List<List<string>> Temperature(double value, string unit)
    {
        List<List<String>> result = new List<List<String>>();
        double value_cecius = 0, value_fahrenheit = 0, value_kelvin = 0;
       
        if (unit == "F")
        {
           value_cecius = (value - 32) * 5/9;
           value_fahrenheit = value;
           value_kelvin = value_cecius + 273.15;
        }
        else if(unit == "K")
        {
            value_cecius = value - 273.15;
            value_fahrenheit = (value - 273.15) * 9/5 + 32;
            value_kelvin = value;
        }
        else if (unit == "C")
        {
            value_cecius = value;
            value_fahrenheit = value * 9/5 + 32;
            value_kelvin = value + 273.15;
        }
        
        result.Add(new List<String> {value_cecius.ToString(), "C\u00b0"});
        result.Add(new List<String> {value_fahrenheit.ToString(), "F\u00b0"});
        result.Add(new List<String> {value_kelvin.ToString(), "K"});
        
        return result;
    }

    /// <summary>
    /// Convert area from one unit to other units
    /// </summary>
    /// <param name="value"></param>
    /// <param name="unit"></param>
    /// <returns>
    /// List of lists containing converted value and unit
    /// </returns>
    public List<List<string>> Area(double value, string unit)
    {
        double value_base = 0;
        List<List<String>> result = new List<List<String>>();
        Dictionary<string, double> units = new Dictionary<string, double>
        {
            { "cm2", 1 },
            { "m2", 10000 },
            { "km2", 10000000000 },
            { "in2", 6.4516 },
            { "ft2", 929.03 },
            { "yd2", 8361.27 },
            { "mi2", 25899880000 },
            { "ac", 40468564.2 },
            { "ha", 100000000 },
        };

        //convert value to base unit cm2
        value_base = value * units[unit];

        //convert value from base unit to other units
        foreach (var item in units)
        {
            double convertedValue = value_base / item.Value;
            result.Add(new List<String> { convertedValue.ToString(CultureInfo.CurrentCulture), item.Key });
        }

        return result;
    }

    /// <summary>
    /// convert Data from one unit to other units
    /// </summary>
    /// <param name="value"></param>
    /// <param name="unit"></param>
    /// <returns>
    /// List of lists containing converted value and unit
    /// </returns>
    public List<List<String>> Data(decimal value, string unit)
    {
        decimal value_base = 0;
        List<List<String>> result = new List<List<String>>();
        Dictionary<string, decimal> units = new Dictionary<string, decimal>
        {   
            {"b",  1},
            {"kb", 1024},
            {"mb", 1048576},
            {"gb", 1073741824},
            {"tb", 1099511627776},
            {"pb", 1125899906842624},
            {"eb", 1152921504606846976},
        };
        
        //convert value to base unit b
        value_base = value * units[unit];
        
        //convert value from base unit to other units
        foreach (var item in units)
        {
            decimal convertedValue = value_base / item.Value;
            result.Add(new List<String> {convertedValue.ToString(CultureInfo.CurrentCulture), item.Key});
        }
        
        return result;
    }
}