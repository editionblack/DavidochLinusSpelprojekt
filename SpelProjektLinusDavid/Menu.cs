//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//using System.Xml.Serialization;
//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Input;
//using Microsoft.Xna.Framework.Graphics;

//namespace SpelProjektLinusDavid
//{
//    public class Menu
//    {
//        public event EventHandler OnMenuChange;


//        public string Axis, Effects;
//        [XmlElement("Item")]
//        public List<MenuItem> Items;
//        int itemNumber;
//        string id;

//        public string ID
//        {
//            get { return id; }
//            set
//            {
//                id = value;
//                OnMenuChange(this, null);
//            }
//        }

//        void AlignMenuItems()
//        {

//        }

//        public Menu()
//        {
//            id = String.Empty;
//            itemNumber = 0;
//            Effects = String.Empty;
//            Axis = "Y";
//        }

//        public void Content()
//        {

//        }

//        public void UnloadContent()
//        {

//        }

//        public void Update(GameTime gameTime)
//        {

//        }

//        public void Draw(SpriteBatch spriteBatch)
//        {

//        }
//    }
//}
