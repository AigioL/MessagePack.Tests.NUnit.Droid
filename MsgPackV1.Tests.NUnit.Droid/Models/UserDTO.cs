using System;
using MPKey = MessagePack.KeyAttribute;
using MPObject = MessagePack.MessagePackObjectAttribute;

namespace Models
{
    [MPObject]
    public class UserDTO
    {
        [MPKey(0)]
        public long Id { get; set; }

        [MPKey(1)]
        public Guid Id2 { get; set; }

        [MPKey(2)]
        public string NickName { get; set; }

        [MPKey(3)]
        public Gender Gender { get; set; }

        [MPKey(4)]
        public string Avatar { get; set; }

        [MPKey(5)]
        public string Signature { get; set; }

        [MPKey(6)]
        public DateTime? BirthDate { get; set; }

        [MPKey(7)]
        public string Other { get; set; }
    }

    public enum Gender : byte
    {
        Unknown = 0,
        Male = 1,
        Female = 2,
    }
}