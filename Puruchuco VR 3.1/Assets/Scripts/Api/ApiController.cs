using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ApiController
{
    private readonly string apiURL;
    private readonly HttpClient httpClient;

    public ApiController()
    {
        httpClient = new HttpClient();
        apiURL = "https://pijz3i88qg.execute-api.us-east-1.amazonaws.com/dev/";
    }

    public async Task<string> SignUp(DataPlayer user)
    {
        string content = JsonUtility.ToJson(user);
        
        HttpResponseMessage response = await httpClient.PostAsync(apiURL + "dpsignup", new StringContent(content, Encoding.UTF8, "application/json"));

        var responseString = await response.Content.ReadAsStringAsync();

        return responseString;
    }

    public async Task<DataPlayer> LogIn(DataPlayer user)
    {
        string content = JsonUtility.ToJson(user);

        HttpResponseMessage response = await httpClient.PostAsync(apiURL + "dplogin", new StringContent(content, Encoding.UTF8, "application/json"));

        var responseString = await response.Content.ReadAsStringAsync();
        DataPlayer responseJson = null;

        if (responseString != "null")
            responseJson = JsonUtility.FromJson<DataPlayer>(responseString);

        return responseJson;
    }

    public async Task<string> AnswerPut(Answer answer)
    {
        string content = JsonUtility.ToJson(answer);

        HttpResponseMessage response = await httpClient.PostAsync(apiURL + "answerput", new StringContent(content, Encoding.UTF8, "application/json"));

        var responseString = await response.Content.ReadAsStringAsync();

        return responseString;
    }

    public async Task<Answer> AnswerGet(DataPlayer user)
    {
        string content = JsonUtility.ToJson(user);

        HttpResponseMessage response = await httpClient.PostAsync(apiURL + "answerget", new StringContent(content, Encoding.UTF8, "application/json"));

        var responseString = await response.Content.ReadAsStringAsync();
        Answer responseJson = null;

        if (responseString != "null")
            responseJson = JsonUtility.FromJson<Answer>(responseString);

        return responseJson;
    }
}
