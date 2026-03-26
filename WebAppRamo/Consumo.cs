using Datos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebAppRamo
{
    public class Consumo
    {
        string RutaFinal = string.Empty;
        string serviceUrl = "https://localhost:44388/";
        private static Consumo consumo;
        
        public Consumo()
        {
        }
        
        public static Consumo CrearInstancia()
        {
            if (consumo == null) consumo = new Consumo();
            return consumo;
        }

        #region Clientes
        public List<cl_Cliente> ListaCliente(ref string MsmError)
        {
            List<cl_Cliente> LstDenominacion = new List<cl_Cliente>();
            cl_Cliente ObjDenominacion = new cl_Cliente();
            RutaFinal = string.Empty;
            RutaFinal = string.Concat(serviceUrl, "api/Cliente/ConsultaClientes");

            //serviceUrl = "https://localhost:44303/api/Denominaciones/ListDenominaciones";
            
            //serviceUrl = "https://jerapi.teamsoftec.com/api/Denominaciones/ListDenominaciones/";

            string LstCelulaJson = string.Empty;
            try
            {
                using (HttpClient httpCliente = new HttpClient())
                {
                    httpCliente.BaseAddress = new Uri(RutaFinal);
                    httpCliente.Timeout = new TimeSpan(0, 2, 0);
                    var request = httpCliente.GetAsync(RutaFinal).Result;
                    if (request.IsSuccessStatusCode)
                    {
                        var response = request.Content.ReadAsStringAsync().Result;
                        var re = request.RequestMessage;
                        LstCelulaJson = response;
                        LstDenominacion = JsonConvert.DeserializeObject<List<cl_Cliente>>(response);

                    }
                }
            }
            catch (Exception ex)
            {
                MsmError = ex.Message;
            }
            return LstDenominacion;
        }

        public RespuestaModelo RegistraCliente(List<cl_Cliente> nuevo, ref string MsmError)
        {
            RespuestaModelo ObjRespModelo = new RespuestaModelo();
            string MnsRetorno = string.Empty;
            RutaFinal = string.Empty;
            RutaFinal = string.Concat(serviceUrl, "api/Cliente/");

            try
            {
                var request = JsonConvert.SerializeObject(nuevo);
                var content = new StringContent(request, Encoding.UTF8, "application/json");
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, accessToken);
                client.BaseAddress = new Uri(RutaFinal);
                var url = string.Format("{0}{1}", RutaFinal, "GuardaCliente");
                //var response = client.PostAsync(url, content);
                var response = Task.Run(async () => await client.PostAsync(url, content)).ConfigureAwait(false).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                {
                    var response2 = response.Content.ReadAsStringAsync().Result;
                    var re = response.RequestMessage;
                    var request2 = JsonConvert.SerializeObject(response.Content);
                    ObjRespModelo = JsonConvert.DeserializeObject<RespuestaModelo>(request2);
                }
            }
            catch (Exception ex)
            {
                ObjRespModelo.ProcesoExitoso = false;
                ObjRespModelo.MensajeError = ex.Message;
            }
            return ObjRespModelo;
        }


        #endregion

    }
}