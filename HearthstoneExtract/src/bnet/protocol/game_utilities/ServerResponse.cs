namespace bnet.protocol.game_utilities
{
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Collections;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class ServerResponse : GeneratedMessageLite<ServerResponse, Builder>
    {
        private static readonly string[] _serverResponseFieldNames = new string[] { "attribute" };
        private static readonly uint[] _serverResponseFieldTags = new uint[] { 10 };
        private PopsicleList<bnet.protocol.game_utilities.Attribute> attribute_ = new PopsicleList<bnet.protocol.game_utilities.Attribute>();
        public const int AttributeFieldNumber = 1;
        private static readonly ServerResponse defaultInstance = new ServerResponse().MakeReadOnly();
        private int memoizedSerializedSize = -1;

        static ServerResponse()
        {
            object.ReferenceEquals(GameUtils.Descriptor, null);
        }

        private ServerResponse()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ServerResponse prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ServerResponse response = obj as ServerResponse;
            if (response == null)
            {
                return false;
            }
            if (this.attribute_.Count != response.attribute_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.attribute_.Count; i++)
            {
                if (!this.attribute_[i].Equals(response.attribute_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public bnet.protocol.game_utilities.Attribute GetAttribute(int index)
        {
            return this.attribute_[index];
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            IEnumerator<bnet.protocol.game_utilities.Attribute> enumerator = this.attribute_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    bnet.protocol.game_utilities.Attribute current = enumerator.Current;
                    hashCode ^= current.GetHashCode();
                }
            }
            finally
            {
                if (enumerator == null)
                {
                }
                enumerator.Dispose();
            }
            return hashCode;
        }

        private ServerResponse MakeReadOnly()
        {
            this.attribute_.MakeReadOnly();
            return this;
        }

        public static ServerResponse ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ServerResponse ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ServerResponse ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ServerResponse ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ServerResponse ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ServerResponse ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ServerResponse ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ServerResponse ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ServerResponse ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ServerResponse ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ServerResponse, Builder>.PrintField<bnet.protocol.game_utilities.Attribute>("attribute", this.attribute_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _serverResponseFieldNames;
            if (this.attribute_.Count > 0)
            {
                output.WriteMessageArray<bnet.protocol.game_utilities.Attribute>(1, strArray[0], this.attribute_);
            }
        }

        public int AttributeCount
        {
            get
            {
                return this.attribute_.Count;
            }
        }

        public IList<bnet.protocol.game_utilities.Attribute> AttributeList
        {
            get
            {
                return this.attribute_;
            }
        }

        public static ServerResponse DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ServerResponse DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                IEnumerator<bnet.protocol.game_utilities.Attribute> enumerator = this.AttributeList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        bnet.protocol.game_utilities.Attribute current = enumerator.Current;
                        if (!current.IsInitialized)
                        {
                            return false;
                        }
                    }
                }
                finally
                {
                    if (enumerator == null)
                    {
                    }
                    enumerator.Dispose();
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
                    IEnumerator<bnet.protocol.game_utilities.Attribute> enumerator = this.AttributeList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            bnet.protocol.game_utilities.Attribute current = enumerator.Current;
                            memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, current);
                        }
                    }
                    finally
                    {
                        if (enumerator == null)
                        {
                        }
                        enumerator.Dispose();
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override ServerResponse ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<ServerResponse, ServerResponse.Builder>
        {
            private ServerResponse result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ServerResponse.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ServerResponse cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public ServerResponse.Builder AddAttribute(bnet.protocol.game_utilities.Attribute value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.attribute_.Add(value);
                return this;
            }

            public ServerResponse.Builder AddAttribute(bnet.protocol.game_utilities.Attribute.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.attribute_.Add(builderForValue.Build());
                return this;
            }

            public ServerResponse.Builder AddRangeAttribute(IEnumerable<bnet.protocol.game_utilities.Attribute> values)
            {
                this.PrepareBuilder();
                this.result.attribute_.Add(values);
                return this;
            }

            public override ServerResponse BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ServerResponse.Builder Clear()
            {
                this.result = ServerResponse.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ServerResponse.Builder ClearAttribute()
            {
                this.PrepareBuilder();
                this.result.attribute_.Clear();
                return this;
            }

            public override ServerResponse.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ServerResponse.Builder(this.result);
                }
                return new ServerResponse.Builder().MergeFrom(this.result);
            }

            public bnet.protocol.game_utilities.Attribute GetAttribute(int index)
            {
                return this.result.GetAttribute(index);
            }

            public override ServerResponse.Builder MergeFrom(ServerResponse other)
            {
                if (other != ServerResponse.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.attribute_.Count != 0)
                    {
                        this.result.attribute_.Add(other.attribute_);
                    }
                }
                return this;
            }

            public override ServerResponse.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ServerResponse.Builder MergeFrom(IMessageLite other)
            {
                if (other is ServerResponse)
                {
                    return this.MergeFrom((ServerResponse) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ServerResponse.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ServerResponse._serverResponseFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ServerResponse._serverResponseFieldTags[index];
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
                    input.ReadMessageArray<bnet.protocol.game_utilities.Attribute>(num, str, this.result.attribute_, bnet.protocol.game_utilities.Attribute.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private ServerResponse PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ServerResponse result = this.result;
                    this.result = new ServerResponse();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public ServerResponse.Builder SetAttribute(int index, bnet.protocol.game_utilities.Attribute value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.attribute_[index] = value;
                return this;
            }

            public ServerResponse.Builder SetAttribute(int index, bnet.protocol.game_utilities.Attribute.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.attribute_[index] = builderForValue.Build();
                return this;
            }

            public int AttributeCount
            {
                get
                {
                    return this.result.AttributeCount;
                }
            }

            public IPopsicleList<bnet.protocol.game_utilities.Attribute> AttributeList
            {
                get
                {
                    return this.PrepareBuilder().attribute_;
                }
            }

            public override ServerResponse DefaultInstanceForType
            {
                get
                {
                    return ServerResponse.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override ServerResponse MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override ServerResponse.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

