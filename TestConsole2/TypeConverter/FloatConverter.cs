using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole2.TypeConverter
{
    public class FloatConverter<T> : DefaultTypeConverter

    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            return float.Parse(text);
        }

        public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            return value.ToString();
        }
    }
}
