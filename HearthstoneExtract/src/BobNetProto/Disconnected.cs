namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class Disconnected : GeneratedMessageLite<Disconnected, Builder>
    {
        private static readonly string[] _disconnectedFieldNames = new string[] { "info" };
        private static readonly uint[] _disconnectedFieldTags = new uint[] { 10 };
        private static readonly Disconnected defaultInstance = new Disconnected().MakeReadOnly();
        private bool hasInfo;
        private GotoServer info_;
        public const int InfoFieldNumber = 1;
        private int memoizedSerializedSize = -1;

        static Disconnected()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private Disconnected()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(Disconnected prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            Disconnected disconnected = obj as Disconnected;
            if (disconnected == null)
            {
                return false;
            }
            return ((this.hasInfo == disconnected.hasInfo) && (!this.hasInfo || this.info_.Equals(disconnected.info_)));
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

        private Disconnected MakeReadOnly()
        {
            return this;
        }

        public static Disconnected ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static Disconnected ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static Disconnected ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Disconnected ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Disconnected ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Disconnected ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Disconnected ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static Disconnected ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Disconnected ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Disconnected ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<Disconnected, Builder>.PrintField("info", this.hasInfo, this.info_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _disconnectedFieldNames;
            if (this.hasInfo)
            {
                output.WriteMessage(1, strArray[0], this.Info);
            }
        }

        public static Disconnected DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override Disconnected DefaultInstanceForType
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

        public GotoServer Info
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.info_ != null)
                {
                    goto Label_0012;
                }
                return GotoServer.DefaultInstance;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (this.HasInfo && !this.Info.IsInitialized)
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

        protected override Disconnected ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<Disconnected, Disconnected.Builder>
        {
            private Disconnected result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = Disconnected.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(Disconnected cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override Disconnected BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override Disconnected.Builder Clear()
            {
                this.result = Disconnected.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public Disconnected.Builder ClearInfo()
            {
                this.PrepareBuilder();
                this.result.hasInfo = false;
                this.result.info_ = null;
                return this;
            }

            public override Disconnected.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new Disconnected.Builder(this.result);
                }
                return new Disconnected.Builder().MergeFrom(this.result);
            }

            public override Disconnected.Builder MergeFrom(Disconnected other)
            {
                if (other != Disconnected.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasInfo)
                    {
                        this.MergeInfo(other.Info);
                    }
                }
                return this;
            }

            public override Disconnected.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override Disconnected.Builder MergeFrom(IMessageLite other)
            {
                if (other is Disconnected)
                {
                    return this.MergeFrom((Disconnected) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override Disconnected.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(Disconnected._disconnectedFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = Disconnected._disconnectedFieldTags[index];
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
                            GotoServer.Builder builder = GotoServer.CreateBuilder();
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

            public Disconnected.Builder MergeInfo(GotoServer value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasInfo && (this.result.info_ != GotoServer.DefaultInstance))
                {
                    this.result.info_ = GotoServer.CreateBuilder(this.result.info_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.info_ = value;
                }
                this.result.hasInfo = true;
                return this;
            }

            private Disconnected PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    Disconnected result = this.result;
                    this.result = new Disconnected();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public Disconnected.Builder SetInfo(GotoServer value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasInfo = true;
                this.result.info_ = value;
                return this;
            }

            public Disconnected.Builder SetInfo(GotoServer.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasInfo = true;
                this.result.info_ = builderForValue.Build();
                return this;
            }

            public override Disconnected DefaultInstanceForType
            {
                get
                {
                    return Disconnected.DefaultInstance;
                }
            }

            public bool HasInfo
            {
                get
                {
                    return this.result.hasInfo;
                }
            }

            public GotoServer Info
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

            protected override Disconnected MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override Disconnected.Builder ThisBuilder
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
                ID = 170
            }
        }
    }
}

