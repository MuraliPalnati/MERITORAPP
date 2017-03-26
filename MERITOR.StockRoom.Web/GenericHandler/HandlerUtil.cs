using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace MERITOR.StockRoom.Web.GenericHandler
{
    public static class HandlerUtil<T>
    {

        // REST GET PROCESSOR
        public static List<T> RestgetProcessor(string APIAction, string Input)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                List<string> InputToService = null;

                InputToService = new List<string>();
                InputToService.Add(Input);

                string URL = System.Configuration.ConfigurationManager.AppSettings["URL"] + APIAction;
                HttpResponseMessage response = httpClient.PostAsJsonAsync<IEnumerable<string>>(URL, InputToService).Result;
                if (response.IsSuccessStatusCode)
                {
                    var ReturnValue = response.Content.ReadAsStringAsync().Result;
                    System.Web.Script.Serialization.JavaScriptSerializer json_serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                    var ReturnedEmployees = json_serializer.Deserialize<List<T>>(ReturnValue);
                    return ReturnedEmployees;
                }

            }
            catch (Exception exp)
            {
                throw exp;
            }
            return null;
        }

        public static T[] RestGetProcessor(string APIAction)
        {
            try
            {
                System.Web.Script.Serialization.JavaScriptSerializer json_serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                string URL = System.Configuration.ConfigurationManager.AppSettings["URL"] + APIAction;
                WebClient client = new WebClient();
                var DataReturned = client.DownloadString(URL);
                T[] myOutput = json_serializer.Deserialize<T[]>(DataReturned);

                return myOutput;
            }
            catch (HttpException exp)
            {
                throw exp;
            }
            catch (Exception exp)
            {
                throw exp;
            }

        }

        public static T[] RestGetProcessor(string APIAction, T Input)
        {
            try
            {
                string URL = System.Configuration.ConfigurationManager.AppSettings["URL"] + APIAction;
                WebClient client = new WebClient();
                var DataReturned = client.DownloadString(URL);

                List<T> Statuss = new List<T>();
                System.Web.Script.Serialization.JavaScriptSerializer json_serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

                return json_serializer.Deserialize<T[]>(DataReturned);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }


        //// REST POST PROCESSOR
        public static List<T> RestPostProcessor(string APIAction, T Input)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["URL"]);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                List<T> InputToService = null;
                if (Input != null)
                {
                    InputToService = new List<T>();
                    InputToService.Add(Input);
                }
                string URL = System.Configuration.ConfigurationManager.AppSettings["URL"] + APIAction;
                HttpResponseMessage response = httpClient.PostAsJsonAsync<IEnumerable<T>>(URL, InputToService).Result;
                if (response.IsSuccessStatusCode)
                {
                    var ReturnValue = response.Content.ReadAsStringAsync().Result;
                    System.Web.Script.Serialization.JavaScriptSerializer json_serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                    var ReturnedEmployees = json_serializer.Deserialize<List<T>>(ReturnValue);
                    return ReturnedEmployees;
                }
                //if (response.StatusCode == HttpStatusCode.InternalServerError)
                //{

                //   var errCode = response.Content.ReadAsStringAsync().Result;
                //   // var errCodee = errCode.Split(':')[1].Trim(new Char[] { '\"', '\\','}' });
                //   // string Errormsg = ErrorMessages.ResourceManager.GetString(errCodee);

                //    throw new HttpException(errCode,500);
                //}
                if (response.StatusCode == HttpStatusCode.InternalServerError)
                {
                    var errCode = response.Content.ReadAsStringAsync().Result;
                    throw new HttpException(errCode, 500);
                }
                else
                    return null;
            }
            catch (HttpException exp)
            {
                throw exp;
            }
        }

        public static List<T> PostProcessor(string APIAction, IEnumerable<T> Input)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["URL"]);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                string URL = System.Configuration.ConfigurationManager.AppSettings["URL"] + APIAction;
                HttpResponseMessage response = httpClient.PostAsJsonAsync<IEnumerable<T>>(URL, Input).Result;
                if (response.IsSuccessStatusCode)
                {
                    var ReturnValue = response.Content.ReadAsStringAsync().Result;
                    System.Web.Script.Serialization.JavaScriptSerializer json_serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                    var ReturnedEmployees = json_serializer.Deserialize<List<T>>(ReturnValue);
                    return ReturnedEmployees;
                }
                else
                    return null;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
       
        public static byte[] RestFilePostProcessor(string APIAction, T Input)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["URL"]);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                List<T> InputToService = null;
                if (Input != null)
                {
                    InputToService = new List<T>();
                    InputToService.Add(Input);
                }
                string URL = System.Configuration.ConfigurationManager.AppSettings["URL"] + APIAction;
                HttpResponseMessage response = httpClient.PostAsJsonAsync<IEnumerable<T>>(URL, InputToService).Result;
                if (response.IsSuccessStatusCode)
                {
                    var attachBlob = response.Content.ReadAsByteArrayAsync().Result;
                    //System.Web.Script.Serialization.JavaScriptSerializer json_serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                    //var ReturnedEmployees = json_serializer.Deserialize<List<T>>(ReturnValue);

                    return attachBlob;
                }
                if (response.StatusCode == HttpStatusCode.InternalServerError)
                {
                    var errCode = response.Content.ReadAsStringAsync().Result;
                    throw new HttpException(errCode, 500);
                }
                else
                    return null;
            }
            catch (HttpException exp)
            {
                throw exp;
            }
        }
    }

}