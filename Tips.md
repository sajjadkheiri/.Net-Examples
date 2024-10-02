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

> [!IMPORTANT]
> Middleware is registered once and It uses until the program is running

> [!IMPORTANT]
> At the end of middleware, you must call Next() method to continue middlewares

> [!TIP]
> When the middleware is started,ordering is crucial.It means that First running middleware will come back the last response.
 <br /> MW Request 1 => MW Request 2 => MW Request 3
 <br /> MW Response 3 => MW Response 2 => MW Response 1 

<br />

#### Types of middleware

- short circuit middleware:

- Terminal middleware:
      
<br />

#### Map
When you want to excute middlewares in a particular route, you can add Map() in the Configure Pipeline.

<br />

> [!TIP]
>  When you have a map with some middlewares, the pipeline just excute your special map.what if you may have other middlewares.


### Routing

### Inversion of control (IOC)
A class must just implement the business that you need.Otherwise,
every work must be inverted in other class.

Key Benefits of IoC:

- **Decoupling:** Objects rely less on actual implementations and more on abstractions, making the system more modular.

- **Ease of Testing:** With dependencies injected, it is easier to replace genuine dependencies with mocks or stubs, enabling unit testing.

- **Flexibility:** Changes to system behavior or configurations can be made without altering the source code, which improves maintenance.

### Dependecy inversion principal

### Dependency Injection (DI)