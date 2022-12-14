using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Unity.Services.Analytics;
using Unity.Services.Core;
using Unity.Services.Core.Environments;
using UnityEngine;

public static class AnalyticsManager
{
    public static async Task InitializeAsync()
    {
        Debug.Log("Initializing AnalyticsManager");
        
        try
        {
            var options = new InitializationOptions();
            options.SetEnvironmentName("production");
            await UnityServices.InitializeAsync(options);
            List<string> consentIdentifiers = await AnalyticsService.Instance.CheckForRequiredConsents();
        }
        catch (ConsentCheckException e)
        {
            // Something went wrong when checking the GeoIP, check the e.Reason and handle appropriately.
        }
        
        
        
        Debug.Log($"AnalyticsManager Initialized {{ State: {UnityServices.State} }}");
    }
    
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