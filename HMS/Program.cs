using HMS.Components;
using System;

string credentialPath = "";

/*
 * Check to see which platform a developer or user is on
 */

if(OperatingSystem.IsLinux() == true || OperatingSystem.IsMacOS() == true) {
   credentialPath = @"../../hotelmanagementsystem-3f342-firebase-adminsdk-njalz-ea30d4f99f.json"; 
} else if(OperatingSystem.IsWindows() == true) {
   credentialPath = @"..\..\hotelmanagementsystem-3f342-firebase-adminsdk-njalz-ea30d4f99f.json"; 
}
 

Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credentialPath);
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

