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

### Testing (XUnit)

#### AAA

- Arrange
- Act
- Assert

#### what is the Detroit and London Testing

#### Naming convention

#### Exception Assert

#### What is the Trait

#### How to print messages in Test Detail Summary

### HttpClient

#### IHttpClientFactory

#### why we should use IhttpClientFactory instead of HttpClient in c#

#### HttpClient Flow

![HttpClient Flow](https://miro.medium.com/v2/resize:fit:1400/1*b1Z5CSqXhvQ7_wupYgJwSw.png)

#### IHttpClientFactory Lifetime

IHttpClientFactory pool => expire after 2 minutes

#### Named client

When you want to use options in different method, you add in configuration.

```c#
builder.Services.AddHttpClient("posts", client =>
{
    client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
});
```

#### Typed client

It is a rapper on the Named client that you can add HttpClient in constructor,
then register in the program file.

Program.cs

```c#
builder.Services.AddHttpClient<PostServices>();
```

PostServices.cs

```c#
public class PostServices
{
    private readonly System.Net.Http.HttpClient _httpClient;

    public PostServices(System.Net.Http.HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("http://localhost:5000");
    }

    public async Task<List<Post>> GetAllAsync()
    {
        var result = await _httpClient.GetStringAsync("/posts");
        return JsonConvert.DeserializeObject<List<Post>>(result);
    }
}
```

#### Http Message Handler

#### Resiliency (Polly)