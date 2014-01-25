namespace bnet.protocol.account
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class AccountId : GeneratedMessageLite<AccountId, Builder>
    {
        private static readonly string[] _accountIdFieldNames = new string[] { "id" };
        private static readonly uint[] _accountIdFieldTags = new uint[] { 13 };
        private static readonly AccountId defaultInstance = new AccountId().MakeReadOnly();
        private bool hasId;
        private uint id_;
        public const int IdFieldNumber = 1;
        private int memoizedSerializedSize = -1;

        static AccountId()
        {
            object.ReferenceEquals(AccountTypes.Descriptor, null);
        }

        private AccountId()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AccountId prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AccountId id = obj as AccountId;
            if (id == null)
            {
                return false;
            }
            return ((this.hasId == id.hasId) && (!this.hasId || this.id_.Equals(id.id_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasId)
            {
                hashCode ^= this.id_.GetHashCode();
            }
            return hashCode;
        }

        private AccountId MakeReadOnly()
        {
            return this;
        }

        public static AccountId ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AccountId ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AccountId ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AccountId ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AccountId ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AccountId ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AccountId ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AccountId ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AccountId ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AccountId ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AccountId, Builder>.PrintField("id", this.hasId, this.id_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _accountIdFieldNames;
            if (this.hasId)
            {
                output.WriteFixed32(1, strArray[0], this.Id);
            }
        }

        public static AccountId DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AccountId DefaultInstanceForType
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
                if (!this.hasId)
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
                    if (this.hasId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeFixed32Size(1, this.Id);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override AccountId ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<AccountId, AccountId.Builder>
        {
            private AccountId result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AccountId.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AccountId cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override AccountId BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AccountId.Builder Clear()
            {
                this.result = AccountId.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AccountId.Builder ClearId()
            {
                this.PrepareBuilder();
                this.result.hasId = false;
                this.result.id_ = 0;
                return this;
            }

            public override AccountId.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AccountId.Builder(this.result);
                }
                return new AccountId.Builder().MergeFrom(this.result);
            }

            public override AccountId.Builder MergeFrom(AccountId other)
            {
                if (other != AccountId.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasId)
                    {
                        this.Id = other.Id;
                    }
                }
                return this;
            }

            public override AccountId.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AccountId.Builder MergeFrom(IMessageLite other)
            {
                if (other is AccountId)
                {
                    return this.MergeFrom((AccountId) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AccountId.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AccountId._accountIdFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AccountId._accountIdFieldTags[index];
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
                    this.result.hasId = input.ReadFixed32(ref this.result.id_);
                }
                return this;
            }

            private AccountId PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AccountId result = this.result;
                    this.result = new AccountId();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            [CLSCompliant(false)]
            public AccountId.Builder SetId(uint value)
            {
                this.PrepareBuilder();
                this.result.hasId = true;
                this.result.id_ = value;
                return this;
            }

            public override AccountId DefaultInstanceForType
            {
                get
                {
                    return AccountId.DefaultInstance;
                }
            }

            public bool HasId
            {
                get
                {
                    return this.result.hasId;
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

            protected override AccountId MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override AccountId.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

