namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class MassDisenchantResponse : GeneratedMessageLite<MassDisenchantResponse, Builder>
    {
        private static readonly string[] _massDisenchantResponseFieldNames = new string[] { "amount" };
        private static readonly uint[] _massDisenchantResponseFieldTags = new uint[] { 8 };
        private int amount_;
        public const int AmountFieldNumber = 1;
        private static readonly MassDisenchantResponse defaultInstance = new MassDisenchantResponse().MakeReadOnly();
        private bool hasAmount;
        private int memoizedSerializedSize = -1;

        static MassDisenchantResponse()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private MassDisenchantResponse()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(MassDisenchantResponse prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            MassDisenchantResponse response = obj as MassDisenchantResponse;
            if (response == null)
            {
                return false;
            }
            return ((this.hasAmount == response.hasAmount) && (!this.hasAmount || this.amount_.Equals(response.amount_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasAmount)
            {
                hashCode ^= this.amount_.GetHashCode();
            }
            return hashCode;
        }

        private MassDisenchantResponse MakeReadOnly()
        {
            return this;
        }

        public static MassDisenchantResponse ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static MassDisenchantResponse ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static MassDisenchantResponse ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static MassDisenchantResponse ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static MassDisenchantResponse ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static MassDisenchantResponse ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static MassDisenchantResponse ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static MassDisenchantResponse ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static MassDisenchantResponse ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static MassDisenchantResponse ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<MassDisenchantResponse, Builder>.PrintField("amount", this.hasAmount, this.amount_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _massDisenchantResponseFieldNames;
            if (this.hasAmount)
            {
                output.WriteInt32(1, strArray[0], this.Amount);
            }
        }

        public int Amount
        {
            get
            {
                return this.amount_;
            }
        }

        public static MassDisenchantResponse DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override MassDisenchantResponse DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasAmount
        {
            get
            {
                return this.hasAmount;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasAmount)
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
                    if (this.hasAmount)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.Amount);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override MassDisenchantResponse ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<MassDisenchantResponse, MassDisenchantResponse.Builder>
        {
            private MassDisenchantResponse result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = MassDisenchantResponse.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(MassDisenchantResponse cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override MassDisenchantResponse BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override MassDisenchantResponse.Builder Clear()
            {
                this.result = MassDisenchantResponse.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public MassDisenchantResponse.Builder ClearAmount()
            {
                this.PrepareBuilder();
                this.result.hasAmount = false;
                this.result.amount_ = 0;
                return this;
            }

            public override MassDisenchantResponse.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new MassDisenchantResponse.Builder(this.result);
                }
                return new MassDisenchantResponse.Builder().MergeFrom(this.result);
            }

            public override MassDisenchantResponse.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override MassDisenchantResponse.Builder MergeFrom(IMessageLite other)
            {
                if (other is MassDisenchantResponse)
                {
                    return this.MergeFrom((MassDisenchantResponse) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override MassDisenchantResponse.Builder MergeFrom(MassDisenchantResponse other)
            {
                if (other != MassDisenchantResponse.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasAmount)
                    {
                        this.Amount = other.Amount;
                    }
                }
                return this;
            }

            public override MassDisenchantResponse.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(MassDisenchantResponse._massDisenchantResponseFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = MassDisenchantResponse._massDisenchantResponseFieldTags[index];
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
                    this.result.hasAmount = input.ReadInt32(ref this.result.amount_);
                }
                return this;
            }

            private MassDisenchantResponse PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    MassDisenchantResponse result = this.result;
                    this.result = new MassDisenchantResponse();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public MassDisenchantResponse.Builder SetAmount(int value)
            {
                this.PrepareBuilder();
                this.result.hasAmount = true;
                this.result.amount_ = value;
                return this;
            }

            public int Amount
            {
                get
                {
                    return this.result.Amount;
                }
                set
                {
                    this.SetAmount(value);
                }
            }

            public override MassDisenchantResponse DefaultInstanceForType
            {
                get
                {
                    return MassDisenchantResponse.DefaultInstance;
                }
            }

            public bool HasAmount
            {
                get
                {
                    return this.result.hasAmount;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override MassDisenchantResponse MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override MassDisenchantResponse.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0x10d
            }
        }
    }
}

