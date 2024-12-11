using HMS.Components;
using System;

string credentialPath = "";
string s_sheetCredentialPath = "";

/*
 * Check to see which platform a developer or user is on
 */

if(OperatingSystem.IsLinux() == true || OperatingSystem.IsMacOS() == true) {
   credentialPath = @"../../hotelmanagementsystem-3f342-firebase-adminsdk-njalz-ea30d4f99f.json"; 
} else if(OperatingSystem.IsWindows() == true) {
   credentialPath = @"..\..\hotelmanagementsystem-3f342-firebase-adminsdk-njalz-ea30d4f99f.json"; 
}

if(OperatingSystem.IsLinux() == true || OperatingSystem.IsMacOS() == true) {
   s_sheetCredentialPath = @"../../hotelmanagementsystem-3f342-88be80a4364b.json"; 
} else if(OperatingSystem.IsWindows() == true) {
   s_sheetCredentialPath = @"..\..\hotelmanagementsystem-3f342-88be80a4364b.json"; 
}
 

Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credentialPath);
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddBlazorBootstrap();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<GoogleSheetsService>(sp =>
    new GoogleSheetsService(s_sheetCredentialPath,  "1fzb746EikuIEnrHHV2Ek36RucMEhc847sh9TaZvtrYI", "HMS"));


builder.Services.AddScoped<c_user>();
// Register BookingService
builder.Services.AddScoped<BookingService>();

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

