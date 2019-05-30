using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEKRA.VULNERABILIDADE.DOMAIN.ENTIITES.BaseEntityMongo
{
    public class BaseEntityMongo
    {
        private DateTime timeNow = DateTime.Now;

        [BsonRepresentation(BsonType.ObjectId)]
        public int ID { get; set; }
        public DateTime DataCriacao  {
            get { return timeNow; }
            set { timeNow = value; }
        }
        public DateTime DataAtualizacao  {
            get { return timeNow; }
            set { timeNow = value; }
        }
    }
}
