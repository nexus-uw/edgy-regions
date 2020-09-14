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
            app.Synth();
        }
    }
}
