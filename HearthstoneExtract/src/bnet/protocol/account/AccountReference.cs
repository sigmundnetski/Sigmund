namespace bnet.protocol.account
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class AccountReference : GeneratedMessageLite<AccountReference, Builder>
    {
        private static readonly string[] _accountReferenceFieldNames = new string[] { "battle_tag", "email", "handle", "id", "region" };
        private static readonly uint[] _accountReferenceFieldTags = new uint[] { 0x22, 0x12, 0x1a, 13, 80 };
        private string battleTag_ = string.Empty;
        public const int BattleTagFieldNumber = 4;
        private static readonly AccountReference defaultInstance = new AccountReference().MakeReadOnly();
        private string email_ = string.Empty;
        public const int EmailFieldNumber = 2;
        private GameAccountHandle handle_;
        public const int HandleFieldNumber = 3;
        private bool hasBattleTag;
        private bool hasEmail;
        private bool hasHandle;
        private bool hasId;
        private bool hasRegion;
        private uint id_;
        public const int IdFieldNumber = 1;
        private int memoizedSerializedSize = -1;
        private uint region_;
        public const int RegionFieldNumber = 10;

        static AccountReference()
        {
            object.ReferenceEquals(AccountTypes.Descriptor, null);
        }

        private AccountReference()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AccountReference prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AccountReference reference = obj as AccountReference;
            if (reference == null)
            {
                return false;
            }
            if ((this.hasId != reference.hasId) || (this.hasId && !this.id_.Equals(reference.id_)))
            {
                return false;
            }
            if ((this.hasEmail != reference.hasEmail) || (this.hasEmail && !this.email_.Equals(reference.email_)))
            {
                return false;
            }
            if ((this.hasHandle != reference.hasHandle) || (this.hasHandle && !this.handle_.Equals(reference.handle_)))
            {
                return false;
            }
            if ((this.hasBattleTag != reference.hasBattleTag) || (this.hasBattleTag && !this.battleTag_.Equals(reference.battleTag_)))
            {
                return false;
            }
            return ((this.hasRegion == reference.hasRegion) && (!this.hasRegion || this.region_.Equals(reference.region_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasId)
            {
                hashCode ^= this.id_.GetHashCode();
            }
            if (this.hasEmail)
            {
                hashCode ^= this.email_.GetHashCode();
            }
            if (this.hasHandle)
            {
                hashCode ^= this.handle_.GetHashCode();
            }
            if (this.hasBattleTag)
            {
                hashCode ^= this.battleTag_.GetHashCode();
            }
            if (this.hasRegion)
            {
                hashCode ^= this.region_.GetHashCode();
            }
            return hashCode;
        }

        private AccountReference MakeReadOnly()
        {
            return this;
        }

        public static AccountReference ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AccountReference ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AccountReference ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AccountReference ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AccountReference ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AccountReference ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AccountReference ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AccountReference ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AccountReference ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AccountReference ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AccountReference, Builder>.PrintField("id", this.hasId, this.id_, writer);
            GeneratedMessageLite<AccountReference, Builder>.PrintField("email", this.hasEmail, this.email_, writer);
            GeneratedMessageLite<AccountReference, Builder>.PrintField("handle", this.hasHandle, this.handle_, writer);
            GeneratedMessageLite<AccountReference, Builder>.PrintField("battle_tag", this.hasBattleTag, this.battleTag_, writer);
            GeneratedMessageLite<AccountReference, Builder>.PrintField("region", this.hasRegion, this.region_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _accountReferenceFieldNames;
            if (this.hasId)
            {
                output.WriteFixed32(1, strArray[3], this.Id);
            }
            if (this.hasEmail)
            {
                output.WriteString(2, strArray[1], this.Email);
            }
            if (this.hasHandle)
            {
                output.WriteMessage(3, strArray[2], this.Handle);
            }
            if (this.hasBattleTag)
            {
                output.WriteString(4, strArray[0], this.BattleTag);
            }
            if (this.hasRegion)
            {
                output.WriteUInt32(10, strArray[4], this.Region);
            }
        }

        public string BattleTag
        {
            get
            {
                return this.battleTag_;
            }
        }

        public static AccountReference DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AccountReference DefaultInstanceForType
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

        public GameAccountHandle Handle
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.handle_ != null)
                {
                    goto Label_0012;
                }
                return GameAccountHandle.DefaultInstance;
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

        public bool HasHandle
        {
            get
            {
                return this.hasHandle;
            }
        }

        public bool HasId
        {
            get
            {
                return this.hasId;
            }
        }

        public bool HasRegion
        {
            get
            {
                return this.hasRegion;
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
                if (this.HasHandle && !this.Handle.IsInitialized)
                {
                    return false;
                }
                return true;
            }
        }

        [CLSCompliant(false)]
        public uint Region
        {
            get
            {
                return this.region_;
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
                    if (this.hasId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeFixed32Size(1, this.Id);
                    }
                    if (this.hasEmail)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(2, this.Email);
                    }
                    if (this.hasHandle)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(3, this.Handle);
                    }
                    if (this.hasBattleTag)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(4, this.BattleTag);
                    }
                    if (this.hasRegion)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(10, this.Region);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override AccountReference ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<AccountReference, AccountReference.Builder>
        {
            private AccountReference result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AccountReference.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AccountReference cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override AccountReference BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AccountReference.Builder Clear()
            {
                this.result = AccountReference.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AccountReference.Builder ClearBattleTag()
            {
                this.PrepareBuilder();
                this.result.hasBattleTag = false;
                this.result.battleTag_ = string.Empty;
                return this;
            }

            public AccountReference.Builder ClearEmail()
            {
                this.PrepareBuilder();
                this.result.hasEmail = false;
                this.result.email_ = string.Empty;
                return this;
            }

            public AccountReference.Builder ClearHandle()
            {
                this.PrepareBuilder();
                this.result.hasHandle = false;
                this.result.handle_ = null;
                return this;
            }

            public AccountReference.Builder ClearId()
            {
                this.PrepareBuilder();
                this.result.hasId = false;
                this.result.id_ = 0;
                return this;
            }

            public AccountReference.Builder ClearRegion()
            {
                this.PrepareBuilder();
                this.result.hasRegion = false;
                this.result.region_ = 0;
                return this;
            }

            public override AccountReference.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AccountReference.Builder(this.result);
                }
                return new AccountReference.Builder().MergeFrom(this.result);
            }

            public override AccountReference.Builder MergeFrom(AccountReference other)
            {
                if (other != AccountReference.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasId)
                    {
                        this.Id = other.Id;
                    }
                    if (other.HasEmail)
                    {
                        this.Email = other.Email;
                    }
                    if (other.HasHandle)
                    {
                        this.MergeHandle(other.Handle);
                    }
                    if (other.HasBattleTag)
                    {
                        this.BattleTag = other.BattleTag;
                    }
                    if (other.HasRegion)
                    {
                        this.Region = other.Region;
                    }
                }
                return this;
            }

            public override AccountReference.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AccountReference.Builder MergeFrom(IMessageLite other)
            {
                if (other is AccountReference)
                {
                    return this.MergeFrom((AccountReference) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AccountReference.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AccountReference._accountReferenceFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AccountReference._accountReferenceFieldTags[index];
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

                        case 13:
                        {
                            this.result.hasId = input.ReadFixed32(ref this.result.id_);
                            continue;
                        }
                        case 0x12:
                        {
                            this.result.hasEmail = input.ReadString(ref this.result.email_);
                            continue;
                        }
                        case 0x1a:
                        {
                            GameAccountHandle.Builder builder = GameAccountHandle.CreateBuilder();
                            if (this.result.hasHandle)
                            {
                                builder.MergeFrom(this.Handle);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.Handle = builder.BuildPartial();
                            continue;
                        }
                        case 0x22:
                        {
                            this.result.hasBattleTag = input.ReadString(ref this.result.battleTag_);
                            continue;
                        }
                        case 80:
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
                    this.result.hasRegion = input.ReadUInt32(ref this.result.region_);
                }
                return this;
            }

            public AccountReference.Builder MergeHandle(GameAccountHandle value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasHandle && (this.result.handle_ != GameAccountHandle.DefaultInstance))
                {
                    this.result.handle_ = GameAccountHandle.CreateBuilder(this.result.handle_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.handle_ = value;
                }
                this.result.hasHandle = true;
                return this;
            }

            private AccountReference PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AccountReference result = this.result;
                    this.result = new AccountReference();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public AccountReference.Builder SetBattleTag(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasBattleTag = true;
                this.result.battleTag_ = value;
                return this;
            }

            public AccountReference.Builder SetEmail(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasEmail = true;
                this.result.email_ = value;
                return this;
            }

            public AccountReference.Builder SetHandle(GameAccountHandle value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasHandle = true;
                this.result.handle_ = value;
                return this;
            }

            public AccountReference.Builder SetHandle(GameAccountHandle.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasHandle = true;
                this.result.handle_ = builderForValue.Build();
                return this;
            }

            [CLSCompliant(false)]
            public AccountReference.Builder SetId(uint value)
            {
                this.PrepareBuilder();
                this.result.hasId = true;
                this.result.id_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public AccountReference.Builder SetRegion(uint value)
            {
                this.PrepareBuilder();
                this.result.hasRegion = true;
                this.result.region_ = value;
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

            public override AccountReference DefaultInstanceForType
            {
                get
                {
                    return AccountReference.DefaultInstance;
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

            public GameAccountHandle Handle
            {
                get
                {
                    return this.result.Handle;
                }
                set
                {
                    this.SetHandle(value);
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

            public bool HasHandle
            {
                get
                {
                    return this.result.hasHandle;
                }
            }

            public bool HasId
            {
                get
                {
                    return this.result.hasId;
                }
            }

            public bool HasRegion
            {
                get
                {
                    return this.result.hasRegion;
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

            protected override AccountReference MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            [CLSCompliant(false)]
            public uint Region
            {
                get
                {
                    return this.result.Region;
                }
                set
                {
                    this.SetRegion(value);
                }
            }

            protected override AccountReference.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

