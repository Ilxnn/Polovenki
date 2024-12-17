using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Classes
{
    public static class messages
    {
        public static List<string> messagesList = new List<string> {"Приветик..)","Да все хорошо, а у тебя как?","Понятненько)","Можно конечно)","Хорошо малыш :* Увидимся пупсик!"};

        public static string GetMessage(int mess) { 
            return messagesList[mess];
        }
    }
}
