using Amazon.CDK;

using Amazon.CDK.AWS.CloudFront;
using Amazon.CDK.AWS.CloudFront.Origins;
using Amazon.CDK.AWS.APIGateway;
using Amazon.CDK.AWS.Lambda;
using System.Collections.Generic;

namespace EdgyRegions
{
    public class LoadTesterStack : Stack
    {
        internal LoadTesterStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            // The code that defines your stack goes here

            var fn = new Function(this, "loadtester", new FunctionProps
            {
                FunctionName = "loadtester",
                Runtime = Runtime.NODEJS_12_X,
                Code = Code.FromAsset("src/EdgyRegions/resources/loadtest"),
                Handler = "index.handler",
                Timeout = Duration.Minutes(15)

            });
            var poly = new Amazon.CDK.AWS.IAM.PolicyStatement
            {
                Effect = Amazon.CDK.AWS.IAM.Effect.ALLOW,
            };
            poly.AddActions(new string[] { "cloudwatch:PutMetricData" });
            poly.AddAllResources();
            fn.AddToRolePolicy(poly);
        }

    }


}
