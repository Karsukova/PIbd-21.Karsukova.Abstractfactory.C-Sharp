using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace AbstractFactoryServiceDAL.BindingModel
{
    [DataContract]
    public class MaterialBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string MaterialName { get; set; }
    }
}
