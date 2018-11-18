using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeKatas.Refactor___Tennis
{
    public interface ITennisGame
    {
        void WonPoint(string playerName);
        string GetScore();
    }
}
