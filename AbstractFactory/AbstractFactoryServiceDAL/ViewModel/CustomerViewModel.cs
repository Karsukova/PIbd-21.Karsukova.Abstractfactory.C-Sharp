using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace AbstractFactoryServiceDAL.ViewModel
{
    [DataContract]
    public class CustomerViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string CustomerFIO { get; set; }
    }
}
