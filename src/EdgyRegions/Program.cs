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
            new EdgyRegionsStack(app, "EdgyRegionsStack");
            app.Synth();
        }
    }
}
