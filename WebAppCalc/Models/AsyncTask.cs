using HtmlAgilityPack;
using System;
using System.Net;

namespace WebAppCalc.Models
{
    public class AsyncTask
    {
        private delegate void AsyncDelegate();

        AsyncDelegate _delegate;
        bool _data;
        private readonly IDAL _dal = new EDAL();       

        // Метод по сигнатуре подходит под делегат BeginEventHandler
        public IAsyncResult OnBegin(object sender, EventArgs e, AsyncCallback cb, object extraData)
        {
            _delegate = ExecuteAsyncTask;
            return _delegate.BeginInvoke(cb, extraData);
        }

        // Метод по сигнатуре подходит под делегат EndEventHandler
        public void OnEnd(IAsyncResult ar)
        {
            _delegate.EndInvoke(ar);           
        }

        // Метод по сигнатуре подходит под делегат EndEventHandler
        public void OnTimeOut(IAsyncResult ar)
        {
            _data = false;//"Вышло время ожидания завершения задачи";
        }

        // Метод для получения результата.
        public bool GetData()
        {
            return _data;
        }

        // Метод, который будет выполнятся в отдельном потоке.
        private void ExecuteAsyncTask()
        {
            _dal.ClearExchangeRates();

            var htmli = @"https://bank.gov.ua/control/en/curmetal/detail/currency?period=daily";

            /* But the best way is to do the same but without webrequest
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(htmli);*/
            HttpWebRequest oReq = (HttpWebRequest)WebRequest.Create(htmli);
            HttpWebResponse resp = (HttpWebResponse)oReq.GetResponse();
            var htmlDoc = new HtmlDocument();
            htmlDoc.Load(resp.GetResponseStream());            

            var father = htmlDoc.DocumentNode.SelectNodes("//tr");
            int count;

            if (father != null)
            {
                foreach (var item in father)
                {
                    if (item.NodeType == HtmlNodeType.Element)
                    {
                        count = 0;
                        ExchangeRates rts = new ExchangeRates();

                        foreach (var item2 in item.ChildNodes)
                        {
                            if (item2.NodeType == HtmlNodeType.Element && (item2.Attributes["class"].Value == "cell" || item2.Attributes["class"].Value == "cell_c"))
                            {
                                count++;

                                if (count == 1)
                                {
                                    rts.DigitalCode = int.Parse(item2.InnerText);
                                }
                                else if (count == 2)
                                {
                                    rts.LetterCode = item2.InnerText;
                                }
                                else if (count == 3)
                                {
                                    rts.NumberOfUnits = int.Parse(item2.InnerText);
                                }
                                else if (count == 4)
                                {
                                    rts.CurrencyName = item2.InnerText;
                                }
                                else if (count == 5)
                                {
                                    string temp = item2.InnerText.Replace(".", ",");
                                    rts.OfficialExchangeRates = double.Parse(temp);
                                }
                            }
                        }

                        if (rts.DigitalCode != 0)
                        {                           
                            _dal.SaveRate(rts);
                            _data = true;
                        }
                    }
                }               
            }
            else
            {
                _data = false;
            }
        }
    }
}