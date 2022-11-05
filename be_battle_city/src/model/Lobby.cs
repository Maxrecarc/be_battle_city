using be_battle_city.src.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace be_battle_city.src
{
    internal class Lobby
    {
        long lobbyId { get; set; }

        List<Player> players { get; set; }
    }
}
