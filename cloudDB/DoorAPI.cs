using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Net;
using RestSharp.Serializers;

namespace cloudDB
{
    public class DoorAPI
    {
        /// HTTP access constant to toggle between local and cloud server.
        public static bool useCloudServer = false;

        /// Base url for local testing and cloud url for production
        const string baseUrlLocal = "http://localhost:8080/";
        const string baseUrlCloud = "https://mongorevit.herokuapp.com/";

        public static string RestAPIBaseUrl
        {
            get { return useCloudServer ? baseUrlCloud : baseUrlLocal; }
        }


        /// GET JSON data from the specified mongoDB collection.

        public static List<Door> Get(string collectionName)
        {
            RestClient client = new RestClient(RestAPIBaseUrl);
            RestRequest request = new RestRequest("/api" + "/" + collectionName, Method.GET);

            IRestResponse<List <Door>> response = client.Execute<List<Door>>(request);

            return response.Data;
        }

        /// Batch POST JSON document data into the specified mongoDB collection.
        public static HttpStatusCode PostBatch(out string content, out string errorMessage,
            string collectionName, List<Door> doorData)
        {
            RestClient client = new RestClient(RestAPIBaseUrl);
            RestRequest request = new RestRequest("/api" + "/" + collectionName + "/" + "batch", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(doorData);

            IRestResponse response = client.Execute(request);
            content = response.Content;
            errorMessage = response.ErrorMessage;

            return response.StatusCode;
        }

    }
}
