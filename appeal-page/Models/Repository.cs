namespace appeal_page.Models
{
    public static class Repository
    {
        private static List<FormInfo> _users = new();

        public static List<FormInfo> Users {
            get{
                return _users;
            }
        }

        public static void CreateUser(FormInfo user)
        {
            user.Id = _users.Count()+1;
            _users.Add(user);
        }

        public static FormInfo? GetById(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }
    }
}