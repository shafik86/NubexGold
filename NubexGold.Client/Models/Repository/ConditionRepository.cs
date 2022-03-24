

using Microsoft.EntityFrameworkCore;

namespace NubexGold.Client.Models.Repository
{
    public class ConditionRepository : IConditionRepository
    {
        private readonly ApplicationDbContext appDbContext;

        public ConditionRepository(ApplicationDbContext applicationDbContext)
        {
            this.appDbContext = applicationDbContext;
        }
        public async Task<Condition> GetCondition(int conditionId)
        {
            return await appDbContext.Conditions.FirstOrDefaultAsync(e => e.ConditionId == conditionId);
        }

        public async Task<IEnumerable<Condition>> GetConditions()
        {
            return await appDbContext.Conditions.ToListAsync();
        }
    }
}
