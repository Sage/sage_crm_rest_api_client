# Sage CRM Rest Client Sample project
This project is to help with the Sage CRM REST API usage. This is just some examples and a client that uses the code in a console application that you can use to test

For references please see [REST API References](https://help.sagecrm.com/2020-r1/RestApiReference/).

## Usage

Usings that are required:
- using Sage.CRM.Rest.Api.Interface;
- using Sage.CRM.Rest.Api.Models;

The Models are only required if you are not going to use generics and use the Models from the project rather.

## Creating the client usage
```
SageCRMRestClient client = new SageCRMBuilder()
                               .SetBaseUrl("{http or https}://{server}/sdata/{crm}j/sagecrm2/-/") //this is your base URL in string format
                               .SetLoginCredentials("admin", "") //login id and password in clear text
                               .Build(); //returns an instance of the SageCRMImplementation class

```
## Special Methods
List of the methods on the Interface that will be available.

**GetAllEntities()**
This returns a list of all entities exposed to web services.
Iteration can be done on *EntityList* property.  This will return EntityName and EntityID with a Dictionary object containing <string,Field>

**GetEntityFields()**
This is similar to the GetAllEntities, but should only be used to get field names for an entity specified. 

- Get => Get
- Add => Post
- Edit => Put
- Delete => Delete

## Using Methods
- var proto = await client.GetAllEntities();
- var entities = await client.GetEntityFields("address");
- var resultPayload = await client.Get("company");
- var resultPayload2 = await client.Get("company", 1222);
- var result = await client.Add({company object}, "company");
- await client.Edit(1231, put, "company");
- await client.Delete<Company>(1231);

## More to come
- A blogpost on [Sage City](https://www.sagecity.com/) will be released shortly and a link will be added here to explain the usage in more detail
- Link to a presentation video will be added when done
- logging in or sending commands using the SID will be added
- More fail-safes will be added for code errors/usage, like incorrect URL's
