using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;
using UnityEngine;

namespace MpgServerPlugin.Handlers
{
    class Player
    {

        //private readonly Random random;

        private string GetRoleFullname(Role role)
        {
            return role.fullName;
        }

        private string Getplayerlist(PlayerList playerList)
        {
            return playerList.name;
        }

        public void OnLeft(LeftEventArgs ev)
        {
            //string rolename = GetRoleFullname(ev.Role);
            if (ev.Player.Team == Team.SCP)
            {
                Map.Broadcast(5, $"<size=50><color=#DF4D4D>{ev.Player.Role}</color>이(가) <color=#DF4D4D>격리</color>되었습니다.\n격리원인 : <color=red>Self Disconnect.</color></size>");
                ev.Player.Ban(10080, $"[Banned by Server Plugin]\nBan by MPG server.\nReason: Scp 중도 퇴장");
                Log.Info($"{ev.Player.Role}({ev.Player.Nickname})가 게임을 중도퇴장했습니다. ({ev.Player})");
            }
            else
            {
                string message = Plugin.Instance.Config.LeftMessage.Replace("{player}", ev.Player.Nickname);
                Map.Broadcast(2, $"<size=30>{ev.Player.Nickname}({ev.Player.Team} {ev.Player})님이 게임을 포기했습니다.</size>");
                Log.Info($"{ev.Player}({ev.Player.Nickname} {ev.Player.Team})님이 게임을 포기했습니다.");
            }
            //ev.Player.Ban(10, "Scp중도 퇴장.");
        }

        public void OnJoined(JoinedEventArgs ev)
        {
            string message = Plugin.Instance.Config.JoinedMessage.Replace("{player}", ev.Player.Nickname);
            Map.Broadcast(2, $"<size=30><color=blue>{ev.Player.Nickname}({ev.Player})</color> 님이 게임에 입장했습니다!</size>");
            ev.Player.ShowHint($"<color=green>환영합니다! {ev.Player.Nickname}님!</color>\n*https://discord.gg/7dErEw7*로 들어와서 규칙확인해주세요!", 10);
            Log.Info($"{ev.Player}({ev.Player.Nickname})님이 서버에 접속했습니다.");
        }

        public void OnDead(DiedEventArgs ev)
        {
            if (ev.Target.IsCuffed)
            {
                Map.Broadcast(5, $"<size=50>{ev.Target.Nickname}({ev.Target})님이 <color=red>체포킬</color>을 당했습니다.\n<color=red>사살자 프로필</color> : {ev.Killer.Nickname}({ev.Killer})</size>");
            }
            //if(ev.Killer.Role == RoleType.~~)
            if (ev.Killer.Role == RoleType.ClassD)
            {
                ev.Target.ShowHint($"당신은 <color=red>사망</color>했습니다.\n사살자 : {ev.Killer.Nickname}({ev.Killer.UserId}) 사살자 정보 : <color=orange>Class D personnel</color>\n체포 여부 : {ev.Target.IsCuffed}", 10);
            }
            else if (ev.Killer.Role == RoleType.ChaosInsurgency)
            {
                ev.Target.ShowHint($"당신은 <color=red>사망</color>했습니다.\n사살자 : {ev.Killer.Nickname}({ev.Killer.UserId}) 사살자 정보 : <color=green>Chaos Insurgency</color>\n체포 여부 : {ev.Target.IsCuffed}", 10);
            }
            else if (ev.Killer.Role == RoleType.NtfCadet)
            {
                ev.Target.ShowHint($"당신은 <color=red>사망</color>했습니다.\n사살자 : {ev.Killer.Nickname}({ev.Killer.UserId}) 사살자 정보 : <color=blue>MTF 사관생도</color>\n체포 여부 : {ev.Target.IsCuffed}", 10);
            }
            else if (ev.Killer.Role == RoleType.NtfCommander)
            {
                ev.Target.ShowHint($"당신은 <color=red>사망</color>했습니다.\n사살자 : {ev.Killer.Nickname}({ev.Killer.UserId}) 사살자 정보 : <color=blue>MTF 지휘관</color>\n체포 여부 : {ev.Target.IsCuffed}", 10);
            }
            else if (ev.Killer.Role == RoleType.NtfLieutenant)
            {
                ev.Target.ShowHint($"당신은 <color=red>사망</color>했습니다.\n사살자 : {ev.Killer.Nickname}({ev.Killer.UserId}) 사살자 정보 : <color=blue>MTF 부사령관</color>\n체포 여부 : {ev.Target.IsCuffed}", 10);
            }
            else if (ev.Killer.Role == RoleType.NtfScientist)
            {
                ev.Target.ShowHint($"당신은 <color=red>사망</color>했습니다.\n사살자 : {ev.Killer.Nickname}({ev.Killer.UserId}) 사살자 정보 : <color=blue>MTF 과학자</color>\n체포 여부 : {ev.Target.IsCuffed}", 10);
            }
            else if (ev.Killer.Role == RoleType.Spectator)
            {
                ev.Target.ShowHint($"당신은 <color=red>사망</color>했습니다.\n사살자 : {ev.Killer.Nickname}({ev.Killer.UserId}) 사살자 정보 : <color=white>관전자</color>\n체포 여부 : {ev.Target.IsCuffed}", 10);
            }
            else if (ev.Killer.Role == RoleType.Scp049)
            {
                ev.Target.ShowHint($"당신은 <color=red>사망</color>했습니다.\n사살자 : {ev.Killer.Nickname}({ev.Killer.UserId}) 사살자 정보 : <color=red>SCP-049</color>\n체포 여부 : {ev.Target.IsCuffed}", 10);
            }
            else if (ev.Killer.Role == RoleType.Scp0492)
            {
                ev.Target.ShowHint($"당신은 <color=red>사망</color>했습니다.\n사살자 : {ev.Killer.Nickname}({ev.Killer.UserId}) 사살자 정보 : <color=red>SCP-049-2</color>\n체포 여부 : {ev.Target.IsCuffed}", 10);
            }
            else if (ev.Killer.Role == RoleType.Scp079)
            {
                ev.Target.ShowHint($"당신은 <color=red>사망</color>했습니다.\n사살자 : {ev.Killer.Nickname}({ev.Killer.UserId}) 사살자 정보 : <color=red>SCP-079</color>\n체포 여부 : {ev.Target.IsCuffed}", 10);
            }
            else if (ev.Killer.Role == RoleType.Scp096)
            {
                ev.Target.ShowHint($"당신은 <color=red>사망</color>했습니다.\n사살자 : {ev.Killer.Nickname}({ev.Killer.UserId}) 사살자 정보 : <color=red>SCP-096</color>\n체포 여부 : {ev.Target.IsCuffed}", 10);
            }
            else if (ev.Killer.Role == RoleType.Scp106)
            {
                ev.Target.ShowHint($"당신은 <color=red>사망</color>했습니다.\n사살자 : {ev.Killer.Nickname}({ev.Killer.UserId}) 사살자 정보 : <color=red>SCP-106</color>\n체포 여부 : {ev.Target.IsCuffed}", 10);
            }
            else if (ev.Killer.Role == RoleType.Scp173)
            {
                ev.Target.ShowHint($"당신은 <color=red>사망</color>했습니다.\n사살자 : {ev.Killer.Nickname}({ev.Killer.UserId}) 사살자 정보 : <color=red>SCP-173</color>\n체포 여부 : {ev.Target.IsCuffed}", 10);
            }
            else if (ev.Killer.Role == RoleType.Scp93953)
            {
                ev.Target.ShowHint($"당신은 <color=red>사망</color>했습니다.\n사살자 : {ev.Killer.Nickname}({ev.Killer.UserId}) 사살자 정보 : <color=red>SCP-939-53</color>\n체포 여부 : {ev.Target.IsCuffed}", 10);
            }
            else if (ev.Killer.Role == RoleType.Scp93989)
            {
                ev.Target.ShowHint($"당신은 <color=red>사망</color>했습니다.\n사살자 : {ev.Killer.Nickname}({ev.Killer.UserId}) 사살자 정보 : <color=red>SCP-939-89</color>\n체포 여부 : {ev.Target.IsCuffed}", 10);
            }
            else
            {
                Log.Info("Unknow Target RoleType");
            }
            ev.Killer.ShowHint($"<size=30>당신은 {ev.Target.Team}인 {ev.Target.Nickname}을 죽였습니다.</size>", 10);
            Log.Info($"Player Dead. Killer : {ev.Killer}({ev.Killer.Nickname}) {ev.Killer.Team}, Dead : {ev.Target.Nickname}({ev.Target}) {ev.Target.Team} (IsCuffed : {ev.Target.IsCuffed})");
        }

        public void OnReloadingWeapon(ReloadingWeaponEventArgs ev)
        {
            ev.Player.ShowHint($"당신은 지금 <color=gray>총</color>을 <color=red>장전</color>하고 있습니다.", 3);
            Log.Info($"{ev.Player.Nickname}({ev.Player}, {ev.Player.Team}) is reloading weapon.");
        }

        public void OnScpcontain(DiedEventArgs ev)
        {
            var targetrole = ev.Target.ReferenceHub.characterClassManager._prevId;
            var killerrole = ev.Killer.ReferenceHub.characterClassManager._prevId;
            string targetname = CharacterClassManager._staticClasses.Get(targetrole).fullName;
            string rolename = CharacterClassManager._staticClasses.Get(killerrole).fullName;
            string unitname = ev.Killer.ReferenceHub.characterClassManager.CurUnitName;
            Log.Info($"SCP Contained successfully.");
            if (ev.Target.Role == RoleType.Scp049)
            {
                if (ev.Killer.Role == RoleType.ChaosInsurgency)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-049</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=green>Chaos Insurgency</color></size>");
                }
                else if (ev.Killer.Role == RoleType.ClassD)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-049</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=orange>Class D personnel</color></size>");
                }
                else if (ev.Killer.Role == RoleType.FacilityGuard)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-049</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=gray>시설 경비</color></size>");
                }
                else if (ev.Killer.Role == RoleType.None)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-049</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=white>Unknow</color></size>");
                }
                else if (ev.Killer.Role == RoleType.NtfCadet)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-049</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=#00D8FF>MTF 사관생도({unitname})</color></size>");
                }
                else if (ev.Killer.Role == RoleType.NtfCommander)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-049</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=#050099>MTF 지휘관({unitname})</color></size>");
                }
                else if (ev.Killer.Role == RoleType.NtfLieutenant)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-049</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=#4374D9>MTF 부사령관({unitname})</color></size>");
                }
                else if (ev.Killer.Role == RoleType.NtfScientist)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-049</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=#4374D9>MTF 과학자({unitname})</color></size>");
                }
                else if (ev.Killer.Role == RoleType.Scientist)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-049</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=yellow>Scientist</color></size>");
                }
                else if (ev.Killer.Role == RoleType.Spectator)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-049</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=white>관전자</color></size>");
                }
                else if (ev.Killer.Role == RoleType.Tutorial)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-049</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=cyan>튜토리얼</color></size>");
                }
                else
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-049</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=white>Unknow</color></size>");
                }
            }
            if (ev.Target.Role == RoleType.Scp096)
            {
                if (ev.Killer.Role == RoleType.ChaosInsurgency)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-096</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=green>Chaos Insurgency</color></size>");
                }
                else if (ev.Killer.Role == RoleType.ClassD)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-096</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=orange>Class D personnel</color></size>");
                }
                else if (ev.Killer.Role == RoleType.FacilityGuard)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-096</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=gray>시설 경비</color></size>");
                }
                else if (ev.Killer.Role == RoleType.None)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-096</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=white>Unknow</color></size>");
                }
                else if (ev.Killer.Role == RoleType.NtfCadet)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-096</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=#00D8FF>MTF 사관생도({unitname})</color></size>");
                }
                else if (ev.Killer.Role == RoleType.NtfCommander)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-096</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=#050099>MTF 지휘관({unitname})</color></size>");
                }
                else if (ev.Killer.Role == RoleType.NtfLieutenant)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-096</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=#4374D9>MTF 부사령관({unitname})</color></size>");
                }
                else if (ev.Killer.Role == RoleType.NtfScientist)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-096</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=#4374D9>MTF 과학자({unitname})</color></size>");
                }
                else if (ev.Killer.Role == RoleType.Scientist)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-096</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=yellow>Scientist</color></size>");
                }
                else if (ev.Killer.Role == RoleType.Spectator)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-096</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=white>관전자</color></size>");
                }
                else if (ev.Killer.Role == RoleType.Tutorial)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-096</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=cyan>튜토리얼</color></size>");
                }
                else
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-096</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=white>Unknow</color></size>");
                }
            }
            if (ev.Target.Role == RoleType.Scp106)
            {
                if (ev.Killer.Role == RoleType.ChaosInsurgency)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-106</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=green>Chaos Insurgency</color></size>");
                }
                else if (ev.Killer.Role == RoleType.ClassD)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-106</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=orange>Class D personnel</color></size>");
                }
                else if (ev.Killer.Role == RoleType.FacilityGuard)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-106</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=gray>시설 경비</color></size>");
                }
                else if (ev.Killer.Role == RoleType.None)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-106</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=white>Unknow</color></size>");
                }
                else if (ev.Killer.Role == RoleType.NtfCadet)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-106</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=#00D8FF>MTF 사관생도({unitname})</color></size>");
                }
                else if (ev.Killer.Role == RoleType.NtfCommander)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-106</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=#050099>MTF 지휘관({unitname})</color></size>");
                }
                else if (ev.Killer.Role == RoleType.NtfLieutenant)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-106</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=#4374D9>MTF 부사령관({unitname})</color></size>");
                }
                else if (ev.Killer.Role == RoleType.NtfScientist)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-106</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=#4374D9>MTF 과학자({unitname})</color></size>");
                }
                else if (ev.Killer.Role == RoleType.Scientist)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-106</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=yellow>Scientist</color></size>");
                }
                else if (ev.Killer.Role == RoleType.Spectator)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-106</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=white>관전자</color></size>");
                }
                else if (ev.Killer.Role == RoleType.Tutorial)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-106</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=cyan>튜토리얼</color></size>");
                }
                else
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-106</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=white>Unknow</color></size>");
                }
            }
            if (ev.Target.Role == RoleType.Scp173)
            {
                if (ev.Killer.Role == RoleType.ChaosInsurgency)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-173</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=green>Chaos Insurgency</color></size>");
                }
                else if (ev.Killer.Role == RoleType.ClassD)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-173</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=orange>Class D personnel</color></size>");
                }
                else if (ev.Killer.Role == RoleType.FacilityGuard)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-173</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=gray>시설 경비</color></size>");
                }
                else if (ev.Killer.Role == RoleType.None)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-173</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=white>Unknow</color></size>");
                }
                else if (ev.Killer.Role == RoleType.NtfCadet)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-173</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=#00D8FF>MTF 사관생도({unitname})</color></size>");
                }
                else if (ev.Killer.Role == RoleType.NtfCommander)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-173</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=#050099>MTF 지휘관({unitname})</color></size>");
                }
                else if (ev.Killer.Role == RoleType.NtfLieutenant)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-173</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=#4374D9>MTF 부사령관({unitname})</color></size>");
                }
                else if (ev.Killer.Role == RoleType.NtfScientist)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-173</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=#4374D9>MTF 과학자({unitname})</color></size>");
                }
                else if (ev.Killer.Role == RoleType.Scientist)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-173</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=yellow>Scientist</color></size>");
                }
                else if (ev.Killer.Role == RoleType.Spectator)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-173</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=white>관전자</color></size>");
                }
                else if (ev.Killer.Role == RoleType.Tutorial)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-173</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=cyan>튜토리얼</color></size>");
                }
                else
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-173</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=white>Unknow</color></size>");
                }
            }
            if (ev.Target.Role == RoleType.Scp106)
            {
                if (ev.Killer.Role == RoleType.ChaosInsurgency)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-106</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=green>Chaos Insurgency</color></size>");
                }
                else if (ev.Killer.Role == RoleType.ClassD)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-106</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=orange>Class D personnel</color></size>");
                }
                else if (ev.Killer.Role == RoleType.FacilityGuard)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-106</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=gray>시설 경비</color></size>");
                }
                else if (ev.Killer.Role == RoleType.None)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-106</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=white>Unknow</color></size>");
                }
                else if (ev.Killer.Role == RoleType.NtfCadet)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-106</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=#00D8FF>MTF 사관생도({unitname})</color></size>");
                }
                else if (ev.Killer.Role == RoleType.NtfCommander)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-106</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=#050099>MTF 지휘관({unitname})</color></size>");
                }
                else if (ev.Killer.Role == RoleType.NtfLieutenant)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-106</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=#4374D9>MTF 부사령관({unitname})</color></size>");
                }
                else if (ev.Killer.Role == RoleType.NtfScientist)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-106</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=#4374D9>MTF 과학자({unitname})</color></size>");
                }
                else if (ev.Killer.Role == RoleType.Scientist)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-106</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=yellow>Scientist</color></size>");
                }
                else if (ev.Killer.Role == RoleType.Spectator)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-106</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=white>관전자</color></size>");
                }
                else if (ev.Killer.Role == RoleType.Tutorial)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-106</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=cyan>튜토리얼</color></size>");
                }
                else
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-106</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=white>Unknow</color></size>");
                }
            }
            if (ev.Target.Role == RoleType.Scp93953)
            {
                if (ev.Killer.Role == RoleType.ChaosInsurgency)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-939-53</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=green>Chaos Insurgency</color></size>");
                }
                else if (ev.Killer.Role == RoleType.ClassD)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-939-53</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=orange>Class D personnel</color></size>");
                }
                else if (ev.Killer.Role == RoleType.FacilityGuard)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-939-53</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=gray>시설 경비</color></size>");
                }
                else if (ev.Killer.Role == RoleType.None)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-939-53</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=white>Unknow</color></size>");
                }
                else if (ev.Killer.Role == RoleType.NtfCadet)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-939-53</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=#00D8FF>MTF 사관생도({unitname})</color></size>");
                }
                else if (ev.Killer.Role == RoleType.NtfCommander)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-939-53</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=#050099>MTF 지휘관({unitname})</color></size>");
                }
                else if (ev.Killer.Role == RoleType.NtfLieutenant)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-939-53</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=#4374D9>MTF 부사령관({unitname})</color></size>");
                }
                else if (ev.Killer.Role == RoleType.NtfScientist)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-939-53</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=#4374D9>MTF 과학자({unitname})</color></size>");
                }
                else if (ev.Killer.Role == RoleType.Scientist)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-939-53</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=yellow>Scientist</color></size>");
                }
                else if (ev.Killer.Role == RoleType.Spectator)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-939-53</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=white>관전자</color></size>");
                }
                else if (ev.Killer.Role == RoleType.Tutorial)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-939-53</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=cyan>튜토리얼</color></size>");
                }
                else
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-939-53</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=white>Unknow</color></size>");
                }
            }
            if (ev.Target.Role == RoleType.Scp93989)
            {
                if (ev.Killer.Role == RoleType.ChaosInsurgency)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-939-89</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=green>Chaos Insurgency</color></size>");
                }
                else if (ev.Killer.Role == RoleType.ClassD)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-939-89</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=orange>Class D personnel</color></size>");
                }
                else if (ev.Killer.Role == RoleType.FacilityGuard)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-939-89</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=gray>시설 경비</color></size>");
                }
                else if (ev.Killer.Role == RoleType.None)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-939-89</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=white>Unknow</color></size>");
                }
                else if (ev.Killer.Role == RoleType.NtfCadet)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-939-89</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=#00D8FF>MTF 사관생도({unitname})</color></size>");
                }
                else if (ev.Killer.Role == RoleType.NtfCommander)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-939-89</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=#050099>MTF 지휘관({unitname})</color></size>");
                }
                else if (ev.Killer.Role == RoleType.NtfLieutenant)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-939-89</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=#4374D9>MTF 부사령관({unitname})</color></size>");
                }
                else if (ev.Killer.Role == RoleType.NtfScientist)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-939-89</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=#4374D9>MTF 과학자({unitname})</color></size>");
                }
                else if (ev.Killer.Role == RoleType.Scientist)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-939-89</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=yellow>Scientist</color></size>");
                }
                else if (ev.Killer.Role == RoleType.Spectator)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-939-89</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=white>관전자</color></size>");
                }
                else if (ev.Killer.Role == RoleType.Tutorial)
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-939-89</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=cyan>튜토리얼</color></size>");
                }
                else
                {
                    Map.Broadcast(10, $"<size=50><color=#DF4D4D>SCP-939-89</color>(이)가 <color=#2478FF>성공적</color>으로 <color=#DF4D4D>격리</color>되었습니다.\n격리 원인 : <color=white>Unknow</color></size>");
                }
            }
        }

        public void OnSpawn(SpawningEventArgs ev)
        {
            var targetrole = ev.Player.ReferenceHub.characterClassManager._prevId;
            string unitname = CharacterClassManager._staticClasses.Get(targetrole).fullName;
            string unitnumber = ev.Player.ReferenceHub.characterClassManager.CurUnitName;
            if (ev.Player.Role == RoleType.ClassD)
            {
                ev.Player.Broadcast(5, $"<size=40>당신은 <color=orange>Class D personnel</color> 으로 스폰했습니다.</size>");
                Timing.WaitForSeconds(1f);
                ev.Player.Broadcast(5, $"<size=40>당신의 <color=#DF4D4D>HP</color> : <color=#2478FF>{ev.Player.Health}</color></size>");
            }
            else if (ev.Player.Role == RoleType.Scientist)
            {
                ev.Player.Broadcast(5, $"<size=40>당신은 <color=yellow>과학자</color> 으로 스폰했습니다.</size>");
                Timing.WaitForSeconds(1f);
                ev.Player.Broadcast(5, $"<size=40>당신의 <color=#DF4D4D>HP</color> : <color=#2478FF>{ev.Player.Health}</color></size>");
            }
            else if (ev.Player.Role == RoleType.Scp049)
            {
                ev.Player.Broadcast(5, $"<size=40>당신은 <color=#DF4D4D>SCP-049</color> 으로 스폰했습니다.</size>");
                Timing.WaitForSeconds(1f);
                ev.Player.Broadcast(5, $"<size=40>당신의 <color=#DF4D4D>HP</color> : <color=#2478FF>{ev.Player.Health}</color></size>");
            }
            else if (ev.Player.Role == RoleType.Scp0492)
            {
                ev.Player.Broadcast(5, $"<size=40>당신은 <color=#DF4D4D>SCP-049-2</color> 으로 스폰했습니다.</size>");
                Timing.WaitForSeconds(1f);
                ev.Player.Broadcast(5, $"<size=40>당신의 <color=#DF4D4D>HP</color> : <color=#2478FF>{ev.Player.Health}</color></size>");
            }
            else if (ev.Player.Role == RoleType.Scp079)
            {
                ev.Player.Broadcast(5, $"<size=40>당신은 <color=#DF4D4D>SCP-079</color> 으로 스폰했습니다.</size>");
                Timing.WaitForSeconds(1f);
                ev.Player.Broadcast(5, $"<size=40>당신의 <color=#DF4D4D>HP</color> : <color=#2478FF>{ev.Player.Health}</color></size>");
            }
            else if (ev.Player.Role == RoleType.Scp096)
            {
                ev.Player.Broadcast(5, $"<size=40>당신은 <color=#DF4D4D>SCP-096</color> 으로 스폰했습니다.</size>");
                Timing.WaitForSeconds(1f);
                ev.Player.Broadcast(5, $"<size=40>당신의 <color=#DF4D4D>HP</color> : <color=#2478FF>{ev.Player.Health}</color></size>");
            }
            else if (ev.Player.Role == RoleType.Scp106)
            {
                ev.Player.Broadcast(5, $"<size=40>당신은 <color=#DF4D4D>SCP-106</color> 으로 스폰했습니다.</size>");
                Timing.WaitForSeconds(1f);
                ev.Player.Broadcast(5, $"<size=40>당신의 <color=#DF4D4D>HP</color> : <color=#2478FF>{ev.Player.Health}</color></size>");
            }
            else if (ev.Player.Role == RoleType.Scp173)
            {
                ev.Player.Broadcast(5, $"<size=40>당신은 <color=#DF4D4D>SCP-173</color> 으로 스폰했습니다.</size>");
                Timing.WaitForSeconds(1f);
                ev.Player.Broadcast(5, $"<size=40>당신의 <color=#DF4D4D>HP</color> : <color=#2478FF>{ev.Player.Health}</color></size>");
            }
            else if (ev.Player.Role == RoleType.Scp93953)
            {
                ev.Player.Scale = new Vector3(0.75f, 0.75f, 0.75f);
                ev.Player.Broadcast(5, $"<size=40>당신은 <color=#DF4D4D>SCP-939-53</color> 으로 스폰했습니다.</size>");
                Timing.WaitForSeconds(1f);
                ev.Player.Broadcast(5, $"<size=40>당신의 <color=#DF4D4D>HP</color> : <color=#2478FF>{ev.Player.Health}</color></size>");
            }
            else if (ev.Player.Role == RoleType.Scp93989)
            {
                ev.Player.Scale = new Vector3(0.85f, 0.85f, 0.85f);
                ev.Player.Broadcast(5, $"<size=40>당신은 <color=#DF4D4D>SCP-939-89</color> 으로 스폰했습니다.</size>");
                Timing.WaitForSeconds(1f);
                ev.Player.Broadcast(5, $"<size=40>당신의 <color=#DF4D4D>HP</color> : <color=#2478FF>{ev.Player.Health}</color></size>");
            }
            else if (ev.Player.Role == RoleType.FacilityGuard)
            {
                ev.Player.SetAmmo(AmmoType.Nato762, 200);
                //ev.Player.AddItem(ItemType.Item);
                //ev.Player.RemoveItem();
                ev.Player.Broadcast(5, $"<size=40>당신은 <color=gray>시설 가드</color> 으로 스폰했습니다.</size>");
                Timing.WaitForSeconds(1f);
                ev.Player.Broadcast(5, $"<size=40>당신의 <color=#DF4D4D>HP</color> : <color=#2478FF>{ev.Player.Health}</color></size>");
            }
            else if (ev.Player.Role == RoleType.NtfCadet)
            {
                ev.Player.SetAmmo(AmmoType.Nato9, 200);
                ev.Player.Broadcast(5, $"<size=40>당신은 <color=blue>MTF 사관생도({unitname}-{unitnumber})</color> 으로 스폰했습니다.</size>");
                Timing.WaitForSeconds(1f);
                ev.Player.Broadcast(5, $"<size=40>당신의 <color=#DF4D4D>HP</color> : <color=#2478FF>{ev.Player.Health}</color></size>");
            }
            else if (ev.Player.Role == RoleType.NtfCommander)
            {
                ev.Player.SetAmmo(AmmoType.Nato556, 200);
                ev.Player.AddItem(ItemType.Medkit);
                ev.Player.Broadcast(5, $"<size=40>당신은 <color=blue>MTF 지휘관({unitname}-{unitnumber})</color> 으로 스폰했습니다.</size>");
                Timing.WaitForSeconds(1f);
                ev.Player.Broadcast(5, $"<size=40>당신의 <color=#DF4D4D>HP</color> : <color=#2478FF>{ev.Player.Health}</color></size>");
            }
            else if (ev.Player.Role == RoleType.NtfLieutenant)
            {
                ev.Player.SetAmmo(AmmoType.Nato556, 200);
                ev.Player.Broadcast(5, $"<size=40>당신은 <color=blue>MTF 부사령관({unitname}-{unitnumber})</color> 으로 스폰했습니다.</size>");
                Timing.WaitForSeconds(1f);
                ev.Player.Broadcast(5, $"<size=40>당신의 <color=#DF4D4D>HP</color> : <color=#2478FF>{ev.Player.Health}</color></size>");
            }
            else if (ev.Player.Role == RoleType.NtfScientist)
            {
                ev.Player.SetAmmo(AmmoType.Nato556, 200);
                ev.Player.Broadcast(5, $"<size=40>당신은 <color=blue>MTF 과학자({unitname}-{unitnumber})</color> 으로 스폰했습니다.</size>");
                Timing.WaitForSeconds(1f);
                ev.Player.Broadcast(5, $"<size=40>당신의 <color=#DF4D4D>HP</color> : <color=#2478FF>{ev.Player.Health}</color></size>");
            }
            else if (ev.Player.Role == RoleType.ChaosInsurgency)
            {
                ev.Player.SetAmmo(AmmoType.Nato762, 500);
                ev.Player.Broadcast(5, $"<size=40>당신은 <color=green>Chaos Insurgency</color> 으로 스폰했습니다.</size>");
                Timing.WaitForSeconds(1f);
                ev.Player.Broadcast(5, $"<size=40>당신의 <color=#DF4D4D>HP</color> : <color=#2478FF>{ev.Player.Health}</color></size>");
            }
            else
            {
                Log.Info("Unknow Spawn");
            }
        }
        
        public void OnFemurbreakerentered(EnteringFemurBreakerEventArgs ev)
        {
            Map.Broadcast(5, $"<size=50>{ev.Player.Nickname}(이)가 <color=#DF4D4D>FemurBreaker</color>에 입장했습니다.</size>");
            ev.Player.ClearBroadcasts();
            ev.Player.Broadcast(5, $"<size=70>당신은 <color=#DF4D4D>FemurBreaker</color>에 입장했습니다.</size>");
            Log.Info($"{ev.Player} has entered femurbreaker");
        }

        public void OnDoorOpening(InteractingDoorEventArgs ev)
        {
            if (ev.Door.lockdown)
            {
                ev.Player.ShowHint("<color=lime>당신은</color> <color=red>잠긴</color> 문을 열려고 <color=red>시도</color>했습니다.", 2);
            }
            if (ev.Door.doorType == Door.DoorTypes.Checkpoint)
            {
                ev.Player.ShowHint("당신은 <color=red>CheckPoint</color> 문을 <color=red>오픈</color>을 시도했습니다.", 2);
            }
        }

        public void OnAnnouncingDecont(AnnouncingDecontaminationEventArgs ev)
        {
            switch (ev.Id)
            {
                case 0:
                    {
                        Map.Broadcast(15, $"<size=50><color=yellow>저위험군</color>의 <color=lime>모든 인원</color>에게 <color=red>알립</color>니다.\n<color=yellow>저위험군</color> <color=red>유기물질 제거</color> 절차가 <color=green>15분후</color>에 이루어집니다.\n<color=red>긴급히 대피</color>하여 주시기 바랍니다.</size>");
                        break;
                    }
                case 1:
                    {
                        Map.Broadcast(15, $"<size=50><color=yellow>저위험군</color> <color=red>폐쇄절차</color>(이)가 <color=red>10분뒤</color>에 이루어 집니다.</size>");
                        break;
                    }
                case 2:
                    {
                        Map.Broadcast(15, $"<size=50><color=yellow>저위험군</color> <color=red>폐쇄절차</color>(이)가 <color=red>5분뒤</color>에 이루어 집니다.</size>");
                        break;
                    }
                case 3:
                    {
                        Map.Broadcast(15, $"<size=50><color=yellow>저위험군</color> <color=red>폐쇄절차</color>(이)가 <color=red>1분뒤</color>에 이루어 집니다.</size>");
                        break;
                    }
                case 4:
                    {
                        Map.Broadcast(15, $"<size=50><color=yellow>저위험군</color> <color=red>폐쇄절차</color>(이)가 <color=red>30초뒤</color>에 이루어 집니다.\n<color=green>저위험군의 모든 검문소(이)가 열렸습니다.</color></size>");
                        break;
                    }
            }
        }

        public void OnDeont(DecontaminatingEventArgs ev)
        {
            Map.Broadcast(15, "<size=50><color=yellow>저위험군</color> <color=red>폐쇄절차</color>(이)가 시작 되었습니다.\n<color=yellow>모든 유기물</color>의 제거가 <color=red>시작됩니다.</color></size>", Broadcast.BroadcastFlags.Normal);
        }

        public void OnEscape(EscapingEventArgs ev)
        {
            if (ev.Player.IsCuffed)
            {
                if (ev.Player.Team == Team.CDP)
                {
                    ev.Player.ShowHint("<size=30>당신은 <color=#DF4D4D>체포</color>된 상태로 탈출해서 \n<color=blue>MTF</color>으로 탈출했습니다.</size>", 10);
                    ev.Player.Broadcast(5, $"<size=30>당신은 <color=#DF4D4D>체포</color>된 상태로 탈출해서 \n<color=blue>MTF</color>으로 탈출했습니다.</size>");
                    Log.Info($"{ev.Player.Nickname}({ev.Player}) has escape(Cuffed)");
                }
                if (ev.Player.Team == Team.RSC)
                {
                    ev.Player.ShowHint($"<size=30>당신은 <color=#DF4D4D>체포</color>된 상태로 탈출해서 \n<color=green>Chaos insurgency</color>으로 탈출했습니다.</size>", 10);
                    ev.Player.Broadcast(5, $"<size=30>당신은 <color=#DF4D4D>체포</color>된 상태로 탈출해서 \n<color=green>Chaos insurgency</color>으로 탈출했습니다.</size>");
                    Log.Info($"{ev.Player.Nickname}({ev.Player}) has escape(Cuffed)");
                }
            }
            else
            {
                if (ev.Player.Team == Team.CDP)
                {
                    ev.Player.ShowHint($"<size=30>당신은 <color=blue>체포가 되지 않은상태</color>로 탈출해서\n<color=green>Chaos insurgency</color>으로 탈출했습니다.</size>", 10);
                    ev.Player.Broadcast(5, $"<size=30>당신은 <color=blue>체포가 되지 않은상태</color>로 탈출해서\n<color=green>Chaos insurgency</color>으로 탈출했습니다.</size>");
                    Log.Info($"{ev.Player.Nickname}({ev.Player}) has escape(Not Cuffed)");
                }
                if (ev.Player.Team == Team.RSC)
                {
                    ev.Player.ShowHint($"<size=30>당신은 <color=blue>체포가 되지 않은상태</color>로 탈출해서\n<colore=blue>MTF</color>으로 탈출했습니다.</size>", 10);
                    ev.Player.Broadcast(5, $"<size=30>당신은 <color=blue>체포가 되지 않은상태</color>로 탈출해서\n<colore=blue>MTF</color>으로 탈출했습니다.</size>");
                    Log.Info($"{ev.Player.Nickname}({ev.Player}) has escape(Not Cuffed)");
                }
            }
        }

        public void OnPocketentered(EnteringPocketDimensionEventArgs ev)
        {
            ev.Player.ShowHint($"<size=50>당신은 <color=#DF4D4D>SCP-106</color>에게 잡혀\n주머니 차원에 갇혔습니다!</size>\n<size=30>사람이 탈출하지 않은 이상 사람 시체가 없는곳으로 가세요!</size>", 10);
            Log.Info($"{ev.Player} has entered Pocket");
            ev.Player.Broadcast(5, $"<size=50>당신은 <color=#DF4D4D>SCP-106</color>에게 잡혀\n주머니 차원에 갇혔습니다!</size>\n<size=30>사람이 탈출하지 않은 이상 사람 시체가 없는곳으로 가세요!</size>");
        }

        public void OnPocketescape(EscapingPocketDimensionEventArgs ev)
        {
            Log.Info($"{ev.Player} has Pocket Escape");
            ev.Player.Broadcast(5, $"<size=50>당신은 <color=#DF4D4D>주머니차원</color>을 탈출했습니다!</size>");
            ev.Player.ShowHint($"<size=50>당신은 <color=#DF4D4D>주머니차원</color>을 탈출했습니다!</size>", 10);
        }

        public void OnPocketDead(FailingEscapePocketDimensionEventArgs ev)
        {
            ev.Player.Broadcast(5, $"<size=50>당신은 <color=#DF4D4D>주머니차원</color>에서 부패되었습니다.</size>");
            Log.Info($"{ev.Player} has Pocket in Die");
            ev.Player.RemoteAdminMessage("테스트용 메시지.");
            ev.Player.ShowHint($"<size=50>당신은 <color=#DF4D4D>주머니차원</color>에서 부패되었습니다.</size>", 10);
        }

        public void OnIntercom(IntercomSpeakingEventArgs ev)
        {
            Log.Info($"{ev.Player} has Starting Speak in the intercom");
            Map.Broadcast(1, $"<size=50><color=#2478FF>{ev.Player.Nickname}</color>님이 <color=#2478FF>방송</color>을 시작했습니다.</size>");
            ev.Player.ClearBroadcasts();
            ev.Player.Broadcast(1, $"<size=50>당신은 <color=#2478FF>방송</color>을 <color=#DF4D4D>시작</color>했습니다.\n<color=#DF4D4D>쓸때 없는</color><color=#2478FF>방송</color>은 제대대상 입니다.</size>");
        }
        public void OnNtfbackup(AnnouncingNtfEntranceEventArgs ev)
        {
            Log.Info($"기동특무부대 {ev.UnitName}-{ev.UnitNumber}가 시설에 진입 {ev.ScpsLeft}의 개체가 남음.");
            if (ev.ScpsLeft >= 1)
            {
                Map.Broadcast(15, $"<size=50><color=#2478FF>기동특무부대</color> Epsilon-11소속 <color=#2478FF>{ev.UnitName}-{ev.UnitNumber}</color>(이)가 시설에 진입했습니다.\n현재 <color=#DF4D4D>격리</color>를 기다리는 <color=#DF4D4D>개체수</color> : {ev.ScpsLeft}</size>");
            }
            else
            {
                Map.Broadcast(15, $"<size=50><color=#2478FF>기동특무부대</color> Epsilon-11소속 <color=#2478FF>{ev.UnitName}-{ev.UnitNumber}</color>(이)가 시설에 진입했습니다.\n현재 <color=#DF4D4D>격리</color>가 필요한 개체가 없습니다.</size>");
            }
        }

        public void OnDroppingItem(DroppingItemEventArgs ev)
        {
            if (ev.Item.id == ItemType.KeycardO5)
            {
                ev.Player.ShowHint($"<size=50><color=#DF4D4D>주의!</color>\n당신은 <color=black>O5 Keycard</color>를 버렸습니다.</size>", 10);
                Log.Info($"{ev.Player.Nickname}({ev.Player.Team}, {ev.Player.UserId}) has dropping item : {ev.Item}");
                ev.Player.Broadcast(5, $"<size=50><color=#DF4D4D>주의!</color>\n당신은 <color=black>O5 Keycard</color>를 버렸습니다.</size>");
            }
            else if (ev.Item.id == ItemType.KeycardFacilityManager)
            {
                ev.Player.ShowHint($"<size=50><color=#DF4D4D>주의!</color>\n당신은 <color=#DF4D4D>Facility Manager Keycard</color>를 버렸습니다.</size>", 10);
                Log.Info($"{ev.Player.Nickname}({ev.Player.Team}, {ev.Player.UserId}) has dropping item : {ev.Item}");
                ev.Player.Broadcast(5, $"<size=50><color=#DF4D4D>주의!</color>\n당신은 <color=#DF4D4D>Facility Manager Keycard</color>를 버렸습니다.</size>");
            }
            else if (ev.Item.id == ItemType.KeycardContainmentEngineer)
            {
                ev.Player.ShowHint($"<size=50><color=#DF4D4D>주의!</color>\n당신은 <color=pink>Containment Engineer Keycard</color>를 버렸습니다.</size>", 10);
                Log.Info($"{ev.Player.Nickname}({ev.Player.Team}, {ev.Player.UserId}) has dropping item : {ev.Item}");
                ev.Player.Broadcast(5, $"<size=50><color=#DF4D4D>주의!</color>\n당신은 <color=pink>Containment Engineer Keycard</color>를 버렸습니다.</size>");
            }
            else
            {
                Log.Info($"{ev.Player.Nickname}({ev.Player.Team}, {ev.Player.UserId}) has dropping item : {ev.Item}");
            }
        }

        public void OnPickingItem(PickingUpItemEventArgs ev)
        {
            if (ev.Pickup.itemId == ItemType.Radio)
            {
                ev.Player.ShowHint($"<color=yellow>당신은</color> <color=blue>무전기</color>를 주웠습니다.\n현재 저희서버는 <color=green>카오스</color>를 제외한 모든 진영이 배터리가 무제한입니다.", 5);
            }
        }

        public void OnBanning(BanningEventArgs ev)
        {
            Log.Info($"{ev.Target.Nickname}({ev.Target.UserId}) has been banned Resaon : {ev.Reason}, Unbanned : {ev.Duration}");
            Map.Broadcast(10, $"<size=40>{ev.Target.Nickname}({ev.Target.UserId})님이 <color=red>서버</color>에서 <color=red>밴</color> 되었습니다.\n사유 : <color=red>{ev.Reason}</color> <color=lime>기간 : {ev.Duration}</color></size>", Broadcast.BroadcastFlags.Normal);
        }

        public void OnKicking(KickingEventArgs ev)
        {
            Log.Info($"{ev.Target.Nickname}({ev.Target.UserId}) has been kicked Resaon : {ev.Reason}");
            Map.Broadcast(10, $"<size=40>{ev.Target.Nickname}({ev.Target.UserId})님이 <color=red>서버</color>에서 <color=red>킥</color> 되었습니다.\n사유 : <color=red>{ev.Reason}</color></size>", Broadcast.BroadcastFlags.Normal);
        }

        public void OnGenOn(GeneratorActivatedEventArgs ev)
        {
            int curgen = Generator079.mainGenerator.NetworktotalVoltage + 1;
            if (curgen < 5)
            {
                Map.Broadcast(10, $"<size=50><color=red>발전기</color> 5개중 <color=red>{curgen}개(이)가</color> 작동되었습니다.</size>");
            }
            else
            {
                Map.Broadcast(10, $"<size=50><color=red>발전기</color> 5개중 <color=red>5개(이)가</color> 작동되었습니다.</size>");
            }
        }

        public void OnTriggerTesla(TriggeringTeslaEventArgs ev)
        {
            ev.Player.SendConsoleMessage("You're trigger tesla gate.", "yellow");
            if (ev.Player.Team == Team.CDP)
            {
                Log.Info($"{ev.Player.Nickname}(Class D Personnel, {ev.Player.UserId})");
            }
            if (ev.Player.Team == Team.CHI)
            {
                Log.Info($"{ev.Player.Nickname}(Chaos Insurgency, {ev.Player.UserId})");
            }
            if (ev.Player.Team == Team.MTF)
            {
                Log.Info($"{ev.Player.Nickname}(MTF Personnel, {ev.Player.UserId})");
            }
            if (ev.Player.Team == Team.RSC)
            {
                Log.Info($"{ev.Player.Nickname}(Scientist Personnel, {ev.Player.UserId})");
            }
            if (ev.Player.Team == Team.SCP)
            {
                Log.Info($"{ev.Player.Nickname}(Class-SCP {ev.Player.Team}, {ev.Player.UserId})");
            }
        }
    }
}
