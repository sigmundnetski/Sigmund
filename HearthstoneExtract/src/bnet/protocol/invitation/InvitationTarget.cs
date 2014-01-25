namespace bnet.protocol.invitation
{
    using bnet.protocol;
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class InvitationTarget : ExtendableMessageLite<InvitationTarget, Builder>
    {
        private static readonly string[] _invitationTargetFieldNames = new string[] { "battle_tag", "email", "identity" };
        private static readonly uint[] _invitationTargetFieldTags = new uint[] { 0x1a, 0x12, 10 };
        private string battleTag_ = string.Empty;
        public const int BattleTagFieldNumber = 3;
        private static readonly InvitationTarget defaultInstance = new InvitationTarget().MakeReadOnly();
        private string email_ = string.Empty;
        public const int EmailFieldNumber = 2;
        private bool hasBattleTag;
        private bool hasEmail;
        private bool hasIdentity;
        private bnet.protocol.Identity identity_;
        public const int IdentityFieldNumber = 1;
        private int memoizedSerializedSize = -1;

        static InvitationTarget()
        {
            object.ReferenceEquals(InvitationTypes.Descriptor, null);
        }

        private InvitationTarget()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(InvitationTarget prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            InvitationTarget target = obj as InvitationTarget;
            if (target == null)
            {
                return false;
            }
            if ((this.hasIdentity != target.hasIdentity) || (this.hasIdentity && !this.identity_.Equals(target.identity_)))
            {
                return false;
            }
            if ((this.hasEmail != target.hasEmail) || (this.hasEmail && !this.email_.Equals(target.email_)))
            {
                return false;
            }
            if ((this.hasBattleTag != target.hasBattleTag) || (this.hasBattleTag && !this.battleTag_.Equals(target.battleTag_)))
            {
                return false;
            }
            if (!base.Equals(target))
            {
                return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasIdentity)
            {
                hashCode ^= this.identity_.GetHashCode();
            }
            if (this.hasEmail)
            {
                hashCode ^= this.email_.GetHashCode();
            }
            if (this.hasBattleTag)
            {
                hashCode ^= this.battleTag_.GetHashCode();
            }
            return (hashCode ^ base.GetHashCode());
        }

        private InvitationTarget MakeReadOnly()
        {
            return this;
        }

        public static InvitationTarget ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static InvitationTarget ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static InvitationTarget ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static InvitationTarget ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static InvitationTarget ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static InvitationTarget ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static InvitationTarget ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static InvitationTarget ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static InvitationTarget ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static InvitationTarget ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<InvitationTarget, Builder>.PrintField("identity", this.hasIdentity, this.identity_, writer);
            GeneratedMessageLite<InvitationTarget, Builder>.PrintField("email", this.hasEmail, this.email_, writer);
            GeneratedMessageLite<InvitationTarget, Builder>.PrintField("battle_tag", this.hasBattleTag, this.battleTag_, writer);
            base.PrintTo(writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _invitationTargetFieldNames;
            ExtendableMessageLite<InvitationTarget, Builder>.ExtensionWriter writer = base.CreateExtensionWriter(this);
            if (this.hasIdentity)
            {
                output.WriteMessage(1, strArray[2], this.Identity);
            }
            if (this.hasEmail)
            {
                output.WriteString(2, strArray[1], this.Email);
            }
            if (this.hasBattleTag)
            {
                output.WriteString(3, strArray[0], this.BattleTag);
            }
            writer.WriteUntil(0x2710, output);
        }

        public string BattleTag
        {
            get
            {
                return this.battleTag_;
            }
        }

        public static InvitationTarget DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override InvitationTarget DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public string Email
        {
            get
            {
                return this.email_;
            }
        }

        public bool HasBattleTag
        {
            get
            {
                return this.hasBattleTag;
            }
        }

        public bool HasEmail
        {
            get
            {
                return this.hasEmail;
            }
        }

        public bool HasIdentity
        {
            get
            {
                return this.hasIdentity;
            }
        }

        public bnet.protocol.Identity Identity
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.identity_ != null)
                {
                    goto Label_0012;
                }
                return bnet.protocol.Identity.DefaultInstance;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (this.HasIdentity && !this.Identity.IsInitialized)
                {
                    return false;
                }
                if (!base.ExtensionsAreInitialized)
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
                    if (this.hasIdentity)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, this.Identity);
                    }
                    if (this.hasEmail)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(2, this.Email);
                    }
                    if (this.hasBattleTag)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(3, this.BattleTag);
                    }
                    memoizedSerializedSize += base.ExtensionsSerializedSize;
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override InvitationTarget ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : ExtendableBuilderLite<InvitationTarget, InvitationTarget.Builder>
        {
            private InvitationTarget result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = InvitationTarget.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(InvitationTarget cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override InvitationTarget BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override InvitationTarget.Builder Clear()
            {
                this.result = InvitationTarget.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public InvitationTarget.Builder ClearBattleTag()
            {
                this.PrepareBuilder();
                this.result.hasBattleTag = false;
                this.result.battleTag_ = string.Empty;
                return this;
            }

            public InvitationTarget.Builder ClearEmail()
            {
                this.PrepareBuilder();
                this.result.hasEmail = false;
                this.result.email_ = string.Empty;
                return this;
            }

            public InvitationTarget.Builder ClearIdentity()
            {
                this.PrepareBuilder();
                this.result.hasIdentity = false;
                this.result.identity_ = null;
                return this;
            }

            public override InvitationTarget.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new InvitationTarget.Builder(this.result);
                }
                return new InvitationTarget.Builder().MergeFrom(this.result);
            }

            public override InvitationTarget.Builder MergeFrom(InvitationTarget other)
            {
                if (other != InvitationTarget.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasIdentity)
                    {
                        this.MergeIdentity(other.Identity);
                    }
                    if (other.HasEmail)
                    {
                        this.Email = other.Email;
                    }
                    if (other.HasBattleTag)
                    {
                        this.BattleTag = other.BattleTag;
                    }
                    base.MergeExtensionFields(other);
                }
                return this;
            }

            public override InvitationTarget.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override InvitationTarget.Builder MergeFrom(IMessageLite other)
            {
                if (other is InvitationTarget)
                {
                    return this.MergeFrom((InvitationTarget) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override InvitationTarget.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(InvitationTarget._invitationTargetFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = InvitationTarget._invitationTargetFieldTags[index];
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
                            bnet.protocol.Identity.Builder builder = bnet.protocol.Identity.CreateBuilder();
                            if (this.result.hasIdentity)
                            {
                                builder.MergeFrom(this.Identity);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.Identity = builder.BuildPartial();
                            continue;
                        }
                        case 0x12:
                        {
                            this.result.hasEmail = input.ReadString(ref this.result.email_);
                            continue;
                        }
                        case 0x1a:
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
                    this.result.hasBattleTag = input.ReadString(ref this.result.battleTag_);
                }
                return this;
            }

            public InvitationTarget.Builder MergeIdentity(bnet.protocol.Identity value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasIdentity && (this.result.identity_ != bnet.protocol.Identity.DefaultInstance))
                {
                    this.result.identity_ = bnet.protocol.Identity.CreateBuilder(this.result.identity_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.identity_ = value;
                }
                this.result.hasIdentity = true;
                return this;
            }

            private InvitationTarget PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    InvitationTarget result = this.result;
                    this.result = new InvitationTarget();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public InvitationTarget.Builder SetBattleTag(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasBattleTag = true;
                this.result.battleTag_ = value;
                return this;
            }

            public InvitationTarget.Builder SetEmail(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasEmail = true;
                this.result.email_ = value;
                return this;
            }

            public InvitationTarget.Builder SetIdentity(bnet.protocol.Identity value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasIdentity = true;
                this.result.identity_ = value;
                return this;
            }

            public InvitationTarget.Builder SetIdentity(bnet.protocol.Identity.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasIdentity = true;
                this.result.identity_ = builderForValue.Build();
                return this;
            }

            public string BattleTag
            {
                get
                {
                    return this.result.BattleTag;
                }
                set
                {
                    this.SetBattleTag(value);
                }
            }

            public override InvitationTarget DefaultInstanceForType
            {
                get
                {
                    return InvitationTarget.DefaultInstance;
                }
            }

            public string Email
            {
                get
                {
                    return this.result.Email;
                }
                set
                {
                    this.SetEmail(value);
                }
            }

            public bool HasBattleTag
            {
                get
                {
                    return this.result.hasBattleTag;
                }
            }

            public bool HasEmail
            {
                get
                {
                    return this.result.hasEmail;
                }
            }

            public bool HasIdentity
            {
                get
                {
                    return this.result.hasIdentity;
                }
            }

            public bnet.protocol.Identity Identity
            {
                get
                {
                    return this.result.Identity;
                }
                set
                {
                    this.SetIdentity(value);
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override InvitationTarget MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override InvitationTarget.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

