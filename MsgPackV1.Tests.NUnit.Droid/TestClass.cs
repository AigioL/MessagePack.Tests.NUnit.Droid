using MessagePack;
using Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tests.NUnit.Droid
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestMethod()
        {
            var version = typeof(MessagePackSerializer).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
            TestContext.WriteLine($"MsgPack: {version}");
            var user = new UserDTO
            {
                Id = 2020,
                Id2 = Guid.NewGuid(),
                Gender = Gender.Male,
                Avatar = "🥼🥽😀🥰",
                NickName = "にほんごにほんごにほんごにほんごにほんご",
                BirthDate = DateTime.Today,
                Other = "한국어한국어한국어한국어한국어",
                Signature = "一二三四五六七八九十一二三四五",
            };
            object content = user;
            var user2 = MessagePackSerializer.Deserialize<UserDTO>(MessagePackSerializer.Serialize(content));
            CheckEquals(user, user2);
            TestContext.WriteLine("Complete.");

            // 1.8.80+c7a4f10920 success.
            // 2.0.335+1efbae4115 fail.
        }

        bool Equals(DateTime? left, DateTime? right)
        {
            if (left.HasValue)
            {
                if (right.HasValue)
                {
                    var r = new DateTimeOffset(right.Value);
                    var l = new DateTimeOffset(left.Value);
                    return r == l;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return Equals(right, left);
            }
        }

        void CheckEquals(UserDTO left, UserDTO right)
        {
            Assert.IsTrue(left.Id == right.Id, "Id");
            Assert.IsTrue(left.Id2 == right.Id2, "Id2");
            Assert.IsTrue(left.Gender == right.Gender, "Gender");
            Assert.IsTrue(left.Avatar == right.Avatar, "Avatar");
            Assert.IsTrue(left.NickName == right.NickName, "NickName");
            Assert.IsTrue(left.Signature == right.Signature, "Signature");
            Assert.IsTrue(Equals(left.BirthDate, right.BirthDate), "BirthDate");
        }
    }
}
