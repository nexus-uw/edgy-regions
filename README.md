# edgy-regions
=======

SEE <blog url> for full write up

# purpose
test out the best combination of API Gateway endpoint type + compression for use behind a CloudFront distribution


# how to set up + deploy
- bootstrap cdk ```cdk bootstrap```
- build C# code: ```dotnet build src ```
- deploy endpoints ```cdk deploy Endpoints ``` 
- deploy test lambdas to all commercial regions ```cdk deploy "loadtest-*" --require-approval never```
- run tests ```bash  ./loadtest.bash```

# notes 
### why js lambda

- too much pain to figure out c# dependencies

### load test lambda

- take in url
- call get for 14mins
- post latency metrics for each call to cloudwatch

### results metrics (dashboard)

```
{
    "metrics": [
        [ "edgy-regions", "time", "test", "edgeCompressed" ],
        [ "...", { "stat": "p90" } ],
        [ "...", "edgeUncompressed" ],
        [ "...", { "stat": "p90" } ],
        [ "...", "regionalCompressed" ],
        [ "...", { "stat": "p90" } ],
        [ "...", "regionalUncompressed" ],
        [ "...", { "stat": "p90" } ]
    ],
    "view": "singleValue",
    "stacked": false,
    "region": "<REGION>",
    "stat": "p50",
    "period": 60,
    "setPeriodToTimeRange": true,
    "title": "<REGION> 15min load test 264 KB response "
}
```

# test executed at ~ 2020 09 20 21:00:00 UTC
