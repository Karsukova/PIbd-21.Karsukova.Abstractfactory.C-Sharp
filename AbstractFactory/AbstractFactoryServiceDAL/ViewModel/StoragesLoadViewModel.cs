using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace AbstractFactoryServiceDAL.ViewModel
{
    [DataContract]
    public class StoragesLoadViewModel
    {
        [DataMember]
        public string StorageName { get; set; }
        [DataMember]
        public int TotalCount { get; set; }
        [DataMember]
        public IEnumerable<Tuple<string, int>> Materials { get; set; }
    }
}
