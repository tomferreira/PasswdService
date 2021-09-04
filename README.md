# PasswdService

A simple microservice to implement password services made up with Azure Functions.

## Checker: [POST] /api/Checker

Verify whether a password is valid. if not valid, return the reason, e.g. InvalidNoneDigit.

## Getting Started

To debug locally, install Azure Functions Core Tools:
```sh
$ npm i -g azure-functions-core-tools@3 --unsafe-perm true
```

And run:
```sh
$ cd PasswdService.Api && func host start
```

The service will be live at the address http://localhost:7071/.

## Unit tests

The project PasswdService.Tests contain the unit tests of microservice.

```sh
$ dotnet test
```