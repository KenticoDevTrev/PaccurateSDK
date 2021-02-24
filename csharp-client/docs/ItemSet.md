# IO.Swagger.Model.ItemSet
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
**Quantity** | **int?** | quantity of items of this type in this item set | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

