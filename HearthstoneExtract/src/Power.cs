using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.XPath;

public class Power
{
    private string mDefinition = string.Empty;
    private PlayErrors.PlayRequirementInfo mPlayRequirementInfo = new PlayErrors.PlayRequirementInfo();
    private static Power s_defaultAttackPower;
    private static Power s_defaultMasterPower;

    public static Power GetDefaultAttackPower()
    {
        if (s_defaultAttackPower == null)
        {
            s_defaultAttackPower = new Power();
            List<PlayErrors.ErrorType> requirements = new List<PlayErrors.ErrorType> { 11, 3 };
            s_defaultAttackPower.mPlayRequirementInfo.requirementsMap = PlayErrors.GetRequirementsMap(requirements);
        }
        return s_defaultAttackPower;
    }

    public static Power GetDefaultMasterPower()
    {
        if (s_defaultMasterPower == null)
        {
            s_defaultMasterPower = new Power();
            List<PlayErrors.ErrorType> requirements = new List<PlayErrors.ErrorType>();
            s_defaultMasterPower.mPlayRequirementInfo.requirementsMap = PlayErrors.GetRequirementsMap(requirements);
        }
        return s_defaultMasterPower;
    }

    public string GetDefinition()
    {
        return this.mDefinition;
    }

    public PlayErrors.PlayRequirementInfo GetPlayRequirementInfo()
    {
        return this.mPlayRequirementInfo;
    }

    public static Power LoadFromXml(XmlElement rootElement)
    {
        Power power = new Power {
            mDefinition = rootElement.GetAttribute("definition")
        };
        XPathNavigator navigator = rootElement.CreateNavigator();
        XPathExpression expr = navigator.Compile("./PlayRequirement");
        XPathNodeIterator iterator = navigator.Select(expr);
        List<PlayErrors.ErrorType> requirements = new List<PlayErrors.ErrorType>();
        while (iterator.MoveNext())
        {
            int num;
            XmlElement node = (XmlElement) ((IHasXmlNode) iterator.Current).GetNode();
            if (int.TryParse(node.GetAttribute("reqID"), out num))
            {
                PlayErrors.ErrorType item = (PlayErrors.ErrorType) num;
                requirements.Add(item);
                switch (item)
                {
                    case PlayErrors.ErrorType.REQ_TARGET_MIN_ATTACK:
                    {
                        if (!int.TryParse(node.GetAttribute("param"), out power.mPlayRequirementInfo.paramMinAtk))
                        {
                            Log.Rachelle.Print(string.Format("Unable to read play requirement param minAtk for power {0}.", power.GetDefinition()));
                        }
                        continue;
                    }
                    case PlayErrors.ErrorType.REQ_TARGET_MAX_ATTACK:
                    {
                        if (!int.TryParse(node.GetAttribute("param"), out power.mPlayRequirementInfo.paramMaxAtk))
                        {
                            Log.Rachelle.Print(string.Format("Unable to read play requirement param maxAtk for power {0}.", power.GetDefinition()));
                        }
                        continue;
                    }
                    case PlayErrors.ErrorType.REQ_TARGET_WITH_RACE:
                    {
                        if (!int.TryParse(node.GetAttribute("param"), out power.mPlayRequirementInfo.paramRace))
                        {
                            Log.Rachelle.Print(string.Format("Unable to read play requirement param race for power {0}.", power.GetDefinition()));
                        }
                        continue;
                    }
                    case PlayErrors.ErrorType.REQ_NUM_MINION_SLOTS:
                    {
                        if (!int.TryParse(node.GetAttribute("param"), out power.mPlayRequirementInfo.paramNumMinionSlots))
                        {
                            Log.Rachelle.Print(string.Format("Unable to read play requirement param num minion slots for power {0}.", power.GetDefinition()));
                        }
                        continue;
                    }
                    case PlayErrors.ErrorType.REQ_MINION_CAP_IF_TARGET_AVAILABLE:
                    {
                        if (!int.TryParse(node.GetAttribute("param"), out power.mPlayRequirementInfo.paramNumMinionSlotsWithTarget))
                        {
                            Log.Rachelle.Print(string.Format("Unable to read play requirement param num minion slots with target for power {0}.", power.GetDefinition()));
                        }
                        continue;
                    }
                    case PlayErrors.ErrorType.REQ_MINIMUM_ENEMY_MINIONS:
                    {
                        if (!int.TryParse(node.GetAttribute("param"), out power.mPlayRequirementInfo.paramMinNumEnemyMinions))
                        {
                            Log.Rachelle.Print(string.Format("Unable to read play requirement param num enemy minions for power {0}.", power.GetDefinition()));
                        }
                        continue;
                    }
                }
                if ((item == PlayErrors.ErrorType.REQ_MINIMUM_TOTAL_MINIONS) && !int.TryParse(node.GetAttribute("param"), out power.mPlayRequirementInfo.paramMinNumTotalMinions))
                {
                    Log.Rachelle.Print(string.Format("Unable to read play requirement param num total minions for power {0}.", power.GetDefinition()));
                }
            }
        }
        power.mPlayRequirementInfo.requirementsMap = PlayErrors.GetRequirementsMap(requirements);
        return power;
    }
}

