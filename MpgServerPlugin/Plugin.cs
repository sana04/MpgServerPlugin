using Server = Exiled.Events.Handlers.Server;
using Player = Exiled.Events.Handlers.Player;
using MapEvents = Exiled.Events.Handlers.Map;
using Warhead = Exiled.Events.Handlers.Warhead;
using Exiled.API.Features;
using Exiled.API.Enums;
using System;
using HarmonyLib;
using Exiled.Loader;
using System.Collections.Generic;
using MEC;
//이 플러그인은 여러 플러그인의 소스를 참고하여 만들었습니다.
//This plugin was created by referring to the sources of several plugins.

namespace MpgServerPlugin
{
    public class Plugin : Plugin<Config>
    {
        private static readonly Lazy<Plugin> LazyInstance = new Lazy<Plugin>(() => new Plugin());
        public static Plugin Instance => LazyInstance.Value;

        public override PluginPriority Priority { get; } = PluginPriority.Medium;

        private Handlers.Player player;
        private Handlers.Server server;
        private Handlers.WarheadEvents warhead;

        private int _patchesCounter;
        public List<CoroutineHandle> Coroutines = new List<CoroutineHandle>();

        public Harmony Harmony { get; private set; }

        private Plugin()
        {
        }

        private void Patch()
        {
            try
            {
                Harmony = new Harmony($"Plugin.{++_patchesCounter}");

                var lastDebugStatus = Harmony.DEBUG;
                Harmony.DEBUG = true;

                Harmony.PatchAll();

                Harmony.DEBUG = lastDebugStatus;

                Log.Debug($"Patch is successfully patch", Loader.ShouldDebugBeShown);
            }
            catch (Exception e)
            {
                Log.Error($"Patch error : {e}");
            }
        }

        private void Unpatch()
        {
            Harmony.UnpatchAll();

            Log.Debug("Patch is successfully unpatch", Loader.ShouldDebugBeShown);
        }

        public override void OnEnabled()
        {
            base.OnEnabled();

            Patch();
            RegisterEvents();
            Log.Info("MpgServerPlugin On");
        }

        public override void OnDisabled()
        {
            base.OnDisabled();

            Unpatch();
            UnregisterEvents();
            Log.Info("MpgServerPlugin Off");
        }

        public void RegisterEvents()
        {
            player = new Handlers.Player();
            server = new Handlers.Server();
            warhead = new Handlers.WarheadEvents();

            Server.WaitingForPlayers += server.OnWaitingForPlayers;
            Server.RoundStarted += server.OnRoundStart;
            Server.RoundEnded += server.OnRoundEnd;
            Server.ReportingCheater += server.OnReporting;
            Player.Left += player.OnLeft;
            Player.Joined += player.OnJoined;
            Player.Died += player.OnDead;
            Player.Spawning += player.OnSpawn;
            Player.EnteringFemurBreaker += player.OnFemurbreakerentered;
            Player.Escaping += player.OnEscape;
            Player.EnteringPocketDimension += player.OnPocketentered;
            Player.EscapingPocketDimension += player.OnPocketescape;
            Player.FailingEscapePocketDimension += player.OnPocketDead;
            Player.IntercomSpeaking += player.OnIntercom;
            Player.TriggeringTesla += player.OnTriggerTesla;
            Player.DroppingItem += player.OnDroppingItem;
            Player.Banning += player.OnBanning;
            Player.Kicking += player.OnKicking;
            Player.Died += player.OnScpcontain;
            Player.ReloadingWeapon += player.OnReloadingWeapon;
            Player.InteractingDoor += player.OnDoorOpening;
            MapEvents.GeneratorActivated += player.OnGenOn;
            MapEvents.AnnouncingDecontamination += player.OnAnnouncingDecont;
            MapEvents.Decontaminating += player.OnDeont;
            //MapEvents.AnnouncingScpTermination += player.OnScpcont;
            MapEvents.AnnouncingNtfEntrance += player.OnNtfbackup;
            Warhead.Starting += warhead.OnAlphaStart;
            Warhead.Stopping += warhead.OnAlphaCancel;
        }

        public void UnregisterEvents()
        {
            Server.WaitingForPlayers -= server.OnWaitingForPlayers;
            Server.RoundStarted -= server.OnRoundStart;
            Server.RoundEnded -= server.OnRoundEnd;
            Server.ReportingCheater -= server.OnReporting;
            Player.Left -= player.OnLeft;
            Player.Joined -= player.OnJoined;
            Player.Died -= player.OnDead;
            Player.Spawning -= player.OnSpawn;
            Player.EnteringFemurBreaker -= player.OnFemurbreakerentered;
            Player.Escaping -= player.OnEscape;
            Player.EnteringPocketDimension -= player.OnPocketentered;
            Player.EscapingPocketDimension -= player.OnPocketescape;
            Player.FailingEscapePocketDimension -= player.OnPocketDead;
            Player.IntercomSpeaking -= player.OnIntercom;
            Player.TriggeringTesla -= player.OnTriggerTesla;
            Player.DroppingItem -= player.OnDroppingItem;
            Player.Banning -= player.OnBanning;
            Player.Kicking -= player.OnKicking;
            Player.Died -= player.OnScpcontain;
            Player.InteractingDoor -= player.OnDoorOpening;
            Player.ReloadingWeapon -= player.OnReloadingWeapon;
            MapEvents.GeneratorActivated -= player.OnGenOn;
            MapEvents.AnnouncingDecontamination -= player.OnAnnouncingDecont;
            MapEvents.Decontaminating -= player.OnDeont;
            //MapEvents.AnnouncingScpTermination -= player.OnScpcont;
            MapEvents.AnnouncingNtfEntrance -= player.OnNtfbackup;
            Warhead.Starting -= warhead.OnAlphaStart;
            Warhead.Stopping -= warhead.OnAlphaCancel;

            player = null;
            server = null;
            warhead = null;
        }
    }
}
