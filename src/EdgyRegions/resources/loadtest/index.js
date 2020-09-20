const AWS = require('aws-sdk')
var cloudwatch = new AWS.CloudWatch()
const fetch = require('node-fetch')

exports.handler = async function ({ url, duration = 14, name }, context) {
  console.log(url, duration, name)
  const endTime = new Date()
  endTime.setMinutes(endTime.getMinutes() + duration)
  let count = 0
  do {
    const start = new Date()
    // lazy mapping to root api gateway
    await fetch(url + '//').then((res) => res.text())
    const end = new Date()
    await cloudwatch
      .putMetricData({
        MetricData: [
          {
            MetricName: 'time',
            Dimensions: [{ Name: 'test', Value: name }],
            Value: end - start,
            Unit: 'Milliseconds',
          },
        ],
        Namespace: 'edgy-regions',
      })
      .promise()
  } while (new Date() < endTime)
  console.log('finished ' + count + ' loads')

  return true
}
