using System.Text.Json;
using System.Web;
using RetroRelics.Playwright.Enums.ebay.QueryParams;
using RetroRelics.Playwright.Models;
using RetroRelics.Playwright.Models.ebay;

namespace RetroRelics.Playwright.Extensions;

public static class EbayFilterOptionsExtensions {
    public static string ToQueryString(this EbayFilterOptions filterOptions) {
        var queryParameter = $"{EbayQueryParameter.Keyword.GetEnumDescription()}={HttpUtility.UrlEncode(filterOptions.Keywords)}";

        if (!string.IsNullOrEmpty(filterOptions.ExcludedKeywords))
            queryParameter += $"&{ExtendedKeywordFilter.ExcludeKeyword.GetEnumDescription()}={HttpUtility.UrlEncode(filterOptions.ExcludedKeywords)}";

        if (filterOptions.Completed != null && filterOptions.Completed.Value)
            queryParameter += $"&{EbayQueryParameter.Completed.GetEnumDescription()}=1";

        if (filterOptions.Sold != null && filterOptions.Sold.Value)
            queryParameter += $"&{EbayQueryParameter.Sold.GetEnumDescription()}=1";

        if (filterOptions.ItemsPerPage != null)
            queryParameter += $"&{EbayQueryParameter.ItemsPerPage.GetEnumDescription()}={filterOptions.ItemsPerPage.GetEnumDescription()}";

        if (filterOptions.ListingType != null)
            queryParameter += $"&{filterOptions.ListingType.GetEnumDescription()}=1";

        if (filterOptions.ArticleLocation != null)
            queryParameter += $"&{EbayQueryParameter.ArticleLocation.GetEnumDescription()}={filterOptions.ArticleLocation.GetEnumDescription()}";

        if (filterOptions.RegionalCode != null)
            queryParameter +=
                $"&{EbayQueryParameter.RegionalCode.GetEnumDescription()}={HttpUtility.UrlEncode(filterOptions.RegionalCode.GetEnumDescription())}";

        return queryParameter;
    }

    public static List<FilterField> ToFilterFields(this EbayFilterOptions filterOptions) {
        var fields = new List<FilterField>();
        foreach (var property in filterOptions.GetType().GetProperties()) {
            var filterField = new FilterField();
            var propertyType = property.PropertyType;
            var underlyingPropertyType = Nullable.GetUnderlyingType(propertyType);

            var value = property.GetValue(filterOptions)?.ToString();
            var type = underlyingPropertyType?.Name ?? propertyType.Name;

            filterField.Name = property.Name;
            filterField.Value = value;
            filterField.Type = type;

            if (propertyType.IsValueType) {
                filterField.Nullable = underlyingPropertyType != null;

                if (underlyingPropertyType != null && underlyingPropertyType.IsEnum) {
                    filterField.Enumeration = true;
                    filterField.EnumerationValues = underlyingPropertyType.GetEnumNames();
                }
            }
            else {
                var nullableAttribute = property.CustomAttributes.FirstOrDefault(a => a.AttributeType.Name == "NullableAttribute");
                filterField.Nullable = nullableAttribute != null;
            }

            fields.Add(filterField);
        }

        return fields;
    }

    public static EbayFilterOptions ToEbayFilterOptions(this List<FilterField> filterFields) {
        var filterOptions = new EbayFilterOptions();
        foreach (var filterField in filterFields) {
            var property = filterOptions.GetType().GetProperty(filterField.Name);

            if (property == null)
                continue;

            var propertyType = property.PropertyType;
            var underlyingPropertyType = Nullable.GetUnderlyingType(propertyType);

            if (underlyingPropertyType != null && underlyingPropertyType == typeof(bool)) {
                if (bool.TryParse(filterField.Value, out var result)) {
                    property.SetValue(filterOptions, result);
                }
            }
            else if (underlyingPropertyType != null && underlyingPropertyType.IsEnum) {
                if (filterField.Value == null)
                    property.SetValue(filterOptions, null);
                else {
                    var enumValue = Enum.Parse(underlyingPropertyType, filterField.Value);
                    property.SetValue(filterOptions, enumValue);
                }
            }
            else {
                var value = Convert.ChangeType(filterField.Value, property.PropertyType);
                property.SetValue(filterOptions, value);
            }
        }

        return filterOptions;
    }

    public static string ToJson(this EbayFilterOptions filterOptions) {
        return JsonSerializer.Serialize(filterOptions);
    }
}