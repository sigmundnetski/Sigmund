namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class PlayerLeave : GeneratedMessageLite<PlayerLeave, Builder>
    {
        private static readonly string[] _playerLeaveFieldNames = new string[0];
        private static readonly uint[] _playerLeaveFieldTags = new uint[0];
        private static readonly PlayerLeave defaultInstance = new PlayerLeave().MakeReadOnly();
        private int memoizedSerializedSize = -1;

        static PlayerLeave()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private PlayerLeave()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(PlayerLeave prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            return (obj is PlayerLeave);
        }

        public override int GetHashCode()
        {
            return base.GetType().GetHashCode();
        }

        private PlayerLeave MakeReadOnly()
        {
            return this;
        }

        public static PlayerLeave ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static PlayerLeave ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static PlayerLeave ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static PlayerLeave ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static PlayerLeave ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static PlayerLeave ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static PlayerLeave ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static PlayerLeave ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static PlayerLeave ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static PlayerLeave ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _playerLeaveFieldNames;
        }

        public static PlayerLeave DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override PlayerLeave DefaultInstanceForType
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
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override PlayerLeave ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<PlayerLeave, PlayerLeave.Builder>
        {
            private PlayerLeave result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = PlayerLeave.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(PlayerLeave cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override PlayerLeave BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override PlayerLeave.Builder Clear()
            {
                this.result = PlayerLeave.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public override PlayerLeave.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new PlayerLeave.Builder(this.result);
                }
                return new PlayerLeave.Builder().MergeFrom(this.result);
            }

            public override PlayerLeave.Builder MergeFrom(PlayerLeave other)
            {
                if (other != PlayerLeave.DefaultInstance)
                {
                    this.PrepareBuilder();
                }
                return this;
            }

            public override PlayerLeave.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override PlayerLeave.Builder MergeFrom(IMessageLite other)
            {
                if (other is PlayerLeave)
                {
                    return this.MergeFrom((PlayerLeave) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override PlayerLeave.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(PlayerLeave._playerLeaveFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = PlayerLeave._playerLeaveFieldTags[index];
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
                    }
                    if (WireFormat.IsEndGroupTag(num))
                    {
                        return this;
                    }
                    this.ParseUnknownField(input, extensionRegistry, num, str);
                }
                return this;
            }

            private PlayerLeave PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    PlayerLeave result = this.result;
                    this.result = new PlayerLeave();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public override PlayerLeave DefaultInstanceForType
            {
                get
                {
                    return PlayerLeave.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override PlayerLeave MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override PlayerLeave.Builder ThisBuilder
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
                ID = 0x6f
            }
        }
    }
}

