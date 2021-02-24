# IO.Swagger.Model.Box
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Name** | **string** | name for the type of box. | [optional] 
**RefId** | **int?** | box type reference identifier passed backed from request. | [optional] 
**Price** | **int?** | Fixed price of the container, in whole units of currency, default USD cents. This can represent the cost of a flat rate carton, the cost of the actual carton materials, or it can include any other flat fees that may need to be added on a &lt;i&gt;per-carton&lt;/i&gt; basis, such as handling, accessorial surchages, oversize fees, etc. This value is &lt;i&gt;added&lt;/i&gt; to any rate table rates defined for the carton. | [optional] 
**WeightTare** | **decimal?** | weight of the container when empty or otherwise unladen, i.e., of the box itself. | [optional] 
**WeightMax** | **decimal?** | maximum allowable gross weight for the box, i.e., all packed item weights plus the weightTare. | 
**Dimensions** | **Object** | the [height,length,width] of the box. | 
**CenterOfMass** | **Object** | the coordinates of the center of mass of the box. | [optional] 
**RateTable** | **Object** | An optional rate table definition for improved carton selection and pricing optimization. Defaults are included using retail rates for FedEx and UPS if carrier and service is provided, but optimization can be improved with more data passed in a carton&#39;s specific rate table. Methods are &lt;ol&gt;&lt;li&gt;Provide carrier, service, and zone.&lt;/li&gt;&lt;li&gt;Provide all acceptable weights and prices to use for the carton, similar to actual carrier rate tables.&lt;/li&gt;&lt;li&gt;Provide the coefficients required for a simple linear weight-dependent pricing model.&lt;/li&gt;&lt;/ol&gt; | [optional] 
**Id** | **int?** |  | [optional] 
**Subspace** | [**Subspace**](Subspace.md) |  | [optional] 
**BoxType** | [**BoxType**](BoxType.md) |  | [optional] 
**Items** | [**List&lt;Item&gt;**](Item.md) |  | [optional] 
**VolumeMax** | **decimal?** | total volume of the box. | [optional] 
**VolumeUsed** | **decimal?** | utilized volume of the box, i.e., item volume plus reserved volume. | [optional] 
**VolumeNet** | **decimal?** | volume of box utilized solely by packed items. | [optional] 
**VolumeRemaining** | **decimal?** | remaining volume of the box. | [optional] 
**VolumeReserved** | **decimal?** | reserved volume of the box, i.e., void fill. | [optional] 
**VolumeUtilization** | **decimal?** | percentage of volume utilized by packed items. | [optional] 
**WeightUsed** | **decimal?** | utilized weight of the box. | [optional] 
**WeightNet** | **decimal?** | total weight of box&#39;s contents, not including the box&#39;s empty (tare) weight. | [optional] 
**WeightRemaining** | **decimal?** | remaining weight of the box. | [optional] 
**WeightUtilization** | **decimal?** | percentage of weight utilized by packed items. | [optional] 
**DimensionalWeight** | **decimal?** | the calculated dimensional weight of this box, if applicable. | [optional] 
**DimensionalWeightUsed** | **bool?** | whether or not dimensional weight was used for this box. | [optional] 
**Svg** | **string** | raw svg of visualization. | [optional] 
**CenterOfMassString** | **string** | string representation of box center of mass. | [optional] 
**DepthOrder** | **List&lt;int?&gt;** | &lt;p&gt;sorted list of &#39;item.index&#39; values representing the ordering utilized by the render, back to front.&lt;/p&gt;&lt;p&gt;This list works in tandem with the &#39;eye&#39; point, and can represent a potentially feasible real-world packing order.&lt;/p&gt;&lt;p&gt;E.g., if the &#39;eye&#39; is set to &#39;{x:1, y:0, z:0}&#39;, then the packing image will show a top-down view of the carton, and &#39;depthOrder&#39; will contain the order to place items so that all items on the bottom of the carton are packed first, then those in the next layer, etc., so that no item is placed beneath another already placed item.&lt;/p&gt;&lt;p&gt;Conversely, if the &#39;eye&#39; is set to &#39;{x:0, y:0, z:1}&#39;, the packing image will show an end-on view- -as if from the doors of a shipping trailer, and &#39;depthOrder&#39; will contain the order to place items so that all items farthest from the doors are placed before items directly in front of them.&lt;/p&gt; | [optional] 
**DepthOrderString** | **string** | string representation of depth ordering. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

