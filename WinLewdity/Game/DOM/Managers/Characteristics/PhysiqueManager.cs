using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinLewdity.Game;
using WinLewdity_GUI.Game.DOM.Managers.Bases;
using static WinLewdity_GUI.Game.Player.PlayerEnums;

namespace WinLewdity_GUI.Game.DOM.Managers.Characteristics
{
    public class PhysiqueManager : CharacteristicManager
    {
        public override int MaxTier { get; set; } = 6;
        public override int Tier
        {
            get
            {
                var ppt = this.PointsPerTier;
                var level = this.GetLevel();
                level.Wait();
                return (int)Math.Floor((double)level.Result / (double)ppt);
            }
        }
        public override async Task<int> GetMaxLevel()
        {
            BodyType body = await GameFunctions.GetBodyTypeAsync();
            switch (body)
            {
                case BodyType.Tiny:
                    return 6000;
                case BodyType.Small:
                    return 10000;
                case BodyType.Normal:
                    return 12000;
                case BodyType.Large:
                    return 16000;
                default:
                    JavascriptResponse con = await JavascriptUtils.FetchJavascriptResult(VariableReference + "max");
                    int raw = (int)con.Result;
                    return await Task.FromResult(raw);

            }
        }
        public override string VariableReference { get; set; } = "V.physique";
    }
}
