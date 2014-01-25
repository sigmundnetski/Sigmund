namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class ArcaneDustBalance : GeneratedMessageLite<ArcaneDustBalance, Builder>
    {
        private static readonly string[] _arcaneDustBalanceFieldNames = new string[] { "balance" };
        private static readonly uint[] _arcaneDustBalanceFieldTags = new uint[] { 8 };
        private long balance_;
        public const int BalanceFieldNumber = 1;
        private static readonly ArcaneDustBalance defaultInstance = new ArcaneDustBalance().MakeReadOnly();
        private bool hasBalance;
        private int memoizedSerializedSize = -1;

        static ArcaneDustBalance()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private ArcaneDustBalance()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ArcaneDustBalance prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ArcaneDustBalance balance = obj as ArcaneDustBalance;
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

        private ArcaneDustBalance MakeReadOnly()
        {
            return this;
        }

        public static ArcaneDustBalance ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ArcaneDustBalance ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ArcaneDustBalance ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ArcaneDustBalance ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ArcaneDustBalance ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ArcaneDustBalance ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ArcaneDustBalance ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ArcaneDustBalance ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ArcaneDustBalance ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ArcaneDustBalance ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ArcaneDustBalance, Builder>.PrintField("balance", this.hasBalance, this.balance_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _arcaneDustBalanceFieldNames;
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

        public static ArcaneDustBalance DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ArcaneDustBalance DefaultInstanceForType
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

        protected override ArcaneDustBalance ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<ArcaneDustBalance, ArcaneDustBalance.Builder>
        {
            private ArcaneDustBalance result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ArcaneDustBalance.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ArcaneDustBalance cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override ArcaneDustBalance BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ArcaneDustBalance.Builder Clear()
            {
                this.result = ArcaneDustBalance.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ArcaneDustBalance.Builder ClearBalance()
            {
                this.PrepareBuilder();
                this.result.hasBalance = false;
                this.result.balance_ = 0L;
                return this;
            }

            public override ArcaneDustBalance.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ArcaneDustBalance.Builder(this.result);
                }
                return new ArcaneDustBalance.Builder().MergeFrom(this.result);
            }

            public override ArcaneDustBalance.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ArcaneDustBalance.Builder MergeFrom(IMessageLite other)
            {
                if (other is ArcaneDustBalance)
                {
                    return this.MergeFrom((ArcaneDustBalance) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ArcaneDustBalance.Builder MergeFrom(ArcaneDustBalance other)
            {
                if (other != ArcaneDustBalance.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasBalance)
                    {
                        this.Balance = other.Balance;
                    }
                }
                return this;
            }

            public override ArcaneDustBalance.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ArcaneDustBalance._arcaneDustBalanceFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ArcaneDustBalance._arcaneDustBalanceFieldTags[index];
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

            private ArcaneDustBalance PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ArcaneDustBalance result = this.result;
                    this.result = new ArcaneDustBalance();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public ArcaneDustBalance.Builder SetBalance(long value)
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

            public override ArcaneDustBalance DefaultInstanceForType
            {
                get
                {
                    return ArcaneDustBalance.DefaultInstance;
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

            protected override ArcaneDustBalance MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override ArcaneDustBalance.Builder ThisBuilder
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
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0x106
            }
        }
    }
}

