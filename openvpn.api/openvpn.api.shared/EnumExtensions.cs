using System;
using System.ComponentModel;

namespace openvpn.api.shared
{
    public static class EnumExtensions
    {

        public static string GetEnumDescription(this Enum value)
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            if (name == null)
                return null;

            var field = type.GetField(name);
            if (field == null)
                return null;
            var attr = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

            return attr != null ? attr.Description : null;
        }
    }
}