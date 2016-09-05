using EveMarket.Core.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EveMarket.Core.Models
{
    public class MineralList
    {
        public double Tritanium { get; set; }
        public double Pyerite { get; set; }
        public double Mexallon { get; set; }
        public double Isogen { get; set; }
        public double Nocxium { get; set; }
        public double Zydrine { get; set; }
        public double Megacyte { get; set; }
        public double Morphite { get; set; }

        public double this[string key]
        {
            get { return (double)GetType().GetRuntimeProperty(key).GetValue(this); }
            set { GetType().GetRuntimeProperty(key).SetValue(this, value); }
        }

        public double this[MineralType key]
        {
            get { return this[key.ToString()]; }
            set { this[key.ToString()] = value; }
        }

        public double TotalVolume
        {
            get { return GetMineralNames().Select(m => this[m]*.01).Sum(); }
        }

        public IEnumerable<string> GetMineralNames()
        {
            yield return nameof(Tritanium);
            yield return nameof(Pyerite);
            yield return nameof(Mexallon);
            yield return nameof(Isogen);
            yield return nameof(Nocxium);
            yield return nameof(Zydrine);
            yield return nameof(Megacyte);
            yield return nameof(Morphite);
        }
    }
}
