namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Collections;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class DebugConsoleZones : GeneratedMessageLite<DebugConsoleZones, Builder>
    {
        private static readonly string[] _debugConsoleZonesFieldNames = new string[] { "zones" };
        private static readonly uint[] _debugConsoleZonesFieldTags = new uint[] { 10 };
        private static readonly DebugConsoleZones defaultInstance = new DebugConsoleZones().MakeReadOnly();
        private int memoizedSerializedSize = -1;
        private PopsicleList<Types.DebugConsoleZone> zones_ = new PopsicleList<Types.DebugConsoleZone>();
        public const int ZonesFieldNumber = 1;

        static DebugConsoleZones()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private DebugConsoleZones()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(DebugConsoleZones prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            DebugConsoleZones zones = obj as DebugConsoleZones;
            if (zones == null)
            {
                return false;
            }
            if (this.zones_.Count != zones.zones_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.zones_.Count; i++)
            {
                if (!this.zones_[i].Equals(zones.zones_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            IEnumerator<Types.DebugConsoleZone> enumerator = this.zones_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    Types.DebugConsoleZone current = enumerator.Current;
                    hashCode ^= current.GetHashCode();
                }
            }
            finally
            {
                if (enumerator == null)
                {
                }
                enumerator.Dispose();
            }
            return hashCode;
        }

        public Types.DebugConsoleZone GetZones(int index)
        {
            return this.zones_[index];
        }

        private DebugConsoleZones MakeReadOnly()
        {
            this.zones_.MakeReadOnly();
            return this;
        }

        public static DebugConsoleZones ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static DebugConsoleZones ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static DebugConsoleZones ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DebugConsoleZones ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DebugConsoleZones ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DebugConsoleZones ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DebugConsoleZones ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static DebugConsoleZones ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DebugConsoleZones ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DebugConsoleZones ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<DebugConsoleZones, Builder>.PrintField<Types.DebugConsoleZone>("zones", this.zones_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _debugConsoleZonesFieldNames;
            if (this.zones_.Count > 0)
            {
                output.WriteMessageArray<Types.DebugConsoleZone>(1, strArray[0], this.zones_);
            }
        }

        public static DebugConsoleZones DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override DebugConsoleZones DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                IEnumerator<Types.DebugConsoleZone> enumerator = this.ZonesList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        Types.DebugConsoleZone current = enumerator.Current;
                        if (!current.IsInitialized)
                        {
                            return false;
                        }
                    }
                }
                finally
                {
                    if (enumerator == null)
                    {
                    }
                    enumerator.Dispose();
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
                    IEnumerator<Types.DebugConsoleZone> enumerator = this.ZonesList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            Types.DebugConsoleZone current = enumerator.Current;
                            memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, current);
                        }
                    }
                    finally
                    {
                        if (enumerator == null)
                        {
                        }
                        enumerator.Dispose();
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override DebugConsoleZones ThisMessage
        {
            get
            {
                return this;
            }
        }

        public int ZonesCount
        {
            get
            {
                return this.zones_.Count;
            }
        }

        public IList<Types.DebugConsoleZone> ZonesList
        {
            get
            {
                return this.zones_;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<DebugConsoleZones, DebugConsoleZones.Builder>
        {
            private DebugConsoleZones result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = DebugConsoleZones.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(DebugConsoleZones cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public DebugConsoleZones.Builder AddRangeZones(IEnumerable<DebugConsoleZones.Types.DebugConsoleZone> values)
            {
                this.PrepareBuilder();
                this.result.zones_.Add(values);
                return this;
            }

            public DebugConsoleZones.Builder AddZones(DebugConsoleZones.Types.DebugConsoleZone value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.zones_.Add(value);
                return this;
            }

            public DebugConsoleZones.Builder AddZones(DebugConsoleZones.Types.DebugConsoleZone.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.zones_.Add(builderForValue.Build());
                return this;
            }

            public override DebugConsoleZones BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override DebugConsoleZones.Builder Clear()
            {
                this.result = DebugConsoleZones.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public DebugConsoleZones.Builder ClearZones()
            {
                this.PrepareBuilder();
                this.result.zones_.Clear();
                return this;
            }

            public override DebugConsoleZones.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new DebugConsoleZones.Builder(this.result);
                }
                return new DebugConsoleZones.Builder().MergeFrom(this.result);
            }

            public DebugConsoleZones.Types.DebugConsoleZone GetZones(int index)
            {
                return this.result.GetZones(index);
            }

            public override DebugConsoleZones.Builder MergeFrom(DebugConsoleZones other)
            {
                if (other != DebugConsoleZones.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.zones_.Count != 0)
                    {
                        this.result.zones_.Add(other.zones_);
                    }
                }
                return this;
            }

            public override DebugConsoleZones.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override DebugConsoleZones.Builder MergeFrom(IMessageLite other)
            {
                if (other is DebugConsoleZones)
                {
                    return this.MergeFrom((DebugConsoleZones) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override DebugConsoleZones.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(DebugConsoleZones._debugConsoleZonesFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = DebugConsoleZones._debugConsoleZonesFieldTags[index];
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
                    input.ReadMessageArray<DebugConsoleZones.Types.DebugConsoleZone>(num, str, this.result.zones_, DebugConsoleZones.Types.DebugConsoleZone.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private DebugConsoleZones PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    DebugConsoleZones result = this.result;
                    this.result = new DebugConsoleZones();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public DebugConsoleZones.Builder SetZones(int index, DebugConsoleZones.Types.DebugConsoleZone value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.zones_[index] = value;
                return this;
            }

            public DebugConsoleZones.Builder SetZones(int index, DebugConsoleZones.Types.DebugConsoleZone.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.zones_[index] = builderForValue.Build();
                return this;
            }

            public override DebugConsoleZones DefaultInstanceForType
            {
                get
                {
                    return DebugConsoleZones.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override DebugConsoleZones MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override DebugConsoleZones.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            public int ZonesCount
            {
                get
                {
                    return this.result.ZonesCount;
                }
            }

            public IPopsicleList<DebugConsoleZones.Types.DebugConsoleZone> ZonesList
            {
                get
                {
                    return this.PrepareBuilder().zones_;
                }
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public static class Types
        {
            [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
            public sealed class DebugConsoleZone : GeneratedMessageLite<DebugConsoleZones.Types.DebugConsoleZone, Builder>
            {
                private static readonly string[] _debugConsoleZoneFieldNames = new string[] { "id", "name" };
                private static readonly uint[] _debugConsoleZoneFieldTags = new uint[] { 0x10, 10 };
                private static readonly DebugConsoleZones.Types.DebugConsoleZone defaultInstance = new DebugConsoleZones.Types.DebugConsoleZone().MakeReadOnly();
                private bool hasId;
                private bool hasName;
                private uint id_;
                public const int IdFieldNumber = 2;
                private int memoizedSerializedSize = -1;
                private string name_ = string.Empty;
                public const int NameFieldNumber = 1;

                static DebugConsoleZone()
                {
                    object.ReferenceEquals(BobNetlite.Descriptor, null);
                }

                private DebugConsoleZone()
                {
                }

                public static Builder CreateBuilder()
                {
                    return new Builder();
                }

                public static Builder CreateBuilder(DebugConsoleZones.Types.DebugConsoleZone prototype)
                {
                    return new Builder(prototype);
                }

                public override Builder CreateBuilderForType()
                {
                    return new Builder();
                }

                public override bool Equals(object obj)
                {
                    DebugConsoleZones.Types.DebugConsoleZone zone = obj as DebugConsoleZones.Types.DebugConsoleZone;
                    if (zone == null)
                    {
                        return false;
                    }
                    if ((this.hasName != zone.hasName) || (this.hasName && !this.name_.Equals(zone.name_)))
                    {
                        return false;
                    }
                    return ((this.hasId == zone.hasId) && (!this.hasId || this.id_.Equals(zone.id_)));
                }

                public override int GetHashCode()
                {
                    int hashCode = base.GetType().GetHashCode();
                    if (this.hasName)
                    {
                        hashCode ^= this.name_.GetHashCode();
                    }
                    if (this.hasId)
                    {
                        hashCode ^= this.id_.GetHashCode();
                    }
                    return hashCode;
                }

                private DebugConsoleZones.Types.DebugConsoleZone MakeReadOnly()
                {
                    return this;
                }

                public static DebugConsoleZones.Types.DebugConsoleZone ParseDelimitedFrom(Stream input)
                {
                    return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
                }

                public static DebugConsoleZones.Types.DebugConsoleZone ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
                {
                    return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
                }

                public static DebugConsoleZones.Types.DebugConsoleZone ParseFrom(byte[] data)
                {
                    return CreateBuilder().MergeFrom(data).BuildParsed();
                }

                public static DebugConsoleZones.Types.DebugConsoleZone ParseFrom(ByteString data)
                {
                    return CreateBuilder().MergeFrom(data).BuildParsed();
                }

                public static DebugConsoleZones.Types.DebugConsoleZone ParseFrom(ICodedInputStream input)
                {
                    return CreateBuilder().MergeFrom(input).BuildParsed();
                }

                public static DebugConsoleZones.Types.DebugConsoleZone ParseFrom(Stream input)
                {
                    return CreateBuilder().MergeFrom(input).BuildParsed();
                }

                public static DebugConsoleZones.Types.DebugConsoleZone ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
                {
                    return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
                }

                public static DebugConsoleZones.Types.DebugConsoleZone ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
                {
                    return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
                }

                public static DebugConsoleZones.Types.DebugConsoleZone ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
                {
                    return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
                }

                public static DebugConsoleZones.Types.DebugConsoleZone ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
                {
                    return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
                }

                public override void PrintTo(TextWriter writer)
                {
                    GeneratedMessageLite<DebugConsoleZones.Types.DebugConsoleZone, Builder>.PrintField("name", this.hasName, this.name_, writer);
                    GeneratedMessageLite<DebugConsoleZones.Types.DebugConsoleZone, Builder>.PrintField("id", this.hasId, this.id_, writer);
                }

                public override Builder ToBuilder()
                {
                    return CreateBuilder(this);
                }

                public override void WriteTo(ICodedOutputStream output)
                {
                    int serializedSize = this.SerializedSize;
                    string[] strArray = _debugConsoleZoneFieldNames;
                    if (this.hasName)
                    {
                        output.WriteString(1, strArray[1], this.Name);
                    }
                    if (this.hasId)
                    {
                        output.WriteUInt32(2, strArray[0], this.Id);
                    }
                }

                public static DebugConsoleZones.Types.DebugConsoleZone DefaultInstance
                {
                    get
                    {
                        return defaultInstance;
                    }
                }

                public override DebugConsoleZones.Types.DebugConsoleZone DefaultInstanceForType
                {
                    get
                    {
                        return DefaultInstance;
                    }
                }

                public bool HasId
                {
                    get
                    {
                        return this.hasId;
                    }
                }

                public bool HasName
                {
                    get
                    {
                        return this.hasName;
                    }
                }

                [CLSCompliant(false)]
                public uint Id
                {
                    get
                    {
                        return this.id_;
                    }
                }

                public override bool IsInitialized
                {
                    get
                    {
                        if (!this.hasName)
                        {
                            return false;
                        }
                        if (!this.hasId)
                        {
                            return false;
                        }
                        return true;
                    }
                }

                public string Name
                {
                    get
                    {
                        return this.name_;
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
                            if (this.hasName)
                            {
                                memoizedSerializedSize += CodedOutputStream.ComputeStringSize(1, this.Name);
                            }
                            if (this.hasId)
                            {
                                memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(2, this.Id);
                            }
                            this.memoizedSerializedSize = memoizedSerializedSize;
                        }
                        return memoizedSerializedSize;
                    }
                }

                protected override DebugConsoleZones.Types.DebugConsoleZone ThisMessage
                {
                    get
                    {
                        return this;
                    }
                }

                [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
                public sealed class Builder : GeneratedBuilderLite<DebugConsoleZones.Types.DebugConsoleZone, DebugConsoleZones.Types.DebugConsoleZone.Builder>
                {
                    private DebugConsoleZones.Types.DebugConsoleZone result;
                    private bool resultIsReadOnly;

                    public Builder()
                    {
                        this.result = DebugConsoleZones.Types.DebugConsoleZone.DefaultInstance;
                        this.resultIsReadOnly = true;
                    }

                    internal Builder(DebugConsoleZones.Types.DebugConsoleZone cloneFrom)
                    {
                        this.result = cloneFrom;
                        this.resultIsReadOnly = true;
                    }

                    public override DebugConsoleZones.Types.DebugConsoleZone BuildPartial()
                    {
                        if (this.resultIsReadOnly)
                        {
                            return this.result;
                        }
                        this.resultIsReadOnly = true;
                        return this.result.MakeReadOnly();
                    }

                    public override DebugConsoleZones.Types.DebugConsoleZone.Builder Clear()
                    {
                        this.result = DebugConsoleZones.Types.DebugConsoleZone.DefaultInstance;
                        this.resultIsReadOnly = true;
                        return this;
                    }

                    public DebugConsoleZones.Types.DebugConsoleZone.Builder ClearId()
                    {
                        this.PrepareBuilder();
                        this.result.hasId = false;
                        this.result.id_ = 0;
                        return this;
                    }

                    public DebugConsoleZones.Types.DebugConsoleZone.Builder ClearName()
                    {
                        this.PrepareBuilder();
                        this.result.hasName = false;
                        this.result.name_ = string.Empty;
                        return this;
                    }

                    public override DebugConsoleZones.Types.DebugConsoleZone.Builder Clone()
                    {
                        if (this.resultIsReadOnly)
                        {
                            return new DebugConsoleZones.Types.DebugConsoleZone.Builder(this.result);
                        }
                        return new DebugConsoleZones.Types.DebugConsoleZone.Builder().MergeFrom(this.result);
                    }

                    public override DebugConsoleZones.Types.DebugConsoleZone.Builder MergeFrom(DebugConsoleZones.Types.DebugConsoleZone other)
                    {
                        if (other != DebugConsoleZones.Types.DebugConsoleZone.DefaultInstance)
                        {
                            this.PrepareBuilder();
                            if (other.HasName)
                            {
                                this.Name = other.Name;
                            }
                            if (other.HasId)
                            {
                                this.Id = other.Id;
                            }
                        }
                        return this;
                    }

                    public override DebugConsoleZones.Types.DebugConsoleZone.Builder MergeFrom(ICodedInputStream input)
                    {
                        return this.MergeFrom(input, ExtensionRegistry.Empty);
                    }

                    public override DebugConsoleZones.Types.DebugConsoleZone.Builder MergeFrom(IMessageLite other)
                    {
                        if (other is DebugConsoleZones.Types.DebugConsoleZone)
                        {
                            return this.MergeFrom((DebugConsoleZones.Types.DebugConsoleZone) other);
                        }
                        base.MergeFrom(other);
                        return this;
                    }

                    public override DebugConsoleZones.Types.DebugConsoleZone.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
                    {
                        uint num;
                        string str;
                        this.PrepareBuilder();
                        while (input.ReadTag(out num, out str))
                        {
                            if ((num == 0) && (str != null))
                            {
                                int index = Array.BinarySearch<string>(DebugConsoleZones.Types.DebugConsoleZone._debugConsoleZoneFieldNames, str, StringComparer.Ordinal);
                                if (index >= 0)
                                {
                                    num = DebugConsoleZones.Types.DebugConsoleZone._debugConsoleZoneFieldTags[index];
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
                                    this.result.hasName = input.ReadString(ref this.result.name_);
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
                            this.result.hasId = input.ReadUInt32(ref this.result.id_);
                        }
                        return this;
                    }

                    private DebugConsoleZones.Types.DebugConsoleZone PrepareBuilder()
                    {
                        if (this.resultIsReadOnly)
                        {
                            DebugConsoleZones.Types.DebugConsoleZone result = this.result;
                            this.result = new DebugConsoleZones.Types.DebugConsoleZone();
                            this.resultIsReadOnly = false;
                            this.MergeFrom(result);
                        }
                        return this.result;
                    }

                    [CLSCompliant(false)]
                    public DebugConsoleZones.Types.DebugConsoleZone.Builder SetId(uint value)
                    {
                        this.PrepareBuilder();
                        this.result.hasId = true;
                        this.result.id_ = value;
                        return this;
                    }

                    public DebugConsoleZones.Types.DebugConsoleZone.Builder SetName(string value)
                    {
                        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                        this.PrepareBuilder();
                        this.result.hasName = true;
                        this.result.name_ = value;
                        return this;
                    }

                    public override DebugConsoleZones.Types.DebugConsoleZone DefaultInstanceForType
                    {
                        get
                        {
                            return DebugConsoleZones.Types.DebugConsoleZone.DefaultInstance;
                        }
                    }

                    public bool HasId
                    {
                        get
                        {
                            return this.result.hasId;
                        }
                    }

                    public bool HasName
                    {
                        get
                        {
                            return this.result.hasName;
                        }
                    }

                    [CLSCompliant(false)]
                    public uint Id
                    {
                        get
                        {
                            return this.result.Id;
                        }
                        set
                        {
                            this.SetId(value);
                        }
                    }

                    public override bool IsInitialized
                    {
                        get
                        {
                            return this.result.IsInitialized;
                        }
                    }

                    protected override DebugConsoleZones.Types.DebugConsoleZone MessageBeingBuilt
                    {
                        get
                        {
                            return this.PrepareBuilder();
                        }
                    }

                    public string Name
                    {
                        get
                        {
                            return this.result.Name;
                        }
                        set
                        {
                            this.SetName(value);
                        }
                    }

                    protected override DebugConsoleZones.Types.DebugConsoleZone.Builder ThisBuilder
                    {
                        get
                        {
                            return this;
                        }
                    }
                }
            }

            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 0x94
            }
        }
    }
}

