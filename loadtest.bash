#!/bin/bash
set -x
# public comercial regions as of sept 2020
declare -a arr=( "us-east-1" 
                  "us-east-2"
                  "us-west-1"
                  "us-west-2"
                  "af-south-1"
                  "ap-east-1"
                  "ap-south-1"
                  "ap-northeast-2"
                  "ap-southeast-1"
                  "ap-southeast-2"
                  "ap-northeast-1"
                  "ca-central-1"
                  "eu-central-1"
                  "eu-west-1"
                  "eu-west-2"
                  "eu-west-3"                               
                  "eu-north-1"
                  "eu-south-1"
                  "me-south-1"
                  "sa-east-1"
                 )
function work() {
  for region in "${arr[@]}"
  do
    aws lambda invoke --function-name loadtester --invocation-type Event --payload "{\"url\":\"$1\",\"name\":\"$2\" , \"duration\":15}" --region $region outfile --profile regionaledge
  done

}
# urls copied from cdk deploy output
work "edgeCompressed" "https://d255zmgjwf6036.cloudfront.net"
work "edgeUncompressed" "https://dcuymx2lunq49.cloudfront.net"
work "regionalUncompressed" "https://d2lmy868oetfbq.cloudfront.net"
work "regionalCompressed" "https://d3jglo0347txef.cloudfront.net"