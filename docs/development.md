# Developing on the ReoAko Umbraco plugin

The project `BornDigital.ReoAko.Umbraco` is implemented as a Razor Class Library and compiles to a NuGet package.

The frontend assets are compiled with `webpack`, the minified assets are copied into the Visual Studio solution.  
See `webpack.config.js` for input and output files.

## Work on the frontend assets:

- Run `npm i` to install the npm packages
- Make your code changes
- Run `npm run build` to compile the input files with webpack, which will copy the minified files into the Razor Class Library

## Work on the .NET solution

To test changes, you can add the projects to an Umbraco solution.

## NuGet

The two projects in the solution compile to NuGet packages.

The NuGet packages are currently upladed manually to nuget.org. We should set up a pipeline to automate this.
