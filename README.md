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
	- Div(int a, int b): double

1. Set the WebService as start page

## Calculator Client

1. Create a new Solution: `ASP.NET Core Web App (MVC)`

1. Add Connected Services

1. Add Microsoft WCF Web Service Reference Provider

1. As End-Point add `http://localhost:51902/CalculatorService.asmx`

1. In Client Option set: Generate Synchronous Operations

1. Create an Model:
```
namespace CalculatorClient.Models
{
    public class CalculatorFields
    {
        public int Avalue { get; set; }
        public int Bvalue { get; set; }
        public double Result { get; set; }
    }
}
```

1. Add the Model and Form to the View index.cshtml:
```
@model CalculatorClient.Models.CalculatorFields
@{
    ViewData["Title"] = "Calculator";
}

<div class="text-center">
    <h1 class="display-4">Calculator</h1>
    @using (Html.BeginForm("Index", "Home", FormMethod.Post))
    {
        <table cellpadding="0" cellspacing="0">
            <tr>
                <th colspan="2" align="center">Person Details</th>
            </tr>
            <tr>
                <td>Value A:  </td>
                <td>
                    @Html.TextBoxFor(m => m.Avalue)
                </td>
            </tr>
            <tr>
                <td>Value B:  </td>
                <td>
                    @Html.TextBoxFor(m => m.Bvalue)
                </td>
            </tr>
            <tr>
                <td>Result:  </td>
                <td>
                    @Html.DisplayFor(m => m.Result)
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <input type="submit" name="submitButton" value="Add" />
                    <input type="submit" name="submitButton" value="Subtract" />
                    <input type="submit" name="submitButton" value="Multiply" />
                    <input type="submit" name="submitButton" value="Divide" />
                </td>
            </tr>
        </table>
    }
</div>
```

1. Add the Post Method to the Controller HomeController.cs:
```
[HttpPost]
public ActionResult Index(CalculatorFields fields, string submitButton)
{
    switch (submitButton)
    {
        case "Add":
            fields.Result = client.Add(fields.Avalue, fields.Bvalue);
            break;
        case "Subtract":
            fields.Result = client.Sub(fields.Avalue, fields.Bvalue);
            break;
        case "Multiply":
            fields.Result = client.Mul(fields.Avalue, fields.Bvalue);
            break;
        case "Divide":
            fields.Result = client.Div(fields.Avalue, fields.Bvalue);
            break;
        default:
            fields = new CalculatorFields() { Avalue = 0, Bvalue = 0, Result = 0 };
            break;
    }
            
    return View(fields);
}
```