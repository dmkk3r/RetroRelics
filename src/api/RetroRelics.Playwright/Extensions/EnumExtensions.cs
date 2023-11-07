using System.ComponentModel;

namespace RetroRelics.Playwright.Extensions;

public static class EnumExtensions {
    public static string GetEnumDescription(this Enum enumValue) {
        var type = enumValue.GetType();
        var fieldInfo = type.GetField(enumValue.ToString());

        if (fieldInfo == null)
            return string.Empty;

        var enumMemberAttribute = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

        return enumMemberAttribute.Length > 0 ? enumMemberAttribute[0].Description : string.Empty;
    }
}