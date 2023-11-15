using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace GoogleCalendar.API.Helper
{

    public class GoogleCalendarHelper
    {
        protected GoogleCalendarHelper()
        {

        }
        public static async Task<Event> CreateGoogleCalendar(Models.GoogleCalendar request)
        {
            string[] Scopes = { "https://www.googleapis.com/auth/calendar" };
            string ApplicationName = "CalenderApiBySamoul";
            UserCredential credential;
            using (var stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "CalenderTokenFile", "CalendarToken.json"), FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }
            // define services
            var services = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
            // define request
            Event eventCalendar = new()
            {
                 
                Summary = request.Summary,
                Location = request.Location,
                Start = new EventDateTime
                {
                   
                    DateTimeDateTimeOffset = request.Start,
                    TimeZone = "Africa/Cairo"
                },
                End = new EventDateTime
                {
                
                   DateTimeDateTimeOffset = request.End,
                    TimeZone = "Africa/Cairo"
                },
                Description = request.Description
            };
            var eventRequest = services.Events.Insert(eventCalendar, "primary");
            var requestCreate = await eventRequest.ExecuteAsync();
            return requestCreate;
        }
    }
}
