# NHS Number Validator

This project is a .Net library to validate the format of NHS numbers.

[![Build Status](https://github.com/baynezy/NHSNumberValidator/workflows/Test%20and%20Deploy%20Library/badge.svg)](https://github.com/baynezy/NHSNumberValidator/actions?query=workflow%3ATest%20and%20Deploy%20Library)

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