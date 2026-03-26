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

        public cl_Cliente ClienteById(int Id, ref string MsmError)
        {
            cl_Cliente ObjDenominacion = new cl_Cliente();
            RutaFinal = string.Empty;
            RutaFinal = string.Concat(serviceUrl, "api/Cliente/ConsultaClienteById?Id=",Id + "");

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
                        ObjDenominacion = JsonConvert.DeserializeObject<cl_Cliente>(response);
                    }
                }
            }
            catch (Exception ex)
            {
                MsmError = ex.Message;
            }
            return ObjDenominacion;
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

        public RespuestaModelo ModificaCliente(cl_Cliente nuevo, ref string MsmError)
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
                var url = string.Format("{0}{1}", RutaFinal, "ModificaCliente");
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

        public RespuestaModelo EliminaCliente(int idCliente, ref string MsmError)
        {
            RespuestaModelo ObjRespModelo = new RespuestaModelo();
            cl_Cliente ObjDenominacion = new cl_Cliente();
            RutaFinal = string.Empty;
            RutaFinal = string.Concat(serviceUrl, "api/Cliente/EliminaCliente?idCliente=", idCliente + "");

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
                        /*
                        var request2 = JsonConvert.SerializeObject(response.Content);
                        ObjRespModelo = JsonConvert.DeserializeObject<RespuestaModelo>(request2);
                        */
                    }
                }
            }
            catch (Exception ex)
            {
                MsmError = ex.Message;
            }
            return ObjRespModelo;
        }

        #endregion

        #region Producto
        public List<cl_Producto> ListaProducto(ref string MsmError)
        {
            List<cl_Producto> LstDenominacion = new List<cl_Producto>();
            cl_Producto ObjDenominacion = new cl_Producto();
            RutaFinal = string.Empty;
            RutaFinal = string.Concat(serviceUrl, "api/Producto/ConsultaProductos");

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
                        LstDenominacion = JsonConvert.DeserializeObject<List<cl_Producto>>(response);

                    }
                }
            }
            catch (Exception ex)
            {
                MsmError = ex.Message;
            }
            return LstDenominacion;
        }

        public cl_Producto ProductoById(int Id, ref string MsmError)
        {
            cl_Producto ObjDenominacion = new cl_Producto();
            RutaFinal = string.Empty;
            RutaFinal = string.Concat(serviceUrl, "api/Producto/ConsultaProductoById?Id=", Id + "");

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
                        ObjDenominacion = JsonConvert.DeserializeObject<cl_Producto>(response);
                    }
                }
            }
            catch (Exception ex)
            {
                MsmError = ex.Message;
            }
            return ObjDenominacion;
        }

        public RespuestaModelo RegistraProducto(List<cl_Producto> nuevo, ref string MsmError)
        {
            RespuestaModelo ObjRespModelo = new RespuestaModelo();
            string MnsRetorno = string.Empty;
            RutaFinal = string.Empty;
            RutaFinal = string.Concat(serviceUrl, "api/Producto/");

            try
            {
                var request = JsonConvert.SerializeObject(nuevo);
                var content = new StringContent(request, Encoding.UTF8, "application/json");
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, accessToken);
                client.BaseAddress = new Uri(RutaFinal);
                var url = string.Format("{0}{1}", RutaFinal, "GuardaProductos");
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

        public RespuestaModelo ModificaProducto(cl_Producto nuevo, ref string MsmError)
        {
            RespuestaModelo ObjRespModelo = new RespuestaModelo();
            string MnsRetorno = string.Empty;
            RutaFinal = string.Empty;
            RutaFinal = string.Concat(serviceUrl, "api/Producto/");

            try
            {
                var request = JsonConvert.SerializeObject(nuevo);
                var content = new StringContent(request, Encoding.UTF8, "application/json");
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, accessToken);
                client.BaseAddress = new Uri(RutaFinal);
                var url = string.Format("{0}{1}", RutaFinal, "ModificaProductos");
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

        public RespuestaModelo EliminaProducto(cl_Producto ObjProducto, ref string MsmError)
        {
            RespuestaModelo ObjRespModelo = new RespuestaModelo();
            string MnsRetorno = string.Empty;
            RutaFinal = string.Empty;
            RutaFinal = string.Concat(serviceUrl, "api/Producto/");

            try
            {
                var request = JsonConvert.SerializeObject(ObjProducto);
                var content = new StringContent(request, Encoding.UTF8, "application/json");
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, accessToken);
                client.BaseAddress = new Uri(RutaFinal);
                var url = string.Format("{0}{1}", RutaFinal, "EliminaProducto");
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

        #region Tipo Producto
        public List<cl_Tipo_Producto> ListaTipoProducto(ref string MsmError)
        {
            List<cl_Tipo_Producto> LstDenominacion = new List<cl_Tipo_Producto>();
            cl_Tipo_Producto ObjDenominacion = new cl_Tipo_Producto();
            RutaFinal = string.Empty;
            RutaFinal = string.Concat(serviceUrl, "api/TipoProducto/ConsultaTipoProductos");

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
                        LstDenominacion = JsonConvert.DeserializeObject<List<cl_Tipo_Producto>>(response);

                    }
                }
            }
            catch (Exception ex)
            {
                MsmError = ex.Message;
            }
            return LstDenominacion;
        }

        #endregion

        #region Tipo Identificación
        public List<cl_Tipo_Identificacion> ListaTipoIdenticacion(ref string MsmError)
        {
            List<cl_Tipo_Identificacion> LstDenominacion = new List<cl_Tipo_Identificacion>();
            cl_Tipo_Identificacion ObjDenominacion = new cl_Tipo_Identificacion();
            RutaFinal = string.Empty;
            RutaFinal = string.Concat(serviceUrl, "api/TipoIdentificacion/ConsultaTipoIdentificacion");

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
                        LstDenominacion = JsonConvert.DeserializeObject<List<cl_Tipo_Identificacion>>(response);

                    }
                }
            }
            catch (Exception ex)
            {
                MsmError = ex.Message;
            }
            return LstDenominacion;
        }

        #endregion

        #region Estado Civil
        public List<cl_EstadoCivil> ListaEstadoCivil(ref string MsmError)
        {
            List<cl_EstadoCivil> LstDenominacion = new List<cl_EstadoCivil>();
            cl_EstadoCivil ObjDenominacion = new cl_EstadoCivil();
            RutaFinal = string.Empty;
            RutaFinal = string.Concat(serviceUrl, "api/EstadoCivil/ConsultaEstadoCivil");

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
                        LstDenominacion = JsonConvert.DeserializeObject<List<cl_EstadoCivil>>(response);
                    }
                }
            }
            catch (Exception ex)
            {
                MsmError = ex.Message;
            }
            return LstDenominacion;
        }

        #endregion

        #region Carrito
        
        public RespuestaModelo RegistraCarrito(cl_CarritoCab nuevo, ref string MsmError)
        {
            RespuestaModelo ObjRespModelo = new RespuestaModelo();
            string MnsRetorno = string.Empty;
            RutaFinal = string.Empty;
            RutaFinal = string.Concat(serviceUrl, "api/Carrito/");

            try
            {
                var request = JsonConvert.SerializeObject(nuevo);
                var content = new StringContent(request, Encoding.UTF8, "application/json");
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, accessToken);
                client.BaseAddress = new Uri(RutaFinal);
                var url = string.Format("{0}{1}", RutaFinal, "GuardaCarrito");
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