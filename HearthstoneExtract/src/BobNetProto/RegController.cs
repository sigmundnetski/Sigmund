namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class RegController : GeneratedMessageLite<RegController, Builder>
    {
        private static readonly string[] _regControllerFieldNames = new string[] { "build_id", "name", "port" };
        private static readonly uint[] _regControllerFieldTags = new uint[] { 0x18, 0x12, 8 };
        private int buildId_;
        public const int BuildIdFieldNumber = 3;
        private static readonly RegController defaultInstance = new RegController().MakeReadOnly();
        private bool hasBuildId;
        private bool hasName;
        private bool hasPort;
        private int memoizedSerializedSize = -1;
        private string name_ = string.Empty;
        public const int NameFieldNumber = 2;
        private int port_;
        public const int PortFieldNumber = 1;

        static RegController()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private RegController()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(RegController prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            RegController controller = obj as RegController;
            if (controller == null)
            {
                return false;
            }
            if ((this.hasPort != controller.hasPort) || (this.hasPort && !this.port_.Equals(controller.port_)))
            {
                return false;
            }
            if ((this.hasName != controller.hasName) || (this.hasName && !this.name_.Equals(controller.name_)))
            {
                return false;
            }
            return ((this.hasBuildId == controller.hasBuildId) && (!this.hasBuildId || this.buildId_.Equals(controller.buildId_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasPort)
            {
                hashCode ^= this.port_.GetHashCode();
            }
            if (this.hasName)
            {
                hashCode ^= this.name_.GetHashCode();
            }
            if (this.hasBuildId)
            {
                hashCode ^= this.buildId_.GetHashCode();
            }
            return hashCode;
        }

        private RegController MakeReadOnly()
        {
            return this;
        }

        public static RegController ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static RegController ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static RegController ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static RegController ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static RegController ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static RegController ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static RegController ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static RegController ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static RegController ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static RegController ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<RegController, Builder>.PrintField("port", this.hasPort, this.port_, writer);
            GeneratedMessageLite<RegController, Builder>.PrintField("name", this.hasName, this.name_, writer);
            GeneratedMessageLite<RegController, Builder>.PrintField("build_id", this.hasBuildId, this.buildId_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _regControllerFieldNames;
            if (this.hasPort)
            {
                output.WriteInt32(1, strArray[2], this.Port);
            }
            if (this.hasName)
            {
                output.WriteString(2, strArray[1], this.Name);
            }
            if (this.hasBuildId)
            {
                output.WriteInt32(3, strArray[0], this.BuildId);
            }
        }

        public int BuildId
        {
            get
            {
                return this.buildId_;
            }
        }

        public static RegController DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override RegController DefaultInstanceForType
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

        public bool HasName
        {
            get
            {
                return this.hasName;
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
                if (!this.hasName)
                {
                    return false;
                }
                if (!this.hasBuildId)
                {
                    return false;
                }
                return true;
            }
        }

        public string Name
        {
            get
            {
                return this.name_;
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
                    if (this.hasName)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(2, this.Name);
                    }
                    if (this.hasBuildId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(3, this.BuildId);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override RegController ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<RegController, RegController.Builder>
        {
            private RegController result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = RegController.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(RegController cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override RegController BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override RegController.Builder Clear()
            {
                this.result = RegController.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public RegController.Builder ClearBuildId()
            {
                this.PrepareBuilder();
                this.result.hasBuildId = false;
                this.result.buildId_ = 0;
                return this;
            }

            public RegController.Builder ClearName()
            {
                this.PrepareBuilder();
                this.result.hasName = false;
                this.result.name_ = string.Empty;
                return this;
            }

            public RegController.Builder ClearPort()
            {
                this.PrepareBuilder();
                this.result.hasPort = false;
                this.result.port_ = 0;
                return this;
            }

            public override RegController.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new RegController.Builder(this.result);
                }
                return new RegController.Builder().MergeFrom(this.result);
            }

            public override RegController.Builder MergeFrom(RegController other)
            {
                if (other != RegController.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasPort)
                    {
                        this.Port = other.Port;
                    }
                    if (other.HasName)
                    {
                        this.Name = other.Name;
                    }
                    if (other.HasBuildId)
                    {
                        this.BuildId = other.BuildId;
                    }
                }
                return this;
            }

            public override RegController.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override RegController.Builder MergeFrom(IMessageLite other)
            {
                if (other is RegController)
                {
                    return this.MergeFrom((RegController) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override RegController.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(RegController._regControllerFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = RegController._regControllerFieldTags[index];
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
                        {
                            this.result.hasName = input.ReadString(ref this.result.name_);
                            continue;
                        }
                        case 0x18:
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
                    this.result.hasBuildId = input.ReadInt32(ref this.result.buildId_);
                }
                return this;
            }

            private RegController PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    RegController result = this.result;
                    this.result = new RegController();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public RegController.Builder SetBuildId(int value)
            {
                this.PrepareBuilder();
                this.result.hasBuildId = true;
                this.result.buildId_ = value;
                return this;
            }

            public RegController.Builder SetName(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasName = true;
                this.result.name_ = value;
                return this;
            }

            public RegController.Builder SetPort(int value)
            {
                this.PrepareBuilder();
                this.result.hasPort = true;
                this.result.port_ = value;
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

            public override RegController DefaultInstanceForType
            {
                get
                {
                    return RegController.DefaultInstance;
                }
            }

            public bool HasBuildId
            {
                get
                {
                    return this.result.hasBuildId;
                }
            }

            public bool HasName
            {
                get
                {
                    return this.result.hasName;
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

            protected override RegController MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public string Name
            {
                get
                {
                    return this.result.Name;
                }
                set
                {
                    this.SetName(value);
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

            protected override RegController.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0x9b
            }
        }
    }
}

