using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Numiteq.DataAccess.Initialization
{
    public abstract class BaseInitializationDataStorage
    {
        protected List<T> Parse<T>(byte[] data)
        {
            var json = Encoding.Default.GetString(data);
            var tokens = JArray.Parse(json);
            var objects = tokens.Select(ct => ct.ToObject<T>()).ToList();
            return objects;
        }
    }
}