using Cats.API.Services.Model;
using Cats.API.ViewModels.Response;
using Cats.Controllers;
using CsvHelper;
using CsvHelper.Configuration;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Cats.Services
{
    /// <summary>
    /// Cat service implementation to interact with Cats entities
    /// </summary>
    public class CatService : ICatService
    {
        private readonly ILogger<CatController> _logger;
        private readonly IConfiguration _configuration;

        public CatService(ILogger<CatController> logger,  IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        /// <summary>
        /// Create Csv shows the full name for each user and the total number of upvotes(across all facts) for each user.
        /// </summary>
        /// <returns>success or failure</returns>
        public async Task<bool> CreateCsv()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_configuration["Env:DataUrl"]);

                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // List data response.
                var url = client.BaseAddress + "fake";
                HttpResponseMessage response = client.GetAsync(url).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body.
                    var result = await response.Content.ReadAsStringAsync();
                    var facts = JsonSerializer.Deserialize<IList<GetFactsResponseItem>>(result);
                    if (facts != null)
                    {
                        var summary = GetSummaryItems(facts);
                        CreateFile(summary);
                    }
                    client.Dispose();
                    return true;
                }
                else
                {
                    _logger.LogInformation("Status Code:" + response.StatusCode + ", " + "Reason:" + response.ReasonPhrase);
                    client.Dispose();
                    return false;
                }
            }
            catch (Exception ex) {
                _logger.LogCritical(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Create Csv file according to the input Summary Items
        /// </summary>
        /// <param name="summaryItems">summary Items</param>
        /// <exception cref="Exception">exception on failure</exception>
        private void CreateFile(IList<SummaryItem> summaryItems)
        {
            var csvConfig = new CsvConfiguration()
            {
                HasHeaderRecord = true,
                Comment = '#',
                AllowComments = true,
                Delimiter = ",",
            };
            var file = _configuration["Env:CsvFile"];
            FileInfo fi = new FileInfo(file);
            if (fi.Directory == null)
            {
                throw new Exception("Csv Directory is not valid");
            }
            if (fi.Directory != null && !fi.Directory.Exists)
            {
                Directory.CreateDirectory(fi.DirectoryName);
            }

            using var writer = new StreamWriter(file);
            using (var csvWriter = new CsvWriter(writer, csvConfig))
            {
                csvWriter.WriteField("user");
                csvWriter.WriteField("totalVotes");
                csvWriter.NextRecord();
                foreach (var summaryItem in summaryItems)
                {
                    csvWriter.WriteField(summaryItem.First + " " + summaryItem.Last);
                    csvWriter.WriteField(summaryItem.UpVotes);
                    csvWriter.NextRecord();
                }
                writer.Flush();
            }
        }

        /// <summary>
        /// Get Summary Items for Cats
        /// </summary>
        /// <param name="facts">facts</param>
        /// <returns>a list of Summary Items</returns>
        private IList<SummaryItem> GetSummaryItems(IList<GetFactsResponseItem> facts)
        {
            var userIds = facts.Select(x => x.User.Id).Distinct().ToList();
            IList<SummaryItem> summaryItems = new List<SummaryItem>();
            foreach (var userId in userIds)
            {
                var summaryItem = new SummaryItem();
                summaryItem.Id = userId;
                var matchingItems = facts.Where(x=>x.User.Id == userId).ToList();
                if (matchingItems != null && matchingItems.Count > 0)
                {
                    var total = 0;
                    foreach (var matchingItem in matchingItems)
                    {
                        total += matchingItem.UpVotes;
                    }
                    summaryItem.UpVotes = total;
                    summaryItem.First = matchingItems[0].User.Name.First;
                    summaryItem.Last = matchingItems[0].User.Name.Last;
                    summaryItems.Add(summaryItem);
                }
            }
            summaryItems = summaryItems
                .OrderByDescending(x => x.UpVotes)
                .ThenBy(x => x.First)
                .ThenBy(x => x.Last)
                .ToList();
            return summaryItems;
        }
    }
}
