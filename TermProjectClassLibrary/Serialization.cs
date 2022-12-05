using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using TermProjectLibrary;

namespace TermProjectClassLibrary
{
    public class Serialization
    {
        public static string Serialize(UserAccount user)
        {
            return JsonConvert.SerializeObject(user);
        }

        public static UserAccount Deserialize(string jsonString)
        {
            UserAccount user = new UserAccount();
            user = JsonConvert.DeserializeObject<UserAccount>(jsonString);
            return user;
        }
    }
}
