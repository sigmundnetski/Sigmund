namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class RemovePlayer : GeneratedMessageLite<RemovePlayer, Builder>
    {
        private static readonly string[] _removePlayerFieldNames = new string[] { "client_handle" };
        private static readonly uint[] _removePlayerFieldTags = new uint[] { 8 };
        private int clientHandle_;
        public const int ClientHandleFieldNumber = 1;
        private static readonly RemovePlayer defaultInstance = new RemovePlayer().MakeReadOnly();
        private bool hasClientHandle;
        private int memoizedSerializedSize = -1;

        static RemovePlayer()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private RemovePlayer()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(RemovePlayer prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            RemovePlayer player = obj as RemovePlayer;
            if (player == null)
            {
                return false;
            }
            return ((this.hasClientHandle == player.hasClientHandle) && (!this.hasClientHandle || this.clientHandle_.Equals(player.clientHandle_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasClientHandle)
            {
                hashCode ^= this.clientHandle_.GetHashCode();
            }
            return hashCode;
        }

        private RemovePlayer MakeReadOnly()
        {
            return this;
        }

        public static RemovePlayer ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static RemovePlayer ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static RemovePlayer ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static RemovePlayer ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static RemovePlayer ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static RemovePlayer ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static RemovePlayer ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static RemovePlayer ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static RemovePlayer ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static RemovePlayer ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<RemovePlayer, Builder>.PrintField("client_handle", this.hasClientHandle, this.clientHandle_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _removePlayerFieldNames;
            if (this.hasClientHandle)
            {
                output.WriteInt32(1, strArray[0], this.ClientHandle);
            }
        }

        public int ClientHandle
        {
            get
            {
                return this.clientHandle_;
            }
        }

        public static RemovePlayer DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override RemovePlayer DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasClientHandle
        {
            get
            {
                return this.hasClientHandle;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasClientHandle)
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
                    if (this.hasClientHandle)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.ClientHandle);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override RemovePlayer ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<RemovePlayer, RemovePlayer.Builder>
        {
            private RemovePlayer result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = RemovePlayer.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(RemovePlayer cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override RemovePlayer BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override RemovePlayer.Builder Clear()
            {
                this.result = RemovePlayer.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public RemovePlayer.Builder ClearClientHandle()
            {
                this.PrepareBuilder();
                this.result.hasClientHandle = false;
                this.result.clientHandle_ = 0;
                return this;
            }

            public override RemovePlayer.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new RemovePlayer.Builder(this.result);
                }
                return new RemovePlayer.Builder().MergeFrom(this.result);
            }

            public override RemovePlayer.Builder MergeFrom(RemovePlayer other)
            {
                if (other != RemovePlayer.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasClientHandle)
                    {
                        this.ClientHandle = other.ClientHandle;
                    }
                }
                return this;
            }

            public override RemovePlayer.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override RemovePlayer.Builder MergeFrom(IMessageLite other)
            {
                if (other is RemovePlayer)
                {
                    return this.MergeFrom((RemovePlayer) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override RemovePlayer.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(RemovePlayer._removePlayerFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = RemovePlayer._removePlayerFieldTags[index];
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
                    this.result.hasClientHandle = input.ReadInt32(ref this.result.clientHandle_);
                }
                return this;
            }

            private RemovePlayer PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    RemovePlayer result = this.result;
                    this.result = new RemovePlayer();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public RemovePlayer.Builder SetClientHandle(int value)
            {
                this.PrepareBuilder();
                this.result.hasClientHandle = true;
                this.result.clientHandle_ = value;
                return this;
            }

            public int ClientHandle
            {
                get
                {
                    return this.result.ClientHandle;
                }
                set
                {
                    this.SetClientHandle(value);
                }
            }

            public override RemovePlayer DefaultInstanceForType
            {
                get
                {
                    return RemovePlayer.DefaultInstance;
                }
            }

            public bool HasClientHandle
            {
                get
                {
                    return this.result.hasClientHandle;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override RemovePlayer MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override RemovePlayer.Builder ThisBuilder
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
                ID = 0x79
            }
        }
    }
}

