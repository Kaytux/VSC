using BibliothequeClassesVSC;
using Stub;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using SteamWebAPI2.Interfaces;
using SteamWebAPI2.Utilities;
using SteamworksSharp;
using SteamworksSharp.Native;

namespace VuesVSC
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public Manager Manager { get; private set; } = new Manager(new Stub.Stub());
        public Navigator Navigator { get; private set; } = new Navigator();
        public App() 
        {
            Manager.ChargeDonnées();
            Manager.InitSteamAPI();
        }
    }
}
