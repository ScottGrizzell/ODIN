using Shared;

namespace Server.Interfaces
{
    public interface IDoc400Service
    {
        public  Task<List<CaseDto>> GetCaseByOffenderId(int offenderId);
    }
}
