using System.ServiceModel;

namespace ConverterWcfServiceLibrary
{
    [ServiceContract]
    public interface IConverterService
    {
        [OperationContract]
        string GetData(string currencyAmount);
    }
}
