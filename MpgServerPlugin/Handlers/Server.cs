using MEC;
using UnityEngine;
using System.Collections.Generic;
using Exiled.API.Features;
using Exiled.Events.EventArgs;

namespace MpgServerPlugin.Handlers
{
    class Server
    {
        private readonly Plugin plugin;

        public void OnWaitingForPlayers()
        {
            Log.Info("플레이어를 기다리는중...");
            Warhead.IsLocked = false;
            plugin.Coroutines.Add(Timing.RunCoroutine(ServerBroadcast()));
        }

        public void OnRoundStart()
        {
            Map.Broadcast(5, Plugin.Instance.Config.RoundStartedMessage);
            Log.Info("RoundStart!");
            plugin.Coroutines.Add(Timing.RunCoroutine(AutoNuke()));
        }

        private IEnumerator<float> ServerBroadcast()
        {
            for (; ; )
            {
                yield return Timing.WaitForSeconds(80f);

                Map.Broadcast(5, $"<size=40><color=lime>Auto Tip</color>\n<color=red>SCP-914</color>에서 아이템을 강화시 손에 들고 업그레이드를 하세요! <color=green>손강화</color>(이)가 된답니다!</size>");

                yield return Timing.WaitForSeconds(80f);

                Map.Broadcast(5, $"<size=40><color=lime>Auto Tip</color>\n<color=gray>총</color>을 들고 문을 열 수 있습니다!</size>");
            }
        }

        private IEnumerator<float> AutoNuke()
        {
            yield return Timing.WaitForSeconds(1500f);

            Warhead.Start();
            Warhead.IsLocked = true;
            Map.Broadcast(10, $"<size=50><color=red>자동핵</color>이(가) <color=red>활성화</color> 되었습니다.</color></size>");
        }

        public void OnRoundEnd(RoundEndedEventArgs ev)
        {
            Map.Broadcast(20, $"<size=50><color=blue>라운드</color>가 종료되었습니다.\n다음 라운드 시작까지 : {ev.TimeToRestart}초</size>");
            Cassie.Message($"Xmas_JingleBells");
            Map.TurnOffAllLights(20.0f, false);
            foreach (CoroutineHandle coroutine in plugin.Coroutines)
                Timing.KillCoroutines(coroutine);
        }

        public void OnReporting(ReportingCheaterEventArgs ev)
        {
            Map.Broadcast(10, $"<size=40><color=lime>{ev.Reporter}</color>님이 <color=red>{ev.Reported}</color>(을)를 신고하였습니다.\n<color=green>사유 : {ev.Reason}</color></size>");
            ev.Reporter.Broadcast(10, $"<size=40>당신은 <color=red>{ev.Reported}</color>(을)를 <color=red>신고</color>\n하였습니다. \n<color=red>신고</color>만으론 부족하기에 <color=red>증거자료</color> 제출을 위해 *HTTPS://discord.gg/7dErEw7* 에 <color=yellow>가입하여</color> <color=red>#신고</color> 채널에 증거를 제출해주시길 바랍니다.</size>");
        }

        public void OnRestartingRound()
        {
            foreach (CoroutineHandle coroutine in plugin.Coroutines)
                Timing.KillCoroutines(coroutine);
        }
    }
}
