using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;


namespace AbstractFactoryServiceDAL.ViewModel
{
    [DataContract]
    public class StorageViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string StorageName { get; set; }
        [DataMember]
        public List<StorageMaterialViewModel> StorageMaterials { get; set; }
    }
}
