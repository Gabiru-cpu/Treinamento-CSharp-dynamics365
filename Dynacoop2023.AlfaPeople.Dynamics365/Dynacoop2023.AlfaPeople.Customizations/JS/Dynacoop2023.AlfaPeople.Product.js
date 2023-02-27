if (typeof (AlfaPeople) == "undefined") { AlfaPeople = {} } 
if (typeof (AlfaPeople.Product) == "undefined") { AlfaPeople = {} } 

AlfaPeople.Product = {
    OnIdChange: function (executionContext) {
        var formContext = executionContext.getFormContext();

        var id = Xrm.Page.data.entity.getId();

		var productId = formContext.getAttribute("productnumber").getValue();

		var execute_new_BuscaNomedoProdutonaAPIExterna91ad0985d7b5ed11b597000d3a888883_Request = {
			// Parameters
			entity: { entityType: "product", id: id }, 
			ProductId: productId, 

			getMetadata: function () {
				return {
					boundParameter: "entity",
					parameterTypes: {
						entity: { typeName: "mscrm.product", structuralProperty: 5 },
						ProductId: { typeName: "Edm.String", structuralProperty: 1 }
					},
					operationType: 0, operationName: "new_BuscaNomedoProdutonaAPIExterna91ad0985d7b5ed11b597000d3a888883"
				};
			}
		};

		Xrm.WebApi.execute(execute_new_BuscaNomedoProdutonaAPIExterna91ad0985d7b5ed11b597000d3a888883_Request).then(
			function success(response) {
				debugger;
				if (response.ok) { return response.json(); }
			}
		).then(function (responseBody) {
			debugger;
			var result = responseBody;
			console.log(result);
			// Return Type: mscrm.new_BuscaNomedoProdutonaAPIExterna91ad0985d7b5ed11b597000d3a888883Response
			// Output Parameters
			var productname = result["ProductName"]; // Edm.String
			formContext.getAttribute("name").setValue(productname);
		}).catch(function (error) {
			debugger;
			console.log(error.message);
		});
    }
}