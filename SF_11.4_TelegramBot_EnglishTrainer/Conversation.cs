using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace SF_11._4_TelegramBot_EnglishTrainer
{
    class Conversation
    {
        private Chat telegramChat;

        private List<Message> telegramMessages;

        public Dictionary<string,Word> Dictionary; //----------------


        public Conversation (Chat chat)
        {
            telegramChat = chat;
            telegramMessages = new List<Message>();
        } 


        public void AddMessage(Message message)
        {
            telegramMessages.Add(message);
        }


        public void ClearMessages()
        {
            telegramMessages.Clear();
        }

        public List<string>GetTextMessages()
        {
            var textMessages = new List<string>();
            foreach(var message in telegramMessages)
            {
                if (message!=null)
                textMessages.Add(message.Text);
            }
            return textMessages;
        }


        public long GetId() => telegramChat.Id;


        public string GetLastMessage() => telegramMessages[^1].Text;


    }
}
