namespace bnet.protocol.channel
{
    using bnet.protocol.attribute;
    using bnet.protocol.invitation;
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Collections;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class ChannelState : ExtendableMessageLite<ChannelState, Builder>
    {
        private static readonly string[] _channelStateFieldNames = new string[] { "attribute", "channel_type", "delegate_name", "invitation", "max_invitations", "max_members", "min_members", "name", "privacy_level", "reason" };
        private static readonly uint[] _channelStateFieldTags = new uint[] { 0x1a, 0x52, 0x4a, 0x22, 40, 8, 0x10, 0x42, 0x38, 0x30 };
        private PopsicleList<bnet.protocol.attribute.Attribute> attribute_ = new PopsicleList<bnet.protocol.attribute.Attribute>();
        public const int AttributeFieldNumber = 3;
        private string channelType_ = "default";
        public const int ChannelTypeFieldNumber = 10;
        private static readonly ChannelState defaultInstance = new ChannelState().MakeReadOnly();
        private string delegateName_ = string.Empty;
        public const int DelegateNameFieldNumber = 9;
        private bool hasChannelType;
        private bool hasDelegateName;
        private bool hasMaxInvitations;
        private bool hasMaxMembers;
        private bool hasMinMembers;
        private bool hasName;
        private bool hasPrivacyLevel;
        private bool hasReason;
        private PopsicleList<Invitation> invitation_ = new PopsicleList<Invitation>();
        public const int InvitationFieldNumber = 4;
        private uint maxInvitations_;
        public const int MaxInvitationsFieldNumber = 5;
        private uint maxMembers_;
        public const int MaxMembersFieldNumber = 1;
        private int memoizedSerializedSize = -1;
        private uint minMembers_;
        public const int MinMembersFieldNumber = 2;
        private string name_ = string.Empty;
        public const int NameFieldNumber = 8;
        private bnet.protocol.channel.ChannelState.Types.PrivacyLevel privacyLevel_ = bnet.protocol.channel.ChannelState.Types.PrivacyLevel.PRIVACY_LEVEL_OPEN;
        public const int PrivacyLevelFieldNumber = 7;
        private uint reason_;
        public const int ReasonFieldNumber = 6;

        static ChannelState()
        {
            object.ReferenceEquals(ChannelTypes.Descriptor, null);
        }

        private ChannelState()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ChannelState prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ChannelState state = obj as ChannelState;
            if (state == null)
            {
                return false;
            }
            if ((this.hasMaxMembers != state.hasMaxMembers) || (this.hasMaxMembers && !this.maxMembers_.Equals(state.maxMembers_)))
            {
                return false;
            }
            if ((this.hasMinMembers != state.hasMinMembers) || (this.hasMinMembers && !this.minMembers_.Equals(state.minMembers_)))
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
            if (this.invitation_.Count != state.invitation_.Count)
            {
                return false;
            }
            for (int j = 0; j < this.invitation_.Count; j++)
            {
                if (!this.invitation_[j].Equals(state.invitation_[j]))
                {
                    return false;
                }
            }
            if ((this.hasMaxInvitations != state.hasMaxInvitations) || (this.hasMaxInvitations && !this.maxInvitations_.Equals(state.maxInvitations_)))
            {
                return false;
            }
            if ((this.hasReason != state.hasReason) || (this.hasReason && !this.reason_.Equals(state.reason_)))
            {
                return false;
            }
            if ((this.hasPrivacyLevel != state.hasPrivacyLevel) || (this.hasPrivacyLevel && !this.privacyLevel_.Equals(state.privacyLevel_)))
            {
                return false;
            }
            if ((this.hasName != state.hasName) || (this.hasName && !this.name_.Equals(state.name_)))
            {
                return false;
            }
            if ((this.hasDelegateName != state.hasDelegateName) || (this.hasDelegateName && !this.delegateName_.Equals(state.delegateName_)))
            {
                return false;
            }
            if ((this.hasChannelType != state.hasChannelType) || (this.hasChannelType && !this.channelType_.Equals(state.channelType_)))
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
            if (this.hasMaxMembers)
            {
                hashCode ^= this.maxMembers_.GetHashCode();
            }
            if (this.hasMinMembers)
            {
                hashCode ^= this.minMembers_.GetHashCode();
            }
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
            IEnumerator<Invitation> enumerator2 = this.invitation_.GetEnumerator();
            try
            {
                while (enumerator2.MoveNext())
                {
                    Invitation invitation = enumerator2.Current;
                    hashCode ^= invitation.GetHashCode();
                }
            }
            finally
            {
                if (enumerator2 == null)
                {
                }
                enumerator2.Dispose();
            }
            if (this.hasMaxInvitations)
            {
                hashCode ^= this.maxInvitations_.GetHashCode();
            }
            if (this.hasReason)
            {
                hashCode ^= this.reason_.GetHashCode();
            }
            if (this.hasPrivacyLevel)
            {
                hashCode ^= this.privacyLevel_.GetHashCode();
            }
            if (this.hasName)
            {
                hashCode ^= this.name_.GetHashCode();
            }
            if (this.hasDelegateName)
            {
                hashCode ^= this.delegateName_.GetHashCode();
            }
            if (this.hasChannelType)
            {
                hashCode ^= this.channelType_.GetHashCode();
            }
            return (hashCode ^ base.GetHashCode());
        }

        public Invitation GetInvitation(int index)
        {
            return this.invitation_[index];
        }

        private ChannelState MakeReadOnly()
        {
            this.attribute_.MakeReadOnly();
            this.invitation_.MakeReadOnly();
            return this;
        }

        public static ChannelState ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ChannelState ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ChannelState ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ChannelState ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ChannelState ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ChannelState ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ChannelState ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ChannelState ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ChannelState ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ChannelState ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ChannelState, Builder>.PrintField("max_members", this.hasMaxMembers, this.maxMembers_, writer);
            GeneratedMessageLite<ChannelState, Builder>.PrintField("min_members", this.hasMinMembers, this.minMembers_, writer);
            GeneratedMessageLite<ChannelState, Builder>.PrintField<bnet.protocol.attribute.Attribute>("attribute", this.attribute_, writer);
            GeneratedMessageLite<ChannelState, Builder>.PrintField<Invitation>("invitation", this.invitation_, writer);
            GeneratedMessageLite<ChannelState, Builder>.PrintField("max_invitations", this.hasMaxInvitations, this.maxInvitations_, writer);
            GeneratedMessageLite<ChannelState, Builder>.PrintField("reason", this.hasReason, this.reason_, writer);
            GeneratedMessageLite<ChannelState, Builder>.PrintField("privacy_level", this.hasPrivacyLevel, this.privacyLevel_, writer);
            GeneratedMessageLite<ChannelState, Builder>.PrintField("name", this.hasName, this.name_, writer);
            GeneratedMessageLite<ChannelState, Builder>.PrintField("delegate_name", this.hasDelegateName, this.delegateName_, writer);
            GeneratedMessageLite<ChannelState, Builder>.PrintField("channel_type", this.hasChannelType, this.channelType_, writer);
            base.PrintTo(writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _channelStateFieldNames;
            ExtendableMessageLite<ChannelState, Builder>.ExtensionWriter writer = base.CreateExtensionWriter(this);
            if (this.hasMaxMembers)
            {
                output.WriteUInt32(1, strArray[5], this.MaxMembers);
            }
            if (this.hasMinMembers)
            {
                output.WriteUInt32(2, strArray[6], this.MinMembers);
            }
            if (this.attribute_.Count > 0)
            {
                output.WriteMessageArray<bnet.protocol.attribute.Attribute>(3, strArray[0], this.attribute_);
            }
            if (this.invitation_.Count > 0)
            {
                output.WriteMessageArray<Invitation>(4, strArray[3], this.invitation_);
            }
            if (this.hasMaxInvitations)
            {
                output.WriteUInt32(5, strArray[4], this.MaxInvitations);
            }
            if (this.hasReason)
            {
                output.WriteUInt32(6, strArray[9], this.Reason);
            }
            if (this.hasPrivacyLevel)
            {
                output.WriteEnum(7, strArray[8], (int) this.PrivacyLevel, this.PrivacyLevel);
            }
            if (this.hasName)
            {
                output.WriteString(8, strArray[7], this.Name);
            }
            if (this.hasDelegateName)
            {
                output.WriteString(9, strArray[2], this.DelegateName);
            }
            if (this.hasChannelType)
            {
                output.WriteString(10, strArray[1], this.ChannelType);
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

        public string ChannelType
        {
            get
            {
                return this.channelType_;
            }
        }

        public static ChannelState DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ChannelState DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public string DelegateName
        {
            get
            {
                return this.delegateName_;
            }
        }

        public bool HasChannelType
        {
            get
            {
                return this.hasChannelType;
            }
        }

        public bool HasDelegateName
        {
            get
            {
                return this.hasDelegateName;
            }
        }

        public bool HasMaxInvitations
        {
            get
            {
                return this.hasMaxInvitations;
            }
        }

        public bool HasMaxMembers
        {
            get
            {
                return this.hasMaxMembers;
            }
        }

        public bool HasMinMembers
        {
            get
            {
                return this.hasMinMembers;
            }
        }

        public bool HasName
        {
            get
            {
                return this.hasName;
            }
        }

        public bool HasPrivacyLevel
        {
            get
            {
                return this.hasPrivacyLevel;
            }
        }

        public bool HasReason
        {
            get
            {
                return this.hasReason;
            }
        }

        public int InvitationCount
        {
            get
            {
                return this.invitation_.Count;
            }
        }

        public IList<Invitation> InvitationList
        {
            get
            {
                return this.invitation_;
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
                IEnumerator<Invitation> enumerator2 = this.InvitationList.GetEnumerator();
                try
                {
                    while (enumerator2.MoveNext())
                    {
                        Invitation invitation = enumerator2.Current;
                        if (!invitation.IsInitialized)
                        {
                            return false;
                        }
                    }
                }
                finally
                {
                    if (enumerator2 == null)
                    {
                    }
                    enumerator2.Dispose();
                }
                if (!base.ExtensionsAreInitialized)
                {
                    return false;
                }
                return true;
            }
        }

        [CLSCompliant(false)]
        public uint MaxInvitations
        {
            get
            {
                return this.maxInvitations_;
            }
        }

        [CLSCompliant(false)]
        public uint MaxMembers
        {
            get
            {
                return this.maxMembers_;
            }
        }

        [CLSCompliant(false)]
        public uint MinMembers
        {
            get
            {
                return this.minMembers_;
            }
        }

        public string Name
        {
            get
            {
                return this.name_;
            }
        }

        public bnet.protocol.channel.ChannelState.Types.PrivacyLevel PrivacyLevel
        {
            get
            {
                return this.privacyLevel_;
            }
        }

        [CLSCompliant(false)]
        public uint Reason
        {
            get
            {
                return this.reason_;
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
                    if (this.hasMaxMembers)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(1, this.MaxMembers);
                    }
                    if (this.hasMinMembers)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(2, this.MinMembers);
                    }
                    IEnumerator<bnet.protocol.attribute.Attribute> enumerator = this.AttributeList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            bnet.protocol.attribute.Attribute current = enumerator.Current;
                            memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(3, current);
                        }
                    }
                    finally
                    {
                        if (enumerator == null)
                        {
                        }
                        enumerator.Dispose();
                    }
                    IEnumerator<Invitation> enumerator2 = this.InvitationList.GetEnumerator();
                    try
                    {
                        while (enumerator2.MoveNext())
                        {
                            Invitation invitation = enumerator2.Current;
                            memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(4, invitation);
                        }
                    }
                    finally
                    {
                        if (enumerator2 == null)
                        {
                        }
                        enumerator2.Dispose();
                    }
                    if (this.hasMaxInvitations)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(5, this.MaxInvitations);
                    }
                    if (this.hasReason)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(6, this.Reason);
                    }
                    if (this.hasPrivacyLevel)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeEnumSize(7, (int) this.PrivacyLevel);
                    }
                    if (this.hasName)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(8, this.Name);
                    }
                    if (this.hasDelegateName)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(9, this.DelegateName);
                    }
                    if (this.hasChannelType)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(10, this.ChannelType);
                    }
                    memoizedSerializedSize += base.ExtensionsSerializedSize;
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override ChannelState ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : ExtendableBuilderLite<ChannelState, ChannelState.Builder>
        {
            private ChannelState result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ChannelState.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ChannelState cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public ChannelState.Builder AddAttribute(bnet.protocol.attribute.Attribute value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.attribute_.Add(value);
                return this;
            }

            public ChannelState.Builder AddAttribute(bnet.protocol.attribute.Attribute.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.attribute_.Add(builderForValue.Build());
                return this;
            }

            public ChannelState.Builder AddInvitation(Invitation value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.invitation_.Add(value);
                return this;
            }

            public ChannelState.Builder AddInvitation(Invitation.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.invitation_.Add(builderForValue.Build());
                return this;
            }

            public ChannelState.Builder AddRangeAttribute(IEnumerable<bnet.protocol.attribute.Attribute> values)
            {
                this.PrepareBuilder();
                this.result.attribute_.Add(values);
                return this;
            }

            public ChannelState.Builder AddRangeInvitation(IEnumerable<Invitation> values)
            {
                this.PrepareBuilder();
                this.result.invitation_.Add(values);
                return this;
            }

            public override ChannelState BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ChannelState.Builder Clear()
            {
                this.result = ChannelState.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ChannelState.Builder ClearAttribute()
            {
                this.PrepareBuilder();
                this.result.attribute_.Clear();
                return this;
            }

            public ChannelState.Builder ClearChannelType()
            {
                this.PrepareBuilder();
                this.result.hasChannelType = false;
                this.result.channelType_ = "default";
                return this;
            }

            public ChannelState.Builder ClearDelegateName()
            {
                this.PrepareBuilder();
                this.result.hasDelegateName = false;
                this.result.delegateName_ = string.Empty;
                return this;
            }

            public ChannelState.Builder ClearInvitation()
            {
                this.PrepareBuilder();
                this.result.invitation_.Clear();
                return this;
            }

            public ChannelState.Builder ClearMaxInvitations()
            {
                this.PrepareBuilder();
                this.result.hasMaxInvitations = false;
                this.result.maxInvitations_ = 0;
                return this;
            }

            public ChannelState.Builder ClearMaxMembers()
            {
                this.PrepareBuilder();
                this.result.hasMaxMembers = false;
                this.result.maxMembers_ = 0;
                return this;
            }

            public ChannelState.Builder ClearMinMembers()
            {
                this.PrepareBuilder();
                this.result.hasMinMembers = false;
                this.result.minMembers_ = 0;
                return this;
            }

            public ChannelState.Builder ClearName()
            {
                this.PrepareBuilder();
                this.result.hasName = false;
                this.result.name_ = string.Empty;
                return this;
            }

            public ChannelState.Builder ClearPrivacyLevel()
            {
                this.PrepareBuilder();
                this.result.hasPrivacyLevel = false;
                this.result.privacyLevel_ = bnet.protocol.channel.ChannelState.Types.PrivacyLevel.PRIVACY_LEVEL_OPEN;
                return this;
            }

            public ChannelState.Builder ClearReason()
            {
                this.PrepareBuilder();
                this.result.hasReason = false;
                this.result.reason_ = 0;
                return this;
            }

            public override ChannelState.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ChannelState.Builder(this.result);
                }
                return new ChannelState.Builder().MergeFrom(this.result);
            }

            public bnet.protocol.attribute.Attribute GetAttribute(int index)
            {
                return this.result.GetAttribute(index);
            }

            public Invitation GetInvitation(int index)
            {
                return this.result.GetInvitation(index);
            }

            public override ChannelState.Builder MergeFrom(ChannelState other)
            {
                if (other != ChannelState.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasMaxMembers)
                    {
                        this.MaxMembers = other.MaxMembers;
                    }
                    if (other.HasMinMembers)
                    {
                        this.MinMembers = other.MinMembers;
                    }
                    if (other.attribute_.Count != 0)
                    {
                        this.result.attribute_.Add(other.attribute_);
                    }
                    if (other.invitation_.Count != 0)
                    {
                        this.result.invitation_.Add(other.invitation_);
                    }
                    if (other.HasMaxInvitations)
                    {
                        this.MaxInvitations = other.MaxInvitations;
                    }
                    if (other.HasReason)
                    {
                        this.Reason = other.Reason;
                    }
                    if (other.HasPrivacyLevel)
                    {
                        this.PrivacyLevel = other.PrivacyLevel;
                    }
                    if (other.HasName)
                    {
                        this.Name = other.Name;
                    }
                    if (other.HasDelegateName)
                    {
                        this.DelegateName = other.DelegateName;
                    }
                    if (other.HasChannelType)
                    {
                        this.ChannelType = other.ChannelType;
                    }
                    base.MergeExtensionFields(other);
                }
                return this;
            }

            public override ChannelState.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ChannelState.Builder MergeFrom(IMessageLite other)
            {
                if (other is ChannelState)
                {
                    return this.MergeFrom((ChannelState) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ChannelState.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ChannelState._channelStateFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ChannelState._channelStateFieldTags[index];
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
                            this.result.hasMaxMembers = input.ReadUInt32(ref this.result.maxMembers_);
                            continue;
                        }
                        case 0x10:
                        {
                            this.result.hasMinMembers = input.ReadUInt32(ref this.result.minMembers_);
                            continue;
                        }
                        case 0x1a:
                        {
                            input.ReadMessageArray<bnet.protocol.attribute.Attribute>(num, str, this.result.attribute_, bnet.protocol.attribute.Attribute.DefaultInstance, extensionRegistry);
                            continue;
                        }
                        case 0x22:
                        {
                            input.ReadMessageArray<Invitation>(num, str, this.result.invitation_, Invitation.DefaultInstance, extensionRegistry);
                            continue;
                        }
                        case 40:
                        {
                            this.result.hasMaxInvitations = input.ReadUInt32(ref this.result.maxInvitations_);
                            continue;
                        }
                        case 0x30:
                        {
                            this.result.hasReason = input.ReadUInt32(ref this.result.reason_);
                            continue;
                        }
                        case 0x38:
                        {
                            object obj2;
                            if (input.ReadEnum<bnet.protocol.channel.ChannelState.Types.PrivacyLevel>(ref this.result.privacyLevel_, out obj2))
                            {
                                this.result.hasPrivacyLevel = true;
                            }
                            else if (obj2 is int)
                            {
                            }
                            continue;
                        }
                        case 0x42:
                        {
                            this.result.hasName = input.ReadString(ref this.result.name_);
                            continue;
                        }
                        case 0x4a:
                        {
                            this.result.hasDelegateName = input.ReadString(ref this.result.delegateName_);
                            continue;
                        }
                        case 0x52:
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
                    this.result.hasChannelType = input.ReadString(ref this.result.channelType_);
                }
                return this;
            }

            private ChannelState PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ChannelState result = this.result;
                    this.result = new ChannelState();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public ChannelState.Builder SetAttribute(int index, bnet.protocol.attribute.Attribute value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.attribute_[index] = value;
                return this;
            }

            public ChannelState.Builder SetAttribute(int index, bnet.protocol.attribute.Attribute.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.attribute_[index] = builderForValue.Build();
                return this;
            }

            public ChannelState.Builder SetChannelType(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasChannelType = true;
                this.result.channelType_ = value;
                return this;
            }

            public ChannelState.Builder SetDelegateName(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasDelegateName = true;
                this.result.delegateName_ = value;
                return this;
            }

            public ChannelState.Builder SetInvitation(int index, Invitation value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.invitation_[index] = value;
                return this;
            }

            public ChannelState.Builder SetInvitation(int index, Invitation.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.invitation_[index] = builderForValue.Build();
                return this;
            }

            [CLSCompliant(false)]
            public ChannelState.Builder SetMaxInvitations(uint value)
            {
                this.PrepareBuilder();
                this.result.hasMaxInvitations = true;
                this.result.maxInvitations_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public ChannelState.Builder SetMaxMembers(uint value)
            {
                this.PrepareBuilder();
                this.result.hasMaxMembers = true;
                this.result.maxMembers_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public ChannelState.Builder SetMinMembers(uint value)
            {
                this.PrepareBuilder();
                this.result.hasMinMembers = true;
                this.result.minMembers_ = value;
                return this;
            }

            public ChannelState.Builder SetName(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasName = true;
                this.result.name_ = value;
                return this;
            }

            public ChannelState.Builder SetPrivacyLevel(bnet.protocol.channel.ChannelState.Types.PrivacyLevel value)
            {
                this.PrepareBuilder();
                this.result.hasPrivacyLevel = true;
                this.result.privacyLevel_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public ChannelState.Builder SetReason(uint value)
            {
                this.PrepareBuilder();
                this.result.hasReason = true;
                this.result.reason_ = value;
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

            public string ChannelType
            {
                get
                {
                    return this.result.ChannelType;
                }
                set
                {
                    this.SetChannelType(value);
                }
            }

            public override ChannelState DefaultInstanceForType
            {
                get
                {
                    return ChannelState.DefaultInstance;
                }
            }

            public string DelegateName
            {
                get
                {
                    return this.result.DelegateName;
                }
                set
                {
                    this.SetDelegateName(value);
                }
            }

            public bool HasChannelType
            {
                get
                {
                    return this.result.hasChannelType;
                }
            }

            public bool HasDelegateName
            {
                get
                {
                    return this.result.hasDelegateName;
                }
            }

            public bool HasMaxInvitations
            {
                get
                {
                    return this.result.hasMaxInvitations;
                }
            }

            public bool HasMaxMembers
            {
                get
                {
                    return this.result.hasMaxMembers;
                }
            }

            public bool HasMinMembers
            {
                get
                {
                    return this.result.hasMinMembers;
                }
            }

            public bool HasName
            {
                get
                {
                    return this.result.hasName;
                }
            }

            public bool HasPrivacyLevel
            {
                get
                {
                    return this.result.hasPrivacyLevel;
                }
            }

            public bool HasReason
            {
                get
                {
                    return this.result.hasReason;
                }
            }

            public int InvitationCount
            {
                get
                {
                    return this.result.InvitationCount;
                }
            }

            public IPopsicleList<Invitation> InvitationList
            {
                get
                {
                    return this.PrepareBuilder().invitation_;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            [CLSCompliant(false)]
            public uint MaxInvitations
            {
                get
                {
                    return this.result.MaxInvitations;
                }
                set
                {
                    this.SetMaxInvitations(value);
                }
            }

            [CLSCompliant(false)]
            public uint MaxMembers
            {
                get
                {
                    return this.result.MaxMembers;
                }
                set
                {
                    this.SetMaxMembers(value);
                }
            }

            protected override ChannelState MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            [CLSCompliant(false)]
            public uint MinMembers
            {
                get
                {
                    return this.result.MinMembers;
                }
                set
                {
                    this.SetMinMembers(value);
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

            public bnet.protocol.channel.ChannelState.Types.PrivacyLevel PrivacyLevel
            {
                get
                {
                    return this.result.PrivacyLevel;
                }
                set
                {
                    this.SetPrivacyLevel(value);
                }
            }

            [CLSCompliant(false)]
            public uint Reason
            {
                get
                {
                    return this.result.Reason;
                }
                set
                {
                    this.SetReason(value);
                }
            }

            protected override ChannelState.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public static class Types
        {
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PrivacyLevel
            {
                PRIVACY_LEVEL_CLOSED = 4,
                PRIVACY_LEVEL_OPEN = 1,
                PRIVACY_LEVEL_OPEN_INVITATION = 3,
                PRIVACY_LEVEL_OPEN_INVITATION_AND_FRIEND = 2
            }
        }
    }
}

