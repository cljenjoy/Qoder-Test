public class Qoder
{
    public string Name { get; set; } = string.Empty;

    public Qoder(string name)
    {
        Name = name;

        string account = getUserAccount();
    }

    private string getUserAccount()
    {
        // TODO: 实现获取用户账户的逻辑
        return string.Empty;
    }
}
