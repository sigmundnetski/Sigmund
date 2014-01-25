namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class AtlasGetOrders : GeneratedMessageLite<AtlasGetOrders, Builder>
    {
        private static readonly string[] _atlasGetOrdersFieldNames = new string[] { "account_id" };
        private static readonly uint[] _atlasGetOrdersFieldTags = new uint[] { 8 };
        private ulong accountId_;
        public const int AccountIdFieldNumber = 1;
        private static readonly AtlasGetOrders defaultInstance = new AtlasGetOrders().MakeReadOnly();
        private bool hasAccountId;
        private int memoizedSerializedSize = -1;

        static AtlasGetOrders()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private AtlasGetOrders()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AtlasGetOrders prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AtlasGetOrders orders = obj as AtlasGetOrders;
            if (orders == null)
            {
                return false;
            }
            return ((this.hasAccountId == orders.hasAccountId) && (!this.hasAccountId || this.accountId_.Equals(orders.accountId_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasAccountId)
            {
                hashCode ^= this.accountId_.GetHashCode();
            }
            return hashCode;
        }

        private AtlasGetOrders MakeReadOnly()
        {
            return this;
        }

        public static AtlasGetOrders ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AtlasGetOrders ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasGetOrders ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasGetOrders ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasGetOrders ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasGetOrders ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasGetOrders ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AtlasGetOrders ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasGetOrders ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasGetOrders ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AtlasGetOrders, Builder>.PrintField("account_id", this.hasAccountId, this.accountId_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _atlasGetOrdersFieldNames;
            if (this.hasAccountId)
            {
                output.WriteUInt64(1, strArray[0], this.AccountId);
            }
        }

        [CLSCompliant(false)]
        public ulong AccountId
        {
            get
            {
                return this.accountId_;
            }
        }

        public static AtlasGetOrders DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AtlasGetOrders DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasAccountId
        {
            get
            {
                return this.hasAccountId;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasAccountId)
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
                    if (this.hasAccountId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt64Size(1, this.AccountId);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override AtlasGetOrders ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<AtlasGetOrders, AtlasGetOrders.Builder>
        {
            private AtlasGetOrders result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AtlasGetOrders.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AtlasGetOrders cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override AtlasGetOrders BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AtlasGetOrders.Builder Clear()
            {
                this.result = AtlasGetOrders.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AtlasGetOrders.Builder ClearAccountId()
            {
                this.PrepareBuilder();
                this.result.hasAccountId = false;
                this.result.accountId_ = 0L;
                return this;
            }

            public override AtlasGetOrders.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AtlasGetOrders.Builder(this.result);
                }
                return new AtlasGetOrders.Builder().MergeFrom(this.result);
            }

            public override AtlasGetOrders.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AtlasGetOrders.Builder MergeFrom(IMessageLite other)
            {
                if (other is AtlasGetOrders)
                {
                    return this.MergeFrom((AtlasGetOrders) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AtlasGetOrders.Builder MergeFrom(AtlasGetOrders other)
            {
                if (other != AtlasGetOrders.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasAccountId)
                    {
                        this.AccountId = other.AccountId;
                    }
                }
                return this;
            }

            public override AtlasGetOrders.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AtlasGetOrders._atlasGetOrdersFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AtlasGetOrders._atlasGetOrdersFieldTags[index];
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
                    this.result.hasAccountId = input.ReadUInt64(ref this.result.accountId_);
                }
                return this;
            }

            private AtlasGetOrders PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AtlasGetOrders result = this.result;
                    this.result = new AtlasGetOrders();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            [CLSCompliant(false)]
            public AtlasGetOrders.Builder SetAccountId(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasAccountId = true;
                this.result.accountId_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public ulong AccountId
            {
                get
                {
                    return this.result.AccountId;
                }
                set
                {
                    this.SetAccountId(value);
                }
            }

            public override AtlasGetOrders DefaultInstanceForType
            {
                get
                {
                    return AtlasGetOrders.DefaultInstance;
                }
            }

            public bool HasAccountId
            {
                get
                {
                    return this.result.hasAccountId;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override AtlasGetOrders MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override AtlasGetOrders.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0x199
            }
        }
    }
}

