using Dynacoop2023.AfaPeople.MyFirstPlugin.DynacoopSV;
using Dynacoop2023.AlfaPeople.SharedProject.VO;
using Microsoft.Xrm.Sdk.Workflow;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dynacoop2023.AlfaPeople.SharedProject.Extensions;

namespace Dynacoop2023.AfaPeople.MyFirstPlugin.Actions
{
    public class BuscaNomedoProdutonaAPIExterna91ad0985d7b5ed11b597000d3a888883 : ActionCore
    {
        [Input("ProductId")]
        public InArgument<string> ProductId { get; set; }
        [Output("ProductName")]
        public OutArgument<string> ProductName { get; set; }

        public override async void ExecuteAction(CodeActivityContext context)
        {
            RestResponse response = GetProductsOnAPI();
            ProductVO productFound = GetProductWithID(context, response);

            ProductName.Set(context, productFound.ProductName);
        }

        private ProductVO GetProductWithID(CodeActivityContext context, RestResponse response)
        {
            //List<ProductVO> productsVO = JsonConvert.DeserializeObject<List<ProductVO>>(response.Content);

            List<ProductVO> productsVO = new List<ProductVO>();
            productsVO.Add(new ProductVO()
            {
                ProductId = "PROD-001",
                ProductName = "Box"
            });

            var productFound = (from p in productsVO
                                where p.ProductId == ProductId.Get(context)
                                select p).ToList().FirstOrDefault();

            if (productFound == null)
            {
                throw new Exception("Produto com esse ID não encontrado");
            }

            return productFound;
        }

        private static RestResponse GetProductsOnAPI()
        {
            var options = new RestClientOptions("https://dynaccop2023-productapi.azurewebsites.net")
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/product", Method.Get);
            request.AddHeader("Content-Type", "application/json");
            RestResponse response = client.Execute(request);
            return response;
        }
    }
}
