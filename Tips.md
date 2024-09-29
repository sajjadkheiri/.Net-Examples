# .Net Tips

### Http context

- Connection
- Request
    - Header
    - Body
    - Cookie
    - ContentType
    - IsHttps
    - Method
    - Path
    - Query
- Request service
- Response
    - ContentLength
    - ContentType
    - Cookie
    - HasStarted
    - Headers
    - Status code
    - WriteAsync
    - Redirection
- User
- Session
- Feature

### Kestrel

- Hosted service (IHostedService):

It is a long running task

### Service



### Middleware

[!important] Middleware is registered once and It uses until the program is running

[!important] At the end of middleware, you must call Next() method
to continue middlewares

[!important] When the middleware is started,ordering is crucial.It means that First running middleware will come back the last response.

MW Request 1 => MW Request 2 => MW Request 3
MW Response 3 => MW Response 2 => MW Response 1 


- Types of middleware

    1. short circuit middleware : 

    2. Terminal middleware

- Map : When you want to excute middlewares in a particular route, you can add Map() in the ConfigurePipeline.

[!important] When you have a map with some middlewares, the pipeline just excute your special map.what if you may have other middlewares.


