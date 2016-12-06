using ConsumeWebServiceRest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TesteurConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string login = "http://localhost:53494/ServiceRDM.svc/Login";
            WSR_Params wsr_params = new WSR_Params();
            wsr_params.Add("pseudo", "toto");
            Console.WriteLine(ExecuteAsync(login, wsr_params,TypeSerializer.Json).Result.Data);

            wsr_params = new WSR_Params();
            wsr_params.Add("pseudo", "titi");
            Console.WriteLine(ExecuteAsync(login, wsr_params, TypeSerializer.Json).Result.Data);

            wsr_params = new WSR_Params();
            wsr_params.Add("pseudo", "titi");
            Console.WriteLine(ExecuteAsync(login, wsr_params, TypeSerializer.Json).Result.Data);

            string getUsers = "http://localhost:53494/ServiceRDM.svc/GetPseudos";
            Console.WriteLine(ExecuteAsync(getUsers,wsr_params, TypeSerializer.Xml).Result);
            Console.Read();
        }

        public static async Task<WSR_Result> ExecuteAsync (string adresse,WSR_Params wsr_params,TypeSerializer type)
        {
            WSR_Result wsr_results = new WSR_Result();
           
           return wsr_results = await ConsumeWSR.Call(adresse, wsr_params, type, CancellationToken.None);
           
            //string result = string.Format("Error code : {0}, Error Message :{1}, Contient data :{2}", wsr_results.ErrorCode,wsr_results.ErrorMessage,wsr_results.Data);
            //return result;
        }
    }
}
