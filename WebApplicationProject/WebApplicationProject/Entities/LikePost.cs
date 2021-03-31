using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationProject.Entities
{
    [DataContract]
    public class LikePost
    {
        [DataMember]
        public int LikeCount { get; set; }
    }
}
