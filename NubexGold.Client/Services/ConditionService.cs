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
            return await httpClient.GetFromJsonAsync<Condition>($"api/Condition/{Id}");
        }

        public async Task<IEnumerable<Condition>> GetConditions()
        {
            return await httpClient.GetFromJsonAsync<Condition[]>("api/Condition");
        }
    }
}
