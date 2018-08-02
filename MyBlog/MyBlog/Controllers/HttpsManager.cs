using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace MyBlog.Controllers
{
    public class HttpsManager
    {
        WebRequest webRequest;
        WebResponse webResponse;
        public HttpsManager()
        {

        }

        public string IsTokenVerified(string clientToken)
        {
            try
            {
                webRequest = WebRequest.Create(DefineManager.FIREBASE_FUNCTIONS_ENDPOINT_CHECK_TOKEN);
                webRequest.Method = "POST";
                string postData = "{\"token\":\"" + clientToken + "\"}";
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                webRequest.ContentType = "application/json";
                webRequest.ContentLength = byteArray.Length;

                Stream dataStream = webRequest.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
                LogManager.PrintLogMessage("HttpsManager", "IsTokenVerified", "try to send data len: " + webRequest.ContentLength, DefineManager.LOG_LEVEL_DEBUG);

                webResponse = webRequest.GetResponse();
                LogManager.PrintLogMessage("HttpsManager", "IsTokenVerified", "response status: " + (((HttpWebResponse)webResponse).StatusCode), DefineManager.LOG_LEVEL_DEBUG);

                dataStream = webResponse.GetResponseStream();
                StreamReader streamReader = new StreamReader(dataStream);
                string responseData = streamReader.ReadToEnd();

                streamReader.Close();
                dataStream.Close();
                webResponse.Close();

                JObject responseObj = JObject.Parse(responseData);
                string responseResultValue = responseObj.GetValue("Result").ToString();

                LogManager.PrintLogMessage("HttpsManager", "IsTokenVerified", "response is: " + responseResultValue, DefineManager.LOG_LEVEL_DEBUG);

                switch (responseResultValue)
                {
                    case DefineManager.VERIFIED_CHECKER_RESULT_OK:
                        string responseUserDisplayName = responseObj.GetValue("displayName").ToString();
                        LogManager.PrintLogMessage("HttpsManager", "IsTokenVerified", "user display name is: " + responseUserDisplayName, DefineManager.LOG_LEVEL_DEBUG);

                        return responseUserDisplayName;
                    case DefineManager.VERIFIED_CHECKER_RESULT_FAIL:
                        LogManager.PrintLogMessage("HttpsManager", "IsTokenVerified", "failed to verify token", DefineManager.LOG_LEVEL_WARN);
                        return null;
                    default:
                        return null;
                }
            }
            catch(Exception err)
            {
                LogManager.PrintLogMessage("HttpsManager", "IsTokenVerified", "failed to communicate with server: " + err, DefineManager.LOG_LEVEL_ERROR);
            }
            return null;
        }
    }
}