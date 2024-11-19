using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Services;
using System.IO;
using Google.Apis.Sheets.v4.Data;

public class GoogleSheetsService
{
    private readonly string[] s_scopes = { SheetsService.Scope.Spreadsheets };
    private readonly string s_applicationName = "HMS";
    private readonly string s_spreadsheetId = "1fzb746EikuIEnrHHV2Ek36RucMEhc847sh9TaZvtrYI";
    private SheetsService SS_sheetsService;

    public GoogleSheetsService(string credentialsFilePath, string spreadsheetId, string applicationName)
    {
       s_spreadsheetId = spreadsheetId;
       s_applicationName = applicationName;

        using var stream = new FileStream(credentialsFilePath, FileMode.Open, FileAccess.Read);
        var credential = GoogleCredential.FromStream(stream).CreateScoped(s_scopes);

        SS_sheetsService = new SheetsService(new BaseClientService.Initializer
        {
            HttpClientInitializer = credential,
            ApplicationName = s_applicationName
        });
    }

    public async Task AppendRowAsync(string sheetName, IList<object> rowData)
    {
        var range = $"{sheetName}!A:A";
        var valueRange = new ValueRange { Values = new List<IList<object>> { rowData } };

        var appendRequest = SS_sheetsService.Spreadsheets.Values.Append(valueRange, s_spreadsheetId, range);
        appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.RAW;

        await appendRequest.ExecuteAsync();
    }
}
