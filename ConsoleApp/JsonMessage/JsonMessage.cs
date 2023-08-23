using Newtonsoft.Json;

namespace ConsoleApp.JsonMessage
{
    public class JsonMessage
    {
        public string GetJsonDeserializedString(string str)
        {
            str = "abcd {'message' : \"xyz {'message':'def'}\"}";
            string result = string.Empty;

            while (str != string.Empty)
            {
                var idx = str.IndexOf("{");
                if (idx is not -1)
                {
                    var substr = str[..idx];
                    result += substr;
                    str = str[idx..];
                    str = (JsonConvert.DeserializeObject<MessageModel>(str)).Message; // Deserialze the message
                }
                else
                {
                    result += str;
                    str = string.Empty;
                }
            }

            return result;
        }
    }
}
