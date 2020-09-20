using Amazon.CDK;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EdgyRegions
{
    sealed class Program
    {
        public static void Main(string[] args)
        {
            var app = new App();

            new EndpointsStack(app, "Endpoints", new StackProps { Env = new Amazon.CDK.Environment { Region = "us-east-1" } });

            // create test lambdas in every region.
            var regions = new[]{ "us-east-2",
                                "us-east-1",
                                "us-west-1",
                                "us-west-2",

                                "af-south-1",
                                "ap-east-1",
                                "ap-south-1",
                                "ap-northeast-2",
                                "ap-southeast-1",
                                "ap-southeast-2",
                                "ap-northeast-1",
                                "ca-central-1",
                                "eu-central-1",
                                "eu-west-1",
                                "eu-west-2",
                                "eu-west-3",
                                "eu-north-1",
                                "eu-south-1",
                                "me-south-1",
                                "sa-east-1"
                                };

            Console.WriteLine($"There are {args.Length} args\n\t{String.Join("\n\t", args)}");


            regions.ToList().ForEach(delegate (String region)
            {
                new LoadTesterStack(app, "loadtest-" + region, new StackProps { Env = new Amazon.CDK.Environment { Region = region } });

            });
            app.Synth();
        }
    }
}
