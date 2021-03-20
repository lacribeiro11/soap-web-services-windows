# soap-web-services-windows

## Install missing packages 

1. Open NuGet Package Manager

1. Add these packages:
	- System.ServiceModel.Http
	- System.ServiceModel.Primitives

## Change to the properties

1. Open the project properties

1. In the Startup Project select `Multiple startup projects`

1. Set booth projects action to `Start`

## Calculator Server

1. Create a new Solution: `ASP.NET Web Application (.NET Framework)`

1. Add Web Service (ASMX)

1. Add the new `WebMethod` to the service:
	- Add(int a, int b): int
	- Sub(int a, int b): int
	- Mul(int a, int b): int
	- Div(int a, int b): int

1. Set the WebService as start page

## Calculator Client

1. Create a new Solution: `ASP.NET Core Web App (MVC)`