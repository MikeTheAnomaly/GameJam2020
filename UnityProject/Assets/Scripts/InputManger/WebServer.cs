using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using UnityEngine;

public class WebServer : MonoBehaviour
{
	Thread thread;
	string dataPath;
	string ipaddress;
	public TextAsset html;
	string textToSend;
	HttpListener server;

	// Start is called before the first frame update
	void Start()
    {
		textToSend = html.text;
		ipaddress = Wsserver.GetLocalIPAddress();
		//dataPath = Application.dataPath;
		thread = new Thread(webserver);
		thread.Start();
    }
	
    // Update is called once per frame
    void Update()
    {
        
    }

	public void OnApplicationQuit()
	{
		server.Close();
		server.Abort();
		thread.Abort();
	}

	void webserver()
	{
		Debug.Log("Setting up");
		server = new HttpListener();
		Debug.Log("Setting up");
		server.Prefixes.Add("http://" + ipaddress + "/");

		server.Start();
		Debug.Log("waiting");

		while (true)
		{
			HttpListenerContext context = server.GetContext();
			HttpListenerResponse response = context.Response;
			//Debug.Log(context.Request.Url.LocalPath);
			//string page;
			//if (context.Request.Url.LocalPath != "/" || context.Request.Url.LocalPath != null)
			//{
			//	page = dataPath + context.Request.Url.LocalPath;
			//}
			//else
			//{
			//	page = dataPath + "ws.html";
			//}
			//if (page == string.Empty)
			//	page = dataPath + "/ws.html";
			//Debug.Log(page);
			//TextReader tr = new StreamReader(page);
			//TextReader tr = new StringReader(textToSend);
			//string msg = tr.ReadToEnd();

			byte[] buffer = Encoding.UTF8.GetBytes(textToSend);

			response.ContentLength64 = buffer.Length;
			Stream st = response.OutputStream;
			st.Write(buffer, 0, buffer.Length);

			context.Response.Close();
		}

	}

}
