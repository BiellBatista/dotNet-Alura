﻿using System.Runtime.Serialization;

namespace _06_04_XX_CasaDoCodigo.Models
{
    [DataContract]
    public abstract class BaseModel
    {
        [DataMember]
        public int Id { get; set; }
    }
}
