using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;

namespace Crosscuting.Common
{
    public static class Extension
    {
        public static string FormatMiles(this decimal number)
        {
            var result = string.Format("{0:#,##0;(#,##0);0}", number);
            return result;
        }

        public static string FormatMiles(this int number)
        {
            var result = string.Format("{0:0.00}", number);
            return result;
        }

        public static string FormatMilesTwoDecimal(this decimal number)
        {
            var result = string.Format("{0:0.00}", number);
            return result;
        }

        public static string FormatMilesFourDecimal(this decimal number)
        {
            var result = string.Format("{0:0.0000}", number);
            return result;
        }

        public static string FormatPorcentaje(this decimal number, short decimals = 2)
        {
            string result;
            switch (decimals)
            {
                case 3:
                    {
                        result = $"{string.Format("{0:#0.000;(#0.000);0.000}", number)}%";
                        break;
                    }
                //case 0:
                //    {
                //        ///COMENTARIO
                //            result = $"{String.Format(CultureInfo.InvariantCulture, "{0:#0.00;(#0.00);0.00}",(number))}%";
                //        break;
                //    }
                //case 1:
                //    {
                //        ///COMENTARIO
                //        result = $"{String.Format(CultureInfo.InvariantCulture, "{0:#0.00;(#0.00);0.00}", (number * 100))}%";
                //        break;
                //    }
                //case 2:
                //    {
                //        ///COMENTARIO
                //        result = $"{String.Format(CultureInfo.InvariantCulture, "{0:#0.00;(#0.00);0.00}", (number / 100))}%";
                //        break;
                //    }
                default:
                    {
                        result = $"{string.Format("{0:#0.00;(#0.00);0.00}", number)}%";
                        break;
                    }
            }
            return result;
        }

        public static decimal mgtPorcentaje(this decimal number, short decimals = 2)
        {
            decimal result;

            switch (decimals)
            {
                default:
                    {
                        result = number*100;
                        break;
                    }
            }

            return result;
        }
        public static DateTime GetDate()
        {
            TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time");
            DateTime cstTime = TimeZoneInfo.ConvertTime(DateTime.Now, cstZone);
            return cstTime;
        }

        public static string GetStrMonth(this int Mes)
        {
            var result = CultureInfo.CreateSpecificCulture("es").DateTimeFormat.GetMonthName(Mes).ToUpper();
            return result;
        }
        public static string GetStrMonth(this short Mes)
        {
            var result = CultureInfo.CreateSpecificCulture("es").DateTimeFormat.GetMonthName(Mes).ToUpper();
            return result;
        }

        public static void AddTable<T>(this DynamicParameters source, string parameterName, string dataTableType, IEnumerable<T> values)
        {
            DataTable dataTable = new DataTable();
            PropertyDescriptorCollection propertyDescriptorCollection = TypeDescriptor.GetProperties(typeof(T));
            for (int i = 0; i < propertyDescriptorCollection.Count; i++)
            {
                PropertyDescriptor propertyDescriptor = propertyDescriptorCollection[i];
                Type type = propertyDescriptor.PropertyType;
                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    type = Nullable.GetUnderlyingType(type);
                }
                dataTable.Columns.Add(propertyDescriptor.Name, type);
            }
            object[] val = new object[propertyDescriptorCollection.Count];
            foreach (T iListItem in values)
            {
                for (int i = 0; i < val.Length; i++)
                {
                    val[i] = propertyDescriptorCollection[i].GetValue(iListItem);
                }
                dataTable.Rows.Add(val);
            }
            source.Add(parameterName, dataTable.AsTableValuedParameter(dataTableType));
        }

        public static readonly string MsjGetError = "";
        public static readonly string MsjPostError = "";
        public static readonly string MsjPutError = "";
        public static readonly string MsjDeleteError = "";

    }
}
