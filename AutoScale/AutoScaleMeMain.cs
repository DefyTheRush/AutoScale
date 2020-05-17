using EXILED;
using System;

namespace TinyMe
{
    public class AutoScaleMeMain : EXILED.Plugin
    {
        public override string getName => "TinyMe";
        public static float ScaleValue;
        public AutoScaleEventHandler Handler;
        bool EnablePlugin;

        public void ReloadCofiguration()
        {
            EnablePlugin = Config.GetBool("autoscale_enable", false);
            if (EnablePlugin)
                Log.Info("Enabling \"AutoScale\"!");
            else
                Log.Info("Disabling \"AutoScale\"!");

            ScaleValue = Config.GetFloat("autoscale_value", 1f);
        }

        public override void OnDisable()
        {
            Events.RoundEndEvent -= Handler.RunWhenRoundEnds;
            Events.RoundStartEvent -= Handler.RunWhenRoundStarts;
            Events.PlayerJoinEvent -= Handler.RunWhenPlayerJoins;
            Handler = null;
        }

        public override void OnEnable()
        {
            ReloadCofiguration();
            if (!EnablePlugin)
                return;

            Handler = new AutoScaleEventHandler();
            Events.PlayerJoinEvent += Handler.RunWhenPlayerJoins;
            Events.RoundStartEvent += Handler.RunWhenRoundStarts;
            Events.RoundEndEvent += Handler.RunWhenRoundEnds;
        }

        public override void OnReload() { }
    }
}
