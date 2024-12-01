using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpCsharpPoKEKW.Model;

namespace TpCsharpPoKEKW.MVVM.ViewModel
{
    public class MonsterChoiseVM :BaseVM
    {
        public List<Monster> AllMonster { get; set; } = new List<Monster>();

    }
}
