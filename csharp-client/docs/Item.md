# IO.Swagger.Model.Item
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**RefId** | **int?** | item type reference identifier passed backed from request. | [optional] 
**Name** | **string** | name or description of item for your reference. | [optional] 
**Color** | **string** | designated color name for the item in pack visualizations. | [optional] 
**Weight** | **decimal?** | weight of this single packed item. | 
**Sequence** | **string** | A sequence value for the item. This is intended for aisle-bin locations, e.g., aisle 11 bin 20 can be &#39;1120&#39;. Combined with maxSequenceDistance, you can restrict cartons to only have contents from within a certain range. This is very helpful for cartonization when picking efficiency is paramount. Sequence can also be used to pre-sort items for efficient packing on any arbitrary number, such as item weight instead of the default item volume. | [optional] 
**Dimensions** | **Object** | the length, width, and height of the item. | 
**CenterOfMass** | **Object** | the coordinates of the center of mass of the item. | [optional] 
**Virtual** | **bool?** | whether or not this is a real item or a virtual, blocking space (from a subspace or loading rules) | [optional] [default to false]
**Index** | **int?** | the sequence at which the item was packed. | [optional] 
**Message** | **string** | any relevant information or warnings about the packing of the item. | [optional] 
**Origin** | **Object** | the [x,y,z] placement point of the back-bottom corner of the item. | [optional] 
**DeltaCost** | **int?** | the change in the estimated final cost of the box caused by adding the item. | [optional] 
**UniqueId** | **string** | a combination of the item&#39;s refId and its packing sequence, uniquely identifying it. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

