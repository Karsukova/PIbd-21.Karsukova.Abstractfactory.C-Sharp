using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbstractFactoryModel
{
    /// <summary>
    /// Сколько материала требуется для изготовления ЖБИ 
    /// </summary>
    public class ZBIMaterial
    {
        public int Id { get; set; }
        public int ZBIId { get; set; }
        public string MaterialName { get; set; }
        public int MaterialId { get; set; }
        public int Count { get; set; }
        public virtual Material Material { get; set; }
        public virtual ZBI ZBI { get; set; }
    }
}
