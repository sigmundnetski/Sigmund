namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class GoldBalance : GeneratedMessageLite<GoldBalance, Builder>
    {
        private static readonly string[] _goldBalanceFieldNames = new string[] { "balance" };
        private static readonly uint[] _goldBalanceFieldTags = new uint[] { 8 };
        private long balance_;
        public const int BalanceFieldNumber = 1;
        private static readonly GoldBalance defaultInstance = new GoldBalance().MakeReadOnly();
        private bool hasBalance;
        private int memoizedSerializedSize = -1;

        static GoldBalance()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private GoldBalance()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(GoldBalance prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            GoldBalance balance = obj as GoldBalance;
            if (balance == null)
            {
                return false;
            }
            return ((this.hasBalance == balance.hasBalance) && (!this.hasBalance || this.balance_.Equals(balance.balance_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasBalance)
            {
                hashCode ^= this.balance_.GetHashCode();
            }
            return hashCode;
        }

        private GoldBalance MakeReadOnly()
        {
            return this;
        }

        public static GoldBalance ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static GoldBalance ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static GoldBalance ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GoldBalance ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GoldBalance ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GoldBalance ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GoldBalance ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static GoldBalance ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GoldBalance ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GoldBalance ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<GoldBalance, Builder>.PrintField("balance", this.hasBalance, this.balance_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _goldBalanceFieldNames;
            if (this.hasBalance)
            {
                output.WriteInt64(1, strArray[0], this.Balance);
            }
        }

        public long Balance
        {
            get
            {
                return this.balance_;
            }
        }

        public static GoldBalance DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override GoldBalance DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasBalance
        {
            get
            {
                return this.hasBalance;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasBalance)
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
                    if (this.hasBalance)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt64Size(1, this.Balance);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override GoldBalance ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<GoldBalance, GoldBalance.Builder>
        {
            private GoldBalance result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = GoldBalance.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(GoldBalance cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override GoldBalance BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override GoldBalance.Builder Clear()
            {
                this.result = GoldBalance.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public GoldBalance.Builder ClearBalance()
            {
                this.PrepareBuilder();
                this.result.hasBalance = false;
                this.result.balance_ = 0L;
                return this;
            }

            public override GoldBalance.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new GoldBalance.Builder(this.result);
                }
                return new GoldBalance.Builder().MergeFrom(this.result);
            }

            public override GoldBalance.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override GoldBalance.Builder MergeFrom(IMessageLite other)
            {
                if (other is GoldBalance)
                {
                    return this.MergeFrom((GoldBalance) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override GoldBalance.Builder MergeFrom(GoldBalance other)
            {
                if (other != GoldBalance.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasBalance)
                    {
                        this.Balance = other.Balance;
                    }
                }
                return this;
            }

            public override GoldBalance.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(GoldBalance._goldBalanceFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = GoldBalance._goldBalanceFieldTags[index];
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
                    this.result.hasBalance = input.ReadInt64(ref this.result.balance_);
                }
                return this;
            }

            private GoldBalance PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    GoldBalance result = this.result;
                    this.result = new GoldBalance();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public GoldBalance.Builder SetBalance(long value)
            {
                this.PrepareBuilder();
                this.result.hasBalance = true;
                this.result.balance_ = value;
                return this;
            }

            public long Balance
            {
                get
                {
                    return this.result.Balance;
                }
                set
                {
                    this.SetBalance(value);
                }
            }

            public override GoldBalance DefaultInstanceForType
            {
                get
                {
                    return GoldBalance.DefaultInstance;
                }
            }

            public bool HasBalance
            {
                get
                {
                    return this.result.hasBalance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override GoldBalance MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override GoldBalance.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public static class Types
        {
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 0x116
            }
        }
    }
}

