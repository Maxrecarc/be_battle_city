using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace be_battle_city.src.module
{
    internal class Command
    {
        String command { get; set; }
        List<String> args { get; set; }

        public void recieveCommand(String com)
        {
            //TODO: получать запрос с сервера и преобразовывать запрос
            //в массив данных, по которым можно дальше работать
        }
    }
}
