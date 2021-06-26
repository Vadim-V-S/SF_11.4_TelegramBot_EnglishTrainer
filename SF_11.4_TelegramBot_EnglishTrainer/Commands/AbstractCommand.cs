using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;

namespace SF_11._4_TelegramBot_EnglishTrainer.Commands
{
   abstract class AbstractCommand: IChatCommand
    {
        public string CommandText;

        public virtual bool CheckMessages(string messages) => CommandText == messages;

    }
}
