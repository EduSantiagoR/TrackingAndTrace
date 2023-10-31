using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Repartidor" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Repartidor.svc or Repartidor.svc.cs at the Solution Explorer and start debugging.
    public class Repartidor : IRepartidor
    {
        public List<object> GetAll()
        {
            Result results = new Result();
            results.Results = BL.Repartidor.GetAll();
            return results.Results;
        }
        public ML.Repartidor GetById(int idRepartidor)
        {
            ML.Repartidor repartidor = BL.Repartidor.GetById(idRepartidor);
            return repartidor;
        }
        public bool Add(ML.Repartidor repartidor)
        {
            bool coorect = BL.Repartidor.Add(repartidor);
            return coorect;
        }
        public bool Update(ML.Repartidor repartidor)
        {
            bool correct = BL.Repartidor.Update(repartidor);
            return correct;
        }
        public bool Delete(int idRepartidor)
        {
            bool correct = BL.Repartidor.Delete(idRepartidor);
            return correct;
        }
    }
    [DataContract]
    public class Result
    {
        [DataMember]
        public List<object> Results { get; set; }
    }
}
