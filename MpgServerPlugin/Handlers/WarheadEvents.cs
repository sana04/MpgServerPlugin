using Exiled.API.Features;
using Exiled.Events.EventArgs;
using UnityEngine;
using System;

namespace MpgServerPlugin.Handlers
{
    class WarheadEvents
    {
        public void OnAlphaStart(StartingEventArgs ev)
        {
            bool isresumed = AlphaWarheadController._resumeScenario != -1;
            double left = isresumed ? AlphaWarheadController.Host.timeToDetonation : AlphaWarheadController.Host.timeToDetonation - 4;
            double count = Math.Truncate(left / 10.0) * 10.0;
            if (!isresumed)
            {
                Log.Info($"Alpha Warhead is On  t-{count}seconds, {ev.Player.Nickname}({ev.Player})");
                Map.Broadcast(15, $"<size=50><color=red>알파탄두</color> 폭★파 절차가 <color=red>실행</color>되었습니다.\n<color=red>시설</color>의 지하가 <color=yellow>{count}</color> 내에 <color=red>폭★발</color>합니다.</size>");
            }
            else
            {
                Log.Info($"Alpha Warhead is resumed On  t-{count}seconds, {ev.Player.Nickname}({ev.Player})");
                Map.Broadcast(15, $"<size=50><color=red>알파탄두</color> 폭★파 절차가 <color=red>다시 실행</color>되었습니다.\n<color=red>시설</color>의 지하가 <color=yellow>{count}</color> 내에 <color=red>폭★발</color>합니다.</size>");
            }
        }

        public void OnAlphaCancel(StoppingEventArgs ev)
        {
            Log.Info($"Alpha Warhead is Off, {ev.Player.Nickname}({ev.Player})");
            Map.Broadcast(15, $"<size=50><color=red>알파탄두</color> 폭★파 절차가 <color=red>취소</color>되었습니다.\n취소한 사람 : {ev.Player.Nickname}</size>");
        }
    }
}
