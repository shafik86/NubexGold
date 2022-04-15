using System.Xml.Serialization;

namespace NubexGold.Client.Services
{
    public class PriceService : IPriceService
    {
     
        public HttpClient httpClient { get; set; }

        public golds curPrice { get; set; }
        //public golds myPrice { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public PriceService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<golds> getAllPrice()
        {
            var url = new Uri("https://gold-feed.com/paid/d7d6s6d66k4j4658e6d6cds638940e/xmlgold_myr.php");
            //var url = new Uri("https://gold-feed.com/paid/d7d6s6d66k4j4658e6d6cds638940e/xmlgold_usd.php");
            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            using (HttpClient client = new HttpClient())
            {
                var result = await client.GetStringAsync(url, cts.Token);
                if (result != null)
                {
                   
                    var xmlserial = new XmlSerializer(typeof(golds));
                    using (var reader = new StringReader(result))
                    {
                        curPrice = (golds)xmlserial.Deserialize(reader);

                    }

                    //Console.WriteLine(result);
            
                }
            }
            return curPrice;
        }
    }
}
