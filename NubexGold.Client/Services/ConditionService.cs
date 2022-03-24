namespace NubexGold.Client.Services
{
    public class ConditionService : IConditionService
    {
        private HttpClient httpClient;
        public ConditionService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<Condition> GetConditionById(int Id)
        {
            var result = await httpClient.GetFromJsonAsync<Condition>($"api/Condition/{Id}");
            return result;
        }

        public async Task<IEnumerable<Condition>> GetConditions()
        {
            var result = await httpClient.GetFromJsonAsync<Condition[]>("api/Condition");
            return result;
        }
    }
}
