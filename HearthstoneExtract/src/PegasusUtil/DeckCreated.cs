namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class DeckCreated : GeneratedMessageLite<DeckCreated, Builder>
    {
        private static readonly string[] _deckCreatedFieldNames = new string[] { "info" };
        private static readonly uint[] _deckCreatedFieldTags = new uint[] { 10 };
        private static readonly DeckCreated defaultInstance = new DeckCreated().MakeReadOnly();
        private bool hasInfo;
        private DeckInfo info_;
        public const int InfoFieldNumber = 1;
        private int memoizedSerializedSize = -1;

        static DeckCreated()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private DeckCreated()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(DeckCreated prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            DeckCreated created = obj as DeckCreated;
            if (created == null)
            {
                return false;
            }
            return ((this.hasInfo == created.hasInfo) && (!this.hasInfo || this.info_.Equals(created.info_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasInfo)
            {
                hashCode ^= this.info_.GetHashCode();
            }
            return hashCode;
        }

        private DeckCreated MakeReadOnly()
        {
            return this;
        }

        public static DeckCreated ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static DeckCreated ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static DeckCreated ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DeckCreated ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DeckCreated ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DeckCreated ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DeckCreated ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static DeckCreated ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DeckCreated ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DeckCreated ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<DeckCreated, Builder>.PrintField("info", this.hasInfo, this.info_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _deckCreatedFieldNames;
            if (this.hasInfo)
            {
                output.WriteMessage(1, strArray[0], this.Info);
            }
        }

        public static DeckCreated DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override DeckCreated DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasInfo
        {
            get
            {
                return this.hasInfo;
            }
        }

        public DeckInfo Info
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.info_ != null)
                {
                    goto Label_0012;
                }
                return DeckInfo.DefaultInstance;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasInfo)
                {
                    return false;
                }
                if (!this.Info.IsInitialized)
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
                    if (this.hasInfo)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, this.Info);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override DeckCreated ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<DeckCreated, DeckCreated.Builder>
        {
            private DeckCreated result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = DeckCreated.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(DeckCreated cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override DeckCreated BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override DeckCreated.Builder Clear()
            {
                this.result = DeckCreated.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public DeckCreated.Builder ClearInfo()
            {
                this.PrepareBuilder();
                this.result.hasInfo = false;
                this.result.info_ = null;
                return this;
            }

            public override DeckCreated.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new DeckCreated.Builder(this.result);
                }
                return new DeckCreated.Builder().MergeFrom(this.result);
            }

            public override DeckCreated.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override DeckCreated.Builder MergeFrom(IMessageLite other)
            {
                if (other is DeckCreated)
                {
                    return this.MergeFrom((DeckCreated) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override DeckCreated.Builder MergeFrom(DeckCreated other)
            {
                if (other != DeckCreated.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasInfo)
                    {
                        this.MergeInfo(other.Info);
                    }
                }
                return this;
            }

            public override DeckCreated.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(DeckCreated._deckCreatedFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = DeckCreated._deckCreatedFieldTags[index];
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
                            DeckInfo.Builder builder = DeckInfo.CreateBuilder();
                            if (this.result.hasInfo)
                            {
                                builder.MergeFrom(this.Info);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.Info = builder.BuildPartial();
                            continue;
                        }
                    }
                    if (WireFormat.IsEndGroupTag(num))
                    {
                        return this;
                    }
                    this.ParseUnknownField(input, extensionRegistry, num, str);
                }
                return this;
            }

            public DeckCreated.Builder MergeInfo(DeckInfo value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasInfo && (this.result.info_ != DeckInfo.DefaultInstance))
                {
                    this.result.info_ = DeckInfo.CreateBuilder(this.result.info_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.info_ = value;
                }
                this.result.hasInfo = true;
                return this;
            }

            private DeckCreated PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    DeckCreated result = this.result;
                    this.result = new DeckCreated();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public DeckCreated.Builder SetInfo(DeckInfo value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasInfo = true;
                this.result.info_ = value;
                return this;
            }

            public DeckCreated.Builder SetInfo(DeckInfo.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasInfo = true;
                this.result.info_ = builderForValue.Build();
                return this;
            }

            public override DeckCreated DefaultInstanceForType
            {
                get
                {
                    return DeckCreated.DefaultInstance;
                }
            }

            public bool HasInfo
            {
                get
                {
                    return this.result.hasInfo;
                }
            }

            public DeckInfo Info
            {
                get
                {
                    return this.result.Info;
                }
                set
                {
                    this.SetInfo(value);
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override DeckCreated MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override DeckCreated.Builder ThisBuilder
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
                ID = 0xd9
            }
        }
    }
}

