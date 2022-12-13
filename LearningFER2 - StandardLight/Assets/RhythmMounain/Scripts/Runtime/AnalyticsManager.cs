using System.Collections.Generic;
using System.Reflection;

public static class AnalyticsManager
{
    public static void SaveDataAsync<T>(string key, T value)
    {
        var values = new Dictionary<string, object>();
        var fieldsAndProperties = typeof(T).GetMembers(BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetField | BindingFlags.GetProperty);
        foreach (var current in fieldsAndProperties)
        {
            if (current is PropertyInfo propertyInfo)
            {
                if (!propertyInfo.CanRead || !propertyInfo.CanWrite)
                {
                    continue;
                }
                
                values[current.Name] = propertyInfo.GetValue(value);
            }
            else if (current is FieldInfo fieldInfo)
            {
                values[current.Name] = fieldInfo.GetValue(value);
            }
        }
        
        Unity.Services.Analytics.AnalyticsService.Instance.CustomData(key, values);
        Unity.Services.Analytics.AnalyticsService.Instance.Flush();
    }
}