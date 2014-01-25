namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class CreateDraftGame : GeneratedMessageLite<CreateDraftGame, Builder>
    {
        private static readonly string[] _createDraftGameFieldNames = new string[0];
        private static readonly uint[] _createDraftGameFieldTags = new uint[0];
        private static readonly CreateDraftGame defaultInstance = new CreateDraftGame().MakeReadOnly();
        private int memoizedSerializedSize = -1;

        static CreateDraftGame()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private CreateDraftGame()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(CreateDraftGame prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            return (obj is CreateDraftGame);
        }

        public override int GetHashCode()
        {
            return base.GetType().GetHashCode();
        }

        private CreateDraftGame MakeReadOnly()
        {
            return this;
        }

        public static CreateDraftGame ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static CreateDraftGame ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static CreateDraftGame ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static CreateDraftGame ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static CreateDraftGame ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static CreateDraftGame ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static CreateDraftGame ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static CreateDraftGame ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static CreateDraftGame ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static CreateDraftGame ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
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
            string[] strArray = _createDraftGameFieldNames;
        }

        public static CreateDraftGame DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override CreateDraftGame DefaultInstanceForType
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

        protected override CreateDraftGame ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<CreateDraftGame, CreateDraftGame.Builder>
        {
            private CreateDraftGame result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = CreateDraftGame.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(CreateDraftGame cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override CreateDraftGame BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override CreateDraftGame.Builder Clear()
            {
                this.result = CreateDraftGame.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public override CreateDraftGame.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new CreateDraftGame.Builder(this.result);
                }
                return new CreateDraftGame.Builder().MergeFrom(this.result);
            }

            public override CreateDraftGame.Builder MergeFrom(CreateDraftGame other)
            {
                if (other != CreateDraftGame.DefaultInstance)
                {
                    this.PrepareBuilder();
                }
                return this;
            }

            public override CreateDraftGame.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override CreateDraftGame.Builder MergeFrom(IMessageLite other)
            {
                if (other is CreateDraftGame)
                {
                    return this.MergeFrom((CreateDraftGame) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override CreateDraftGame.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(CreateDraftGame._createDraftGameFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = CreateDraftGame._createDraftGameFieldTags[index];
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

            private CreateDraftGame PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    CreateDraftGame result = this.result;
                    this.result = new CreateDraftGame();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public override CreateDraftGame DefaultInstanceForType
            {
                get
                {
                    return CreateDraftGame.DefaultInstance;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override CreateDraftGame MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override CreateDraftGame.Builder ThisBuilder
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
                ID = 0xa7
            }
        }
    }
}

