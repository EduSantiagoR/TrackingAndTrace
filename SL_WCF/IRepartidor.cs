using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRepartidor" in both code and config file together.
    [ServiceContract]
    public interface IRepartidor
    {
        [OperationContract]
        [ServiceKnownType(typeof(ML.Repartidor))]
        List<object> GetAll();
        [OperationContract]
        [ServiceKnownType(typeof(ML.Repartidor))]
        ML.Repartidor GetById(int idRepartidor);
        [OperationContract]
        bool Add(ML.Repartidor repartidor);
        [OperationContract]
        bool Update(ML.Repartidor repartidor);
        [OperationContract]
        bool Delete(int idRepartidor);
    }
}
