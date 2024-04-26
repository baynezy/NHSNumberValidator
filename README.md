# NHS Number Validator

This project is a .Net library to validate the format of NHS numbers.


| Branch    | Status                                                                                                                                                                                                        |
|-----------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| `master`  | [![master](https://github.com/baynezy/NHSNumberValidator/actions/workflows/branch-master.yml/badge.svg?branch=master)](https://github.com/baynezy/NHSNumberValidator/actions/workflows/branch-master.yml)     |
| `develop` | [![develop](https://github.com/baynezy/NHSNumberValidator/actions/workflows/branch-develop.yml/badge.svg?branch=develop)](https://github.com/baynezy/NHSNumberValidator/actions/workflows/branch-develop.yml) |

## Installation

The library is available on NuGet:

[![NuGet version](https://badge.fury.io/nu/NHSNumberValidator.svg)](http://badge.fury.io/nu/NHSNumberValidator)

```powershell
dotnet add package NHSNumberValidator
```

## Usage

```csharp
var isValid = Validator.Validate("1234567890");
```