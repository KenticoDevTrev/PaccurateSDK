# IO.Swagger.Model.BoxProperties
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

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

