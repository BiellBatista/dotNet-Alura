﻿using System.Runtime.Serialization;

namespace _04_02_XX_CasaDoCodigo.Models
{
    [DataContract]
    public abstract class BaseModel
    {
        [DataMember]
        public int Id { get; protected set; }
    }
}
