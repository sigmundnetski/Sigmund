namespace bnet.protocol.notification
{
    using bnet.protocol.notification.Proto;
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class FindClientResponse : GeneratedMessageLite<FindClientResponse, Builder>
    {
        private static readonly string[] _findClientResponseFieldNames = new string[] { "client_process_id", "label" };
        private static readonly uint[] _findClientResponseFieldTags = new uint[] { 0x12, 8 };
        private ProcessId clientProcessId_;
        public const int ClientProcessIdFieldNumber = 2;
        private static readonly FindClientResponse defaultInstance = new FindClientResponse().MakeReadOnly();
        private bool hasClientProcessId;
        private bool hasLabel;
        private uint label_;
        public const int LabelFieldNumber = 1;
        private int memoizedSerializedSize = -1;

        static FindClientResponse()
        {
            object.ReferenceEquals(bnet.protocol.notification.Proto.Notification.Descriptor, null);
        }

        private FindClientResponse()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(FindClientResponse prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            FindClientResponse response = obj as FindClientResponse;
            if (response == null)
            {
                return false;
            }
            if ((this.hasLabel != response.hasLabel) || (this.hasLabel && !this.label_.Equals(response.label_)))
            {
                return false;
            }
            return ((this.hasClientProcessId == response.hasClientProcessId) && (!this.hasClientProcessId || this.clientProcessId_.Equals(response.clientProcessId_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasLabel)
            {
                hashCode ^= this.label_.GetHashCode();
            }
            if (this.hasClientProcessId)
            {
                hashCode ^= this.clientProcessId_.GetHashCode();
            }
            return hashCode;
        }

        private FindClientResponse MakeReadOnly()
        {
            return this;
        }

        public static FindClientResponse ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static FindClientResponse ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static FindClientResponse ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static FindClientResponse ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static FindClientResponse ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static FindClientResponse ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static FindClientResponse ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static FindClientResponse ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static FindClientResponse ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static FindClientResponse ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<FindClientResponse, Builder>.PrintField("label", this.hasLabel, this.label_, writer);
            GeneratedMessageLite<FindClientResponse, Builder>.PrintField("client_process_id", this.hasClientProcessId, this.clientProcessId_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _findClientResponseFieldNames;
            if (this.hasLabel)
            {
                output.WriteUInt32(1, strArray[1], this.Label);
            }
            if (this.hasClientProcessId)
            {
                output.WriteMessage(2, strArray[0], this.ClientProcessId);
            }
        }

        public ProcessId ClientProcessId
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.clientProcessId_ != null)
                {
                    goto Label_0012;
                }
                return ProcessId.DefaultInstance;
            }
        }

        public static FindClientResponse DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override FindClientResponse DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasClientProcessId
        {
            get
            {
                return this.hasClientProcessId;
            }
        }

        public bool HasLabel
        {
            get
            {
                return this.hasLabel;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasLabel)
                {
                    return false;
                }
                if (this.HasClientProcessId && !this.ClientProcessId.IsInitialized)
                {
                    return false;
                }
                return true;
            }
        }

        [CLSCompliant(false)]
        public uint Label
        {
            get
            {
                return this.label_;
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
                    if (this.hasLabel)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(1, this.Label);
                    }
                    if (this.hasClientProcessId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(2, this.ClientProcessId);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override FindClientResponse ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<FindClientResponse, FindClientResponse.Builder>
        {
            private FindClientResponse result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = FindClientResponse.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(FindClientResponse cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override FindClientResponse BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override FindClientResponse.Builder Clear()
            {
                this.result = FindClientResponse.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public FindClientResponse.Builder ClearClientProcessId()
            {
                this.PrepareBuilder();
                this.result.hasClientProcessId = false;
                this.result.clientProcessId_ = null;
                return this;
            }

            public FindClientResponse.Builder ClearLabel()
            {
                this.PrepareBuilder();
                this.result.hasLabel = false;
                this.result.label_ = 0;
                return this;
            }

            public override FindClientResponse.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new FindClientResponse.Builder(this.result);
                }
                return new FindClientResponse.Builder().MergeFrom(this.result);
            }

            public FindClientResponse.Builder MergeClientProcessId(ProcessId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasClientProcessId && (this.result.clientProcessId_ != ProcessId.DefaultInstance))
                {
                    this.result.clientProcessId_ = ProcessId.CreateBuilder(this.result.clientProcessId_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.clientProcessId_ = value;
                }
                this.result.hasClientProcessId = true;
                return this;
            }

            public override FindClientResponse.Builder MergeFrom(FindClientResponse other)
            {
                if (other != FindClientResponse.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasLabel)
                    {
                        this.Label = other.Label;
                    }
                    if (other.HasClientProcessId)
                    {
                        this.MergeClientProcessId(other.ClientProcessId);
                    }
                }
                return this;
            }

            public override FindClientResponse.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override FindClientResponse.Builder MergeFrom(IMessageLite other)
            {
                if (other is FindClientResponse)
                {
                    return this.MergeFrom((FindClientResponse) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override FindClientResponse.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(FindClientResponse._findClientResponseFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = FindClientResponse._findClientResponseFieldTags[index];
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
                            this.result.hasLabel = input.ReadUInt32(ref this.result.label_);
                            continue;
                        }
                        case 0x12:
                        {
                            ProcessId.Builder builder = ProcessId.CreateBuilder();
                            if (this.result.hasClientProcessId)
                            {
                                builder.MergeFrom(this.ClientProcessId);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.ClientProcessId = builder.BuildPartial();
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

            private FindClientResponse PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    FindClientResponse result = this.result;
                    this.result = new FindClientResponse();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public FindClientResponse.Builder SetClientProcessId(ProcessId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasClientProcessId = true;
                this.result.clientProcessId_ = value;
                return this;
            }

            public FindClientResponse.Builder SetClientProcessId(ProcessId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasClientProcessId = true;
                this.result.clientProcessId_ = builderForValue.Build();
                return this;
            }

            [CLSCompliant(false)]
            public FindClientResponse.Builder SetLabel(uint value)
            {
                this.PrepareBuilder();
                this.result.hasLabel = true;
                this.result.label_ = value;
                return this;
            }

            public ProcessId ClientProcessId
            {
                get
                {
                    return this.result.ClientProcessId;
                }
                set
                {
                    this.SetClientProcessId(value);
                }
            }

            public override FindClientResponse DefaultInstanceForType
            {
                get
                {
                    return FindClientResponse.DefaultInstance;
                }
            }

            public bool HasClientProcessId
            {
                get
                {
                    return this.result.hasClientProcessId;
                }
            }

            public bool HasLabel
            {
                get
                {
                    return this.result.hasLabel;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            [CLSCompliant(false)]
            public uint Label
            {
                get
                {
                    return this.result.Label;
                }
                set
                {
                    this.SetLabel(value);
                }
            }

            protected override FindClientResponse MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override FindClientResponse.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

