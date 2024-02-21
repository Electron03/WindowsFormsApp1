using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WindowsFormsApp1
{
    class ItemColor
    {
        string itemName;//имя элемента
        Color itemColor;//цвет элемента
        bool hasChanged = false;//были изменения?

        public ItemColor(string itemName, Color itemColor)
        {
            this.ItemName = itemName;
            this.IItemColor = itemColor;
        }

        public string ItemName { get => itemName; set => itemName = value; }
        public Color IItemColor { get => itemColor; set => itemColor = value; }
        public bool HasChanged { get => hasChanged; set => hasChanged = value; }
    }
}