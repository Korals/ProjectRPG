using System.Collections.Generic;
using ProjectK.Business.Characters;

namespace ProjectK.Business
{
    public class User
    {
        public int Id { get; private set; }
        public string UserName { get; private set; }
        public byte[] PasswordHash { get; private set; }
        public byte[] PasswordSalt { get; private set; }
        public ICollection<Character> Characters { get; private set; } = new HashSet<Character>();
    }
}