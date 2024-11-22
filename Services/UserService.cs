using Microsoft.Extensions.Options;
using NumberCheck.Interfaces;

namespace NumberCheck.Services;

public class UserService : IUserService
{
    private readonly IOptions<ApplicationRandomNumber> _options;
    public UserService(IOptions<ApplicationRandomNumber> options)
    {
        _options = options;
    }
    private Dictionary<string, int> Users { get; set; } = new Dictionary<string, int>();
    public bool SaveUserName(string userName)
    {
        if (Users.TryAdd(userName, 0))
        {
            return true;
        }

        return false;
    }

    public bool IsUser(string userName)
    {
        return Users.ContainsKey(userName);
    }

    public int? WhichAttemptOnUser(string userName)
    {
        if (Users.TryGetValue(userName, out int usersAttempted))
            return usersAttempted;

        return null;
    }

    public bool IsSaveUserAttempt(string userName)
    {
        Users[userName] += 1;
        return true;
    }

    public bool IsUserCanCheckNumber(string userName)
    {
        if (Users.TryGetValue(userName, out int usersAttempted))
        {
            return usersAttempted < _options.Value.AttemptedNumber;
        }

        return false;
    }
}