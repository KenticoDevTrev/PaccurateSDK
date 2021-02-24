# IO.Swagger.Model.PackResponse
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Boxes** | [**List&lt;Box&gt;**](Box.md) | List of boxes, packed, with their contained items. | [optional] 
**Title** | **string** | title of packing result, when applicable. | [optional] 
**Built** | **string** | build timestamp of engine. | [optional] 
**Version** | **string** | version of engine | [optional] 
**LenBoxes** | **int?** | cardinality of all packed boxes | [optional] 
**LenItems** | **int?** | cardinality of all items | [optional] 
**LenLeftovers** | **int?** | cardinality of items unabled to be packed | [optional] 
**TotalCost** | **int?** | total estimated cost of all packed boxes, when applicable, in cents. | [optional] 
**PackTime** | **decimal?** | seconds spent in packing | [optional] 
**RenderTime** | **decimal?** | seconds spent in rendering and placement instruction creation of packing solution | [optional] 
**TotalTime** | **decimal?** | seconds spent generating response, total. | [optional] 
**Leftovers** | [**List&lt;Item&gt;**](Item.md) | items left over that could not be packed into any available boxes. | [optional] 
**ItemSortUsed** | **string** | name of item sort algorithm used. | [optional] 
**BoxTypeChoiceGoalUsed** | **string** | name of box type choice goal used. | [optional] 
**Scripts** | **string** | additional javascripts for any image loading. | [optional] 
**Styles** | **string** | additional styles for pack images | [optional] 
**Svgs** | **string** | all box SVG images | [optional] 
**Images** | [**List&lt;Image&gt;**](Image.md) | if PNG imageFormat selected, list of PNG image objects. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

