using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DataAcces.Models
{
    /// <summary>
    /// Base class for models to store in repo
    /// </summary>
    [DataContract]
    public abstract class BaseModel
    {
        [DataMember]
        public long ID { get; set; }
    }
}
