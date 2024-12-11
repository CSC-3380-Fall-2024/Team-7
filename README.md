# Team-7 (Hotel Operations and Efficiency System)
Team Members:
-  Cleveland, Project Manager 👔
-  Maureen, Communications Lead 🗣️🔊
-  Jp, Git Master 🗃️
-  Eby, Design Lead 👩🏻‍🎨
-  Ronald, Quality Assurance Tester 🕵🏽

## Purpose
- Our project's focus is to create a hotel management system that is efficent for both employees of the hotel and their customers as well as centralizes everything so people won't have to use multiple apps/platforms to get what they need done

## Installation Instructions
- Make sure you have the latest **.NET 8.0 SDK** installed on your machine. The directions are [here](https://learn.microsoft.com/en-us/dotnet/core/install/windows#net-installer) and the installation packages for Windows, Mac, and Linux are [here](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- **For developers only**: This is the link to make a new project into an [Ant Design Blazor Web App](https://antblazor.com/en-US/docs/getting-started)
- Installing the Bootstrap

### To add Blazor Bootstrap into the project
In your bash do
```
dotnet add package Microsoft.AspNetCore.Components.Web --version 8.0.4
```
then 
```
dotnet add package Blazor.Bootstrap --version 3.1.1
```

### If the references are not already added->

#### Add CSS References
After the `<base href="/" />` tag in the head section of the `Components/App.razor` file.

```html
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous">
<link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css" rel="stylesheet" />
<link href="_content/Blazor.Bootstrap/blazor.bootstrap.css" rel="stylesheet" />
```

#### Add script references
Insert the following references into the body section of the Components/App.razor file, immediately after the _framework/blazor.web.js reference:
```html
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/4.0.1/chart.umd.js" integrity="sha512-gQhCDsnnnUfaRzD8k1L5llCCV6O9HN09zClIzzeJ8OJ9MpGmIlCxm+pdCkqTwqJ4JcjbojFr79rl2F1mzcoLMQ==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/chartjs-plugin-datalabels/2.2.0/chartjs-plugin-datalabels.min.js" integrity="sha512-JPcRR8yFa8mmCsfrw4TNte1ZvF1e3+1SdGMslZvmrzDYxS69J7J49vkFL8u6u8PlPJK+H3voElBtUCzaXj+6ig==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
<script src="https://cdn.jsdelivr.net/npm/sortablejs@latest/Sortable.min.js"></script>
<script src="_content/Blazor.Bootstrap/blazor.bootstrap.js"></script>
```
#### Register services
Add Blazor Bootstrap service in the Program.cs right after var builder = WebApplication.CreateBuilder(args);

```html
builder.Services.AddBlazorBootstrap();
```
Add register tag helpers in Components/_Imports.razor
```html
@using BlazorBootstrap;
```

Remove default references

Delete the wwwroot/css/bootstrap folder.
Remove the following line from Components/App.razor file:
```html
<link rel="stylesheet" href="bootstrap/bootstrap.min.css" />
```

After do this in your bash 
```
dotnet restore
```
then 
```
dotnet build
```


Then after go into a file called program.cs and hit play(if you have vscode) if you do not have vscode
download vscode here
https://code.visualstudio.com/

### How to Run
Put both API keys that JP sent you in the same directory/folder as the Team-7 folder. That means that if you're in the HMS directory, the API keys should be two directories above that. It will be in whatever directory you're in when you run `cd ../..` from the HMS directory.

In your terminal, you must be in the HMS directory to run the project. You can either run the `dotnet watch` or `dotnet run` commands from the HMS directory and the web page will load.

Make sure to look at all of our pages. Some are in the Nav Bar at the top. Some are in the footer. Some are only accessible to employees (so make sure to make an employee account and log into it). Some are only accessible to users. Some are only accessible through buttons that you get to by going through other pages. We know you'll be thorough but we wanted to make you aware of all of our work :).

If you would like to add an account as an employee, your interview process was a sucess and you were given employee id #3, so when you make an account as an employee, you can use that as your employee Id =).
