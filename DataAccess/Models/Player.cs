using DataAcces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    /// <summary>
    /// Player that is stored in PlayersRepo
    /// </summary>
    [DataContract]
    public class Player : BaseModel,IPlayer
    {
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public int Score { get; set; }
        [DataMember]
        public int Level { get; set; }
        [DataMember]
        public int Wins { get; set; }
        [DataMember]
        public int Loses { get; set; }
    }
}
