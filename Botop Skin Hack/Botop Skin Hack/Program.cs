﻿using System;
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
        public static Menu Enemy;
        public static Menu Ally;
        public static  List<AIHeroClient> All_Players = new List<AIHeroClient>();
        public static Slider sliderr;

        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Game_Loaded;
        }
        static void Game_Loaded(EventArgs arg)
        {
            Skinhackbuddy = MainMenu.AddMenu("Botop Skin Hack", "shsaeed");
            Skinhackbuddy.AddGroupLabel("Botop Skin Hack  Version 0.3");
            Skinhackbuddy.AddSeparator();
            Skinhackbuddy.AddLabel("By Saeed Suleiman AKA (Botop)");
            Skinhackbuddy.Add("Skin Index", new Slider(Player.Instance.ChampionName + "Skin Index", 0, 0, 15)).OnValueChange += ChangeDSkin;
            Enemy = Skinhackbuddy.AddSubMenu("Enemy Champions" , "enemysub");
            Ally = Skinhackbuddy.AddSubMenu("Ally Champions" , "allysub");
            foreach (var hero in HeroManager.AllHeroes)
            {
                if (!hero.IsMe)
                {

                All_Players.Add(hero);
                var her = hero;

                if (hero.IsAlly)
                {
                 sliderr =  Ally.Add("skin." + hero.ChampionName, new Slider(her.Name + "(" + her.ChampionName + ")", 0, 0, 15));
                 sliderr.OnValueChange += delegate(ValueBase<int> obj, ValueBase<int>.ValueChangeArgs argg)
                 {
                     her.SetSkin(her.ChampionName, argg.NewValue);
                 };
                }
                else
                {
                    sliderr = Enemy.Add("skin." + hero.ChampionName, new Slider(her.Name + "(" + her.ChampionName + ")", 0, 0, 15));
                    sliderr.OnValueChange += delegate(ValueBase<int> obj, ValueBase<int>.ValueChangeArgs argg)
                    {
                        her.SetSkin(her.ChampionName, argg.NewValue);
                    };
                }

            }
            Chat.Print("Skin Hack Buddy By Botop (Saeed Suleiman) Loaded. Version 0.3");
        }
        }
        public static void ChangeDSkin(Object sender, EventArgs args)
        {
            int skinid = Skinhackbuddy["Skin Index"].Cast<Slider>().CurrentValue;
            Player.SetSkinId(skinid);
            
        }
       
       
    }
}
