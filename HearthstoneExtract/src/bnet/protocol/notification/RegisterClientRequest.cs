namespace bnet.protocol.notification
{
    using bnet.protocol.notification.Proto;
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
    public sealed class RegisterClientRequest : GeneratedMessageLite<RegisterClientRequest, Builder>
    {
        private static readonly string[] _registerClientRequestFieldNames = new string[] { "entity_id" };
        private static readonly uint[] _registerClientRequestFieldTags = new uint[] { 10 };
        private static readonly RegisterClientRequest defaultInstance = new RegisterClientRequest().MakeReadOnly();
        private bnet.protocol.notification.EntityId entityId_;
        public const int EntityIdFieldNumber = 1;
        private bool hasEntityId;
        private int memoizedSerializedSize = -1;

        static RegisterClientRequest()
        {
            object.ReferenceEquals(bnet.protocol.notification.Proto.Notification.Descriptor, null);
        }

        private RegisterClientRequest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(RegisterClientRequest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            RegisterClientRequest request = obj as RegisterClientRequest;
            if (request == null)
            {
                return false;
            }
            return ((this.hasEntityId == request.hasEntityId) && (!this.hasEntityId || this.entityId_.Equals(request.entityId_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasEntityId)
            {
                hashCode ^= this.entityId_.GetHashCode();
            }
            return hashCode;
        }

        private RegisterClientRequest MakeReadOnly()
        {
            return this;
        }

        public static RegisterClientRequest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static RegisterClientRequest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static RegisterClientRequest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static RegisterClientRequest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static RegisterClientRequest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static RegisterClientRequest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static RegisterClientRequest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static RegisterClientRequest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static RegisterClientRequest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static RegisterClientRequest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<RegisterClientRequest, Builder>.PrintField("entity_id", this.hasEntityId, this.entityId_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _registerClientRequestFieldNames;
            if (this.hasEntityId)
            {
                output.WriteMessage(1, strArray[0], this.EntityId);
            }
        }

        public static RegisterClientRequest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override RegisterClientRequest DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bnet.protocol.notification.EntityId EntityId
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.entityId_ != null)
                {
                    goto Label_0012;
                }
                return bnet.protocol.notification.EntityId.DefaultInstance;
            }
        }

        public bool HasEntityId
        {
            get
            {
                return this.hasEntityId;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasEntityId)
                {
                    return false;
                }
                if (!this.EntityId.IsInitialized)
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
                    if (this.hasEntityId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, this.EntityId);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override RegisterClientRequest ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<RegisterClientRequest, RegisterClientRequest.Builder>
        {
            private RegisterClientRequest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = RegisterClientRequest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(RegisterClientRequest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override RegisterClientRequest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override RegisterClientRequest.Builder Clear()
            {
                this.result = RegisterClientRequest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public RegisterClientRequest.Builder ClearEntityId()
            {
                this.PrepareBuilder();
                this.result.hasEntityId = false;
                this.result.entityId_ = null;
                return this;
            }

            public override RegisterClientRequest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new RegisterClientRequest.Builder(this.result);
                }
                return new RegisterClientRequest.Builder().MergeFrom(this.result);
            }

            public RegisterClientRequest.Builder MergeEntityId(bnet.protocol.notification.EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasEntityId && (this.result.entityId_ != bnet.protocol.notification.EntityId.DefaultInstance))
                {
                    this.result.entityId_ = bnet.protocol.notification.EntityId.CreateBuilder(this.result.entityId_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.entityId_ = value;
                }
                this.result.hasEntityId = true;
                return this;
            }

            public override RegisterClientRequest.Builder MergeFrom(RegisterClientRequest other)
            {
                if (other != RegisterClientRequest.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasEntityId)
                    {
                        this.MergeEntityId(other.EntityId);
                    }
                }
                return this;
            }

            public override RegisterClientRequest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override RegisterClientRequest.Builder MergeFrom(IMessageLite other)
            {
                if (other is RegisterClientRequest)
                {
                    return this.MergeFrom((RegisterClientRequest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override RegisterClientRequest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(RegisterClientRequest._registerClientRequestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = RegisterClientRequest._registerClientRequestFieldTags[index];
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
                            bnet.protocol.notification.EntityId.Builder builder = bnet.protocol.notification.EntityId.CreateBuilder();
                            if (this.result.hasEntityId)
                            {
                                builder.MergeFrom(this.EntityId);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.EntityId = builder.BuildPartial();
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

            private RegisterClientRequest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    RegisterClientRequest result = this.result;
                    this.result = new RegisterClientRequest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public RegisterClientRequest.Builder SetEntityId(bnet.protocol.notification.EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasEntityId = true;
                this.result.entityId_ = value;
                return this;
            }

            public RegisterClientRequest.Builder SetEntityId(bnet.protocol.notification.EntityId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasEntityId = true;
                this.result.entityId_ = builderForValue.Build();
                return this;
            }

            public override RegisterClientRequest DefaultInstanceForType
            {
                get
                {
                    return RegisterClientRequest.DefaultInstance;
                }
            }

            public bnet.protocol.notification.EntityId EntityId
            {
                get
                {
                    return this.result.EntityId;
                }
                set
                {
                    this.SetEntityId(value);
                }
            }

            public bool HasEntityId
            {
                get
                {
                    return this.result.hasEntityId;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override RegisterClientRequest MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override RegisterClientRequest.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

