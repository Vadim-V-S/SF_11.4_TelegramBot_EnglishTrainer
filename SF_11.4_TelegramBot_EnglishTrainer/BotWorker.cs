using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;


namespace SF_11._4_TelegramBot_EnglishTrainer
{
    
    class BotWorker
    {
        public ITelegramBotClient botClient;
        public BotMessageLogic logic;


        public void InitializeBot()
        {
            botClient = new TelegramBotClient(BotCredentials.Token);
            logic = new BotMessageLogic();
        }


        public void StartBot()
        {
            botClient.OnMessage += BotClient_OnMessage;
            botClient.StartReceiving();
        }


        public void StopBot()
        {
            botClient.StopReceiving();
        }


        private async void BotClient_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            if (e.Message!=null)
            {
                await logic.Responce();
            }
        }
    }
}
