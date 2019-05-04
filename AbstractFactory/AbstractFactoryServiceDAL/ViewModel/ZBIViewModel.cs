using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace AbstractFactoryServiceDAL.ViewModel
{
    [DataContract]
    public class ZBIViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string ZBIName { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public List<ZBIMaterialViewModel> ZBIMaterials { get; set; }
    }
}
