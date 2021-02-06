using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Threading.Tasks;

namespace PBDesk
{
    public class Query
    {
        public const Byte STATUS_SUCCESS = 1, STATUS_FAILURE = 0;
        public const String 
            TYPE_GET = "GET", 
            TYPE_POST = "POST", 
            TYPE_UPDATE = "UPDATE", 
            TYPE_DELETE = "DELETE",
            TYPE_PUT = "PUT";

        public Byte Status { get; private set; }
        public List<Byte> Response { get; private set; }
        public HttpStatusCode Code { get; private set; }

        public Query()
        {
            this.Status = Query.STATUS_FAILURE;
            this.Response = new List<Byte>();
            this.Code = 0;
        }

        public Query(in String url, in String type)
        {
            this.Status = Query.STATUS_FAILURE;
            this.Response = new List<Byte>();
            this.Code = 0;
            this.Send(url, type);
        }

        public Query(in String url, in String type, in List<Parameter> list)
        {
            this.Status = Query.STATUS_FAILURE;
            this.Response = new List<Byte>();
            this.Code = 0;
            this.Send(url, type, list);
        }

        public void Send(in String url, in String type, in List<Parameter> list = null)
        {
            // Подключаемся к ресурсу
            HttpWebRequest web_request = (HttpWebRequest) WebRequest.CreateHttp(url);

            // Устанавливаем тип запроса
            web_request.Method = type;

            if (list != null)
            {
                // Задаем данные для отправки
                String data = "";

                for (int i = 0; i < list.Count; i++)
                {
                    if (i > 0)
                        data += "&";

                    data += list[i].Name + "=" + list[i].Value;
                }

                // Преобразуем данные в массив байтов
                Byte[] bytes = System.Text.Encoding.UTF8.GetBytes(data);

                // Устанавливаем тип содержимого (зашифрованно)
                web_request.ContentType = "application/x-www-form-urlencoded";

                // Устанавливаем заголовок запроса
                web_request.ContentLength = bytes.Length;

                // Устанавливаем тип содержимого (зашифрованно)
                web_request.ContentType = "application/x-www-form-urlencoded";

                // Записываем данные в поток запроса
                using (Stream stream = web_request.GetRequestStream())
                    stream.Write(bytes, 0, bytes.Length);
            }
            
            // Получаем ответ от ресурса
            try
            {
                HttpWebResponse web_response = (HttpWebResponse) web_request.GetResponse();

                // Получаем http-код ответа
                this.Code = web_response.StatusCode;

                // Получаем данные из ответа ресурса
                using (MemoryStream memory = new MemoryStream())
                {
                    web_response.GetResponseStream().CopyTo(memory);
                    this.Response = new List<Byte>(memory.ToArray());
                }

                web_response.Close();

            } 
            catch (WebException web_exception)
            {
                // Получаем http-код ответа
                this.Code = (HttpStatusCode) web_exception.Status;

                // Получаем данные из ответа ресурса
                using (MemoryStream memory = new MemoryStream())
                {
                    web_exception.Response.GetResponseStream().CopyTo(memory);
                    this.Response = new List<Byte>(memory.ToArray());
                }
            }

            if (this.Code >= (HttpStatusCode) 200 && this.Code <= (HttpStatusCode) 299)
                this.Status = Query.STATUS_SUCCESS;
            else
                this.Status = Query.STATUS_FAILURE;
        }
    }
}
