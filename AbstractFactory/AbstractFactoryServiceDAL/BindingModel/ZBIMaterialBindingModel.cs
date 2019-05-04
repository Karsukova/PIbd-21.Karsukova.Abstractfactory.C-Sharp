using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace AbstractFactoryServiceDAL.BindingModel
{
    [DataContract]
    public class ZBIMaterialBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ZBIId { get; set; }
        [DataMember]
        public int MaterialId { get; set; }
        [DataMember]
        public int Count { get; set; }
    }
}
