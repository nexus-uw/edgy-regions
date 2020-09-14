exports.handler = async function (event, context) {
  return {
    statusCode: 200,
    headers: {
      // no caching
      'Cache-Control': 'no-store',
      Expires: '0',
    },
    body: JSON.stringify(
      Array(250 * 1000) // 250kb
        .fill('')
        .map((_) => Math.round(Math.random() * 10))
        .join('')
    ),
  }
}
