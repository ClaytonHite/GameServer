using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuresOnlineGameServer.Entities.Items
{
    public class Attributes
    {
        public string[] magicalAttribute = { "Assassin's", "Banishing", "Frenzied", "Celestial", "Divine", "Flaming", "Frozen", "Precise", "Reliable", "Shadowed", "Sharp", "Shocking", "Vengeful" };
        public string[] materialAttribute = { "Adamantine", "Alder", "Ash", "Bone", "Bronze", "Bronzewood", "Copper", "Golden", "Iron", "Mithril", "Oak", "Stone", "Wooden", "Yew" };
        public int damageAttribute;
        public string MagicalAttributeString;
        public string MaterialAttributeString;
        public int MagicInt;
        public int MaterialInt;
        public int DamageAttribute;
        public Attributes(int magic, int material, int damage)
        {
            this.MagicalAttributeString = magicalAttribute[magic];
            this.MagicInt = magic;
            this.MagicalAttributeString = materialAttribute[material];
            this.MaterialInt = material;
            this.DamageAttribute = damage;
        }
    }
}
