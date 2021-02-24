# IO.Swagger.Api.DefaultApi

All URIs are relative to *https://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**RootPost**](DefaultApi.md#rootpost) | **POST** / | 


<a name="rootpost"></a>
# **RootPost**
> PackResponse RootPost (Pack pack = null)



a pure-JSON endpoint for packing requests. 

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class RootPostExample
    {
        public void main()
        {
            var apiInstance = new DefaultApi();
            var pack = new Pack(); // Pack | complete set of items, boxes, and parameters to pack. (optional) 

            try
            {
                PackResponse result = apiInstance.RootPost(pack);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.RootPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **pack** | [**Pack**](Pack.md)| complete set of items, boxes, and parameters to pack. | [optional] 

### Return type

[**PackResponse**](PackResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

