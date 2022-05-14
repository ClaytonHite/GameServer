using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuresOnlineGameServer.Entities.Items
{
    public class Item
    {
        public int ID;
        public string Name;
        public string Type;
        public Attributes Attributes;
        public int ImageNumber;
        public bool Stackable;
        public Item(int _id, string _name, string _type, Attributes _attributes, int _imageNumber, bool _stackable)
        {
            this.ID = _id;
            this.Name = _name;
            this.Type = _type;
            this.Attributes = _attributes;
            this.ImageNumber = _imageNumber;
            this.Stackable = _stackable;
        }
    }
}
