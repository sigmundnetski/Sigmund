namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class OpenBooster : GeneratedMessageLite<OpenBooster, Builder>
    {
        private static readonly string[] _openBoosterFieldNames = new string[] { "booster_type" };
        private static readonly uint[] _openBoosterFieldTags = new uint[] { 0x10 };
        private int boosterType_;
        public const int BoosterTypeFieldNumber = 2;
        private static readonly OpenBooster defaultInstance = new OpenBooster().MakeReadOnly();
        private bool hasBoosterType;
        private int memoizedSerializedSize = -1;

        static OpenBooster()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private OpenBooster()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(OpenBooster prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            OpenBooster booster = obj as OpenBooster;
            if (booster == null)
            {
                return false;
            }
            return ((this.hasBoosterType == booster.hasBoosterType) && (!this.hasBoosterType || this.boosterType_.Equals(booster.boosterType_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasBoosterType)
            {
                hashCode ^= this.boosterType_.GetHashCode();
            }
            return hashCode;
        }

        private OpenBooster MakeReadOnly()
        {
            return this;
        }

        public static OpenBooster ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static OpenBooster ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static OpenBooster ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static OpenBooster ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static OpenBooster ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static OpenBooster ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static OpenBooster ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static OpenBooster ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static OpenBooster ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static OpenBooster ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<OpenBooster, Builder>.PrintField("booster_type", this.hasBoosterType, this.boosterType_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _openBoosterFieldNames;
            if (this.hasBoosterType)
            {
                output.WriteInt32(2, strArray[0], this.BoosterType);
            }
        }

        public int BoosterType
        {
            get
            {
                return this.boosterType_;
            }
        }

        public static OpenBooster DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override OpenBooster DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasBoosterType
        {
            get
            {
                return this.hasBoosterType;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasBoosterType)
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
                    if (this.hasBoosterType)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.BoosterType);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override OpenBooster ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<OpenBooster, OpenBooster.Builder>
        {
            private OpenBooster result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = OpenBooster.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(OpenBooster cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override OpenBooster BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override OpenBooster.Builder Clear()
            {
                this.result = OpenBooster.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public OpenBooster.Builder ClearBoosterType()
            {
                this.PrepareBuilder();
                this.result.hasBoosterType = false;
                this.result.boosterType_ = 0;
                return this;
            }

            public override OpenBooster.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new OpenBooster.Builder(this.result);
                }
                return new OpenBooster.Builder().MergeFrom(this.result);
            }

            public override OpenBooster.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override OpenBooster.Builder MergeFrom(IMessageLite other)
            {
                if (other is OpenBooster)
                {
                    return this.MergeFrom((OpenBooster) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override OpenBooster.Builder MergeFrom(OpenBooster other)
            {
                if (other != OpenBooster.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasBoosterType)
                    {
                        this.BoosterType = other.BoosterType;
                    }
                }
                return this;
            }

            public override OpenBooster.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(OpenBooster._openBoosterFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = OpenBooster._openBoosterFieldTags[index];
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

                        case 0x10:
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
                    this.result.hasBoosterType = input.ReadInt32(ref this.result.boosterType_);
                }
                return this;
            }

            private OpenBooster PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    OpenBooster result = this.result;
                    this.result = new OpenBooster();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public OpenBooster.Builder SetBoosterType(int value)
            {
                this.PrepareBuilder();
                this.result.hasBoosterType = true;
                this.result.boosterType_ = value;
                return this;
            }

            public int BoosterType
            {
                get
                {
                    return this.result.BoosterType;
                }
                set
                {
                    this.SetBoosterType(value);
                }
            }

            public override OpenBooster DefaultInstanceForType
            {
                get
                {
                    return OpenBooster.DefaultInstance;
                }
            }

            public bool HasBoosterType
            {
                get
                {
                    return this.result.hasBoosterType;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override OpenBooster MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override OpenBooster.Builder ThisBuilder
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
                ID = 0xe1,
                System = 0
            }
        }
    }
}

