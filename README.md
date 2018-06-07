# Idotf
Fluent if/else flow control with support for deferred execution

![Build status](https://ci.appveyor.com/api/projects/status/hithub/nsarris/idotf?branch=master&svg=true)
![Test status](http://teststatusbadge.azurewebsites.net/api/status/nsarris/idotf)
(https://ci.appveyor.com/project/nsarris/idotf)

Example flow of actions:

```csharp
    I.F(a == b, SomeAction)
    .ElseIf(() => a == 1, () => DoSomething(3))
    .ElseIf(() => IsNumber("1"), () => DoSomething(4))
    .Else(() => DoSomething(5));
```

Example flow of funcs returning int:

```csharp
var result =
    I.F(a == b, GetNumber)
    .ElseIf(() => a == 1, () => GetAnotherNumber(3))
    .ElseIf(() => IsNumber("1"), () => GetAnotherNumber(4))
    .Else(() => GetAnotherNumber(5))
    .Result;
```

Example deferred of funcs returning int with input of int:

```csharp
var r =
    I.FDeferred(a == b, (int input) => GetNumber())
    .ElseIf(() => a == 1, (int input) => GetAnotherNumber(input))
    .ElseIf(() => IsNumber("1"), (int input) => GetAnotherNumber(input))
    .Else((int input) => GetAnotherNumber(input))
    .Execute(input: 5)
    .Result;
```
