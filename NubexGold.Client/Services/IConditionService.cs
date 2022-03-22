

namespace NubexGold.Client.Services
{
    public interface IConditionService
    {
        Task<IEnumerable<Condition>> GetConditions();
        Task<Condition> GetConditionById(int Id);
        //Condition GetCondition(Condition condition);

    }
}
