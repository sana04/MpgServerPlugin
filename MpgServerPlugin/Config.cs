using Exiled.API.Interfaces;
using System.ComponentModel;

namespace MpgServerPlugin
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        [Description("서버의 접속 설정 메시지. {player}는 플레이어 닉네임입니다.")]
        public string JoinedMessage { get; set; } = "{player}가 서버에 접속했습니다.";

        [Description("서버의 퇴장 설정 메시지. {player}는 플레이어 닉네임입니다.")]
        public string LeftMessage { get; set; } = "{player}가 서버에서 나갔습니다.";

        [Description("서버의 라운드 시작 설정 메시지.")]
        public string RoundStartedMessage { get; set; } = "<size=50><color=blue>라운드</color>가 시작되었습니다.</size>";

        //[Description("Sets a message for when someone triggers a trap.")]
        //public string BoobyTrapMessage { get; set; } = "You have activated my trap card!";
    }
}
