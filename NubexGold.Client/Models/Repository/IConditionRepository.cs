namespace NubexGold.Client.Models.Repository
{
    public interface IConditionRepository
    {
        Task<IEnumerable<Condition>> GetConditions();
        Task<Condition> GetCondition(int conditionId);
    }
}
