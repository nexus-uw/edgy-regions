# Welcome to your CDK C# project!

This is a blank project for C# development with CDK.

The `cdk.json` file tells the CDK Toolkit how to execute your app.

It uses the [.NET Core CLI](https://docs.microsoft.com/dotnet/articles/core/) to compile and execute your project.

## Useful commands

* `dotnet build src` compile this app
* `cdk deploy`       deploy this stack to your default AWS account/region
* `cdk diff`         compare deployed stack with current state
* `cdk synth`        emits the synthesized CloudFormation template

cdk bootstrap --profile regionaledge

//install commands
// build + install lambda
dotnet build src &&  cdk deploy --profile regionaledge

--profile regionaledge

why js lambda
- too much pain to figure out c# dep


test lambda
- take in url
- call get for 14mins
- post latency metrics for each call to cloudwatch