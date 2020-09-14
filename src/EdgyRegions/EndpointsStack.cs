using Amazon.CDK;

using Amazon.CDK.AWS.CloudFront;
using Amazon.CDK.AWS.CloudFront.Origins;
using Amazon.CDK.AWS.APIGateway;
using Amazon.CDK.AWS.Lambda;
using System.Collections.Generic;

namespace EdgyRegions
{
    public class EndpointsStack : Stack
    {
        internal EndpointsStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            // The code that defines your stack goes here

            var fn = new Function(this, "myfunction", new FunctionProps
            {
                Runtime = Runtime.NODEJS_12_X,
                Code = Code.FromAsset("src/EdgyRegions/resources"),
                Handler = "lazy.handler"
            });
            var fnIntegration = new LambdaIntegration(fn, new LambdaIntegrationOptions
            {
                Proxy = true,
                // IntegrationResponses = new IIntegrationResponse[] { new IntegrationResponse { StatusCode = "200" } }
            });

            var edgeCompressedApi = new RestApi(this, "edgeCompressedApi", new RestApiProps
            {
                EndpointConfiguration = new EndpointConfiguration { Types = new EndpointType[] { EndpointType.EDGE } },
                MinimumCompressionSize = 1
            });
            edgeCompressedApi.Root.AddMethod("GET", fnIntegration);

            var edgeUncompressedApi = new RestApi(this, "edgeUncompressedApi", new RestApiProps
            {
                EndpointConfiguration = new EndpointConfiguration { Types = new EndpointType[] { EndpointType.EDGE } },
                // MinimumCompressionSize = -1 // default is disabled 
            });
            edgeUncompressedApi.Root.AddMethod("GET", fnIntegration);

            var regionalCompressedApi = new RestApi(this, "regionalCompressedApi", new RestApiProps
            {
                EndpointConfiguration = new EndpointConfiguration { Types = new EndpointType[] { EndpointType.REGIONAL } },
                MinimumCompressionSize = 1
            });
            regionalCompressedApi.Root.AddMethod("GET", fnIntegration);

            var regionalUncompressedApi = new RestApi(this, "regionalUncompressedApi", new RestApiProps
            {
                EndpointConfiguration = new EndpointConfiguration { Types = new EndpointType[] { EndpointType.REGIONAL } },
                // MinimumCompressionSize = -1 // default is disabled 
            });
            regionalUncompressedApi.Root.AddMethod("GET", fnIntegration);

            // var edgeCompressed = new CloudFrontWebDistribution(this, "edgeCompressed", new CloudFrontWebDistributionProps
            // {
            //     OriginConfigs = new[]{
            //         new SourceConfiguration{
            //             Behaviors = new IBehavior[]{
            //                 new Behavior{}
            //                 },
            //             CustomOriginSource = new CustomOriginConfig{
            //                 DomainName = edgeCompressedApi.DomainName.DomainName, // defaults to prod
            //             }
            //         }
            //     }
            // });
        }
    }
}
