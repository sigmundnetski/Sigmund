namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class AtlasGetDecks : GeneratedMessageLite<AtlasGetDecks, Builder>
    {
        private static readonly string[] _atlasGetDecksFieldNames = new string[] { "account_id" };
        private static readonly uint[] _atlasGetDecksFieldTags = new uint[] { 8 };
        private ulong accountId_;
        public const int AccountIdFieldNumber = 1;
        private static readonly AtlasGetDecks defaultInstance = new AtlasGetDecks().MakeReadOnly();
        private bool hasAccountId;
        private int memoizedSerializedSize = -1;

        static AtlasGetDecks()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private AtlasGetDecks()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AtlasGetDecks prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AtlasGetDecks decks = obj as AtlasGetDecks;
            if (decks == null)
            {
                return false;
            }
            return ((this.hasAccountId == decks.hasAccountId) && (!this.hasAccountId || this.accountId_.Equals(decks.accountId_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasAccountId)
            {
                hashCode ^= this.accountId_.GetHashCode();
            }
            return hashCode;
        }

        private AtlasGetDecks MakeReadOnly()
        {
            return this;
        }

        public static AtlasGetDecks ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AtlasGetDecks ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasGetDecks ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasGetDecks ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasGetDecks ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasGetDecks ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasGetDecks ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AtlasGetDecks ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasGetDecks ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasGetDecks ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AtlasGetDecks, Builder>.PrintField("account_id", this.hasAccountId, this.accountId_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _atlasGetDecksFieldNames;
            if (this.hasAccountId)
            {
                output.WriteUInt64(1, strArray[0], this.AccountId);
            }
        }

        [CLSCompliant(false)]
        public ulong AccountId
        {
            get
            {
                return this.accountId_;
            }
        }

        public static AtlasGetDecks DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AtlasGetDecks DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasAccountId
        {
            get
            {
                return this.hasAccountId;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasAccountId)
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
                    if (this.hasAccountId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt64Size(1, this.AccountId);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override AtlasGetDecks ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<AtlasGetDecks, AtlasGetDecks.Builder>
        {
            private AtlasGetDecks result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AtlasGetDecks.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AtlasGetDecks cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override AtlasGetDecks BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AtlasGetDecks.Builder Clear()
            {
                this.result = AtlasGetDecks.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AtlasGetDecks.Builder ClearAccountId()
            {
                this.PrepareBuilder();
                this.result.hasAccountId = false;
                this.result.accountId_ = 0L;
                return this;
            }

            public override AtlasGetDecks.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AtlasGetDecks.Builder(this.result);
                }
                return new AtlasGetDecks.Builder().MergeFrom(this.result);
            }

            public override AtlasGetDecks.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AtlasGetDecks.Builder MergeFrom(IMessageLite other)
            {
                if (other is AtlasGetDecks)
                {
                    return this.MergeFrom((AtlasGetDecks) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AtlasGetDecks.Builder MergeFrom(AtlasGetDecks other)
            {
                if (other != AtlasGetDecks.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasAccountId)
                    {
                        this.AccountId = other.AccountId;
                    }
                }
                return this;
            }

            public override AtlasGetDecks.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AtlasGetDecks._atlasGetDecksFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AtlasGetDecks._atlasGetDecksFieldTags[index];
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
                    this.result.hasAccountId = input.ReadUInt64(ref this.result.accountId_);
                }
                return this;
            }

            private AtlasGetDecks PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AtlasGetDecks result = this.result;
                    this.result = new AtlasGetDecks();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            [CLSCompliant(false)]
            public AtlasGetDecks.Builder SetAccountId(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasAccountId = true;
                this.result.accountId_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public ulong AccountId
            {
                get
                {
                    return this.result.AccountId;
                }
                set
                {
                    this.SetAccountId(value);
                }
            }

            public override AtlasGetDecks DefaultInstanceForType
            {
                get
                {
                    return AtlasGetDecks.DefaultInstance;
                }
            }

            public bool HasAccountId
            {
                get
                {
                    return this.result.hasAccountId;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override AtlasGetDecks MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override AtlasGetDecks.Builder ThisBuilder
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
                ID = 0x194
            }
        }
    }
}

