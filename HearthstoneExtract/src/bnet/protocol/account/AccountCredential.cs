namespace bnet.protocol.account
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class AccountCredential : GeneratedMessageLite<AccountCredential, Builder>
    {
        private static readonly string[] _accountCredentialFieldNames = new string[] { "data", "id" };
        private static readonly uint[] _accountCredentialFieldTags = new uint[] { 0x12, 8 };
        private ByteString data_ = ByteString.Empty;
        public const int DataFieldNumber = 2;
        private static readonly AccountCredential defaultInstance = new AccountCredential().MakeReadOnly();
        private bool hasData;
        private bool hasId;
        private uint id_;
        public const int IdFieldNumber = 1;
        private int memoizedSerializedSize = -1;

        static AccountCredential()
        {
            object.ReferenceEquals(AccountTypes.Descriptor, null);
        }

        private AccountCredential()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AccountCredential prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AccountCredential credential = obj as AccountCredential;
            if (credential == null)
            {
                return false;
            }
            if ((this.hasId != credential.hasId) || (this.hasId && !this.id_.Equals(credential.id_)))
            {
                return false;
            }
            return ((this.hasData == credential.hasData) && (!this.hasData || this.data_.Equals(credential.data_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasId)
            {
                hashCode ^= this.id_.GetHashCode();
            }
            if (this.hasData)
            {
                hashCode ^= this.data_.GetHashCode();
            }
            return hashCode;
        }

        private AccountCredential MakeReadOnly()
        {
            return this;
        }

        public static AccountCredential ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AccountCredential ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AccountCredential ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AccountCredential ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AccountCredential ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AccountCredential ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AccountCredential ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AccountCredential ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AccountCredential ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AccountCredential ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AccountCredential, Builder>.PrintField("id", this.hasId, this.id_, writer);
            GeneratedMessageLite<AccountCredential, Builder>.PrintField("data", this.hasData, this.data_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _accountCredentialFieldNames;
            if (this.hasId)
            {
                output.WriteUInt32(1, strArray[1], this.Id);
            }
            if (this.hasData)
            {
                output.WriteBytes(2, strArray[0], this.Data);
            }
        }

        public ByteString Data
        {
            get
            {
                return this.data_;
            }
        }

        public static AccountCredential DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AccountCredential DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasData
        {
            get
            {
                return this.hasData;
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
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(1, this.Id);
                    }
                    if (this.hasData)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBytesSize(2, this.Data);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override AccountCredential ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<AccountCredential, AccountCredential.Builder>
        {
            private AccountCredential result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AccountCredential.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AccountCredential cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override AccountCredential BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AccountCredential.Builder Clear()
            {
                this.result = AccountCredential.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AccountCredential.Builder ClearData()
            {
                this.PrepareBuilder();
                this.result.hasData = false;
                this.result.data_ = ByteString.Empty;
                return this;
            }

            public AccountCredential.Builder ClearId()
            {
                this.PrepareBuilder();
                this.result.hasId = false;
                this.result.id_ = 0;
                return this;
            }

            public override AccountCredential.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AccountCredential.Builder(this.result);
                }
                return new AccountCredential.Builder().MergeFrom(this.result);
            }

            public override AccountCredential.Builder MergeFrom(AccountCredential other)
            {
                if (other != AccountCredential.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasId)
                    {
                        this.Id = other.Id;
                    }
                    if (other.HasData)
                    {
                        this.Data = other.Data;
                    }
                }
                return this;
            }

            public override AccountCredential.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AccountCredential.Builder MergeFrom(IMessageLite other)
            {
                if (other is AccountCredential)
                {
                    return this.MergeFrom((AccountCredential) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AccountCredential.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AccountCredential._accountCredentialFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AccountCredential._accountCredentialFieldTags[index];
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
                            this.result.hasId = input.ReadUInt32(ref this.result.id_);
                            continue;
                        }
                        case 0x12:
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
                    this.result.hasData = input.ReadBytes(ref this.result.data_);
                }
                return this;
            }

            private AccountCredential PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AccountCredential result = this.result;
                    this.result = new AccountCredential();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public AccountCredential.Builder SetData(ByteString value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasData = true;
                this.result.data_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public AccountCredential.Builder SetId(uint value)
            {
                this.PrepareBuilder();
                this.result.hasId = true;
                this.result.id_ = value;
                return this;
            }

            public ByteString Data
            {
                get
                {
                    return this.result.Data;
                }
                set
                {
                    this.SetData(value);
                }
            }

            public override AccountCredential DefaultInstanceForType
            {
                get
                {
                    return AccountCredential.DefaultInstance;
                }
            }

            public bool HasData
            {
                get
                {
                    return this.result.hasData;
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

            protected override AccountCredential MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override AccountCredential.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

