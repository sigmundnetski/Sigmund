namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class RegServer : GeneratedMessageLite<RegServer, Builder>
    {
        private static readonly string[] _regServerFieldNames = new string[] { "build_id", "debug_name", "port", "version" };
        private static readonly uint[] _regServerFieldTags = new uint[] { 8, 0x12, 0x18, 0x22 };
        private int buildId_;
        public const int BuildIdFieldNumber = 1;
        private string debugName_ = string.Empty;
        public const int DebugNameFieldNumber = 2;
        private static readonly RegServer defaultInstance = new RegServer().MakeReadOnly();
        private bool hasBuildId;
        private bool hasDebugName;
        private bool hasPort;
        private bool hasVersion;
        private int memoizedSerializedSize = -1;
        private int port_;
        public const int PortFieldNumber = 3;
        private string version_ = string.Empty;
        public const int VersionFieldNumber = 4;

        static RegServer()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private RegServer()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(RegServer prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            RegServer server = obj as RegServer;
            if (server == null)
            {
                return false;
            }
            if ((this.hasBuildId != server.hasBuildId) || (this.hasBuildId && !this.buildId_.Equals(server.buildId_)))
            {
                return false;
            }
            if ((this.hasDebugName != server.hasDebugName) || (this.hasDebugName && !this.debugName_.Equals(server.debugName_)))
            {
                return false;
            }
            if ((this.hasPort != server.hasPort) || (this.hasPort && !this.port_.Equals(server.port_)))
            {
                return false;
            }
            return ((this.hasVersion == server.hasVersion) && (!this.hasVersion || this.version_.Equals(server.version_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasBuildId)
            {
                hashCode ^= this.buildId_.GetHashCode();
            }
            if (this.hasDebugName)
            {
                hashCode ^= this.debugName_.GetHashCode();
            }
            if (this.hasPort)
            {
                hashCode ^= this.port_.GetHashCode();
            }
            if (this.hasVersion)
            {
                hashCode ^= this.version_.GetHashCode();
            }
            return hashCode;
        }

        private RegServer MakeReadOnly()
        {
            return this;
        }

        public static RegServer ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static RegServer ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static RegServer ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static RegServer ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static RegServer ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static RegServer ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static RegServer ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static RegServer ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static RegServer ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static RegServer ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<RegServer, Builder>.PrintField("build_id", this.hasBuildId, this.buildId_, writer);
            GeneratedMessageLite<RegServer, Builder>.PrintField("debug_name", this.hasDebugName, this.debugName_, writer);
            GeneratedMessageLite<RegServer, Builder>.PrintField("port", this.hasPort, this.port_, writer);
            GeneratedMessageLite<RegServer, Builder>.PrintField("version", this.hasVersion, this.version_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _regServerFieldNames;
            if (this.hasBuildId)
            {
                output.WriteInt32(1, strArray[0], this.BuildId);
            }
            if (this.hasDebugName)
            {
                output.WriteString(2, strArray[1], this.DebugName);
            }
            if (this.hasPort)
            {
                output.WriteInt32(3, strArray[2], this.Port);
            }
            if (this.hasVersion)
            {
                output.WriteString(4, strArray[3], this.Version);
            }
        }

        public int BuildId
        {
            get
            {
                return this.buildId_;
            }
        }

        public string DebugName
        {
            get
            {
                return this.debugName_;
            }
        }

        public static RegServer DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override RegServer DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasBuildId
        {
            get
            {
                return this.hasBuildId;
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

        public bool HasVersion
        {
            get
            {
                return this.hasVersion;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasBuildId)
                {
                    return false;
                }
                if (!this.hasDebugName)
                {
                    return false;
                }
                if (!this.hasPort)
                {
                    return false;
                }
                if (!this.hasVersion)
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
                    if (this.hasBuildId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.BuildId);
                    }
                    if (this.hasDebugName)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(2, this.DebugName);
                    }
                    if (this.hasPort)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(3, this.Port);
                    }
                    if (this.hasVersion)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(4, this.Version);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override RegServer ThisMessage
        {
            get
            {
                return this;
            }
        }

        public string Version
        {
            get
            {
                return this.version_;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<RegServer, RegServer.Builder>
        {
            private RegServer result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = RegServer.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(RegServer cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override RegServer BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override RegServer.Builder Clear()
            {
                this.result = RegServer.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public RegServer.Builder ClearBuildId()
            {
                this.PrepareBuilder();
                this.result.hasBuildId = false;
                this.result.buildId_ = 0;
                return this;
            }

            public RegServer.Builder ClearDebugName()
            {
                this.PrepareBuilder();
                this.result.hasDebugName = false;
                this.result.debugName_ = string.Empty;
                return this;
            }

            public RegServer.Builder ClearPort()
            {
                this.PrepareBuilder();
                this.result.hasPort = false;
                this.result.port_ = 0;
                return this;
            }

            public RegServer.Builder ClearVersion()
            {
                this.PrepareBuilder();
                this.result.hasVersion = false;
                this.result.version_ = string.Empty;
                return this;
            }

            public override RegServer.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new RegServer.Builder(this.result);
                }
                return new RegServer.Builder().MergeFrom(this.result);
            }

            public override RegServer.Builder MergeFrom(RegServer other)
            {
                if (other != RegServer.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasBuildId)
                    {
                        this.BuildId = other.BuildId;
                    }
                    if (other.HasDebugName)
                    {
                        this.DebugName = other.DebugName;
                    }
                    if (other.HasPort)
                    {
                        this.Port = other.Port;
                    }
                    if (other.HasVersion)
                    {
                        this.Version = other.Version;
                    }
                }
                return this;
            }

            public override RegServer.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override RegServer.Builder MergeFrom(IMessageLite other)
            {
                if (other is RegServer)
                {
                    return this.MergeFrom((RegServer) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override RegServer.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(RegServer._regServerFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = RegServer._regServerFieldTags[index];
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
                            this.result.hasBuildId = input.ReadInt32(ref this.result.buildId_);
                            continue;
                        }
                        case 0x12:
                        {
                            this.result.hasDebugName = input.ReadString(ref this.result.debugName_);
                            continue;
                        }
                        case 0x18:
                        {
                            this.result.hasPort = input.ReadInt32(ref this.result.port_);
                            continue;
                        }
                        case 0x22:
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
                    this.result.hasVersion = input.ReadString(ref this.result.version_);
                }
                return this;
            }

            private RegServer PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    RegServer result = this.result;
                    this.result = new RegServer();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public RegServer.Builder SetBuildId(int value)
            {
                this.PrepareBuilder();
                this.result.hasBuildId = true;
                this.result.buildId_ = value;
                return this;
            }

            public RegServer.Builder SetDebugName(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasDebugName = true;
                this.result.debugName_ = value;
                return this;
            }

            public RegServer.Builder SetPort(int value)
            {
                this.PrepareBuilder();
                this.result.hasPort = true;
                this.result.port_ = value;
                return this;
            }

            public RegServer.Builder SetVersion(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasVersion = true;
                this.result.version_ = value;
                return this;
            }

            public int BuildId
            {
                get
                {
                    return this.result.BuildId;
                }
                set
                {
                    this.SetBuildId(value);
                }
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

            public override RegServer DefaultInstanceForType
            {
                get
                {
                    return RegServer.DefaultInstance;
                }
            }

            public bool HasBuildId
            {
                get
                {
                    return this.result.hasBuildId;
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

            public bool HasVersion
            {
                get
                {
                    return this.result.hasVersion;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override RegServer MessageBeingBuilt
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

            protected override RegServer.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            public string Version
            {
                get
                {
                    return this.result.Version;
                }
                set
                {
                    this.SetVersion(value);
                }
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public static class Types
        {
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 0x73
            }
        }
    }
}

