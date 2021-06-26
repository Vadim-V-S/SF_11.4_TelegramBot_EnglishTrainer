using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace SF_11._4_TelegramBot_EnglishTrainer.Commands
{
    class AddWordCommand : AbstractCommand
    {
        private ITelegramBotClient botClient;
        private Dictionary<long, Word> Buffer;

        public AddWordCommand(ITelegramBotClient botClient)
        {
            this.botClient = botClient;
            Buffer = new Dictionary<long, Word>();
            CommandText = "/addword";
        }


        public async void StartProccessAsync(Conversation chat)
        {
            Buffer.Add(chat.GetId(), new Word());

            string text = "Введите значение на русском";

            await SendCommandText(text, chat.GetId());
        }


        public async void AddStatesAsync(AddingState addingState, Conversation chat, string message)
        {
            var word = Buffer[chat.GetId()];
            string text = "";

            switch (addingState)
            {
                case AddingState.Russian:
                    word.RussianWord = message;

                    text = "Введите английское значение";
                    break;

                case AddingState.English:
                    word.EnglishWord = message;

                    text = "Введите тему";
                    break;

                case AddingState.Theme:
                    word.Theme = message;

                    text = "Слово " + word.EnglishWord + " добавлено ";
                    break;

                    chat.Dictionary.Add(word.RussianWord,word);

                    Buffer.Remove(chat.GetId());
                    break;
            }

        }


        private async Task SendCommandText(string text, long chat)
        {
            await botClient.SendTextMessageAsync(chatId: chat, text: text);
        }
    }
}
