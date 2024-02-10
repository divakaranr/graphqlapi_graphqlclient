using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class User
    {
        public string id;
        public string name;
        public static string GetUserByIdResponse(string id, string name)
        {
            return $@"{{
            ""data"": {{
                ""user"": {{
                    ""id"": ""{id}"",
                    ""name"": ""{name}""
                }}
            }}
        }}";
        }
    }


}
