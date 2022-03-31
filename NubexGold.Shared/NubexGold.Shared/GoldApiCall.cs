using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NubexGold.Shared
{
    public class GoldApiCall
    {
        public string UrlHeader = "x-access-token";
        public DateTime CurrentDate = DateTime.Now.AddDays(-1);
        public string ApiGoldKey { get; set; } = "goldapi-otq18l1eftjky-io";
        public string SilverApiUrl = "https://www.goldapi.io/api/XAG/MYR/";
        public string GoldApiUrl = "https://www.goldapi.io/api/XAU/MYR/20220330";

        public CurrentGold Price { get; set; }

        private async void GetPrice()
        {
            var result = new CurrentGold();

            using (var gold = new HttpClient())
            {
                gold.BaseAddress = new Uri(GoldApiUrl);
                gold.DefaultRequestHeaders.Accept.Clear();
                gold.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                gold.DefaultRequestHeaders.Add("x-auth-token", ApiGoldKey);
                //gold.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(ApiGoldKey);


            }

            //cts = new CancellationTokenSource(TimeSpan.FromSeconds(2));

            /////api/v1/face/getInformation
            ////var ends = new CancellationTokenSource(TimeSpan.FromMilliseconds(10));
            //Message = null;
            //var url = new Uri("http://" + AddEditDeviceModel.device_ip + "/" + DevicesEndpoints.getInformation());
            //try
            //{

            //    using (var client = new HttpClient())
            //    {

            //        //var result = await client.GetAsync(url);
            //        //client.Timeout = TimeSpan.FromSeconds(3);
            //        try
            //        {
            //            var result = await client.GetAsync(url, cts.Token);
            //            if (cts.IsCancellationRequested)
            //            {
            //                return;
            //            }
            //            //#################################################
            //            //if (client.Timeout == TimeSpan.FromSeconds(3))
            //            //{
            //            //    client.Dispose();
            //            //}
            //            //client.Timeout = TimeSpan.FromSeconds(3);
            //            //client.Timeout = TimeSpan.Zero;

            //            //#################################################
            //            if (!result.IsSuccessStatusCode)
            //            {
            //                APIStatus = "Wrong IP";
            //                return;

            //            }
            //            else
            //            {
            //                var responseString = await result.Content.ReadAsStringAsync();

            //                getDeviceInfo = JsonSerializer.Deserialize<GetDeviceInfo>(responseString);
            //                AddEditDeviceModel.device_name = getDeviceInfo.data.DeviceName;
            //                AddEditDeviceModel.serial_number = getDeviceInfo.data.DeviceSNumber;
            //                AddEditDeviceModel.model = getDeviceInfo.data.DeviceModel;
            //                AddEditDeviceModel.manufacturer = getDeviceInfo.data.ManufacturerName;
            //                AddEditDeviceModel.device_ip = getDeviceInfo.data.DeviceAddress;
            //                AddEditDeviceModel.model = getDeviceInfo.data.DeviceModel ?? AddEditDeviceModel.model;
            //                APIStatus = "API Success";

            //            }

            //        }
            //        catch (Exception e)
            //        {
            //            APIStatus = "API getDeviceInformation x Berjaya";
            //        }
            //        finally
            //        {
            //            cts.Dispose();
            //        }

            //    }
            //}
            //catch (Exception)
            //{
            //    APIStatus = "API GetInformation x Berjaya";
            //    //addeditModal
            //    NavigationManager.NavigateTo("/addeditModal");
            //}
        }
    }
}
