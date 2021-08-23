namespace Share.Models.Common
{
    /// <summary>
    /// 本地用户信息
    /// </summary>
    public class LocalUserInfo
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public string Role { get; set; }
        public Guid Id { get; set; }
        public LocalUserInfo(Guid id, string username, string email, string role = null, string avatar = null)
        {
            Id = id;
            Username = username;
            Email = email;
            Avatar = avatar;
            Role = role;
        }
    }
}
