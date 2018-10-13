using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BananaHomie.Smb.Internal
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class TableColumnAttribute : Attribute
    {
        public string Name { get; set; }
        public int Order { get; set; } = 99;
        public int Justification { get; set; }
        public object Value { get; private set; }

        public TableColumnAttribute(string name, int justification)
        {
            Name = name;
            Justification = justification;
        }

        public string FormatString()
        {
            return $"{{0, {Justification}}}";
        }

        public string FormatName()
        {
            return string.Format(FormatString(), Name);
        }

        public string Format()
        {
            return string.Format(FormatString(), Value);
        }

        public static string GetHeaderString(IEnumerable<TableColumnAttribute> columns)
        {
            var headerBldr = new StringBuilder();

            foreach (var column in columns)
                headerBldr.Append(column.FormatName() + " ");

            return headerBldr.ToString().Trim();
        }

        public static string ToString(IEnumerable<TableColumnAttribute> columns)
        {
            var bldr = new StringBuilder();
            foreach (var column in columns)
                bldr.Append(column.Format() + " ");

            return bldr.ToString();
        }

        public static List<TableColumnAttribute> GetColumns(object o)
        {
            var columns = new List<TableColumnAttribute>();
            foreach (var property in o.GetType().GetProperties())
            {
                if (!property.IsDefined<TableColumnAttribute>())
                    continue;

                var value = property.GetValue(o);
                var attr = property.GetCustomAttribute<TableColumnAttribute>();
                attr.Value = value;

                columns.Add(attr);
            }

            return columns.OrderBy(c => c.Order).ToList();
        }
    }
}
