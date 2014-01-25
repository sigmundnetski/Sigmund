namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class ServerControl : GeneratedMessageLite<ServerControl, Builder>
    {
        private static readonly string[] _serverControlFieldNames = new string[] { "control_type" };
        private static readonly uint[] _serverControlFieldTags = new uint[] { 8 };
        private BobNetProto.ServerControl.Types.ControlType controlType_ = BobNetProto.ServerControl.Types.ControlType.STOP_GAMES;
        public const int ControlTypeFieldNumber = 1;
        private static readonly ServerControl defaultInstance = new ServerControl().MakeReadOnly();
        private bool hasControlType;
        private int memoizedSerializedSize = -1;

        static ServerControl()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private ServerControl()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ServerControl prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ServerControl control = obj as ServerControl;
            if (control == null)
            {
                return false;
            }
            return ((this.hasControlType == control.hasControlType) && (!this.hasControlType || this.controlType_.Equals(control.controlType_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasControlType)
            {
                hashCode ^= this.controlType_.GetHashCode();
            }
            return hashCode;
        }

        private ServerControl MakeReadOnly()
        {
            return this;
        }

        public static ServerControl ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ServerControl ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ServerControl ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ServerControl ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ServerControl ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ServerControl ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ServerControl ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ServerControl ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ServerControl ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ServerControl ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ServerControl, Builder>.PrintField("control_type", this.hasControlType, this.controlType_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _serverControlFieldNames;
            if (this.hasControlType)
            {
                output.WriteEnum(1, strArray[0], (int) this.ControlType, this.ControlType);
            }
        }

        public BobNetProto.ServerControl.Types.ControlType ControlType
        {
            get
            {
                return this.controlType_;
            }
        }

        public static ServerControl DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ServerControl DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasControlType
        {
            get
            {
                return this.hasControlType;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasControlType)
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
                    if (this.hasControlType)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeEnumSize(1, (int) this.ControlType);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override ServerControl ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<ServerControl, ServerControl.Builder>
        {
            private ServerControl result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ServerControl.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ServerControl cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override ServerControl BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ServerControl.Builder Clear()
            {
                this.result = ServerControl.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ServerControl.Builder ClearControlType()
            {
                this.PrepareBuilder();
                this.result.hasControlType = false;
                this.result.controlType_ = BobNetProto.ServerControl.Types.ControlType.STOP_GAMES;
                return this;
            }

            public override ServerControl.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ServerControl.Builder(this.result);
                }
                return new ServerControl.Builder().MergeFrom(this.result);
            }

            public override ServerControl.Builder MergeFrom(ServerControl other)
            {
                if (other != ServerControl.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasControlType)
                    {
                        this.ControlType = other.ControlType;
                    }
                }
                return this;
            }

            public override ServerControl.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ServerControl.Builder MergeFrom(IMessageLite other)
            {
                if (other is ServerControl)
                {
                    return this.MergeFrom((ServerControl) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ServerControl.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    object obj2;
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ServerControl._serverControlFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ServerControl._serverControlFieldTags[index];
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
                    if (input.ReadEnum<BobNetProto.ServerControl.Types.ControlType>(ref this.result.controlType_, out obj2))
                    {
                        this.result.hasControlType = true;
                    }
                    else if (!(obj2 is int))
                    {
                        continue;
                    }
                }
                return this;
            }

            private ServerControl PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ServerControl result = this.result;
                    this.result = new ServerControl();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public ServerControl.Builder SetControlType(BobNetProto.ServerControl.Types.ControlType value)
            {
                this.PrepareBuilder();
                this.result.hasControlType = true;
                this.result.controlType_ = value;
                return this;
            }

            public BobNetProto.ServerControl.Types.ControlType ControlType
            {
                get
                {
                    return this.result.ControlType;
                }
                set
                {
                    this.SetControlType(value);
                }
            }

            public override ServerControl DefaultInstanceForType
            {
                get
                {
                    return ServerControl.DefaultInstance;
                }
            }

            public bool HasControlType
            {
                get
                {
                    return this.result.hasControlType;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override ServerControl MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override ServerControl.Builder ThisBuilder
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
            public enum ControlType
            {
                START_GAMES = 2,
                STOP_GAMES = 1
            }

            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 0x68
            }
        }
    }
}

