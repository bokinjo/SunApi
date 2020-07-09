using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SunLibrary
{
    public class SunProcesor
    {
        public static async Task<SunModel> LoadSunInformation()
        {
            string datum = DateTime.Today.ToString();
            string url = "https://api.sunrise-sunset.org/json?lat=43.5116383&lng=16.4399659&date=" + datum;



            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    SunResaultModel result = await response.Content.ReadAsAsync<SunResaultModel>();

                    return result.Results;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }
    }
}
