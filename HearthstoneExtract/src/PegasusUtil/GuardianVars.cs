namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class GuardianVars : GeneratedMessageLite<GuardianVars, Builder>
    {
        private static readonly string[] _guardianVarsFieldNames = new string[] { 
            "battle_pay", "buy_with_gold", "casual", "crafting", "forge", "friendly", "hunter", "mage", "manager", "paladin", "practice", "priest", "rogue", "shaman", "showUserUI", "store", 
            "tourney", "warlock", "warrior"
         };
        private static readonly uint[] _guardianVarsFieldTags = new uint[] { 
            0x90, 0x98, 0x18, 0x38, 0x20, 40, 0x40, 0x48, 0x30, 80, 0x10, 0x58, 0x60, 0x68, 0x80, 0x88, 
            8, 0x70, 120
         };
        private bool battlePay_;
        public const int BattlePayFieldNumber = 0x12;
        private bool buyWithGold_;
        public const int BuyWithGoldFieldNumber = 0x13;
        private bool casual_;
        public const int CasualFieldNumber = 3;
        private bool crafting_;
        public const int CraftingFieldNumber = 7;
        private static readonly GuardianVars defaultInstance = new GuardianVars().MakeReadOnly();
        private bool forge_;
        public const int ForgeFieldNumber = 4;
        private bool friendly_;
        public const int FriendlyFieldNumber = 5;
        private bool hasBattlePay;
        private bool hasBuyWithGold;
        private bool hasCasual;
        private bool hasCrafting;
        private bool hasForge;
        private bool hasFriendly;
        private bool hasHunter;
        private bool hasMage;
        private bool hasManager;
        private bool hasPaladin;
        private bool hasPractice;
        private bool hasPriest;
        private bool hasRogue;
        private bool hasShaman;
        private bool hasShowUserUI;
        private bool hasStore;
        private bool hasTourney;
        private bool hasWarlock;
        private bool hasWarrior;
        private bool hunter_;
        public const int HunterFieldNumber = 8;
        private bool mage_;
        public const int MageFieldNumber = 9;
        private bool manager_;
        public const int ManagerFieldNumber = 6;
        private int memoizedSerializedSize = -1;
        private bool paladin_;
        public const int PaladinFieldNumber = 10;
        private bool practice_;
        public const int PracticeFieldNumber = 2;
        private bool priest_;
        public const int PriestFieldNumber = 11;
        private bool rogue_;
        public const int RogueFieldNumber = 12;
        private bool shaman_;
        public const int ShamanFieldNumber = 13;
        private int showUserUI_;
        public const int ShowUserUIFieldNumber = 0x10;
        private bool store_;
        public const int StoreFieldNumber = 0x11;
        private bool tourney_;
        public const int TourneyFieldNumber = 1;
        private bool warlock_;
        public const int WarlockFieldNumber = 14;
        private bool warrior_;
        public const int WarriorFieldNumber = 15;

        static GuardianVars()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private GuardianVars()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(GuardianVars prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            GuardianVars vars = obj as GuardianVars;
            if (vars == null)
            {
                return false;
            }
            if ((this.hasTourney != vars.hasTourney) || (this.hasTourney && !this.tourney_.Equals(vars.tourney_)))
            {
                return false;
            }
            if ((this.hasPractice != vars.hasPractice) || (this.hasPractice && !this.practice_.Equals(vars.practice_)))
            {
                return false;
            }
            if ((this.hasCasual != vars.hasCasual) || (this.hasCasual && !this.casual_.Equals(vars.casual_)))
            {
                return false;
            }
            if ((this.hasForge != vars.hasForge) || (this.hasForge && !this.forge_.Equals(vars.forge_)))
            {
                return false;
            }
            if ((this.hasFriendly != vars.hasFriendly) || (this.hasFriendly && !this.friendly_.Equals(vars.friendly_)))
            {
                return false;
            }
            if ((this.hasManager != vars.hasManager) || (this.hasManager && !this.manager_.Equals(vars.manager_)))
            {
                return false;
            }
            if ((this.hasCrafting != vars.hasCrafting) || (this.hasCrafting && !this.crafting_.Equals(vars.crafting_)))
            {
                return false;
            }
            if ((this.hasHunter != vars.hasHunter) || (this.hasHunter && !this.hunter_.Equals(vars.hunter_)))
            {
                return false;
            }
            if ((this.hasMage != vars.hasMage) || (this.hasMage && !this.mage_.Equals(vars.mage_)))
            {
                return false;
            }
            if ((this.hasPaladin != vars.hasPaladin) || (this.hasPaladin && !this.paladin_.Equals(vars.paladin_)))
            {
                return false;
            }
            if ((this.hasPriest != vars.hasPriest) || (this.hasPriest && !this.priest_.Equals(vars.priest_)))
            {
                return false;
            }
            if ((this.hasRogue != vars.hasRogue) || (this.hasRogue && !this.rogue_.Equals(vars.rogue_)))
            {
                return false;
            }
            if ((this.hasShaman != vars.hasShaman) || (this.hasShaman && !this.shaman_.Equals(vars.shaman_)))
            {
                return false;
            }
            if ((this.hasWarlock != vars.hasWarlock) || (this.hasWarlock && !this.warlock_.Equals(vars.warlock_)))
            {
                return false;
            }
            if ((this.hasWarrior != vars.hasWarrior) || (this.hasWarrior && !this.warrior_.Equals(vars.warrior_)))
            {
                return false;
            }
            if ((this.hasShowUserUI != vars.hasShowUserUI) || (this.hasShowUserUI && !this.showUserUI_.Equals(vars.showUserUI_)))
            {
                return false;
            }
            if ((this.hasStore != vars.hasStore) || (this.hasStore && !this.store_.Equals(vars.store_)))
            {
                return false;
            }
            if ((this.hasBattlePay != vars.hasBattlePay) || (this.hasBattlePay && !this.battlePay_.Equals(vars.battlePay_)))
            {
                return false;
            }
            return ((this.hasBuyWithGold == vars.hasBuyWithGold) && (!this.hasBuyWithGold || this.buyWithGold_.Equals(vars.buyWithGold_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasTourney)
            {
                hashCode ^= this.tourney_.GetHashCode();
            }
            if (this.hasPractice)
            {
                hashCode ^= this.practice_.GetHashCode();
            }
            if (this.hasCasual)
            {
                hashCode ^= this.casual_.GetHashCode();
            }
            if (this.hasForge)
            {
                hashCode ^= this.forge_.GetHashCode();
            }
            if (this.hasFriendly)
            {
                hashCode ^= this.friendly_.GetHashCode();
            }
            if (this.hasManager)
            {
                hashCode ^= this.manager_.GetHashCode();
            }
            if (this.hasCrafting)
            {
                hashCode ^= this.crafting_.GetHashCode();
            }
            if (this.hasHunter)
            {
                hashCode ^= this.hunter_.GetHashCode();
            }
            if (this.hasMage)
            {
                hashCode ^= this.mage_.GetHashCode();
            }
            if (this.hasPaladin)
            {
                hashCode ^= this.paladin_.GetHashCode();
            }
            if (this.hasPriest)
            {
                hashCode ^= this.priest_.GetHashCode();
            }
            if (this.hasRogue)
            {
                hashCode ^= this.rogue_.GetHashCode();
            }
            if (this.hasShaman)
            {
                hashCode ^= this.shaman_.GetHashCode();
            }
            if (this.hasWarlock)
            {
                hashCode ^= this.warlock_.GetHashCode();
            }
            if (this.hasWarrior)
            {
                hashCode ^= this.warrior_.GetHashCode();
            }
            if (this.hasShowUserUI)
            {
                hashCode ^= this.showUserUI_.GetHashCode();
            }
            if (this.hasStore)
            {
                hashCode ^= this.store_.GetHashCode();
            }
            if (this.hasBattlePay)
            {
                hashCode ^= this.battlePay_.GetHashCode();
            }
            if (this.hasBuyWithGold)
            {
                hashCode ^= this.buyWithGold_.GetHashCode();
            }
            return hashCode;
        }

        private GuardianVars MakeReadOnly()
        {
            return this;
        }

        public static GuardianVars ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static GuardianVars ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static GuardianVars ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GuardianVars ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GuardianVars ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GuardianVars ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GuardianVars ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static GuardianVars ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GuardianVars ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GuardianVars ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<GuardianVars, Builder>.PrintField("tourney", this.hasTourney, this.tourney_, writer);
            GeneratedMessageLite<GuardianVars, Builder>.PrintField("practice", this.hasPractice, this.practice_, writer);
            GeneratedMessageLite<GuardianVars, Builder>.PrintField("casual", this.hasCasual, this.casual_, writer);
            GeneratedMessageLite<GuardianVars, Builder>.PrintField("forge", this.hasForge, this.forge_, writer);
            GeneratedMessageLite<GuardianVars, Builder>.PrintField("friendly", this.hasFriendly, this.friendly_, writer);
            GeneratedMessageLite<GuardianVars, Builder>.PrintField("manager", this.hasManager, this.manager_, writer);
            GeneratedMessageLite<GuardianVars, Builder>.PrintField("crafting", this.hasCrafting, this.crafting_, writer);
            GeneratedMessageLite<GuardianVars, Builder>.PrintField("hunter", this.hasHunter, this.hunter_, writer);
            GeneratedMessageLite<GuardianVars, Builder>.PrintField("mage", this.hasMage, this.mage_, writer);
            GeneratedMessageLite<GuardianVars, Builder>.PrintField("paladin", this.hasPaladin, this.paladin_, writer);
            GeneratedMessageLite<GuardianVars, Builder>.PrintField("priest", this.hasPriest, this.priest_, writer);
            GeneratedMessageLite<GuardianVars, Builder>.PrintField("rogue", this.hasRogue, this.rogue_, writer);
            GeneratedMessageLite<GuardianVars, Builder>.PrintField("shaman", this.hasShaman, this.shaman_, writer);
            GeneratedMessageLite<GuardianVars, Builder>.PrintField("warlock", this.hasWarlock, this.warlock_, writer);
            GeneratedMessageLite<GuardianVars, Builder>.PrintField("warrior", this.hasWarrior, this.warrior_, writer);
            GeneratedMessageLite<GuardianVars, Builder>.PrintField("showUserUI", this.hasShowUserUI, this.showUserUI_, writer);
            GeneratedMessageLite<GuardianVars, Builder>.PrintField("store", this.hasStore, this.store_, writer);
            GeneratedMessageLite<GuardianVars, Builder>.PrintField("battle_pay", this.hasBattlePay, this.battlePay_, writer);
            GeneratedMessageLite<GuardianVars, Builder>.PrintField("buy_with_gold", this.hasBuyWithGold, this.buyWithGold_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _guardianVarsFieldNames;
            if (this.hasTourney)
            {
                output.WriteBool(1, strArray[0x10], this.Tourney);
            }
            if (this.hasPractice)
            {
                output.WriteBool(2, strArray[10], this.Practice);
            }
            if (this.hasCasual)
            {
                output.WriteBool(3, strArray[2], this.Casual);
            }
            if (this.hasForge)
            {
                output.WriteBool(4, strArray[4], this.Forge);
            }
            if (this.hasFriendly)
            {
                output.WriteBool(5, strArray[5], this.Friendly);
            }
            if (this.hasManager)
            {
                output.WriteBool(6, strArray[8], this.Manager);
            }
            if (this.hasCrafting)
            {
                output.WriteBool(7, strArray[3], this.Crafting);
            }
            if (this.hasHunter)
            {
                output.WriteBool(8, strArray[6], this.Hunter);
            }
            if (this.hasMage)
            {
                output.WriteBool(9, strArray[7], this.Mage);
            }
            if (this.hasPaladin)
            {
                output.WriteBool(10, strArray[9], this.Paladin);
            }
            if (this.hasPriest)
            {
                output.WriteBool(11, strArray[11], this.Priest);
            }
            if (this.hasRogue)
            {
                output.WriteBool(12, strArray[12], this.Rogue);
            }
            if (this.hasShaman)
            {
                output.WriteBool(13, strArray[13], this.Shaman);
            }
            if (this.hasWarlock)
            {
                output.WriteBool(14, strArray[0x11], this.Warlock);
            }
            if (this.hasWarrior)
            {
                output.WriteBool(15, strArray[0x12], this.Warrior);
            }
            if (this.hasShowUserUI)
            {
                output.WriteInt32(0x10, strArray[14], this.ShowUserUI);
            }
            if (this.hasStore)
            {
                output.WriteBool(0x11, strArray[15], this.Store);
            }
            if (this.hasBattlePay)
            {
                output.WriteBool(0x12, strArray[0], this.BattlePay);
            }
            if (this.hasBuyWithGold)
            {
                output.WriteBool(0x13, strArray[1], this.BuyWithGold);
            }
        }

        public bool BattlePay
        {
            get
            {
                return this.battlePay_;
            }
        }

        public bool BuyWithGold
        {
            get
            {
                return this.buyWithGold_;
            }
        }

        public bool Casual
        {
            get
            {
                return this.casual_;
            }
        }

        public bool Crafting
        {
            get
            {
                return this.crafting_;
            }
        }

        public static GuardianVars DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override GuardianVars DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool Forge
        {
            get
            {
                return this.forge_;
            }
        }

        public bool Friendly
        {
            get
            {
                return this.friendly_;
            }
        }

        public bool HasBattlePay
        {
            get
            {
                return this.hasBattlePay;
            }
        }

        public bool HasBuyWithGold
        {
            get
            {
                return this.hasBuyWithGold;
            }
        }

        public bool HasCasual
        {
            get
            {
                return this.hasCasual;
            }
        }

        public bool HasCrafting
        {
            get
            {
                return this.hasCrafting;
            }
        }

        public bool HasForge
        {
            get
            {
                return this.hasForge;
            }
        }

        public bool HasFriendly
        {
            get
            {
                return this.hasFriendly;
            }
        }

        public bool HasHunter
        {
            get
            {
                return this.hasHunter;
            }
        }

        public bool HasMage
        {
            get
            {
                return this.hasMage;
            }
        }

        public bool HasManager
        {
            get
            {
                return this.hasManager;
            }
        }

        public bool HasPaladin
        {
            get
            {
                return this.hasPaladin;
            }
        }

        public bool HasPractice
        {
            get
            {
                return this.hasPractice;
            }
        }

        public bool HasPriest
        {
            get
            {
                return this.hasPriest;
            }
        }

        public bool HasRogue
        {
            get
            {
                return this.hasRogue;
            }
        }

        public bool HasShaman
        {
            get
            {
                return this.hasShaman;
            }
        }

        public bool HasShowUserUI
        {
            get
            {
                return this.hasShowUserUI;
            }
        }

        public bool HasStore
        {
            get
            {
                return this.hasStore;
            }
        }

        public bool HasTourney
        {
            get
            {
                return this.hasTourney;
            }
        }

        public bool HasWarlock
        {
            get
            {
                return this.hasWarlock;
            }
        }

        public bool HasWarrior
        {
            get
            {
                return this.hasWarrior;
            }
        }

        public bool Hunter
        {
            get
            {
                return this.hunter_;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                return true;
            }
        }

        public bool Mage
        {
            get
            {
                return this.mage_;
            }
        }

        public bool Manager
        {
            get
            {
                return this.manager_;
            }
        }

        public bool Paladin
        {
            get
            {
                return this.paladin_;
            }
        }

        public bool Practice
        {
            get
            {
                return this.practice_;
            }
        }

        public bool Priest
        {
            get
            {
                return this.priest_;
            }
        }

        public bool Rogue
        {
            get
            {
                return this.rogue_;
            }
        }

        public override int SerializedSize
        {
            get
            {
                int memoizedSerializedSize = this.memoizedSerializedSize;
                if (memoizedSerializedSize == -1)
                {
                    memoizedSerializedSize = 0;
                    if (this.hasTourney)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(1, this.Tourney);
                    }
                    if (this.hasPractice)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(2, this.Practice);
                    }
                    if (this.hasCasual)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(3, this.Casual);
                    }
                    if (this.hasForge)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(4, this.Forge);
                    }
                    if (this.hasFriendly)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(5, this.Friendly);
                    }
                    if (this.hasManager)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(6, this.Manager);
                    }
                    if (this.hasCrafting)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(7, this.Crafting);
                    }
                    if (this.hasHunter)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(8, this.Hunter);
                    }
                    if (this.hasMage)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(9, this.Mage);
                    }
                    if (this.hasPaladin)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(10, this.Paladin);
                    }
                    if (this.hasPriest)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(11, this.Priest);
                    }
                    if (this.hasRogue)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(12, this.Rogue);
                    }
                    if (this.hasShaman)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(13, this.Shaman);
                    }
                    if (this.hasWarlock)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(14, this.Warlock);
                    }
                    if (this.hasWarrior)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(15, this.Warrior);
                    }
                    if (this.hasShowUserUI)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(0x10, this.ShowUserUI);
                    }
                    if (this.hasStore)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(0x11, this.Store);
                    }
                    if (this.hasBattlePay)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(0x12, this.BattlePay);
                    }
                    if (this.hasBuyWithGold)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBoolSize(0x13, this.BuyWithGold);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        public bool Shaman
        {
            get
            {
                return this.shaman_;
            }
        }

        public int ShowUserUI
        {
            get
            {
                return this.showUserUI_;
            }
        }

        public bool Store
        {
            get
            {
                return this.store_;
            }
        }

        protected override GuardianVars ThisMessage
        {
            get
            {
                return this;
            }
        }

        public bool Tourney
        {
            get
            {
                return this.tourney_;
            }
        }

        public bool Warlock
        {
            get
            {
                return this.warlock_;
            }
        }

        public bool Warrior
        {
            get
            {
                return this.warrior_;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<GuardianVars, GuardianVars.Builder>
        {
            private GuardianVars result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = GuardianVars.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(GuardianVars cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override GuardianVars BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override GuardianVars.Builder Clear()
            {
                this.result = GuardianVars.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public GuardianVars.Builder ClearBattlePay()
            {
                this.PrepareBuilder();
                this.result.hasBattlePay = false;
                this.result.battlePay_ = false;
                return this;
            }

            public GuardianVars.Builder ClearBuyWithGold()
            {
                this.PrepareBuilder();
                this.result.hasBuyWithGold = false;
                this.result.buyWithGold_ = false;
                return this;
            }

            public GuardianVars.Builder ClearCasual()
            {
                this.PrepareBuilder();
                this.result.hasCasual = false;
                this.result.casual_ = false;
                return this;
            }

            public GuardianVars.Builder ClearCrafting()
            {
                this.PrepareBuilder();
                this.result.hasCrafting = false;
                this.result.crafting_ = false;
                return this;
            }

            public GuardianVars.Builder ClearForge()
            {
                this.PrepareBuilder();
                this.result.hasForge = false;
                this.result.forge_ = false;
                return this;
            }

            public GuardianVars.Builder ClearFriendly()
            {
                this.PrepareBuilder();
                this.result.hasFriendly = false;
                this.result.friendly_ = false;
                return this;
            }

            public GuardianVars.Builder ClearHunter()
            {
                this.PrepareBuilder();
                this.result.hasHunter = false;
                this.result.hunter_ = false;
                return this;
            }

            public GuardianVars.Builder ClearMage()
            {
                this.PrepareBuilder();
                this.result.hasMage = false;
                this.result.mage_ = false;
                return this;
            }

            public GuardianVars.Builder ClearManager()
            {
                this.PrepareBuilder();
                this.result.hasManager = false;
                this.result.manager_ = false;
                return this;
            }

            public GuardianVars.Builder ClearPaladin()
            {
                this.PrepareBuilder();
                this.result.hasPaladin = false;
                this.result.paladin_ = false;
                return this;
            }

            public GuardianVars.Builder ClearPractice()
            {
                this.PrepareBuilder();
                this.result.hasPractice = false;
                this.result.practice_ = false;
                return this;
            }

            public GuardianVars.Builder ClearPriest()
            {
                this.PrepareBuilder();
                this.result.hasPriest = false;
                this.result.priest_ = false;
                return this;
            }

            public GuardianVars.Builder ClearRogue()
            {
                this.PrepareBuilder();
                this.result.hasRogue = false;
                this.result.rogue_ = false;
                return this;
            }

            public GuardianVars.Builder ClearShaman()
            {
                this.PrepareBuilder();
                this.result.hasShaman = false;
                this.result.shaman_ = false;
                return this;
            }

            public GuardianVars.Builder ClearShowUserUI()
            {
                this.PrepareBuilder();
                this.result.hasShowUserUI = false;
                this.result.showUserUI_ = 0;
                return this;
            }

            public GuardianVars.Builder ClearStore()
            {
                this.PrepareBuilder();
                this.result.hasStore = false;
                this.result.store_ = false;
                return this;
            }

            public GuardianVars.Builder ClearTourney()
            {
                this.PrepareBuilder();
                this.result.hasTourney = false;
                this.result.tourney_ = false;
                return this;
            }

            public GuardianVars.Builder ClearWarlock()
            {
                this.PrepareBuilder();
                this.result.hasWarlock = false;
                this.result.warlock_ = false;
                return this;
            }

            public GuardianVars.Builder ClearWarrior()
            {
                this.PrepareBuilder();
                this.result.hasWarrior = false;
                this.result.warrior_ = false;
                return this;
            }

            public override GuardianVars.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new GuardianVars.Builder(this.result);
                }
                return new GuardianVars.Builder().MergeFrom(this.result);
            }

            public override GuardianVars.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override GuardianVars.Builder MergeFrom(IMessageLite other)
            {
                if (other is GuardianVars)
                {
                    return this.MergeFrom((GuardianVars) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override GuardianVars.Builder MergeFrom(GuardianVars other)
            {
                if (other != GuardianVars.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasTourney)
                    {
                        this.Tourney = other.Tourney;
                    }
                    if (other.HasPractice)
                    {
                        this.Practice = other.Practice;
                    }
                    if (other.HasCasual)
                    {
                        this.Casual = other.Casual;
                    }
                    if (other.HasForge)
                    {
                        this.Forge = other.Forge;
                    }
                    if (other.HasFriendly)
                    {
                        this.Friendly = other.Friendly;
                    }
                    if (other.HasManager)
                    {
                        this.Manager = other.Manager;
                    }
                    if (other.HasCrafting)
                    {
                        this.Crafting = other.Crafting;
                    }
                    if (other.HasHunter)
                    {
                        this.Hunter = other.Hunter;
                    }
                    if (other.HasMage)
                    {
                        this.Mage = other.Mage;
                    }
                    if (other.HasPaladin)
                    {
                        this.Paladin = other.Paladin;
                    }
                    if (other.HasPriest)
                    {
                        this.Priest = other.Priest;
                    }
                    if (other.HasRogue)
                    {
                        this.Rogue = other.Rogue;
                    }
                    if (other.HasShaman)
                    {
                        this.Shaman = other.Shaman;
                    }
                    if (other.HasWarlock)
                    {
                        this.Warlock = other.Warlock;
                    }
                    if (other.HasWarrior)
                    {
                        this.Warrior = other.Warrior;
                    }
                    if (other.HasShowUserUI)
                    {
                        this.ShowUserUI = other.ShowUserUI;
                    }
                    if (other.HasStore)
                    {
                        this.Store = other.Store;
                    }
                    if (other.HasBattlePay)
                    {
                        this.BattlePay = other.BattlePay;
                    }
                    if (other.HasBuyWithGold)
                    {
                        this.BuyWithGold = other.BuyWithGold;
                    }
                }
                return this;
            }

            public override GuardianVars.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(GuardianVars._guardianVarsFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = GuardianVars._guardianVarsFieldTags[index];
                        }
                        else
                        {
                            this.ParseUnknownField(input, extensionRegistry, num, str);
                            continue;
                        }
                    }
                    switch (num)
                    {
                        case 0:
                            throw InvalidProtocolBufferException.InvalidTag();

                        case 8:
                        {
                            this.result.hasTourney = input.ReadBool(ref this.result.tourney_);
                            continue;
                        }
                        case 0x10:
                        {
                            this.result.hasPractice = input.ReadBool(ref this.result.practice_);
                            continue;
                        }
                        case 0x18:
                        {
                            this.result.hasCasual = input.ReadBool(ref this.result.casual_);
                            continue;
                        }
                        case 0x20:
                        {
                            this.result.hasForge = input.ReadBool(ref this.result.forge_);
                            continue;
                        }
                        case 40:
                        {
                            this.result.hasFriendly = input.ReadBool(ref this.result.friendly_);
                            continue;
                        }
                        case 0x30:
                        {
                            this.result.hasManager = input.ReadBool(ref this.result.manager_);
                            continue;
                        }
                        case 0x38:
                        {
                            this.result.hasCrafting = input.ReadBool(ref this.result.crafting_);
                            continue;
                        }
                        case 0x40:
                        {
                            this.result.hasHunter = input.ReadBool(ref this.result.hunter_);
                            continue;
                        }
                        case 0x48:
                        {
                            this.result.hasMage = input.ReadBool(ref this.result.mage_);
                            continue;
                        }
                        case 80:
                        {
                            this.result.hasPaladin = input.ReadBool(ref this.result.paladin_);
                            continue;
                        }
                        case 0x58:
                        {
                            this.result.hasPriest = input.ReadBool(ref this.result.priest_);
                            continue;
                        }
                        case 0x60:
                        {
                            this.result.hasRogue = input.ReadBool(ref this.result.rogue_);
                            continue;
                        }
                        case 0x68:
                        {
                            this.result.hasShaman = input.ReadBool(ref this.result.shaman_);
                            continue;
                        }
                        case 0x70:
                        {
                            this.result.hasWarlock = input.ReadBool(ref this.result.warlock_);
                            continue;
                        }
                        case 120:
                        {
                            this.result.hasWarrior = input.ReadBool(ref this.result.warrior_);
                            continue;
                        }
                        case 0x80:
                        {
                            this.result.hasShowUserUI = input.ReadInt32(ref this.result.showUserUI_);
                            continue;
                        }
                        case 0x88:
                        {
                            this.result.hasStore = input.ReadBool(ref this.result.store_);
                            continue;
                        }
                        case 0x90:
                        {
                            this.result.hasBattlePay = input.ReadBool(ref this.result.battlePay_);
                            continue;
                        }
                        case 0x98:
                            break;

                        default:
                        {
                            if (WireFormat.IsEndGroupTag(num))
                            {
                                return this;
                            }
                            this.ParseUnknownField(input, extensionRegistry, num, str);
                            continue;
                        }
                    }
                    this.result.hasBuyWithGold = input.ReadBool(ref this.result.buyWithGold_);
                }
                return this;
            }

            private GuardianVars PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    GuardianVars result = this.result;
                    this.result = new GuardianVars();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public GuardianVars.Builder SetBattlePay(bool value)
            {
                this.PrepareBuilder();
                this.result.hasBattlePay = true;
                this.result.battlePay_ = value;
                return this;
            }

            public GuardianVars.Builder SetBuyWithGold(bool value)
            {
                this.PrepareBuilder();
                this.result.hasBuyWithGold = true;
                this.result.buyWithGold_ = value;
                return this;
            }

            public GuardianVars.Builder SetCasual(bool value)
            {
                this.PrepareBuilder();
                this.result.hasCasual = true;
                this.result.casual_ = value;
                return this;
            }

            public GuardianVars.Builder SetCrafting(bool value)
            {
                this.PrepareBuilder();
                this.result.hasCrafting = true;
                this.result.crafting_ = value;
                return this;
            }

            public GuardianVars.Builder SetForge(bool value)
            {
                this.PrepareBuilder();
                this.result.hasForge = true;
                this.result.forge_ = value;
                return this;
            }

            public GuardianVars.Builder SetFriendly(bool value)
            {
                this.PrepareBuilder();
                this.result.hasFriendly = true;
                this.result.friendly_ = value;
                return this;
            }

            public GuardianVars.Builder SetHunter(bool value)
            {
                this.PrepareBuilder();
                this.result.hasHunter = true;
                this.result.hunter_ = value;
                return this;
            }

            public GuardianVars.Builder SetMage(bool value)
            {
                this.PrepareBuilder();
                this.result.hasMage = true;
                this.result.mage_ = value;
                return this;
            }

            public GuardianVars.Builder SetManager(bool value)
            {
                this.PrepareBuilder();
                this.result.hasManager = true;
                this.result.manager_ = value;
                return this;
            }

            public GuardianVars.Builder SetPaladin(bool value)
            {
                this.PrepareBuilder();
                this.result.hasPaladin = true;
                this.result.paladin_ = value;
                return this;
            }

            public GuardianVars.Builder SetPractice(bool value)
            {
                this.PrepareBuilder();
                this.result.hasPractice = true;
                this.result.practice_ = value;
                return this;
            }

            public GuardianVars.Builder SetPriest(bool value)
            {
                this.PrepareBuilder();
                this.result.hasPriest = true;
                this.result.priest_ = value;
                return this;
            }

            public GuardianVars.Builder SetRogue(bool value)
            {
                this.PrepareBuilder();
                this.result.hasRogue = true;
                this.result.rogue_ = value;
                return this;
            }

            public GuardianVars.Builder SetShaman(bool value)
            {
                this.PrepareBuilder();
                this.result.hasShaman = true;
                this.result.shaman_ = value;
                return this;
            }

            public GuardianVars.Builder SetShowUserUI(int value)
            {
                this.PrepareBuilder();
                this.result.hasShowUserUI = true;
                this.result.showUserUI_ = value;
                return this;
            }

            public GuardianVars.Builder SetStore(bool value)
            {
                this.PrepareBuilder();
                this.result.hasStore = true;
                this.result.store_ = value;
                return this;
            }

            public GuardianVars.Builder SetTourney(bool value)
            {
                this.PrepareBuilder();
                this.result.hasTourney = true;
                this.result.tourney_ = value;
                return this;
            }

            public GuardianVars.Builder SetWarlock(bool value)
            {
                this.PrepareBuilder();
                this.result.hasWarlock = true;
                this.result.warlock_ = value;
                return this;
            }

            public GuardianVars.Builder SetWarrior(bool value)
            {
                this.PrepareBuilder();
                this.result.hasWarrior = true;
                this.result.warrior_ = value;
                return this;
            }

            public bool BattlePay
            {
                get
                {
                    return this.result.BattlePay;
                }
                set
                {
                    this.SetBattlePay(value);
                }
            }

            public bool BuyWithGold
            {
                get
                {
                    return this.result.BuyWithGold;
                }
                set
                {
                    this.SetBuyWithGold(value);
                }
            }

            public bool Casual
            {
                get
                {
                    return this.result.Casual;
                }
                set
                {
                    this.SetCasual(value);
                }
            }

            public bool Crafting
            {
                get
                {
                    return this.result.Crafting;
                }
                set
                {
                    this.SetCrafting(value);
                }
            }

            public override GuardianVars DefaultInstanceForType
            {
                get
                {
                    return GuardianVars.DefaultInstance;
                }
            }

            public bool Forge
            {
                get
                {
                    return this.result.Forge;
                }
                set
                {
                    this.SetForge(value);
                }
            }

            public bool Friendly
            {
                get
                {
                    return this.result.Friendly;
                }
                set
                {
                    this.SetFriendly(value);
                }
            }

            public bool HasBattlePay
            {
                get
                {
                    return this.result.hasBattlePay;
                }
            }

            public bool HasBuyWithGold
            {
                get
                {
                    return this.result.hasBuyWithGold;
                }
            }

            public bool HasCasual
            {
                get
                {
                    return this.result.hasCasual;
                }
            }

            public bool HasCrafting
            {
                get
                {
                    return this.result.hasCrafting;
                }
            }

            public bool HasForge
            {
                get
                {
                    return this.result.hasForge;
                }
            }

            public bool HasFriendly
            {
                get
                {
                    return this.result.hasFriendly;
                }
            }

            public bool HasHunter
            {
                get
                {
                    return this.result.hasHunter;
                }
            }

            public bool HasMage
            {
                get
                {
                    return this.result.hasMage;
                }
            }

            public bool HasManager
            {
                get
                {
                    return this.result.hasManager;
                }
            }

            public bool HasPaladin
            {
                get
                {
                    return this.result.hasPaladin;
                }
            }

            public bool HasPractice
            {
                get
                {
                    return this.result.hasPractice;
                }
            }

            public bool HasPriest
            {
                get
                {
                    return this.result.hasPriest;
                }
            }

            public bool HasRogue
            {
                get
                {
                    return this.result.hasRogue;
                }
            }

            public bool HasShaman
            {
                get
                {
                    return this.result.hasShaman;
                }
            }

            public bool HasShowUserUI
            {
                get
                {
                    return this.result.hasShowUserUI;
                }
            }

            public bool HasStore
            {
                get
                {
                    return this.result.hasStore;
                }
            }

            public bool HasTourney
            {
                get
                {
                    return this.result.hasTourney;
                }
            }

            public bool HasWarlock
            {
                get
                {
                    return this.result.hasWarlock;
                }
            }

            public bool HasWarrior
            {
                get
                {
                    return this.result.hasWarrior;
                }
            }

            public bool Hunter
            {
                get
                {
                    return this.result.Hunter;
                }
                set
                {
                    this.SetHunter(value);
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            public bool Mage
            {
                get
                {
                    return this.result.Mage;
                }
                set
                {
                    this.SetMage(value);
                }
            }

            public bool Manager
            {
                get
                {
                    return this.result.Manager;
                }
                set
                {
                    this.SetManager(value);
                }
            }

            protected override GuardianVars MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public bool Paladin
            {
                get
                {
                    return this.result.Paladin;
                }
                set
                {
                    this.SetPaladin(value);
                }
            }

            public bool Practice
            {
                get
                {
                    return this.result.Practice;
                }
                set
                {
                    this.SetPractice(value);
                }
            }

            public bool Priest
            {
                get
                {
                    return this.result.Priest;
                }
                set
                {
                    this.SetPriest(value);
                }
            }

            public bool Rogue
            {
                get
                {
                    return this.result.Rogue;
                }
                set
                {
                    this.SetRogue(value);
                }
            }

            public bool Shaman
            {
                get
                {
                    return this.result.Shaman;
                }
                set
                {
                    this.SetShaman(value);
                }
            }

            public int ShowUserUI
            {
                get
                {
                    return this.result.ShowUserUI;
                }
                set
                {
                    this.SetShowUserUI(value);
                }
            }

            public bool Store
            {
                get
                {
                    return this.result.Store;
                }
                set
                {
                    this.SetStore(value);
                }
            }

            protected override GuardianVars.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            public bool Tourney
            {
                get
                {
                    return this.result.Tourney;
                }
                set
                {
                    this.SetTourney(value);
                }
            }

            public bool Warlock
            {
                get
                {
                    return this.result.Warlock;
                }
                set
                {
                    this.SetWarlock(value);
                }
            }

            public bool Warrior
            {
                get
                {
                    return this.result.Warrior;
                }
                set
                {
                    this.SetWarrior(value);
                }
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0x108
            }
        }
    }
}

