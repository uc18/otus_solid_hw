namespace NumberCheck.Interfaces;

public interface IUserService
{
    bool SaveUserName(string userName);
    int? WhichAttemptOnUser(string userName);
    bool IsUser(string userName);
    bool IsSaveUserAttempt(string userName);
    bool IsUserCanCheckNumber(string userName);
}