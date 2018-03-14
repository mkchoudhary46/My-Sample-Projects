using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DriverjobsService
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            string baseUrl = "http://driverjobs.com.au/driverjobs_sandbox";
            client.BaseAddress = new Uri(baseUrl);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "UTF-8");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Language", "n-US,en;q=0.8");
            client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");

            const string serviceUrl = "/api/edit_job";
            var uri = new Uri(baseUrl + serviceUrl);

            var requestBody = GetRequestData();
            var content = JsonConvert.SerializeObject(requestBody);
            var response = client.PostAsync(uri.ToString(), new StringContent(content, Encoding.UTF8, "application/json"));
            var res = response.Result;
        }

        private static object GetRequestData()
        {
            var body = new
            {
                user_id = 6,
                job_title = "Test Accr",
                //job_description = "<img class='aligncenter' src='http://www.driverjobs.com.au/driverjobs_sandbox/wp-content/uploads/2016/10/1476943302.png' /><div class=\"videoembed\" id=\"FlashContent\" style=\"height: 310px; padding: 5px 0px; text-align: center; width: 400px; color: rgb(0, 0, 0); font-family: Helvetica, Arial, sans-serif; line-height: 18px; background-color: rgb(247, 247, 247);\"><iframe allowfullscreen=\"\" frameborder=\"0\" height=\"100%\" src=\"https://www.youtube.com/embed/7uvSeifPpMc?wmode=opaque\" title=\"VideoJobAd\" width=\"100%\"></iframe></div>",
                
                job_description = "<div class=\"videoembed\" id=\"FlashContent\" style=\"height: 310px; padding: 5px 0px; text-align: center; width: 400px; color: rgb(0, 0, 0); font-family: Helvetica, Arial, sans-serif; line-height: 18px; background-color: rgb(247, 247, 247);\"><iframe allowfullscreen=\"\" frameborder=\"0\" height=\"100%\" src=\"https://www.youtube.com/embed/7uvSeifPpMc?wmode=opaque\" title=\"VideoJobAd\" width=\"100%\"></iframe></div>",


                //job_description = "<div style=\"background:#000;\"><a href=\"#\" style=\"text-decoration: none;color: #e0e424;font-size: 3vw;text-align: center;background: #605d5f;padding: 20px 10px;display:block; border-radius: 3px; font-family: arial; border: 1px solid #ffffff;background: #33302b; background: -moz-linear-gradient(top, #33302b 0%, #595a5b 100%);background: -webkit-linear-gradient(top, #33302b 0%,#595a5b 100%); background: linear-gradient(to bottom, #33302b 0%,#595a5b 100%); filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#33302b', endColorstr='#595a5b',GradientType=0 );text-shadow: 1px 0px 1px\">WASTE DRIVERS NEEDED - RING 1800 want a job </a></div>",
                archive = "0",
                job_type = "permanent",
                SkillNamesWithMatch = string.Empty,
                SkillNamesWithoutMatch = string.Empty,
                SkillAliases = string.Empty,
                accreditation_name = string.Empty,
                jobapplication_email = string.Empty,
                company_name = string.Empty,
                company_website = string.Empty,
                company_tagline = string.Empty,
                position_filled = 0,
                job_video = string.Empty,
                job_expiry_date = string.Empty,
                job_image = "",
                logo_image = "",
                jr_geo_latitude = "",
                jr_geo_longitude = "",
                Location = string.Empty,
                postStatus="publish",
                jobType = "permanent",
                shortdescription = "",
                DaysFeatured =30,
                IsFeatured = true,
                ReferenceNumber = "",
                publishedDate = DateTime.Now.ToShortDateString(),
                job_id = 5112
            };
            return body;
        }
    }
}
