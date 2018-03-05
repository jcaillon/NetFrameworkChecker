# NetFrameworkChecker

## About this project

This program reads the version of .net framework installed on your computer and compares it to a required version.

If you don't have the required version, the program displays 2 versions of the requied .net installer (one offline and one online).

You also can click on the install button which will download the online installer and start it. 

This program required at least .net 2.0 to run; but betting that your end user has 2.0 installed is a pretty safe bet.

## Start / options

`NetFrameworkChecker.exe "required_version" "software_name" [-ShowOnlyIfNotInstalled]`

- required_version : the .net version actually required
- software_name : name of the software that needs .net, to inform the user why he has to install .net framework
- [-ShowOnlyIfNotInstalled] : optional, to specify that the program must not be shown if the required version is already installed (silent checking)

Example :

`NetFrameworkChecker.exe "4.6.2" "3P" -ShowOnlyIfNotInstalled`

## Technical references 

The list of download links for the different .version is taken from there : 

https://docs.microsoft.com/en-us/dotnet/framework/deployment/deployment-guide-for-developers

You can find a description of the language history there :

https://github.com/dotnet/csharplang/blob/master/Language-Version-History.md
https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-version-history 

Relation between .net framework version and C# version : 

https://stackoverflow.com/questions/247621/what-are-the-correct-version-numbers-for-c

* __C# 1.0__ released with .NET 1.0 and VS2002 (January 2002)
* __C# 1.2__ (bizarrely enough); released with .NET 1.1 and VS2003 (April 2003). First version to call Dispose on IEnumerators which implemented IDisposable. A few other small features.
* __C# 2.0__ released with .NET 2.0 and VS2005 (November 2005). Major new features: generics, anonymous methods, nullable types, iterator blocks
* __C# 3.0__ released with .NET 3.5 and VS2008 (November 2007). Major new features: lambda expressions, extension methods, expression trees, anonymous types, implicit typing (var), query expressions
* __C# 4.0__ released with .NET 4 and VS2010 (April 2010). Major new features: late binding (dynamic), delegate and interface generic variance, more COM support, named arguments, tuple data type and optional parameters
* __C# 5.0__ released with .NET 4.5 and VS2012 (August 2012). Major features: async programming, caller info attributes. Breaking change: loop variable closure.
* __C# 6.0__ released with .NET 4.6 and VS2015 (July 2015). Implemented by Roslyn. Features: initializers for automatically implemented properties, using directives to import static members, exception filters, element initializers, await in catch and finally, extension Add methods in collection initializers.
* __C# 7.0__ released with .NET 4.7 and VS2017 (March 2017) Major new features: tuples, ref locals and ref return, pattern matching (including pattern-based switch statements), inline out parameter declarations, local functions, binary literals, digit separators, and arbitrary async returns.
* __C# 7.1__ released with VS2017 v15.3 (August 2017) Minor new features: async main, tuple member name inference, default expression, pattern matching with generics.
* __C# 7.2__ released with VS2017 v15.5 (November 2017) Minor new features: private protected access modifier, Span<T>, aka interior pointer, aka stackonly struct, everything else.
