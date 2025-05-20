[![Build status](https://img.shields.io/appveyor/ci/alunacjones/lsl-executeif.svg)](https://ci.appveyor.com/project/alunacjones/lsl-executeif)
[![Coveralls branch](https://img.shields.io/coverallsCoverage/github/alunacjones/LSL.ExecuteIf)](https://coveralls.io/github/alunacjones/LSL.ExecuteIf)
[![NuGet](https://img.shields.io/nuget/v/LSL.ExecuteIf.svg)](https://www.nuget.org/packages/LSL.ExecuteIf/)

# LSL.ExecuteIf

A simple library to provide fluent conditional execution of a delegate
that gets given the target to do with as it pleases.

## Using a predicate

```csharp
var values = new List<int> { 1, 2 };
values.ExecuteIf(() => true, v => v.Add(3));

// values will now be { 1, 2, 3 }
```

## Using a condition

```csharp
var values = new List<int> { 1, 2 };
values.ExecuteIf(true, v => v.Add(3));

// values will now be { 1, 2, 3 }
```
