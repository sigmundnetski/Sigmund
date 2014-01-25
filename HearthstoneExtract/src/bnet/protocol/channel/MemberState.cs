namespace bnet.protocol.channel
{
    using bnet.protocol;
    using bnet.protocol.attribute;
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Collections;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class MemberState : ExtendableMessageLite<MemberState, Builder>
    {
        private static readonly string[] _memberStateFieldNames = new string[] { "attribute", "info", "privileges", "role" };
        private static readonly uint[] _memberStateFieldTags = new uint[] { 10, 0x22, 0x18, 0x12 };
        private PopsicleList<bnet.protocol.attribute.Attribute> attribute_ = new PopsicleList<bnet.protocol.attribute.Attribute>();
        public const int AttributeFieldNumber = 1;
        private static readonly MemberState defaultInstance = new MemberState().MakeReadOnly();
        private bool hasInfo;
        private bool hasPrivileges;
        private AccountInfo info_;
        public const int InfoFieldNumber = 4;
        private int memoizedSerializedSize = -1;
        private ulong privileges_;
        public const int PrivilegesFieldNumber = 3;
        private PopsicleList<uint> role_ = new PopsicleList<uint>();
        public const int RoleFieldNumber = 2;
        private int roleMemoizedSerializedSize;

        static MemberState()
        {
            object.ReferenceEquals(ChannelTypes.Descriptor, null);
        }

        private MemberState()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(MemberState prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            MemberState state = obj as MemberState;
            if (state == null)
            {
                return false;
            }
            if (this.attribute_.Count != state.attribute_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.attribute_.Count; i++)
            {
                if (!this.attribute_[i].Equals(state.attribute_[i]))
                {
                    return false;
                }
            }
            if (this.role_.Count != state.role_.Count)
            {
                return false;
            }
            for (int j = 0; j < this.role_.Count; j++)
            {
                uint num3 = this.role_[j];
                if (!num3.Equals(state.role_[j]))
                {
                    return false;
                }
            }
            if ((this.hasPrivileges != state.hasPrivileges) || (this.hasPrivileges && !this.privileges_.Equals(state.privileges_)))
            {
                return false;
            }
            if ((this.hasInfo != state.hasInfo) || (this.hasInfo && !this.info_.Equals(state.info_)))
            {
                return false;
            }
            if (!base.Equals(state))
            {
                return false;
            }
            return true;
        }

        public bnet.protocol.attribute.Attribute GetAttribute(int index)
        {
            return this.attribute_[index];
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            IEnumerator<bnet.protocol.attribute.Attribute> enumerator = this.attribute_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    bnet.protocol.attribute.Attribute current = enumerator.Current;
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
            IEnumerator<uint> enumerator2 = this.role_.GetEnumerator();
            try
            {
                while (enumerator2.MoveNext())
                {
                    uint num2 = enumerator2.Current;
                    hashCode ^= num2.GetHashCode();
                }
            }
            finally
            {
                if (enumerator2 == null)
                {
                }
                enumerator2.Dispose();
            }
            if (this.hasPrivileges)
            {
                hashCode ^= this.privileges_.GetHashCode();
            }
            if (this.hasInfo)
            {
                hashCode ^= this.info_.GetHashCode();
            }
            return (hashCode ^ base.GetHashCode());
        }

        [CLSCompliant(false)]
        public uint GetRole(int index)
        {
            return this.role_[index];
        }

        private MemberState MakeReadOnly()
        {
            this.attribute_.MakeReadOnly();
            this.role_.MakeReadOnly();
            return this;
        }

        public static MemberState ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static MemberState ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static MemberState ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static MemberState ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static MemberState ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static MemberState ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static MemberState ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static MemberState ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static MemberState ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static MemberState ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<MemberState, Builder>.PrintField<bnet.protocol.attribute.Attribute>("attribute", this.attribute_, writer);
            GeneratedMessageLite<MemberState, Builder>.PrintField<uint>("role", this.role_, writer);
            GeneratedMessageLite<MemberState, Builder>.PrintField("privileges", this.hasPrivileges, this.privileges_, writer);
            GeneratedMessageLite<MemberState, Builder>.PrintField("info", this.hasInfo, this.info_, writer);
            base.PrintTo(writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _memberStateFieldNames;
            ExtendableMessageLite<MemberState, Builder>.ExtensionWriter writer = base.CreateExtensionWriter(this);
            if (this.attribute_.Count > 0)
            {
                output.WriteMessageArray<bnet.protocol.attribute.Attribute>(1, strArray[0], this.attribute_);
            }
            if (this.role_.Count > 0)
            {
                output.WritePackedUInt32Array(2, strArray[3], this.roleMemoizedSerializedSize, this.role_);
            }
            if (this.hasPrivileges)
            {
                output.WriteUInt64(3, strArray[2], this.Privileges);
            }
            if (this.hasInfo)
            {
                output.WriteMessage(4, strArray[1], this.Info);
            }
            writer.WriteUntil(0x2710, output);
        }

        public int AttributeCount
        {
            get
            {
                return this.attribute_.Count;
            }
        }

        public IList<bnet.protocol.attribute.Attribute> AttributeList
        {
            get
            {
                return this.attribute_;
            }
        }

        public static MemberState DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override MemberState DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasInfo
        {
            get
            {
                return this.hasInfo;
            }
        }

        public bool HasPrivileges
        {
            get
            {
                return this.hasPrivileges;
            }
        }

        public AccountInfo Info
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.info_ != null)
                {
                    goto Label_0012;
                }
                return AccountInfo.DefaultInstance;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                IEnumerator<bnet.protocol.attribute.Attribute> enumerator = this.AttributeList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        bnet.protocol.attribute.Attribute current = enumerator.Current;
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
                if (!base.ExtensionsAreInitialized)
                {
                    return false;
                }
                return true;
            }
        }

        [CLSCompliant(false)]
        public ulong Privileges
        {
            get
            {
                return this.privileges_;
            }
        }

        public int RoleCount
        {
            get
            {
                return this.role_.Count;
            }
        }

        [CLSCompliant(false)]
        public IList<uint> RoleList
        {
            get
            {
                return Lists.AsReadOnly<uint>(this.role_);
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
                    IEnumerator<bnet.protocol.attribute.Attribute> enumerator = this.AttributeList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            bnet.protocol.attribute.Attribute current = enumerator.Current;
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
                    int num2 = 0;
                    IEnumerator<uint> enumerator2 = this.RoleList.GetEnumerator();
                    try
                    {
                        while (enumerator2.MoveNext())
                        {
                            uint num3 = enumerator2.Current;
                            num2 += CodedOutputStream.ComputeUInt32SizeNoTag(num3);
                        }
                    }
                    finally
                    {
                        if (enumerator2 == null)
                        {
                        }
                        enumerator2.Dispose();
                    }
                    memoizedSerializedSize += num2;
                    if (this.role_.Count != 0)
                    {
                        memoizedSerializedSize += 1 + CodedOutputStream.ComputeInt32SizeNoTag(num2);
                    }
                    this.roleMemoizedSerializedSize = num2;
                    if (this.hasPrivileges)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt64Size(3, this.Privileges);
                    }
                    if (this.hasInfo)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(4, this.Info);
                    }
                    memoizedSerializedSize += base.ExtensionsSerializedSize;
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override MemberState ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : ExtendableBuilderLite<MemberState, MemberState.Builder>
        {
            private MemberState result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = MemberState.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(MemberState cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public MemberState.Builder AddAttribute(bnet.protocol.attribute.Attribute value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.attribute_.Add(value);
                return this;
            }

            public MemberState.Builder AddAttribute(bnet.protocol.attribute.Attribute.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.attribute_.Add(builderForValue.Build());
                return this;
            }

            public MemberState.Builder AddRangeAttribute(IEnumerable<bnet.protocol.attribute.Attribute> values)
            {
                this.PrepareBuilder();
                this.result.attribute_.Add(values);
                return this;
            }

            [CLSCompliant(false)]
            public MemberState.Builder AddRangeRole(IEnumerable<uint> values)
            {
                this.PrepareBuilder();
                this.result.role_.Add(values);
                return this;
            }

            [CLSCompliant(false)]
            public MemberState.Builder AddRole(uint value)
            {
                this.PrepareBuilder();
                this.result.role_.Add(value);
                return this;
            }

            public override MemberState BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override MemberState.Builder Clear()
            {
                this.result = MemberState.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public MemberState.Builder ClearAttribute()
            {
                this.PrepareBuilder();
                this.result.attribute_.Clear();
                return this;
            }

            public MemberState.Builder ClearInfo()
            {
                this.PrepareBuilder();
                this.result.hasInfo = false;
                this.result.info_ = null;
                return this;
            }

            public MemberState.Builder ClearPrivileges()
            {
                this.PrepareBuilder();
                this.result.hasPrivileges = false;
                this.result.privileges_ = 0L;
                return this;
            }

            public MemberState.Builder ClearRole()
            {
                this.PrepareBuilder();
                this.result.role_.Clear();
                return this;
            }

            public override MemberState.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new MemberState.Builder(this.result);
                }
                return new MemberState.Builder().MergeFrom(this.result);
            }

            public bnet.protocol.attribute.Attribute GetAttribute(int index)
            {
                return this.result.GetAttribute(index);
            }

            [CLSCompliant(false)]
            public uint GetRole(int index)
            {
                return this.result.GetRole(index);
            }

            public override MemberState.Builder MergeFrom(MemberState other)
            {
                if (other != MemberState.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.attribute_.Count != 0)
                    {
                        this.result.attribute_.Add(other.attribute_);
                    }
                    if (other.role_.Count != 0)
                    {
                        this.result.role_.Add(other.role_);
                    }
                    if (other.HasPrivileges)
                    {
                        this.Privileges = other.Privileges;
                    }
                    if (other.HasInfo)
                    {
                        this.MergeInfo(other.Info);
                    }
                    base.MergeExtensionFields(other);
                }
                return this;
            }

            public override MemberState.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override MemberState.Builder MergeFrom(IMessageLite other)
            {
                if (other is MemberState)
                {
                    return this.MergeFrom((MemberState) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override MemberState.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    AccountInfo.Builder builder;
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(MemberState._memberStateFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = MemberState._memberStateFieldTags[index];
                        }
                        else
                        {
                            this.ParseUnknownField(input, extensionRegistry, num, str);
                            continue;
                        }
                    }
                    switch (num)
                    {
                        case 0x10:
                        case 0x12:
                        {
                            input.ReadUInt32Array(num, str, this.result.role_);
                            continue;
                        }
                        case 0:
                            throw InvalidProtocolBufferException.InvalidTag();

                        case 10:
                            goto Label_00B1;

                        case 0x18:
                            goto Label_00E7;

                        case 0x22:
                            goto Label_0108;

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
                Label_00B1:
                    input.ReadMessageArray<bnet.protocol.attribute.Attribute>(num, str, this.result.attribute_, bnet.protocol.attribute.Attribute.DefaultInstance, extensionRegistry);
                    continue;
                Label_00E7:
                    this.result.hasPrivileges = input.ReadUInt64(ref this.result.privileges_);
                    continue;
                Label_0108:
                    builder = AccountInfo.CreateBuilder();
                    if (this.result.hasInfo)
                    {
                        builder.MergeFrom(this.Info);
                    }
                    input.ReadMessage(builder, extensionRegistry);
                    this.Info = builder.BuildPartial();
                }
                return this;
            }

            public MemberState.Builder MergeInfo(AccountInfo value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasInfo && (this.result.info_ != AccountInfo.DefaultInstance))
                {
                    this.result.info_ = AccountInfo.CreateBuilder(this.result.info_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.info_ = value;
                }
                this.result.hasInfo = true;
                return this;
            }

            private MemberState PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    MemberState result = this.result;
                    this.result = new MemberState();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public MemberState.Builder SetAttribute(int index, bnet.protocol.attribute.Attribute value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.attribute_[index] = value;
                return this;
            }

            public MemberState.Builder SetAttribute(int index, bnet.protocol.attribute.Attribute.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.attribute_[index] = builderForValue.Build();
                return this;
            }

            public MemberState.Builder SetInfo(AccountInfo value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasInfo = true;
                this.result.info_ = value;
                return this;
            }

            public MemberState.Builder SetInfo(AccountInfo.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasInfo = true;
                this.result.info_ = builderForValue.Build();
                return this;
            }

            [CLSCompliant(false)]
            public MemberState.Builder SetPrivileges(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasPrivileges = true;
                this.result.privileges_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public MemberState.Builder SetRole(int index, uint value)
            {
                this.PrepareBuilder();
                this.result.role_[index] = value;
                return this;
            }

            public int AttributeCount
            {
                get
                {
                    return this.result.AttributeCount;
                }
            }

            public IPopsicleList<bnet.protocol.attribute.Attribute> AttributeList
            {
                get
                {
                    return this.PrepareBuilder().attribute_;
                }
            }

            public override MemberState DefaultInstanceForType
            {
                get
                {
                    return MemberState.DefaultInstance;
                }
            }

            public bool HasInfo
            {
                get
                {
                    return this.result.hasInfo;
                }
            }

            public bool HasPrivileges
            {
                get
                {
                    return this.result.hasPrivileges;
                }
            }

            public AccountInfo Info
            {
                get
                {
                    return this.result.Info;
                }
                set
                {
                    this.SetInfo(value);
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override MemberState MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            [CLSCompliant(false)]
            public ulong Privileges
            {
                get
                {
                    return this.result.Privileges;
                }
                set
                {
                    this.SetPrivileges(value);
                }
            }

            public int RoleCount
            {
                get
                {
                    return this.result.RoleCount;
                }
            }

            [CLSCompliant(false)]
            public IPopsicleList<uint> RoleList
            {
                get
                {
                    return this.PrepareBuilder().role_;
                }
            }

            protected override MemberState.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

