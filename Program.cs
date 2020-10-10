using System;
using System.IO;
using System.Net;
using api.Entitys;
using Newtonsoft.Json;


namespace api
{
    class Program
    {
        public static Page PageInit { get; set; }
        public static int Empates { get; set; }
        static void Main(string[] args)
        {
            getNumDraws(2011);
        }
        public static void getNumDraws(int year)
        {
            int TotalOfPages = 2;
            for (int NumberPage = 1; NumberPage <= TotalOfPages; NumberPage++)
            {
                GetTeamsEmpates(year, NumberPage);
                if(NumberPage < 2){
                    TotalOfPages = PageInit.total_pages;
                } else {
                    continue;
                }
            }
            Console.WriteLine(Empates);
        }
        public static void GetTeamsEmpates(int year, int Page)
        {
            string ResponseConcrete;
            string ApiRequest = string.Format("https://jsonmock.hackerrank.com/api/football_matches?year={0}&page={1}", year, Page);

            var RequestWeb = WebRequest.CreateHttp(ApiRequest);
            RequestWeb.Method = "GET";

            var ResponseRequestGET = RequestWeb.GetResponse();

            var StreamData = ResponseRequestGET.GetResponseStream();
            StreamReader ReadStreamData = new StreamReader(StreamData);
            object ObjResponse = ReadStreamData.ReadToEnd();
            ResponseConcrete = ObjResponse.ToString();

            PageInit = JsonConvert.DeserializeObject<Page>(ResponseConcrete);

            for (int Count = 0; Count < PageInit.Data.Count; Count++)
            {
                if (PageInit.Data[Count].team1goals == PageInit.Data[Count].team2goals)
                {
                    Empates += 1;
                }
            }
            ResponseRequestGET.Close();
        }
    }
}
