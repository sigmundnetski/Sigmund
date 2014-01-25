namespace PegasusGame
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class PowerHistoryHide : GeneratedMessageLite<PowerHistoryHide, Builder>
    {
        private static readonly string[] _powerHistoryHideFieldNames = new string[] { "entity", "zone" };
        private static readonly uint[] _powerHistoryHideFieldTags = new uint[] { 8, 0x10 };
        private static readonly PowerHistoryHide defaultInstance = new PowerHistoryHide().MakeReadOnly();
        private int entity_;
        public const int EntityFieldNumber = 1;
        private bool hasEntity;
        private bool hasZone;
        private int memoizedSerializedSize = -1;
        private int zone_;
        public const int ZoneFieldNumber = 2;

        static PowerHistoryHide()
        {
            object.ReferenceEquals(PegasusGamelite.Descriptor, null);
        }

        private PowerHistoryHide()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(PowerHistoryHide prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            PowerHistoryHide hide = obj as PowerHistoryHide;
            if (hide == null)
            {
                return false;
            }
            if ((this.hasEntity != hide.hasEntity) || (this.hasEntity && !this.entity_.Equals(hide.entity_)))
            {
                return false;
            }
            return ((this.hasZone == hide.hasZone) && (!this.hasZone || this.zone_.Equals(hide.zone_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasEntity)
            {
                hashCode ^= this.entity_.GetHashCode();
            }
            if (this.hasZone)
            {
                hashCode ^= this.zone_.GetHashCode();
            }
            return hashCode;
        }

        private PowerHistoryHide MakeReadOnly()
        {
            return this;
        }

        public static PowerHistoryHide ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static PowerHistoryHide ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static PowerHistoryHide ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static PowerHistoryHide ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static PowerHistoryHide ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static PowerHistoryHide ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static PowerHistoryHide ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static PowerHistoryHide ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static PowerHistoryHide ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static PowerHistoryHide ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<PowerHistoryHide, Builder>.PrintField("entity", this.hasEntity, this.entity_, writer);
            GeneratedMessageLite<PowerHistoryHide, Builder>.PrintField("zone", this.hasZone, this.zone_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _powerHistoryHideFieldNames;
            if (this.hasEntity)
            {
                output.WriteInt32(1, strArray[0], this.Entity);
            }
            if (this.hasZone)
            {
                output.WriteInt32(2, strArray[1], this.Zone);
            }
        }

        public static PowerHistoryHide DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override PowerHistoryHide DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public int Entity
        {
            get
            {
                return this.entity_;
            }
        }

        public bool HasEntity
        {
            get
            {
                return this.hasEntity;
            }
        }

        public bool HasZone
        {
            get
            {
                return this.hasZone;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasEntity)
                {
                    return false;
                }
                if (!this.hasZone)
                {
                    return false;
                }
                return true;
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
                    if (this.hasEntity)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.Entity);
                    }
                    if (this.hasZone)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.Zone);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override PowerHistoryHide ThisMessage
        {
            get
            {
                return this;
            }
        }

        public int Zone
        {
            get
            {
                return this.zone_;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<PowerHistoryHide, PowerHistoryHide.Builder>
        {
            private PowerHistoryHide result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = PowerHistoryHide.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(PowerHistoryHide cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override PowerHistoryHide BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override PowerHistoryHide.Builder Clear()
            {
                this.result = PowerHistoryHide.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public PowerHistoryHide.Builder ClearEntity()
            {
                this.PrepareBuilder();
                this.result.hasEntity = false;
                this.result.entity_ = 0;
                return this;
            }

            public PowerHistoryHide.Builder ClearZone()
            {
                this.PrepareBuilder();
                this.result.hasZone = false;
                this.result.zone_ = 0;
                return this;
            }

            public override PowerHistoryHide.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new PowerHistoryHide.Builder(this.result);
                }
                return new PowerHistoryHide.Builder().MergeFrom(this.result);
            }

            public override PowerHistoryHide.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override PowerHistoryHide.Builder MergeFrom(IMessageLite other)
            {
                if (other is PowerHistoryHide)
                {
                    return this.MergeFrom((PowerHistoryHide) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override PowerHistoryHide.Builder MergeFrom(PowerHistoryHide other)
            {
                if (other != PowerHistoryHide.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasEntity)
                    {
                        this.Entity = other.Entity;
                    }
                    if (other.HasZone)
                    {
                        this.Zone = other.Zone;
                    }
                }
                return this;
            }

            public override PowerHistoryHide.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(PowerHistoryHide._powerHistoryHideFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = PowerHistoryHide._powerHistoryHideFieldTags[index];
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
                            this.result.hasEntity = input.ReadInt32(ref this.result.entity_);
                            continue;
                        }
                        case 0x10:
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
                    this.result.hasZone = input.ReadInt32(ref this.result.zone_);
                }
                return this;
            }

            private PowerHistoryHide PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    PowerHistoryHide result = this.result;
                    this.result = new PowerHistoryHide();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public PowerHistoryHide.Builder SetEntity(int value)
            {
                this.PrepareBuilder();
                this.result.hasEntity = true;
                this.result.entity_ = value;
                return this;
            }

            public PowerHistoryHide.Builder SetZone(int value)
            {
                this.PrepareBuilder();
                this.result.hasZone = true;
                this.result.zone_ = value;
                return this;
            }

            public override PowerHistoryHide DefaultInstanceForType
            {
                get
                {
                    return PowerHistoryHide.DefaultInstance;
                }
            }

            public int Entity
            {
                get
                {
                    return this.result.Entity;
                }
                set
                {
                    this.SetEntity(value);
                }
            }

            public bool HasEntity
            {
                get
                {
                    return this.result.hasEntity;
                }
            }

            public bool HasZone
            {
                get
                {
                    return this.result.hasZone;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override PowerHistoryHide MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override PowerHistoryHide.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            public int Zone
            {
                get
                {
                    return this.result.Zone;
                }
                set
                {
                    this.SetZone(value);
                }
            }
        }
    }
}

