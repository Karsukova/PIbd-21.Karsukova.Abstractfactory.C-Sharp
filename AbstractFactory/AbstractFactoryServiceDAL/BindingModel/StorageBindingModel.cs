using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace AbstractFactoryServiceDAL.BindingModel
{
    [DataContract]
    public class StorageBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string StorageName { get; set; }
    }
}
