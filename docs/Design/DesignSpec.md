# Design Specification and Technical Design Decisions


## Design Patterns


### Command Query Responsibility Separation (CQRS)

### Mediator Pattern
 Jimmy Bogard's MediatR package
 

### CQRS and Mediator together

allows the inversion of dependency, the control flow





#### Validation of Requests sent to APIs

We don't want dirty/non-conforming requests being passed to the backend interacting with other parts of our code or persisted to database. This can risk the integrity of the data in the database and increase the likelihood of invalid values/data being used by other parts of the system, which could well result in exceptions, that if are not handled correctly will cause errors.
The Validation of Requests made to the API from the Client is a cross-cutting concern, in other words no matter what request is being handled, we are likely to want to validate it first before doing anything else with it.

We can take advantage of the mediator patten by adding some behaviour to the request pipeline to handle exceptions and return error messages to the client.

A library called FluentValidations can help with this.

It allows us to create Validators for each Query or Command and then inject a checking behaviour into the request pipeline that will ensure requests confirm to pre-defined constraints (definition of valid)

by doing this we can control what http response status code is returned with our exception meaning for example, a 404 Not Found is returned for an exception where the particular resource is not found, rather than returning a less useful 500 internal server error.

#### Logging of Requests

logging is another common concern that is cross-cutting - we want to log when things happen and when errors / exceptions ocurr in the program. in the same way we can inject logging behavior into our request pipeline using the mediator pattern

