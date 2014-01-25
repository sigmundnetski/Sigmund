namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
    public sealed class RegUtil : GeneratedMessageLite<RegUtil, Builder>
    {
        private static readonly string[] _regUtilFieldNames = new string[] { "debug_name", "port" };
        private static readonly uint[] _regUtilFieldTags = new uint[] { 0x12, 8 };
        private string debugName_ = string.Empty;
        public const int DebugNameFieldNumber = 2;
        private static readonly RegUtil defaultInstance = new RegUtil().MakeReadOnly();
        private bool hasDebugName;
        private bool hasPort;
        private int memoizedSerializedSize = -1;
        private int port_;
        public const int PortFieldNumber = 1;

        static RegUtil()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private RegUtil()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(RegUtil prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            RegUtil util = obj as RegUtil;
            if (util == null)
            {
                return false;
            }
            if ((this.hasPort != util.hasPort) || (this.hasPort && !this.port_.Equals(util.port_)))
            {
                return false;
            }
            return ((this.hasDebugName == util.hasDebugName) && (!this.hasDebugName || this.debugName_.Equals(util.debugName_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasPort)
            {
                hashCode ^= this.port_.GetHashCode();
            }
            if (this.hasDebugName)
            {
                hashCode ^= this.debugName_.GetHashCode();
            }
            return hashCode;
        }

        private RegUtil MakeReadOnly()
        {
            return this;
        }

        public static RegUtil ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static RegUtil ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static RegUtil ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static RegUtil ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static RegUtil ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static RegUtil ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static RegUtil ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static RegUtil ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static RegUtil ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static RegUtil ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<RegUtil, Builder>.PrintField("port", this.hasPort, this.port_, writer);
            GeneratedMessageLite<RegUtil, Builder>.PrintField("debug_name", this.hasDebugName, this.debugName_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _regUtilFieldNames;
            if (this.hasPort)
            {
                output.WriteInt32(1, strArray[1], this.Port);
            }
            if (this.hasDebugName)
            {
                output.WriteString(2, strArray[0], this.DebugName);
            }
        }

        public string DebugName
        {
            get
            {
                return this.debugName_;
            }
        }

        public static RegUtil DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override RegUtil DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasDebugName
        {
            get
            {
                return this.hasDebugName;
            }
        }

        public bool HasPort
        {
            get
            {
                return this.hasPort;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasPort)
                {
                    return false;
                }
                if (!this.hasDebugName)
                {
                    return false;
                }
                return true;
            }
        }

        public int Port
        {
            get
            {
                return this.port_;
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
                    if (this.hasPort)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.Port);
                    }
                    if (this.hasDebugName)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(2, this.DebugName);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override RegUtil ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<RegUtil, RegUtil.Builder>
        {
            private RegUtil result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = RegUtil.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(RegUtil cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override RegUtil BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override RegUtil.Builder Clear()
            {
                this.result = RegUtil.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public RegUtil.Builder ClearDebugName()
            {
                this.PrepareBuilder();
                this.result.hasDebugName = false;
                this.result.debugName_ = string.Empty;
                return this;
            }

            public RegUtil.Builder ClearPort()
            {
                this.PrepareBuilder();
                this.result.hasPort = false;
                this.result.port_ = 0;
                return this;
            }

            public override RegUtil.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new RegUtil.Builder(this.result);
                }
                return new RegUtil.Builder().MergeFrom(this.result);
            }

            public override RegUtil.Builder MergeFrom(RegUtil other)
            {
                if (other != RegUtil.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasPort)
                    {
                        this.Port = other.Port;
                    }
                    if (other.HasDebugName)
                    {
                        this.DebugName = other.DebugName;
                    }
                }
                return this;
            }

            public override RegUtil.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override RegUtil.Builder MergeFrom(IMessageLite other)
            {
                if (other is RegUtil)
                {
                    return this.MergeFrom((RegUtil) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override RegUtil.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(RegUtil._regUtilFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = RegUtil._regUtilFieldTags[index];
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
                            this.result.hasPort = input.ReadInt32(ref this.result.port_);
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
                    this.result.hasDebugName = input.ReadString(ref this.result.debugName_);
                }
                return this;
            }

            private RegUtil PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    RegUtil result = this.result;
                    this.result = new RegUtil();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public RegUtil.Builder SetDebugName(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasDebugName = true;
                this.result.debugName_ = value;
                return this;
            }

            public RegUtil.Builder SetPort(int value)
            {
                this.PrepareBuilder();
                this.result.hasPort = true;
                this.result.port_ = value;
                return this;
            }

            public string DebugName
            {
                get
                {
                    return this.result.DebugName;
                }
                set
                {
                    this.SetDebugName(value);
                }
            }

            public override RegUtil DefaultInstanceForType
            {
                get
                {
                    return RegUtil.DefaultInstance;
                }
            }

            public bool HasDebugName
            {
                get
                {
                    return this.result.hasDebugName;
                }
            }

            public bool HasPort
            {
                get
                {
                    return this.result.hasPort;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override RegUtil MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public int Port
            {
                get
                {
                    return this.result.Port;
                }
                set
                {
                    this.SetPort(value);
                }
            }

            protected override RegUtil.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public static class Types
        {
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 0x95
            }
        }
    }
}

