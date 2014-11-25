using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Buddy.Wildstar.BotCommon;
using Buddy.Wildstar.Game;
using Buddy.Wildstar.Game.Actors;

namespace Omnibus.Classes
{
	public class AbilityPriority
	{
		/// <summary>
		///     Turtle turtle turtle turtle
		/// </summary>
		private readonly List<Tuple<string,CastCondition, CastAction>> _priorityDictionary = new List<Tuple<string, CastCondition, CastAction>>();
		
		public void Add(string spellName, CastCondition condition, CastAction cast)
		{
			_priorityDictionary.Add(new Tuple<string, CastCondition, CastAction>(spellName, condition, cast));
		}

		public void Add(string spellName, CastCondition condition)
		{
			Add(spellName, condition, async cast => await SpellCastBehaviors.CastSimple(spellName, awaitCastFinished: true));
		}


		public SpellManager.SpellInformation GetHighestPriorityAbility(Actor context)
		{
			List<SpellManager.SpellInformation> ablList = ToValidAbilityList(context);
			//Omnibus.Logger.Debug("Ability List: " + ablList.Count);
			return ablList.FirstOrDefault();
		}

        /// <summary>
        ///     Returns the highest priority Tuple entry
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Tuple<SpellManager.SpellInformation, CastAction> GetHighestPriorityTuple(Actor context)
        {
            var ability = _priorityDictionary.Where(u =>
            {
                if (!u.Item2(context))
                {
                    return false;
                }

                SpellManager.SpellInformation spell = SpellManager.GetSpell(u.Item1);
                if (spell != null)
                {
                    // That's all. If we can cast it, go ahead and cast it.
                    return spell.CanCast;
                }

                return false;
            }).FirstOrDefault();

	        if (ability == null)
		        return null;

            return new Tuple<SpellManager.SpellInformation, CastAction>(SpellManager.GetSpell(ability.Item1), ability.Item3); 
        }


		/// <summary>
		///     Turns this AbilityPriority collection into a prioritized list of castable spells.
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public List<SpellManager.SpellInformation> ToValidAbilityList(Actor context)
		{
			return _priorityDictionary.Where(u =>
			{
				if (!u.Item2(context))
				{
					return false;
				}

				SpellManager.SpellInformation spell = SpellManager.GetSpell(u.Item1);
				if (spell != null)
				{
					// That's all. If we can cast it, go ahead and cast it.
					return spell.CanCast;
				}

				return false;
			}).Select(s => SpellManager.GetSpell(s.Item1)).ToList();
		}
	}

	public delegate bool CastCondition(Actor onTarget);

	public delegate Task<bool> CastAction(Actor onTarget);

	public delegate T Selection<out T>(Actor context);
}