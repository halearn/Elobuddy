using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Constants;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Rendering;
using EloBuddy.SDK.Utils;

namespace Botop_Skin_Hack
{

    class Program
    {
        public static string Model = ObjectManager.Player.BaseSkinName;
        public static Menu Skinhackbuddy;
        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Game_Loaded;
        }
        static void Game_Loaded(EventArgs arg)
        {

            Skinhackbuddy = MainMenu.AddMenu("Botop Skin Hack", "shsaeed");
            Skinhackbuddy.AddGroupLabel("Botop Skin Hack  Version 0.1");
            Skinhackbuddy.AddSeparator();
            Skinhackbuddy.AddLabel("By Saeed Suleiman AKA (Botop)");
            Skinhackbuddy.Add("Skin Index", new Slider("Skin Index", 0, 0, 15)).OnValueChange += ChangeDSkin;              
            Chat.Print("Skin Hack Buddy By Botop (Saeed Suleiman) Loaded. Version 0.1");
        }
        public static void ChangeDSkin(Object sender, EventArgs args)
        {
            int skinid = Skinhackbuddy["Skin Index"].Cast<Slider>().CurrentValue;
            Player.SetSkinId(skinid);

        }
       
    }
}
