namespace PegasusGame
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class PowerHistoryData : GeneratedMessageLite<PowerHistoryData, Builder>
    {
        private static readonly string[] _powerHistoryDataFieldNames = new string[] { "create_game", "full_entity", "hide_entity", "meta_data", "power_end", "power_start", "show_entity", "tag_change" };
        private static readonly uint[] _powerHistoryDataFieldTags = new uint[] { 0x2a, 10, 0x1a, 0x42, 0x3a, 50, 0x12, 0x22 };
        private PowerHistoryCreateGame createGame_;
        public const int CreateGameFieldNumber = 5;
        private static readonly PowerHistoryData defaultInstance = new PowerHistoryData().MakeReadOnly();
        private PowerHistoryEntity fullEntity_;
        public const int FullEntityFieldNumber = 1;
        private bool hasCreateGame;
        private bool hasFullEntity;
        private bool hasHideEntity;
        private bool hasMetaData;
        private bool hasPowerEnd;
        private bool hasPowerStart;
        private bool hasShowEntity;
        private bool hasTagChange;
        private PowerHistoryHide hideEntity_;
        public const int HideEntityFieldNumber = 3;
        private int memoizedSerializedSize = -1;
        private PowerHistoryMetaData metaData_;
        public const int MetaDataFieldNumber = 8;
        private PowerHistoryEnd powerEnd_;
        public const int PowerEndFieldNumber = 7;
        private PowerHistoryStart powerStart_;
        public const int PowerStartFieldNumber = 6;
        private PowerHistoryEntity showEntity_;
        public const int ShowEntityFieldNumber = 2;
        private PowerHistoryTagChange tagChange_;
        public const int TagChangeFieldNumber = 4;

        static PowerHistoryData()
        {
            object.ReferenceEquals(PegasusGamelite.Descriptor, null);
        }

        private PowerHistoryData()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(PowerHistoryData prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            PowerHistoryData data = obj as PowerHistoryData;
            if (data == null)
            {
                return false;
            }
            if ((this.hasFullEntity != data.hasFullEntity) || (this.hasFullEntity && !this.fullEntity_.Equals(data.fullEntity_)))
            {
                return false;
            }
            if ((this.hasShowEntity != data.hasShowEntity) || (this.hasShowEntity && !this.showEntity_.Equals(data.showEntity_)))
            {
                return false;
            }
            if ((this.hasHideEntity != data.hasHideEntity) || (this.hasHideEntity && !this.hideEntity_.Equals(data.hideEntity_)))
            {
                return false;
            }
            if ((this.hasTagChange != data.hasTagChange) || (this.hasTagChange && !this.tagChange_.Equals(data.tagChange_)))
            {
                return false;
            }
            if ((this.hasCreateGame != data.hasCreateGame) || (this.hasCreateGame && !this.createGame_.Equals(data.createGame_)))
            {
                return false;
            }
            if ((this.hasPowerStart != data.hasPowerStart) || (this.hasPowerStart && !this.powerStart_.Equals(data.powerStart_)))
            {
                return false;
            }
            if ((this.hasPowerEnd != data.hasPowerEnd) || (this.hasPowerEnd && !this.powerEnd_.Equals(data.powerEnd_)))
            {
                return false;
            }
            return ((this.hasMetaData == data.hasMetaData) && (!this.hasMetaData || this.metaData_.Equals(data.metaData_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasFullEntity)
            {
                hashCode ^= this.fullEntity_.GetHashCode();
            }
            if (this.hasShowEntity)
            {
                hashCode ^= this.showEntity_.GetHashCode();
            }
            if (this.hasHideEntity)
            {
                hashCode ^= this.hideEntity_.GetHashCode();
            }
            if (this.hasTagChange)
            {
                hashCode ^= this.tagChange_.GetHashCode();
            }
            if (this.hasCreateGame)
            {
                hashCode ^= this.createGame_.GetHashCode();
            }
            if (this.hasPowerStart)
            {
                hashCode ^= this.powerStart_.GetHashCode();
            }
            if (this.hasPowerEnd)
            {
                hashCode ^= this.powerEnd_.GetHashCode();
            }
            if (this.hasMetaData)
            {
                hashCode ^= this.metaData_.GetHashCode();
            }
            return hashCode;
        }

        private PowerHistoryData MakeReadOnly()
        {
            return this;
        }

        public static PowerHistoryData ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static PowerHistoryData ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static PowerHistoryData ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static PowerHistoryData ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static PowerHistoryData ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static PowerHistoryData ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static PowerHistoryData ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static PowerHistoryData ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static PowerHistoryData ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static PowerHistoryData ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<PowerHistoryData, Builder>.PrintField("full_entity", this.hasFullEntity, this.fullEntity_, writer);
            GeneratedMessageLite<PowerHistoryData, Builder>.PrintField("show_entity", this.hasShowEntity, this.showEntity_, writer);
            GeneratedMessageLite<PowerHistoryData, Builder>.PrintField("hide_entity", this.hasHideEntity, this.hideEntity_, writer);
            GeneratedMessageLite<PowerHistoryData, Builder>.PrintField("tag_change", this.hasTagChange, this.tagChange_, writer);
            GeneratedMessageLite<PowerHistoryData, Builder>.PrintField("create_game", this.hasCreateGame, this.createGame_, writer);
            GeneratedMessageLite<PowerHistoryData, Builder>.PrintField("power_start", this.hasPowerStart, this.powerStart_, writer);
            GeneratedMessageLite<PowerHistoryData, Builder>.PrintField("power_end", this.hasPowerEnd, this.powerEnd_, writer);
            GeneratedMessageLite<PowerHistoryData, Builder>.PrintField("meta_data", this.hasMetaData, this.metaData_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _powerHistoryDataFieldNames;
            if (this.hasFullEntity)
            {
                output.WriteMessage(1, strArray[1], this.FullEntity);
            }
            if (this.hasShowEntity)
            {
                output.WriteMessage(2, strArray[6], this.ShowEntity);
            }
            if (this.hasHideEntity)
            {
                output.WriteMessage(3, strArray[2], this.HideEntity);
            }
            if (this.hasTagChange)
            {
                output.WriteMessage(4, strArray[7], this.TagChange);
            }
            if (this.hasCreateGame)
            {
                output.WriteMessage(5, strArray[0], this.CreateGame);
            }
            if (this.hasPowerStart)
            {
                output.WriteMessage(6, strArray[5], this.PowerStart);
            }
            if (this.hasPowerEnd)
            {
                output.WriteMessage(7, strArray[4], this.PowerEnd);
            }
            if (this.hasMetaData)
            {
                output.WriteMessage(8, strArray[3], this.MetaData);
            }
        }

        public PowerHistoryCreateGame CreateGame
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.createGame_ != null)
                {
                    goto Label_0012;
                }
                return PowerHistoryCreateGame.DefaultInstance;
            }
        }

        public static PowerHistoryData DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override PowerHistoryData DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public PowerHistoryEntity FullEntity
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.fullEntity_ != null)
                {
                    goto Label_0012;
                }
                return PowerHistoryEntity.DefaultInstance;
            }
        }

        public bool HasCreateGame
        {
            get
            {
                return this.hasCreateGame;
            }
        }

        public bool HasFullEntity
        {
            get
            {
                return this.hasFullEntity;
            }
        }

        public bool HasHideEntity
        {
            get
            {
                return this.hasHideEntity;
            }
        }

        public bool HasMetaData
        {
            get
            {
                return this.hasMetaData;
            }
        }

        public bool HasPowerEnd
        {
            get
            {
                return this.hasPowerEnd;
            }
        }

        public bool HasPowerStart
        {
            get
            {
                return this.hasPowerStart;
            }
        }

        public bool HasShowEntity
        {
            get
            {
                return this.hasShowEntity;
            }
        }

        public bool HasTagChange
        {
            get
            {
                return this.hasTagChange;
            }
        }

        public PowerHistoryHide HideEntity
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.hideEntity_ != null)
                {
                    goto Label_0012;
                }
                return PowerHistoryHide.DefaultInstance;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (this.HasFullEntity && !this.FullEntity.IsInitialized)
                {
                    return false;
                }
                if (this.HasShowEntity && !this.ShowEntity.IsInitialized)
                {
                    return false;
                }
                if (this.HasHideEntity && !this.HideEntity.IsInitialized)
                {
                    return false;
                }
                if (this.HasTagChange && !this.TagChange.IsInitialized)
                {
                    return false;
                }
                if (this.HasCreateGame && !this.CreateGame.IsInitialized)
                {
                    return false;
                }
                if (this.HasPowerStart && !this.PowerStart.IsInitialized)
                {
                    return false;
                }
                return true;
            }
        }

        public PowerHistoryMetaData MetaData
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.metaData_ != null)
                {
                    goto Label_0012;
                }
                return PowerHistoryMetaData.DefaultInstance;
            }
        }

        public PowerHistoryEnd PowerEnd
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.powerEnd_ != null)
                {
                    goto Label_0012;
                }
                return PowerHistoryEnd.DefaultInstance;
            }
        }

        public PowerHistoryStart PowerStart
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.powerStart_ != null)
                {
                    goto Label_0012;
                }
                return PowerHistoryStart.DefaultInstance;
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
                    if (this.hasFullEntity)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, this.FullEntity);
                    }
                    if (this.hasShowEntity)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(2, this.ShowEntity);
                    }
                    if (this.hasHideEntity)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(3, this.HideEntity);
                    }
                    if (this.hasTagChange)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(4, this.TagChange);
                    }
                    if (this.hasCreateGame)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(5, this.CreateGame);
                    }
                    if (this.hasPowerStart)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(6, this.PowerStart);
                    }
                    if (this.hasPowerEnd)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(7, this.PowerEnd);
                    }
                    if (this.hasMetaData)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(8, this.MetaData);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        public PowerHistoryEntity ShowEntity
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.showEntity_ != null)
                {
                    goto Label_0012;
                }
                return PowerHistoryEntity.DefaultInstance;
            }
        }

        public PowerHistoryTagChange TagChange
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.tagChange_ != null)
                {
                    goto Label_0012;
                }
                return PowerHistoryTagChange.DefaultInstance;
            }
        }

        protected override PowerHistoryData ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<PowerHistoryData, PowerHistoryData.Builder>
        {
            private PowerHistoryData result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = PowerHistoryData.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(PowerHistoryData cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override PowerHistoryData BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override PowerHistoryData.Builder Clear()
            {
                this.result = PowerHistoryData.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public PowerHistoryData.Builder ClearCreateGame()
            {
                this.PrepareBuilder();
                this.result.hasCreateGame = false;
                this.result.createGame_ = null;
                return this;
            }

            public PowerHistoryData.Builder ClearFullEntity()
            {
                this.PrepareBuilder();
                this.result.hasFullEntity = false;
                this.result.fullEntity_ = null;
                return this;
            }

            public PowerHistoryData.Builder ClearHideEntity()
            {
                this.PrepareBuilder();
                this.result.hasHideEntity = false;
                this.result.hideEntity_ = null;
                return this;
            }

            public PowerHistoryData.Builder ClearMetaData()
            {
                this.PrepareBuilder();
                this.result.hasMetaData = false;
                this.result.metaData_ = null;
                return this;
            }

            public PowerHistoryData.Builder ClearPowerEnd()
            {
                this.PrepareBuilder();
                this.result.hasPowerEnd = false;
                this.result.powerEnd_ = null;
                return this;
            }

            public PowerHistoryData.Builder ClearPowerStart()
            {
                this.PrepareBuilder();
                this.result.hasPowerStart = false;
                this.result.powerStart_ = null;
                return this;
            }

            public PowerHistoryData.Builder ClearShowEntity()
            {
                this.PrepareBuilder();
                this.result.hasShowEntity = false;
                this.result.showEntity_ = null;
                return this;
            }

            public PowerHistoryData.Builder ClearTagChange()
            {
                this.PrepareBuilder();
                this.result.hasTagChange = false;
                this.result.tagChange_ = null;
                return this;
            }

            public override PowerHistoryData.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new PowerHistoryData.Builder(this.result);
                }
                return new PowerHistoryData.Builder().MergeFrom(this.result);
            }

            public PowerHistoryData.Builder MergeCreateGame(PowerHistoryCreateGame value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasCreateGame && (this.result.createGame_ != PowerHistoryCreateGame.DefaultInstance))
                {
                    this.result.createGame_ = PowerHistoryCreateGame.CreateBuilder(this.result.createGame_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.createGame_ = value;
                }
                this.result.hasCreateGame = true;
                return this;
            }

            public override PowerHistoryData.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override PowerHistoryData.Builder MergeFrom(IMessageLite other)
            {
                if (other is PowerHistoryData)
                {
                    return this.MergeFrom((PowerHistoryData) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override PowerHistoryData.Builder MergeFrom(PowerHistoryData other)
            {
                if (other != PowerHistoryData.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasFullEntity)
                    {
                        this.MergeFullEntity(other.FullEntity);
                    }
                    if (other.HasShowEntity)
                    {
                        this.MergeShowEntity(other.ShowEntity);
                    }
                    if (other.HasHideEntity)
                    {
                        this.MergeHideEntity(other.HideEntity);
                    }
                    if (other.HasTagChange)
                    {
                        this.MergeTagChange(other.TagChange);
                    }
                    if (other.HasCreateGame)
                    {
                        this.MergeCreateGame(other.CreateGame);
                    }
                    if (other.HasPowerStart)
                    {
                        this.MergePowerStart(other.PowerStart);
                    }
                    if (other.HasPowerEnd)
                    {
                        this.MergePowerEnd(other.PowerEnd);
                    }
                    if (other.HasMetaData)
                    {
                        this.MergeMetaData(other.MetaData);
                    }
                }
                return this;
            }

            public override PowerHistoryData.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(PowerHistoryData._powerHistoryDataFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = PowerHistoryData._powerHistoryDataFieldTags[index];
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

                        case 10:
                        {
                            PowerHistoryEntity.Builder builder = PowerHistoryEntity.CreateBuilder();
                            if (this.result.hasFullEntity)
                            {
                                builder.MergeFrom(this.FullEntity);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.FullEntity = builder.BuildPartial();
                            continue;
                        }
                        case 0x12:
                        {
                            PowerHistoryEntity.Builder builder2 = PowerHistoryEntity.CreateBuilder();
                            if (this.result.hasShowEntity)
                            {
                                builder2.MergeFrom(this.ShowEntity);
                            }
                            input.ReadMessage(builder2, extensionRegistry);
                            this.ShowEntity = builder2.BuildPartial();
                            continue;
                        }
                        case 0x1a:
                        {
                            PowerHistoryHide.Builder builder3 = PowerHistoryHide.CreateBuilder();
                            if (this.result.hasHideEntity)
                            {
                                builder3.MergeFrom(this.HideEntity);
                            }
                            input.ReadMessage(builder3, extensionRegistry);
                            this.HideEntity = builder3.BuildPartial();
                            continue;
                        }
                        case 0x22:
                        {
                            PowerHistoryTagChange.Builder builder4 = PowerHistoryTagChange.CreateBuilder();
                            if (this.result.hasTagChange)
                            {
                                builder4.MergeFrom(this.TagChange);
                            }
                            input.ReadMessage(builder4, extensionRegistry);
                            this.TagChange = builder4.BuildPartial();
                            continue;
                        }
                        case 0x2a:
                        {
                            PowerHistoryCreateGame.Builder builder5 = PowerHistoryCreateGame.CreateBuilder();
                            if (this.result.hasCreateGame)
                            {
                                builder5.MergeFrom(this.CreateGame);
                            }
                            input.ReadMessage(builder5, extensionRegistry);
                            this.CreateGame = builder5.BuildPartial();
                            continue;
                        }
                        case 50:
                        {
                            PowerHistoryStart.Builder builder6 = PowerHistoryStart.CreateBuilder();
                            if (this.result.hasPowerStart)
                            {
                                builder6.MergeFrom(this.PowerStart);
                            }
                            input.ReadMessage(builder6, extensionRegistry);
                            this.PowerStart = builder6.BuildPartial();
                            continue;
                        }
                        case 0x3a:
                        {
                            PowerHistoryEnd.Builder builder7 = PowerHistoryEnd.CreateBuilder();
                            if (this.result.hasPowerEnd)
                            {
                                builder7.MergeFrom(this.PowerEnd);
                            }
                            input.ReadMessage(builder7, extensionRegistry);
                            this.PowerEnd = builder7.BuildPartial();
                            continue;
                        }
                        case 0x42:
                        {
                            PowerHistoryMetaData.Builder builder8 = PowerHistoryMetaData.CreateBuilder();
                            if (this.result.hasMetaData)
                            {
                                builder8.MergeFrom(this.MetaData);
                            }
                            input.ReadMessage(builder8, extensionRegistry);
                            this.MetaData = builder8.BuildPartial();
                            continue;
                        }
                    }
                    if (WireFormat.IsEndGroupTag(num))
                    {
                        return this;
                    }
                    this.ParseUnknownField(input, extensionRegistry, num, str);
                }
                return this;
            }

            public PowerHistoryData.Builder MergeFullEntity(PowerHistoryEntity value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasFullEntity && (this.result.fullEntity_ != PowerHistoryEntity.DefaultInstance))
                {
                    this.result.fullEntity_ = PowerHistoryEntity.CreateBuilder(this.result.fullEntity_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.fullEntity_ = value;
                }
                this.result.hasFullEntity = true;
                return this;
            }

            public PowerHistoryData.Builder MergeHideEntity(PowerHistoryHide value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasHideEntity && (this.result.hideEntity_ != PowerHistoryHide.DefaultInstance))
                {
                    this.result.hideEntity_ = PowerHistoryHide.CreateBuilder(this.result.hideEntity_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.hideEntity_ = value;
                }
                this.result.hasHideEntity = true;
                return this;
            }

            public PowerHistoryData.Builder MergeMetaData(PowerHistoryMetaData value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasMetaData && (this.result.metaData_ != PowerHistoryMetaData.DefaultInstance))
                {
                    this.result.metaData_ = PowerHistoryMetaData.CreateBuilder(this.result.metaData_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.metaData_ = value;
                }
                this.result.hasMetaData = true;
                return this;
            }

            public PowerHistoryData.Builder MergePowerEnd(PowerHistoryEnd value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasPowerEnd && (this.result.powerEnd_ != PowerHistoryEnd.DefaultInstance))
                {
                    this.result.powerEnd_ = PowerHistoryEnd.CreateBuilder(this.result.powerEnd_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.powerEnd_ = value;
                }
                this.result.hasPowerEnd = true;
                return this;
            }

            public PowerHistoryData.Builder MergePowerStart(PowerHistoryStart value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasPowerStart && (this.result.powerStart_ != PowerHistoryStart.DefaultInstance))
                {
                    this.result.powerStart_ = PowerHistoryStart.CreateBuilder(this.result.powerStart_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.powerStart_ = value;
                }
                this.result.hasPowerStart = true;
                return this;
            }

            public PowerHistoryData.Builder MergeShowEntity(PowerHistoryEntity value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasShowEntity && (this.result.showEntity_ != PowerHistoryEntity.DefaultInstance))
                {
                    this.result.showEntity_ = PowerHistoryEntity.CreateBuilder(this.result.showEntity_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.showEntity_ = value;
                }
                this.result.hasShowEntity = true;
                return this;
            }

            public PowerHistoryData.Builder MergeTagChange(PowerHistoryTagChange value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasTagChange && (this.result.tagChange_ != PowerHistoryTagChange.DefaultInstance))
                {
                    this.result.tagChange_ = PowerHistoryTagChange.CreateBuilder(this.result.tagChange_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.tagChange_ = value;
                }
                this.result.hasTagChange = true;
                return this;
            }

            private PowerHistoryData PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    PowerHistoryData result = this.result;
                    this.result = new PowerHistoryData();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public PowerHistoryData.Builder SetCreateGame(PowerHistoryCreateGame value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasCreateGame = true;
                this.result.createGame_ = value;
                return this;
            }

            public PowerHistoryData.Builder SetCreateGame(PowerHistoryCreateGame.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasCreateGame = true;
                this.result.createGame_ = builderForValue.Build();
                return this;
            }

            public PowerHistoryData.Builder SetFullEntity(PowerHistoryEntity value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasFullEntity = true;
                this.result.fullEntity_ = value;
                return this;
            }

            public PowerHistoryData.Builder SetFullEntity(PowerHistoryEntity.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasFullEntity = true;
                this.result.fullEntity_ = builderForValue.Build();
                return this;
            }

            public PowerHistoryData.Builder SetHideEntity(PowerHistoryHide value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasHideEntity = true;
                this.result.hideEntity_ = value;
                return this;
            }

            public PowerHistoryData.Builder SetHideEntity(PowerHistoryHide.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasHideEntity = true;
                this.result.hideEntity_ = builderForValue.Build();
                return this;
            }

            public PowerHistoryData.Builder SetMetaData(PowerHistoryMetaData value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasMetaData = true;
                this.result.metaData_ = value;
                return this;
            }

            public PowerHistoryData.Builder SetMetaData(PowerHistoryMetaData.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasMetaData = true;
                this.result.metaData_ = builderForValue.Build();
                return this;
            }

            public PowerHistoryData.Builder SetPowerEnd(PowerHistoryEnd value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasPowerEnd = true;
                this.result.powerEnd_ = value;
                return this;
            }

            public PowerHistoryData.Builder SetPowerEnd(PowerHistoryEnd.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasPowerEnd = true;
                this.result.powerEnd_ = builderForValue.Build();
                return this;
            }

            public PowerHistoryData.Builder SetPowerStart(PowerHistoryStart value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasPowerStart = true;
                this.result.powerStart_ = value;
                return this;
            }

            public PowerHistoryData.Builder SetPowerStart(PowerHistoryStart.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasPowerStart = true;
                this.result.powerStart_ = builderForValue.Build();
                return this;
            }

            public PowerHistoryData.Builder SetShowEntity(PowerHistoryEntity value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasShowEntity = true;
                this.result.showEntity_ = value;
                return this;
            }

            public PowerHistoryData.Builder SetShowEntity(PowerHistoryEntity.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasShowEntity = true;
                this.result.showEntity_ = builderForValue.Build();
                return this;
            }

            public PowerHistoryData.Builder SetTagChange(PowerHistoryTagChange value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasTagChange = true;
                this.result.tagChange_ = value;
                return this;
            }

            public PowerHistoryData.Builder SetTagChange(PowerHistoryTagChange.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasTagChange = true;
                this.result.tagChange_ = builderForValue.Build();
                return this;
            }

            public PowerHistoryCreateGame CreateGame
            {
                get
                {
                    return this.result.CreateGame;
                }
                set
                {
                    this.SetCreateGame(value);
                }
            }

            public override PowerHistoryData DefaultInstanceForType
            {
                get
                {
                    return PowerHistoryData.DefaultInstance;
                }
            }

            public PowerHistoryEntity FullEntity
            {
                get
                {
                    return this.result.FullEntity;
                }
                set
                {
                    this.SetFullEntity(value);
                }
            }

            public bool HasCreateGame
            {
                get
                {
                    return this.result.hasCreateGame;
                }
            }

            public bool HasFullEntity
            {
                get
                {
                    return this.result.hasFullEntity;
                }
            }

            public bool HasHideEntity
            {
                get
                {
                    return this.result.hasHideEntity;
                }
            }

            public bool HasMetaData
            {
                get
                {
                    return this.result.hasMetaData;
                }
            }

            public bool HasPowerEnd
            {
                get
                {
                    return this.result.hasPowerEnd;
                }
            }

            public bool HasPowerStart
            {
                get
                {
                    return this.result.hasPowerStart;
                }
            }

            public bool HasShowEntity
            {
                get
                {
                    return this.result.hasShowEntity;
                }
            }

            public bool HasTagChange
            {
                get
                {
                    return this.result.hasTagChange;
                }
            }

            public PowerHistoryHide HideEntity
            {
                get
                {
                    return this.result.HideEntity;
                }
                set
                {
                    this.SetHideEntity(value);
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override PowerHistoryData MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public PowerHistoryMetaData MetaData
            {
                get
                {
                    return this.result.MetaData;
                }
                set
                {
                    this.SetMetaData(value);
                }
            }

            public PowerHistoryEnd PowerEnd
            {
                get
                {
                    return this.result.PowerEnd;
                }
                set
                {
                    this.SetPowerEnd(value);
                }
            }

            public PowerHistoryStart PowerStart
            {
                get
                {
                    return this.result.PowerStart;
                }
                set
                {
                    this.SetPowerStart(value);
                }
            }

            public PowerHistoryEntity ShowEntity
            {
                get
                {
                    return this.result.ShowEntity;
                }
                set
                {
                    this.SetShowEntity(value);
                }
            }

            public PowerHistoryTagChange TagChange
            {
                get
                {
                    return this.result.TagChange;
                }
                set
                {
                    this.SetTagChange(value);
                }
            }

            protected override PowerHistoryData.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

