namespace PegasusGame
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class FinishGameState : GeneratedMessageLite<FinishGameState, Builder>
    {
        private static readonly string[] _finishGameStateFieldNames = new string[0];
        private static readonly uint[] _finishGameStateFieldTags = new uint[0];
        private static readonly FinishGameState defaultInstance = new FinishGameState().MakeReadOnly();
        private int memoizedSerializedSize = -1;

        static FinishGameState()
        {
            object.ReferenceEquals(PegasusGamelite.Descriptor, null);
        }

        private FinishGameState()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(FinishGameState prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            return (obj is FinishGameState);
        }

        public override int GetHashCode()
        {
            return base.GetType().GetHashCode();
        }

        private FinishGameState MakeReadOnly()
        {
            return this;
        }

        public static FinishGameState ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static FinishGameState ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static FinishGameState ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static FinishGameState ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static FinishGameState ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static FinishGameState ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static FinishGameState ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static FinishGameState ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static FinishGameState ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static FinishGameState ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
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
            string[] strArray = _finishGameStateFieldNames;
        }

        public static FinishGameState DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override FinishGameState DefaultInstanceForType
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

        protected override FinishGameState ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<FinishGameState, FinishGameState.Builder>
        {
            private FinishGameState result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = FinishGameState.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(FinishGameState cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override FinishGameState BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override FinishGameState.Builder Clear()
            {
                this.result = FinishGameState.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public override FinishGameState.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new FinishGameState.Builder(this.result);
                }
                return new FinishGameState.Builder().MergeFrom(this.result);
            }

            public override FinishGameState.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override FinishGameState.Builder MergeFrom(IMessageLite other)
            {
                if (other is FinishGameState)
                {
                    return this.MergeFrom((FinishGameState) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override FinishGameState.Builder MergeFrom(FinishGameState other)
            {
                if (other != FinishGameState.DefaultInstance)
                {
                    this.PrepareBuilder();
                }
                return this;
            }

            public override FinishGameState.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(FinishGameState._finishGameStateFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = FinishGameState._finishGameStateFieldTags[index];
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

            private FinishGameState PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    FinishGameState result = this.result;
                    this.result = new FinishGameState();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public override FinishGameState DefaultInstanceForType
            {
                get
                {
                    return FinishGameState.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override FinishGameState MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override FinishGameState.Builder ThisBuilder
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
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 8
            }
        }
    }
}

