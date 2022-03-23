# Rhetos.LanguageServicesCompatibility

Rhetos.LanguageServicesCompatibility is a DSL package (a plugin module) for [Rhetos development platform](https://github.com/Rhetos/Rhetos).

It provides support for Rhetos DSL IntelliSense in Visual Studio ([Rhetos Language Services](https://github.com/Rhetos/LanguageServices))
for older applications with Rhetos v4.

Rhetos v5 apps, and newer, support Rhetos Language Services by default; they do not need this plugin.

Contents:

1. [Installation and configuration](#installation-and-configuration)
2. [Usage](#usage)
3. [How to contribute](#how-to-contribute)
   1. [Building and testing the source code](#building-and-testing-the-source-code)

See [rhetos.org](http://www.rhetos.org/) for more information on Rhetos.

## Installation and configuration

Install this package to a Rhetos v4 application
by adding 'Rhetos.LanguageServicesCompatibility' NuGet package,
available at the [NuGet.org](https://www.nuget.org/) on-line gallery.

## Usage

Rhetos.LanguageServicesCompatibility will automatically create DSL syntax files required for Rhetos DSL IntelliSense.
It generates files in `obj\Rhetos` folder: `DslSyntax.json` and `DslDocumentation.json`.

## How to contribute

Contributions are very welcome. The easiest way is to fork this repo, and then
make a pull request from your fork. The first time you make a pull request, you
may be asked to sign a Contributor Agreement.
For more info see [How to Contribute](https://github.com/Rhetos/Rhetos/wiki/How-to-Contribute) on Rhetos wiki.

### Building and testing the source code

* Note: This package is already available at the [NuGet.org](https://www.nuget.org/) online gallery.
  You don't need to build it from source in order to use it in your application.
* To build the package from source, run `Clean.bat`, `Build.bat` and `Test.bat`.
* For the test script to work, you need to create an empty database and
  a settings file `test\TestApp\ConnectionStrings.config` (copy from Template.ConnectionStrings.config)
  with the database connection string.
* The build output is a NuGet package in the "Install" subfolder.
