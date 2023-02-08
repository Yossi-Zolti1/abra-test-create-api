using Abra_test.Domain;

namespace Abra_test.Services.ApiRandomUserService
{
    public interface IUsersService
    {
        Task<UserGenResponse.Result> GetUsersData(string gender);
        Task<List<string>> GetListOfMails();
        Task<string[]> GetMostPupalarCountry();
        Task<string> GetTheOldestUser();
    }
}
