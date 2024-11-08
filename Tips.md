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

It is a long-running task

### Service

### Middleware

> [!IMPORTANT]
> Middleware is registered once, and It uses until the program is running

> [!IMPORTANT]
> At the end of middleware, you must call Next() method to continue middlewares

> [!TIP]
> When the middleware is started,ordering is crucial.It means that First running middleware will come back the last
> response.
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
> When you have a map with some middlewares, the pipeline just excute your special map.what if you may have other
> middlewares.

### Routing

### Dependency

#### 1. Inversion of control (IOC)

A class must just implement the business that you need.Otherwise,
every work must be inverted in other class.

Key Benefits of IoC:

- **Decoupling:** Objects rely less on actual implementations and more on abstractions, making the system more modular.

- **Ease of Testing:** With dependencies injected, it is easier to replace genuine dependencies with mocks or stubs,
  enabling unit testing.

- **Flexibility:** Changes to system behavior or configurations can be made without altering the source code, which
  improves maintenance.

#### 2. Dependecy inversion principal (DIP)

#### 3. Dependency Injection (DI)

#### 4. Dependency chain

#### 4. Concrete Injection

you don't need to add interface for registering Dependency life cycle. With Concrete injection, you just
register your class in the dependecy life cycle method.

#### 5. Life cycle

- Transient :  Every time, when you need to an instance of object, program create a fresh or new object
- Scope : Whenever you create an instance, it will be created once per user and shared across all the request (e.g. HTTP
  Request,Transaction )
- Singleton : It creates just one instance all over the program until application will be destroyed

> [!Tip]
> We cannot register a Scope object in a Singleton object but Transient oject is ok

> [!Tip]
> We register both life time object in the Scope class, Transient and Singleton

> [!Tip]
> We register both life time object in the Transient class, Scope and Singleton

#### 6. Factory

#### 7. Method Injection

#### 8. Constructor Injection

IMiddleware interface

> [!IMPORTANT]
> If you have an interface with veriety of inherited class, you should
> register all of classes with the interface. Eventually, you use
> IEnumerable in routing

### Client-Side package manager

### HTTPS

#### UseHttpsRedirection() Middleware

```c#
app.UseHttpsRedirection();
```

> [!IMPORTANT]
> When we use UseHttpsRedirection in the Program class, All the http
> request will cast to https with status 307. This approach can be
> vulnerable security against Man-in-the-middle attack

#### HSTS

Register Hsts service :

```c#
builder.Services.AddHsts(opt => {
    opt.MaxAge = TimeSpan.FromDays(1);
    opt.IncludeSubDomains = true;
});
```

Use optional Hsts middleware :

```c#
if(!appEnvironment.IsProduction())
{
    app.UseHsts();
}
```

<br />

> [!IMPORTANT]
> Hsts Always work with defautl HTTPS port(443).If you manually change
> the Https port, Hsts will not be able to detect the port

### Exception

#### - Developer Exception

```c#
if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(new DeveloperExceptionPageOption
    {
        SourceCodeLineCount = 8
    });
}
```

#### - Production Exception

```c#
if(app.Environment.IsProduction())
{
    app.UseExceptionHandler(new DeveloperExceptionPageOption
    {
        SourceCodeLineCount = 8
    });
}
```

### State management

#### Cookie

These are beneficial items to how we use Cookie :

- Domain
- Expires
- HttpOnly
- IsEssential
- MaxAge
- Path
- SameSite
- Secure

#### Cache

- InMemory
- Distributed

#### Session

### Configuration

#### Types of fetching data from config file

#### Add extra config file

#### which config is running?

LunchSettings => ASPNETCORE_ENVIRONMENT

#### Add .cs (dto) file for working with Configuration (IOption)

### Log

#### Every Log consist of

- Log level
- Event category
- Message
- Parameters
- Exceptions
- EventId

#### Types of Logging format

##### Flat Log

- NetScapades.RollingFile

- Serilog
    - Structured data
    - Provided sink
    - Enrichment

##### Structured Log

- ELK
- Splunk
- seq

#### Log verbosity

#### Scope

### Rest Api

#### 6 golden rulls of Rest

- Client-Server
- Stateless
- Cacheable
- Uniform interface
- Layered system
- Code on demand

#### Minimal Api

#### Controller

#### Attributes of controller

- Route
- HttpGet
- HttpPost
- HttpDelete
- HttpPatch
- HttpHead
- AcceptVerbs

#### what is the difference between ViewResult and IActionResult

#### DI in Controller

1. Instantiate in constructor

2. Instantiate in input parameter

```c#
public IActonResult GetProduct(ProductDbContext dbContext)
{
    var product = dbContext.Prodcuts.ToList();
    return Ok(product);
}
  ```

#### Model Binding


```c#
[HttpGet(GetProduct/{id})]
public IActonResult GetProduct(ProductDbContext dbContext,int id)
{
    var product = dbContext.Prodcuts.Where(x=>x.Id == id).ToList();
    
    if(product is null)
        return NotFound();
    
    return Ok(product);
}
  ```

#### What is the Over binding and Over posting


### Razor

### View-Components

### Tag Helpers

### Model Binding

### Model Validation

### Filters

### Identity

#### What is the AAA

- Authentication
- Authorization
- Accounting


### Authentication and Authorization

### gRPC

gRPC Trasfers data with binary format with HTTP2

#### What is the difference between RPC and REST

- RPC (Remote procedure call)
    - Communication with Network protocol
    - It isn't asynchronous

- REST
    - Speak according to the HTTP


#### what is the gRPC channel

- Critical data for initial a channel:
    - Host address
    - Port
    - Connection credential
        - SSL / TLS
        - Application layer transport security (ALTS)
        - Token based authentication

> [!TIP]
> 1. You can set a credential for a connection
> 2. You can set a credential for a request


- Channel status : 
    - Idle
    - Connecting
    - Ready
    - Transent Failure
    - Shutdown


#### How many type of services in gRPC

- Unary

![Unary](https://techdozo.dev/wp-content/uploads/2021/09/grpc-Page-2.png.webp)

- Service streaming

![Service streaming](https://techdozo.dev/wp-content/uploads/2021/10/grpc-Server-Streaming.drawio.png.webp)

- Client streaming

![Client streaming](https://techdozo.dev/wp-content/uploads/2023/01/image-1024x380.png.webp)

- Biderectional streaming

![Biderectional streaming](https://techdozo.dev/wp-content/uploads/2023/02/image-1024x520.png.webp)


#### gRPC status

gRPC status are different with http status. There are some status of gRPC

- OK (0)
- CANCELLED	(1)
- UNKNOWN (2)
- INVALID_ARGUMENT (3)
- DEADLINE_EXCEEDED	(4)
- NOT_FOUND	(5)
- ALREADY_EXISTS (6)
- PERMISSION_DENIED	(7)
- RESOURCE_EXHAUSTED (8)
- FAILED_PRECONDITION (9)
- ABORTED (10)
- OUT_OF_RANGE (11)
- UNIMPLEMENTED	(12)
- INTERNAL (13)
- UNAVAILABLE (14)
- DATA_LOSS (15)
- UNAUTHENTICATED (16)

#### What are the advantages and disadvantages of gRPC

- Advantages : 
    - High Performance: gRPC is built on HTTP/2 and Protocol Buffers (Protobuf), which make data transmission faster and more efficient.
      The binary serialization of Protobuf is more compact and quicker to process compared to text formats like JSON.
    - Supports Multiplexing: With HTTP/2, gRPC can handle multiple simultaneous requests over a single connection, which is particularly useful for real-time applications.
    - Rich Communication Options: gRPC supports four types of communication:
    - Strongly Typed APIs: With Protobuf, APIs are strongly typed, enabling better data validation, documentation, and type-safety.\
    - Binary Format : the bester security

- Disadvantages : 

    - Binary Format Not Human-Readable: Protobuf is a binary format, making it harder to debug directly compared to text-based formats like JSON.
    - Limited Browser Support: gRPC cannot be used natively in browsers because HTTP/2 support is limited in certain browser contexts. Workarounds like gRPC-web are required.
    - Learning Curve for Protobuf: Protobuf requires defining schemas and learning a new serialization format, which can increase development complexity for teams not familiar with it.
    - Limited RESTful Integration: gRPC doesn’t align with traditional REST/HTTP conventions, which may not be ideal for public APIs or services needing REST compatibility.
    - Incompatibility with HTTP/1.1: Since gRPC relies on HTTP/2, legacy systems or networks using HTTP/1.1 may face compatibility issues.

#### What is the Protocol Buffer

ProtoBuff file consist of 3 sections

1. Indivisual declaration (ProtoBuff version, ...)

```c#
    syntax = "proto3";

    option csharp_namespace = "ProtobufSamples"

    package greet;
```

> [!IMPORTANT]
> If you just use 'package' section, your service namespace will the name of package.
> However, When you declare 'option csharp_namespace', your service will be worked with the name's option

> [!TIP]
> When you have both choice 'option' and 'package', the package name comes after service name as a prefix.Moreover,
> the option wont be changed and will work as a namespace

2. Service declaration

```c#

service ServiceName{
    rpc MethodName(InputParam) returns (OutputParam){};
}

```

> [!TIP]
> Each method has to have Input Parameter and Outout parameters

3. Message declaration

