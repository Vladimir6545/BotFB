using BotFB.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using Bot.Messenger;
using Bot.Messenger.Models;
using Newtonsoft.Json.Linq;

namespace BotFB.Controllers
{
    public class FacebookBotController : Controller
    {
        string _tokenPage = "";
        // GET: FacebookBot
        public ActionResult Receive()
        {
            var query = Request.QueryString;


            if (query["hub.mode"] == "subscribe" &&
                query["hub.verify_token"] == "ArtemBot123")
            {
                string type = Request.QueryString["type"];
                var retVal = query["hub.challenge"];
                return Json(int.Parse(retVal), JsonRequestBehavior.AllowGet);
            }
            else
            {
                ViewBag.Logo = Url.Content(@"~/Content/Image/1.jpg");
                return View();
            }
        }

        [ActionName("Receive")]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ReceivePost(BotRequest data)
        {
            Task.Factory.StartNew(() =>
            {
                foreach (var entry in data.Entry)
                {
                    foreach (var message in entry.Messaging)
                    {
                        if (string.IsNullOrWhiteSpace(message?.Message?.Text))
                            continue;

                        string _typeText = message.Message.Text;

                        switch (_typeText)
                        {
                            case "1":
                                FirstMessage(message);
                                break;

                            case "2":
                                SendURL(message);
                                break;

                            case "3":
                                SendButtonURL(message);
                                break;
                        }
                    }
                }
            });

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        private void SendURL(BotMessageReceivedRequest userMessage)
        {
                var msg = "https://loremflickr.com/320/240";
            var json = $@" {{recipient: {{  id: {userMessage.Sender.Id}}},message: {{text: ""{msg}"" }}}}";
            PostRaw("https://graph.facebook.com/v2.6/me/messages?access_token=" + _tokenPage, json);
        }

        private void SendButtonURL(BotMessageReceivedRequest userMessage)
        {
            /*
             "attachment":{
      "type":"template",
      "payload":{
        "template_type":"button",
        "text":"Try the URL button!",
        "buttons":[
          {
            "type":"web_url",
            "url":"https://loremflickr.com/320/240",
            "title":"URL Button",
            "webview_height_ratio": "full"
          }
        ]
      }
    }
             */

            dynamic messageData = new JObject();
            messageData.attachment = new JObject();
            messageData.attachment.type = "template";
            messageData.attachment.payload = new JObject();
            messageData.attachment.payload.template_type = "generic";


            messageData.attachment.payload.elements
                = new JArray(
                    new JObject(
                        new JProperty("title", "hola"),
                        new JProperty("subtitle", "Mundo"),
                        new JProperty("buttons",
                            new JArray(
                                new JObject(
                                    new JProperty("type", "element_share")
                                )
                            )
                        )
                    )
                );

            var msg1 = "https://loremflickr.com/320/240";
            var json1 = $@" {{recipient: {{  id: {userMessage.Sender.Id}}},message: {{text: ""{msg1}"" }}}}";

            var msg = " attachment:{ type : template, payload:{template_type:button,        text:Try the URL button!, buttons :[ { type:web_url, url:https://loremflickr.com/320/240, title:URL Button, webview_height_ratio: full } ] } }";



            var json = $@" {{recipient: {{  id: {userMessage.Sender.Id}}},
                             message: {{{messageData}}}}}";
            PostRaw("https://graph.facebook.com/v2.6/me/messages?access_token=" + _tokenPage, json);
        }
        private void FirstMessage(BotMessageReceivedRequest userMessage)
        {
            var msg = "Введите ключевые слова для отработки бота: Фото, Видео, Кнопка, Ссылка, КнопкаСсылка, НомерТелефона, Опросник";

            var json = $@" {{recipient: {{  id: {userMessage.Sender.Id}}},message: {{text: ""{msg}"" }}}}";
            PostRaw("https://graph.facebook.com/v2.6/me/messages?access_token=" + _tokenPage, json);
        }

        private string PostRaw(string url, string data)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = "POST";
            using (var requestWriter = new StreamWriter(request.GetRequestStream()))
            {
                requestWriter.Write(data);
            }

            var response = (HttpWebResponse)request.GetResponse();
            if (response == null)
                throw new InvalidOperationException("GetResponse returns null");

            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                return sr.ReadToEnd();
            }
        }
    }
}
/*
 * https://fb.kit.academy/FacebookBot/Receive
 */
