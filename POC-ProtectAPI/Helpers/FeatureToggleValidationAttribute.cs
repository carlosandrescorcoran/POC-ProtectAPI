using GraphQL.Client;
using GraphQL.Common.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace POC_ProtectAPI.Helpers
{
    public class FeatureToggleValidationAttribute : ActionFilterAttribute
    {
        public string ToggleName { get; set; }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var bookRequest = new GraphQLRequest
            {
                Query = "{ flag(feature: " + ((char)34) + ToggleName + ((char)34) + "){ feature enabled } }",
                Variables = new
                {
                    featurep = ToggleName
                }
            };
            var graphQLClient = new GraphQLClient("http://localhost:4000/graphql");
            var graphQLResponseTask = graphQLClient.PostAsync(bookRequest);
            graphQLResponseTask.Wait();
            var featureEnabled = graphQLResponseTask.Result.Data.flag.enabled.Value;
            if (!featureEnabled)
            {
                context.Result = new BadRequestObjectResult("User unauthorized.");
            }   
        }
    }
}
