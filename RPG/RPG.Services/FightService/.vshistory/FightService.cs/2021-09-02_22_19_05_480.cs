using RPG.Data.Context;

namespace RPG.Services.FightService
{
    public class FightService : IFightService
    {
        private readonly DataContext _dataContext;

        public FightService(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

    }
}
