using System;

namespace HttpServersStorage
{
    public class ServerDiagnostic
    {
        public ServerDiagnostic() { }

        public async Task<DiagnoseResult> Diagnose(string httpURL)
        {
            DateTime startDateTime = DateTime.Now;

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(httpURL);
            DiagnoseResult diagnoseResult = new DiagnoseResult(
                Convert.ToInt32(response.StatusCode), (DateTime.Now - startDateTime).TotalMicroseconds);
            return diagnoseResult;

            /*HttpResponseCode 
            HttpResponseLatency */
        }
    }
}