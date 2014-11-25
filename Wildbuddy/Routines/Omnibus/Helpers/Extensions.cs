using Buddy.Common.Math;
using Buddy.Wildstar.Game;
using Buddy.Wildstar.Game.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omnibus.Helpers
{
    public static class Extensions
    {
        public static readonly CCStateType[] CleansableCC = new CCStateType[] { CCStateType.Disorient, CCStateType.Fear, CCStateType.Stun, CCStateType.Snare, CCStateType.Root };

        #region Actor
        public static bool HasBuff(this Actor actor, string buff, int timeLeft = 0)
        {
            return actor.Buffs.Any(b => b.Name == buff && b.TimeLeft.TotalMilliseconds >= timeLeft);
        }

        public static bool HasCleansableCC(this Actor actor)
        {
            return CleansableCC.Any(c => actor.GetCCState(c).TimeRemaining > 0);  
        }

        public static bool HasCC(this Actor actor, CCStateType state)
        {
            return actor.GetCCState(state).TimeRemaining > 0; 
        }

        public static bool IsFacing(this Actor actor, Actor Target) 
        {
            return Vector4.Dot(actor.Facing, Target.Facing) > 0; 
        }

        public static IEnumerable<Actor> GetSurrounding(this Actor actor, float distance = 5f, bool enemy = true)
        {
            return GameManager.Actors.Where(s => actor.Position.Distance(s.Value.Position) <= distance).Select(s => s.Value); //TODO: Enemy flag check 
        }

        #endregion 

        #region Class

        public static bool IsOneOf<T>(this T c, params T[] input)
        {
            return input.Any(s => s.Equals(c));
        }

        #endregion


    }
}
