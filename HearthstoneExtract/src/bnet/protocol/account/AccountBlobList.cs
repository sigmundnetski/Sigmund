namespace bnet.protocol.account
{
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Collections;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class AccountBlobList : GeneratedMessageLite<AccountBlobList, Builder>
    {
        private static readonly string[] _accountBlobListFieldNames = new string[] { "blob" };
        private static readonly uint[] _accountBlobListFieldTags = new uint[] { 10 };
        private PopsicleList<AccountBlob> blob_ = new PopsicleList<AccountBlob>();
        public const int BlobFieldNumber = 1;
        private static readonly AccountBlobList defaultInstance = new AccountBlobList().MakeReadOnly();
        private int memoizedSerializedSize = -1;

        static AccountBlobList()
        {
            object.ReferenceEquals(AccountTypes.Descriptor, null);
        }

        private AccountBlobList()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AccountBlobList prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AccountBlobList list = obj as AccountBlobList;
            if (list == null)
            {
                return false;
            }
            if (this.blob_.Count != list.blob_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.blob_.Count; i++)
            {
                if (!this.blob_[i].Equals(list.blob_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public AccountBlob GetBlob(int index)
        {
            return this.blob_[index];
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            IEnumerator<AccountBlob> enumerator = this.blob_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    AccountBlob current = enumerator.Current;
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

        private AccountBlobList MakeReadOnly()
        {
            this.blob_.MakeReadOnly();
            return this;
        }

        public static AccountBlobList ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AccountBlobList ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AccountBlobList ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AccountBlobList ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AccountBlobList ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AccountBlobList ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AccountBlobList ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AccountBlobList ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AccountBlobList ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AccountBlobList ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AccountBlobList, Builder>.PrintField<AccountBlob>("blob", this.blob_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _accountBlobListFieldNames;
            if (this.blob_.Count > 0)
            {
                output.WriteMessageArray<AccountBlob>(1, strArray[0], this.blob_);
            }
        }

        public int BlobCount
        {
            get
            {
                return this.blob_.Count;
            }
        }

        public IList<AccountBlob> BlobList
        {
            get
            {
                return this.blob_;
            }
        }

        public static AccountBlobList DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AccountBlobList DefaultInstanceForType
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
                IEnumerator<AccountBlob> enumerator = this.BlobList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        AccountBlob current = enumerator.Current;
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
                    IEnumerator<AccountBlob> enumerator = this.BlobList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            AccountBlob current = enumerator.Current;
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

        protected override AccountBlobList ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<AccountBlobList, AccountBlobList.Builder>
        {
            private AccountBlobList result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AccountBlobList.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AccountBlobList cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public AccountBlobList.Builder AddBlob(AccountBlob value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.blob_.Add(value);
                return this;
            }

            public AccountBlobList.Builder AddBlob(AccountBlob.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.blob_.Add(builderForValue.Build());
                return this;
            }

            public AccountBlobList.Builder AddRangeBlob(IEnumerable<AccountBlob> values)
            {
                this.PrepareBuilder();
                this.result.blob_.Add(values);
                return this;
            }

            public override AccountBlobList BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AccountBlobList.Builder Clear()
            {
                this.result = AccountBlobList.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AccountBlobList.Builder ClearBlob()
            {
                this.PrepareBuilder();
                this.result.blob_.Clear();
                return this;
            }

            public override AccountBlobList.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AccountBlobList.Builder(this.result);
                }
                return new AccountBlobList.Builder().MergeFrom(this.result);
            }

            public AccountBlob GetBlob(int index)
            {
                return this.result.GetBlob(index);
            }

            public override AccountBlobList.Builder MergeFrom(AccountBlobList other)
            {
                if (other != AccountBlobList.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.blob_.Count != 0)
                    {
                        this.result.blob_.Add(other.blob_);
                    }
                }
                return this;
            }

            public override AccountBlobList.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AccountBlobList.Builder MergeFrom(IMessageLite other)
            {
                if (other is AccountBlobList)
                {
                    return this.MergeFrom((AccountBlobList) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AccountBlobList.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AccountBlobList._accountBlobListFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AccountBlobList._accountBlobListFieldTags[index];
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
                    input.ReadMessageArray<AccountBlob>(num, str, this.result.blob_, AccountBlob.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private AccountBlobList PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AccountBlobList result = this.result;
                    this.result = new AccountBlobList();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public AccountBlobList.Builder SetBlob(int index, AccountBlob value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.blob_[index] = value;
                return this;
            }

            public AccountBlobList.Builder SetBlob(int index, AccountBlob.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.blob_[index] = builderForValue.Build();
                return this;
            }

            public int BlobCount
            {
                get
                {
                    return this.result.BlobCount;
                }
            }

            public IPopsicleList<AccountBlob> BlobList
            {
                get
                {
                    return this.PrepareBuilder().blob_;
                }
            }

            public override AccountBlobList DefaultInstanceForType
            {
                get
                {
                    return AccountBlobList.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override AccountBlobList MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override AccountBlobList.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

