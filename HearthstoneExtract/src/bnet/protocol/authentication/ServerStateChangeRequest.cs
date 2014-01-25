namespace bnet.protocol.authentication
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class ServerStateChangeRequest : GeneratedMessageLite<ServerStateChangeRequest, Builder>
    {
        private static readonly string[] _serverStateChangeRequestFieldNames = new string[] { "event_time", "state" };
        private static readonly uint[] _serverStateChangeRequestFieldTags = new uint[] { 0x10, 8 };
        private static readonly ServerStateChangeRequest defaultInstance = new ServerStateChangeRequest().MakeReadOnly();
        private ulong eventTime_;
        public const int EventTimeFieldNumber = 2;
        private bool hasEventTime;
        private bool hasState;
        private int memoizedSerializedSize = -1;
        private uint state_;
        public const int StateFieldNumber = 1;

        static ServerStateChangeRequest()
        {
            object.ReferenceEquals(AuthenticationService.Descriptor, null);
        }

        private ServerStateChangeRequest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ServerStateChangeRequest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ServerStateChangeRequest request = obj as ServerStateChangeRequest;
            if (request == null)
            {
                return false;
            }
            if ((this.hasState != request.hasState) || (this.hasState && !this.state_.Equals(request.state_)))
            {
                return false;
            }
            return ((this.hasEventTime == request.hasEventTime) && (!this.hasEventTime || this.eventTime_.Equals(request.eventTime_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasState)
            {
                hashCode ^= this.state_.GetHashCode();
            }
            if (this.hasEventTime)
            {
                hashCode ^= this.eventTime_.GetHashCode();
            }
            return hashCode;
        }

        private ServerStateChangeRequest MakeReadOnly()
        {
            return this;
        }

        public static ServerStateChangeRequest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ServerStateChangeRequest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ServerStateChangeRequest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ServerStateChangeRequest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ServerStateChangeRequest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ServerStateChangeRequest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ServerStateChangeRequest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ServerStateChangeRequest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ServerStateChangeRequest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ServerStateChangeRequest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ServerStateChangeRequest, Builder>.PrintField("state", this.hasState, this.state_, writer);
            GeneratedMessageLite<ServerStateChangeRequest, Builder>.PrintField("event_time", this.hasEventTime, this.eventTime_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _serverStateChangeRequestFieldNames;
            if (this.hasState)
            {
                output.WriteUInt32(1, strArray[1], this.State);
            }
            if (this.hasEventTime)
            {
                output.WriteUInt64(2, strArray[0], this.EventTime);
            }
        }

        public static ServerStateChangeRequest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ServerStateChangeRequest DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        [CLSCompliant(false)]
        public ulong EventTime
        {
            get
            {
                return this.eventTime_;
            }
        }

        public bool HasEventTime
        {
            get
            {
                return this.hasEventTime;
            }
        }

        public bool HasState
        {
            get
            {
                return this.hasState;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasState)
                {
                    return false;
                }
                if (!this.hasEventTime)
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
                    if (this.hasState)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(1, this.State);
                    }
                    if (this.hasEventTime)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt64Size(2, this.EventTime);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        [CLSCompliant(false)]
        public uint State
        {
            get
            {
                return this.state_;
            }
        }

        protected override ServerStateChangeRequest ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<ServerStateChangeRequest, ServerStateChangeRequest.Builder>
        {
            private ServerStateChangeRequest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ServerStateChangeRequest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ServerStateChangeRequest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override ServerStateChangeRequest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ServerStateChangeRequest.Builder Clear()
            {
                this.result = ServerStateChangeRequest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ServerStateChangeRequest.Builder ClearEventTime()
            {
                this.PrepareBuilder();
                this.result.hasEventTime = false;
                this.result.eventTime_ = 0L;
                return this;
            }

            public ServerStateChangeRequest.Builder ClearState()
            {
                this.PrepareBuilder();
                this.result.hasState = false;
                this.result.state_ = 0;
                return this;
            }

            public override ServerStateChangeRequest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ServerStateChangeRequest.Builder(this.result);
                }
                return new ServerStateChangeRequest.Builder().MergeFrom(this.result);
            }

            public override ServerStateChangeRequest.Builder MergeFrom(ServerStateChangeRequest other)
            {
                if (other != ServerStateChangeRequest.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasState)
                    {
                        this.State = other.State;
                    }
                    if (other.HasEventTime)
                    {
                        this.EventTime = other.EventTime;
                    }
                }
                return this;
            }

            public override ServerStateChangeRequest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ServerStateChangeRequest.Builder MergeFrom(IMessageLite other)
            {
                if (other is ServerStateChangeRequest)
                {
                    return this.MergeFrom((ServerStateChangeRequest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ServerStateChangeRequest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ServerStateChangeRequest._serverStateChangeRequestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ServerStateChangeRequest._serverStateChangeRequestFieldTags[index];
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
                            this.result.hasState = input.ReadUInt32(ref this.result.state_);
                            continue;
                        }
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
                    this.result.hasEventTime = input.ReadUInt64(ref this.result.eventTime_);
                }
                return this;
            }

            private ServerStateChangeRequest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ServerStateChangeRequest result = this.result;
                    this.result = new ServerStateChangeRequest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            [CLSCompliant(false)]
            public ServerStateChangeRequest.Builder SetEventTime(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasEventTime = true;
                this.result.eventTime_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public ServerStateChangeRequest.Builder SetState(uint value)
            {
                this.PrepareBuilder();
                this.result.hasState = true;
                this.result.state_ = value;
                return this;
            }

            public override ServerStateChangeRequest DefaultInstanceForType
            {
                get
                {
                    return ServerStateChangeRequest.DefaultInstance;
                }
            }

            [CLSCompliant(false)]
            public ulong EventTime
            {
                get
                {
                    return this.result.EventTime;
                }
                set
                {
                    this.SetEventTime(value);
                }
            }

            public bool HasEventTime
            {
                get
                {
                    return this.result.hasEventTime;
                }
            }

            public bool HasState
            {
                get
                {
                    return this.result.hasState;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override ServerStateChangeRequest MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            [CLSCompliant(false)]
            public uint State
            {
                get
                {
                    return this.result.State;
                }
                set
                {
                    this.SetState(value);
                }
            }

            protected override ServerStateChangeRequest.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

