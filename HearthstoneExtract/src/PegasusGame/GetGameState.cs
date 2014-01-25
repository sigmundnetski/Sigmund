namespace PegasusGame
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class GetGameState : GeneratedMessageLite<GetGameState, Builder>
    {
        private static readonly string[] _getGameStateFieldNames = new string[0];
        private static readonly uint[] _getGameStateFieldTags = new uint[0];
        private static readonly GetGameState defaultInstance = new GetGameState().MakeReadOnly();
        private int memoizedSerializedSize = -1;

        static GetGameState()
        {
            object.ReferenceEquals(PegasusGamelite.Descriptor, null);
        }

        private GetGameState()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(GetGameState prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            return (obj is GetGameState);
        }

        public override int GetHashCode()
        {
            return base.GetType().GetHashCode();
        }

        private GetGameState MakeReadOnly()
        {
            return this;
        }

        public static GetGameState ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static GetGameState ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static GetGameState ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GetGameState ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GetGameState ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GetGameState ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GetGameState ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static GetGameState ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GetGameState ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GetGameState ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
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
            string[] strArray = _getGameStateFieldNames;
        }

        public static GetGameState DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override GetGameState DefaultInstanceForType
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

        protected override GetGameState ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<GetGameState, GetGameState.Builder>
        {
            private GetGameState result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = GetGameState.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(GetGameState cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override GetGameState BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override GetGameState.Builder Clear()
            {
                this.result = GetGameState.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public override GetGameState.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new GetGameState.Builder(this.result);
                }
                return new GetGameState.Builder().MergeFrom(this.result);
            }

            public override GetGameState.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override GetGameState.Builder MergeFrom(IMessageLite other)
            {
                if (other is GetGameState)
                {
                    return this.MergeFrom((GetGameState) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override GetGameState.Builder MergeFrom(GetGameState other)
            {
                if (other != GetGameState.DefaultInstance)
                {
                    this.PrepareBuilder();
                }
                return this;
            }

            public override GetGameState.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(GetGameState._getGameStateFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = GetGameState._getGameStateFieldTags[index];
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

            private GetGameState PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    GetGameState result = this.result;
                    this.result = new GetGameState();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public override GetGameState DefaultInstanceForType
            {
                get
                {
                    return GetGameState.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override GetGameState MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override GetGameState.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 1
            }
        }
    }
}

