﻿using MobileApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Data
{
    public class RestService
    {
        HttpClient client;
        string grant_type = "password";

        public RestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded' "));
        }

        public async Task<Token>Login(User user)
        {
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("grand_type", grant_type));
            postData.Add(new KeyValuePair<string, string>("username", user.Username));
            postData.Add(new KeyValuePair<string, string>("passwod", user.Password));
            var content = new FormUrlEncodedContent(postData);

            var response = await PostResponseLogin<Token>(Constant.LoginUrl, content);
            DateTime dt = new DateTime();
            dt = DateTime.Today;
            response.expire_date = dt.AddSeconds(response.expire_in);
            return response;
        }

        public async Task<T> PostResponseLogin<T>(string weburl, FormUrlEncodedContent content) where T : class
        {
            var response = await client.PostAsync(weburl, content);
            var jsonResult = response.Content.ReadAsStringAsync().Result;
            var responseObject = JsonConvert.DeserializeObject<T>(jsonResult);
            return responseObject;
        }

        public async Task<T> PostResponse<T>(string weburl, string jsonstring) where T : class
        {
            var Token = App.TokenDatabase.GetToken();
            string ContetType = "application/json";
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token.access_token);
            try
            {
                var result = await client.PostAsync(weburl, new StringContent(jsonstring, Encoding.UTF8, ContetType));
                if(result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var JsonResult = result.Content.ReadAsStringAsync().Result;
                    try
                    {
                        var ContetnResp = JsonConvert.DeserializeObject<T>(JsonResult);
                        return ContetnResp;
                    }
                    catch { return null; }
                }             
            }
            catch { return null; }
            return null;
            
        }

        public async Task<T> GetResponse<T>(string weburl) where T : class
        {
            var Token = App.TokenDatabase.GetToken();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token.access_token);
            try
            {
                var response = await client.GetAsync(weburl);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var JsonResult = response.Content.ReadAsStringAsync().Result;
                    try
                    {
                        var ContentResp = JsonConvert.DeserializeObject<T>(JsonResult);
                        return ContentResp;
                    }
                    catch { return null; }
                }
            }
            catch { return null; }
            return null;
        }


    }
}
