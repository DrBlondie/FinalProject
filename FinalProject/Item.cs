using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject {
    public class Item {
        private string name;
        private string[] requirements;
        private int price;
        private int craftingTime;
        private string location;
        private string type;

        public Item(string _name, string[] _requirements, int _price, int time, string loc, string _type) {
            name = _name;
            requirements = _requirements;
            price = _price;
            craftingTime = time;
            location = loc;
            type = _type;
        }

        public string Name {
            get {
                return name;
            }
        }
        public string[] Requirements {
            get {
                return requirements;
            }
        }
        public int Price {
            get {
                return price;
            }
        }
        public int CraftingTime {
            get {
                return craftingTime;
            }
        }
        public string Location {
            get {
                return location;
            }
        }
        public string Type {
            get {
                return type;
            }
        }
    }
}
