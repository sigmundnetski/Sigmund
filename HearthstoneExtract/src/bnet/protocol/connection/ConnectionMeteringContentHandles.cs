namespace bnet.protocol.connection
{
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Collections;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class ConnectionMeteringContentHandles : GeneratedMessageLite<ConnectionMeteringContentHandles, Builder>
    {
        private static readonly string[] _connectionMeteringContentHandlesFieldNames = new string[] { "content_handle" };
        private static readonly uint[] _connectionMeteringContentHandlesFieldTags = new uint[] { 10 };
        private PopsicleList<ContentHandle> contentHandle_ = new PopsicleList<ContentHandle>();
        public const int ContentHandleFieldNumber = 1;
        private static readonly ConnectionMeteringContentHandles defaultInstance = new ConnectionMeteringContentHandles().MakeReadOnly();
        private int memoizedSerializedSize = -1;

        static ConnectionMeteringContentHandles()
        {
            object.ReferenceEquals(Connect.Descriptor, null);
        }

        private ConnectionMeteringContentHandles()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(ConnectionMeteringContentHandles prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            ConnectionMeteringContentHandles handles = obj as ConnectionMeteringContentHandles;
            if (handles == null)
            {
                return false;
            }
            if (this.contentHandle_.Count != handles.contentHandle_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.contentHandle_.Count; i++)
            {
                if (!this.contentHandle_[i].Equals(handles.contentHandle_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public ContentHandle GetContentHandle(int index)
        {
            return this.contentHandle_[index];
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            IEnumerator<ContentHandle> enumerator = this.contentHandle_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    ContentHandle current = enumerator.Current;
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

        private ConnectionMeteringContentHandles MakeReadOnly()
        {
            this.contentHandle_.MakeReadOnly();
            return this;
        }

        public static ConnectionMeteringContentHandles ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static ConnectionMeteringContentHandles ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static ConnectionMeteringContentHandles ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ConnectionMeteringContentHandles ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ConnectionMeteringContentHandles ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static ConnectionMeteringContentHandles ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static ConnectionMeteringContentHandles ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static ConnectionMeteringContentHandles ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ConnectionMeteringContentHandles ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static ConnectionMeteringContentHandles ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<ConnectionMeteringContentHandles, Builder>.PrintField<ContentHandle>("content_handle", this.contentHandle_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _connectionMeteringContentHandlesFieldNames;
            if (this.contentHandle_.Count > 0)
            {
                output.WriteMessageArray<ContentHandle>(1, strArray[0], this.contentHandle_);
            }
        }

        public int ContentHandleCount
        {
            get
            {
                return this.contentHandle_.Count;
            }
        }

        public IList<ContentHandle> ContentHandleList
        {
            get
            {
                return this.contentHandle_;
            }
        }

        public static ConnectionMeteringContentHandles DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override ConnectionMeteringContentHandles DefaultInstanceForType
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
                IEnumerator<ContentHandle> enumerator = this.ContentHandleList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        ContentHandle current = enumerator.Current;
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
                    IEnumerator<ContentHandle> enumerator = this.ContentHandleList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            ContentHandle current = enumerator.Current;
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

        protected override ConnectionMeteringContentHandles ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<ConnectionMeteringContentHandles, ConnectionMeteringContentHandles.Builder>
        {
            private ConnectionMeteringContentHandles result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = ConnectionMeteringContentHandles.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(ConnectionMeteringContentHandles cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public ConnectionMeteringContentHandles.Builder AddContentHandle(ContentHandle value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.contentHandle_.Add(value);
                return this;
            }

            public ConnectionMeteringContentHandles.Builder AddContentHandle(ContentHandle.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.contentHandle_.Add(builderForValue.Build());
                return this;
            }

            public ConnectionMeteringContentHandles.Builder AddRangeContentHandle(IEnumerable<ContentHandle> values)
            {
                this.PrepareBuilder();
                this.result.contentHandle_.Add(values);
                return this;
            }

            public override ConnectionMeteringContentHandles BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override ConnectionMeteringContentHandles.Builder Clear()
            {
                this.result = ConnectionMeteringContentHandles.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public ConnectionMeteringContentHandles.Builder ClearContentHandle()
            {
                this.PrepareBuilder();
                this.result.contentHandle_.Clear();
                return this;
            }

            public override ConnectionMeteringContentHandles.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new ConnectionMeteringContentHandles.Builder(this.result);
                }
                return new ConnectionMeteringContentHandles.Builder().MergeFrom(this.result);
            }

            public ContentHandle GetContentHandle(int index)
            {
                return this.result.GetContentHandle(index);
            }

            public override ConnectionMeteringContentHandles.Builder MergeFrom(ConnectionMeteringContentHandles other)
            {
                if (other != ConnectionMeteringContentHandles.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.contentHandle_.Count != 0)
                    {
                        this.result.contentHandle_.Add(other.contentHandle_);
                    }
                }
                return this;
            }

            public override ConnectionMeteringContentHandles.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override ConnectionMeteringContentHandles.Builder MergeFrom(IMessageLite other)
            {
                if (other is ConnectionMeteringContentHandles)
                {
                    return this.MergeFrom((ConnectionMeteringContentHandles) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override ConnectionMeteringContentHandles.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(ConnectionMeteringContentHandles._connectionMeteringContentHandlesFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = ConnectionMeteringContentHandles._connectionMeteringContentHandlesFieldTags[index];
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
                    input.ReadMessageArray<ContentHandle>(num, str, this.result.contentHandle_, ContentHandle.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            private ConnectionMeteringContentHandles PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    ConnectionMeteringContentHandles result = this.result;
                    this.result = new ConnectionMeteringContentHandles();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public ConnectionMeteringContentHandles.Builder SetContentHandle(int index, ContentHandle value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.contentHandle_[index] = value;
                return this;
            }

            public ConnectionMeteringContentHandles.Builder SetContentHandle(int index, ContentHandle.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.contentHandle_[index] = builderForValue.Build();
                return this;
            }

            public int ContentHandleCount
            {
                get
                {
                    return this.result.ContentHandleCount;
                }
            }

            public IPopsicleList<ContentHandle> ContentHandleList
            {
                get
                {
                    return this.PrepareBuilder().contentHandle_;
                }
            }

            public override ConnectionMeteringContentHandles DefaultInstanceForType
            {
                get
                {
                    return ConnectionMeteringContentHandles.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override ConnectionMeteringContentHandles MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override ConnectionMeteringContentHandles.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

