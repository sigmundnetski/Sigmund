namespace bnet.protocol.invitation
{
    using bnet.protocol;
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
    public sealed class Suggestion : GeneratedMessageLite<Suggestion, Builder>
    {
        private static readonly string[] _suggestionFieldNames = new string[] { "channel_id", "suggestee_id", "suggestee_name", "suggester_account_id", "suggester_id", "suggester_name" };
        private static readonly uint[] _suggestionFieldTags = new uint[] { 10, 0x1a, 0x2a, 50, 0x12, 0x22 };
        private EntityId channelId_;
        public const int ChannelIdFieldNumber = 1;
        private static readonly Suggestion defaultInstance = new Suggestion().MakeReadOnly();
        private bool hasChannelId;
        private bool hasSuggesteeId;
        private bool hasSuggesteeName;
        private bool hasSuggesterAccountId;
        private bool hasSuggesterId;
        private bool hasSuggesterName;
        private int memoizedSerializedSize = -1;
        private EntityId suggesteeId_;
        public const int SuggesteeIdFieldNumber = 3;
        private string suggesteeName_ = string.Empty;
        public const int SuggesteeNameFieldNumber = 5;
        private EntityId suggesterAccountId_;
        public const int SuggesterAccountIdFieldNumber = 6;
        private EntityId suggesterId_;
        public const int SuggesterIdFieldNumber = 2;
        private string suggesterName_ = string.Empty;
        public const int SuggesterNameFieldNumber = 4;

        static Suggestion()
        {
            object.ReferenceEquals(InvitationTypes.Descriptor, null);
        }

        private Suggestion()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(Suggestion prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            Suggestion suggestion = obj as Suggestion;
            if (suggestion == null)
            {
                return false;
            }
            if ((this.hasChannelId != suggestion.hasChannelId) || (this.hasChannelId && !this.channelId_.Equals(suggestion.channelId_)))
            {
                return false;
            }
            if ((this.hasSuggesterId != suggestion.hasSuggesterId) || (this.hasSuggesterId && !this.suggesterId_.Equals(suggestion.suggesterId_)))
            {
                return false;
            }
            if ((this.hasSuggesteeId != suggestion.hasSuggesteeId) || (this.hasSuggesteeId && !this.suggesteeId_.Equals(suggestion.suggesteeId_)))
            {
                return false;
            }
            if ((this.hasSuggesterName != suggestion.hasSuggesterName) || (this.hasSuggesterName && !this.suggesterName_.Equals(suggestion.suggesterName_)))
            {
                return false;
            }
            if ((this.hasSuggesteeName != suggestion.hasSuggesteeName) || (this.hasSuggesteeName && !this.suggesteeName_.Equals(suggestion.suggesteeName_)))
            {
                return false;
            }
            return ((this.hasSuggesterAccountId == suggestion.hasSuggesterAccountId) && (!this.hasSuggesterAccountId || this.suggesterAccountId_.Equals(suggestion.suggesterAccountId_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasChannelId)
            {
                hashCode ^= this.channelId_.GetHashCode();
            }
            if (this.hasSuggesterId)
            {
                hashCode ^= this.suggesterId_.GetHashCode();
            }
            if (this.hasSuggesteeId)
            {
                hashCode ^= this.suggesteeId_.GetHashCode();
            }
            if (this.hasSuggesterName)
            {
                hashCode ^= this.suggesterName_.GetHashCode();
            }
            if (this.hasSuggesteeName)
            {
                hashCode ^= this.suggesteeName_.GetHashCode();
            }
            if (this.hasSuggesterAccountId)
            {
                hashCode ^= this.suggesterAccountId_.GetHashCode();
            }
            return hashCode;
        }

        private Suggestion MakeReadOnly()
        {
            return this;
        }

        public static Suggestion ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static Suggestion ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static Suggestion ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Suggestion ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Suggestion ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Suggestion ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Suggestion ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static Suggestion ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Suggestion ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Suggestion ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<Suggestion, Builder>.PrintField("channel_id", this.hasChannelId, this.channelId_, writer);
            GeneratedMessageLite<Suggestion, Builder>.PrintField("suggester_id", this.hasSuggesterId, this.suggesterId_, writer);
            GeneratedMessageLite<Suggestion, Builder>.PrintField("suggestee_id", this.hasSuggesteeId, this.suggesteeId_, writer);
            GeneratedMessageLite<Suggestion, Builder>.PrintField("suggester_name", this.hasSuggesterName, this.suggesterName_, writer);
            GeneratedMessageLite<Suggestion, Builder>.PrintField("suggestee_name", this.hasSuggesteeName, this.suggesteeName_, writer);
            GeneratedMessageLite<Suggestion, Builder>.PrintField("suggester_account_id", this.hasSuggesterAccountId, this.suggesterAccountId_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _suggestionFieldNames;
            if (this.hasChannelId)
            {
                output.WriteMessage(1, strArray[0], this.ChannelId);
            }
            if (this.hasSuggesterId)
            {
                output.WriteMessage(2, strArray[4], this.SuggesterId);
            }
            if (this.hasSuggesteeId)
            {
                output.WriteMessage(3, strArray[1], this.SuggesteeId);
            }
            if (this.hasSuggesterName)
            {
                output.WriteString(4, strArray[5], this.SuggesterName);
            }
            if (this.hasSuggesteeName)
            {
                output.WriteString(5, strArray[2], this.SuggesteeName);
            }
            if (this.hasSuggesterAccountId)
            {
                output.WriteMessage(6, strArray[3], this.SuggesterAccountId);
            }
        }

        public EntityId ChannelId
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.channelId_ != null)
                {
                    goto Label_0012;
                }
                return EntityId.DefaultInstance;
            }
        }

        public static Suggestion DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override Suggestion DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasChannelId
        {
            get
            {
                return this.hasChannelId;
            }
        }

        public bool HasSuggesteeId
        {
            get
            {
                return this.hasSuggesteeId;
            }
        }

        public bool HasSuggesteeName
        {
            get
            {
                return this.hasSuggesteeName;
            }
        }

        public bool HasSuggesterAccountId
        {
            get
            {
                return this.hasSuggesterAccountId;
            }
        }

        public bool HasSuggesterId
        {
            get
            {
                return this.hasSuggesterId;
            }
        }

        public bool HasSuggesterName
        {
            get
            {
                return this.hasSuggesterName;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasSuggesterId)
                {
                    return false;
                }
                if (!this.hasSuggesteeId)
                {
                    return false;
                }
                if (this.HasChannelId && !this.ChannelId.IsInitialized)
                {
                    return false;
                }
                if (!this.SuggesterId.IsInitialized)
                {
                    return false;
                }
                if (!this.SuggesteeId.IsInitialized)
                {
                    return false;
                }
                if (this.HasSuggesterAccountId && !this.SuggesterAccountId.IsInitialized)
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
                    if (this.hasChannelId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, this.ChannelId);
                    }
                    if (this.hasSuggesterId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(2, this.SuggesterId);
                    }
                    if (this.hasSuggesteeId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(3, this.SuggesteeId);
                    }
                    if (this.hasSuggesterName)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(4, this.SuggesterName);
                    }
                    if (this.hasSuggesteeName)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(5, this.SuggesteeName);
                    }
                    if (this.hasSuggesterAccountId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(6, this.SuggesterAccountId);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        public EntityId SuggesteeId
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.suggesteeId_ != null)
                {
                    goto Label_0012;
                }
                return EntityId.DefaultInstance;
            }
        }

        public string SuggesteeName
        {
            get
            {
                return this.suggesteeName_;
            }
        }

        public EntityId SuggesterAccountId
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.suggesterAccountId_ != null)
                {
                    goto Label_0012;
                }
                return EntityId.DefaultInstance;
            }
        }

        public EntityId SuggesterId
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.suggesterId_ != null)
                {
                    goto Label_0012;
                }
                return EntityId.DefaultInstance;
            }
        }

        public string SuggesterName
        {
            get
            {
                return this.suggesterName_;
            }
        }

        protected override Suggestion ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<Suggestion, Suggestion.Builder>
        {
            private Suggestion result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = Suggestion.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(Suggestion cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override Suggestion BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override Suggestion.Builder Clear()
            {
                this.result = Suggestion.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public Suggestion.Builder ClearChannelId()
            {
                this.PrepareBuilder();
                this.result.hasChannelId = false;
                this.result.channelId_ = null;
                return this;
            }

            public Suggestion.Builder ClearSuggesteeId()
            {
                this.PrepareBuilder();
                this.result.hasSuggesteeId = false;
                this.result.suggesteeId_ = null;
                return this;
            }

            public Suggestion.Builder ClearSuggesteeName()
            {
                this.PrepareBuilder();
                this.result.hasSuggesteeName = false;
                this.result.suggesteeName_ = string.Empty;
                return this;
            }

            public Suggestion.Builder ClearSuggesterAccountId()
            {
                this.PrepareBuilder();
                this.result.hasSuggesterAccountId = false;
                this.result.suggesterAccountId_ = null;
                return this;
            }

            public Suggestion.Builder ClearSuggesterId()
            {
                this.PrepareBuilder();
                this.result.hasSuggesterId = false;
                this.result.suggesterId_ = null;
                return this;
            }

            public Suggestion.Builder ClearSuggesterName()
            {
                this.PrepareBuilder();
                this.result.hasSuggesterName = false;
                this.result.suggesterName_ = string.Empty;
                return this;
            }

            public override Suggestion.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new Suggestion.Builder(this.result);
                }
                return new Suggestion.Builder().MergeFrom(this.result);
            }

            public Suggestion.Builder MergeChannelId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasChannelId && (this.result.channelId_ != EntityId.DefaultInstance))
                {
                    this.result.channelId_ = EntityId.CreateBuilder(this.result.channelId_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.channelId_ = value;
                }
                this.result.hasChannelId = true;
                return this;
            }

            public override Suggestion.Builder MergeFrom(Suggestion other)
            {
                if (other != Suggestion.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasChannelId)
                    {
                        this.MergeChannelId(other.ChannelId);
                    }
                    if (other.HasSuggesterId)
                    {
                        this.MergeSuggesterId(other.SuggesterId);
                    }
                    if (other.HasSuggesteeId)
                    {
                        this.MergeSuggesteeId(other.SuggesteeId);
                    }
                    if (other.HasSuggesterName)
                    {
                        this.SuggesterName = other.SuggesterName;
                    }
                    if (other.HasSuggesteeName)
                    {
                        this.SuggesteeName = other.SuggesteeName;
                    }
                    if (other.HasSuggesterAccountId)
                    {
                        this.MergeSuggesterAccountId(other.SuggesterAccountId);
                    }
                }
                return this;
            }

            public override Suggestion.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override Suggestion.Builder MergeFrom(IMessageLite other)
            {
                if (other is Suggestion)
                {
                    return this.MergeFrom((Suggestion) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override Suggestion.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(Suggestion._suggestionFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = Suggestion._suggestionFieldTags[index];
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
                            EntityId.Builder builder = EntityId.CreateBuilder();
                            if (this.result.hasChannelId)
                            {
                                builder.MergeFrom(this.ChannelId);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.ChannelId = builder.BuildPartial();
                            continue;
                        }
                        case 0x12:
                        {
                            EntityId.Builder builder2 = EntityId.CreateBuilder();
                            if (this.result.hasSuggesterId)
                            {
                                builder2.MergeFrom(this.SuggesterId);
                            }
                            input.ReadMessage(builder2, extensionRegistry);
                            this.SuggesterId = builder2.BuildPartial();
                            continue;
                        }
                        case 0x1a:
                        {
                            EntityId.Builder builder3 = EntityId.CreateBuilder();
                            if (this.result.hasSuggesteeId)
                            {
                                builder3.MergeFrom(this.SuggesteeId);
                            }
                            input.ReadMessage(builder3, extensionRegistry);
                            this.SuggesteeId = builder3.BuildPartial();
                            continue;
                        }
                        case 0x22:
                        {
                            this.result.hasSuggesterName = input.ReadString(ref this.result.suggesterName_);
                            continue;
                        }
                        case 0x2a:
                        {
                            this.result.hasSuggesteeName = input.ReadString(ref this.result.suggesteeName_);
                            continue;
                        }
                        case 50:
                        {
                            EntityId.Builder builder4 = EntityId.CreateBuilder();
                            if (this.result.hasSuggesterAccountId)
                            {
                                builder4.MergeFrom(this.SuggesterAccountId);
                            }
                            input.ReadMessage(builder4, extensionRegistry);
                            this.SuggesterAccountId = builder4.BuildPartial();
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

            public Suggestion.Builder MergeSuggesteeId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasSuggesteeId && (this.result.suggesteeId_ != EntityId.DefaultInstance))
                {
                    this.result.suggesteeId_ = EntityId.CreateBuilder(this.result.suggesteeId_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.suggesteeId_ = value;
                }
                this.result.hasSuggesteeId = true;
                return this;
            }

            public Suggestion.Builder MergeSuggesterAccountId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasSuggesterAccountId && (this.result.suggesterAccountId_ != EntityId.DefaultInstance))
                {
                    this.result.suggesterAccountId_ = EntityId.CreateBuilder(this.result.suggesterAccountId_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.suggesterAccountId_ = value;
                }
                this.result.hasSuggesterAccountId = true;
                return this;
            }

            public Suggestion.Builder MergeSuggesterId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasSuggesterId && (this.result.suggesterId_ != EntityId.DefaultInstance))
                {
                    this.result.suggesterId_ = EntityId.CreateBuilder(this.result.suggesterId_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.suggesterId_ = value;
                }
                this.result.hasSuggesterId = true;
                return this;
            }

            private Suggestion PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    Suggestion result = this.result;
                    this.result = new Suggestion();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public Suggestion.Builder SetChannelId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasChannelId = true;
                this.result.channelId_ = value;
                return this;
            }

            public Suggestion.Builder SetChannelId(EntityId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasChannelId = true;
                this.result.channelId_ = builderForValue.Build();
                return this;
            }

            public Suggestion.Builder SetSuggesteeId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasSuggesteeId = true;
                this.result.suggesteeId_ = value;
                return this;
            }

            public Suggestion.Builder SetSuggesteeId(EntityId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasSuggesteeId = true;
                this.result.suggesteeId_ = builderForValue.Build();
                return this;
            }

            public Suggestion.Builder SetSuggesteeName(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasSuggesteeName = true;
                this.result.suggesteeName_ = value;
                return this;
            }

            public Suggestion.Builder SetSuggesterAccountId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasSuggesterAccountId = true;
                this.result.suggesterAccountId_ = value;
                return this;
            }

            public Suggestion.Builder SetSuggesterAccountId(EntityId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasSuggesterAccountId = true;
                this.result.suggesterAccountId_ = builderForValue.Build();
                return this;
            }

            public Suggestion.Builder SetSuggesterId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasSuggesterId = true;
                this.result.suggesterId_ = value;
                return this;
            }

            public Suggestion.Builder SetSuggesterId(EntityId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasSuggesterId = true;
                this.result.suggesterId_ = builderForValue.Build();
                return this;
            }

            public Suggestion.Builder SetSuggesterName(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasSuggesterName = true;
                this.result.suggesterName_ = value;
                return this;
            }

            public EntityId ChannelId
            {
                get
                {
                    return this.result.ChannelId;
                }
                set
                {
                    this.SetChannelId(value);
                }
            }

            public override Suggestion DefaultInstanceForType
            {
                get
                {
                    return Suggestion.DefaultInstance;
                }
            }

            public bool HasChannelId
            {
                get
                {
                    return this.result.hasChannelId;
                }
            }

            public bool HasSuggesteeId
            {
                get
                {
                    return this.result.hasSuggesteeId;
                }
            }

            public bool HasSuggesteeName
            {
                get
                {
                    return this.result.hasSuggesteeName;
                }
            }

            public bool HasSuggesterAccountId
            {
                get
                {
                    return this.result.hasSuggesterAccountId;
                }
            }

            public bool HasSuggesterId
            {
                get
                {
                    return this.result.hasSuggesterId;
                }
            }

            public bool HasSuggesterName
            {
                get
                {
                    return this.result.hasSuggesterName;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override Suggestion MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public EntityId SuggesteeId
            {
                get
                {
                    return this.result.SuggesteeId;
                }
                set
                {
                    this.SetSuggesteeId(value);
                }
            }

            public string SuggesteeName
            {
                get
                {
                    return this.result.SuggesteeName;
                }
                set
                {
                    this.SetSuggesteeName(value);
                }
            }

            public EntityId SuggesterAccountId
            {
                get
                {
                    return this.result.SuggesterAccountId;
                }
                set
                {
                    this.SetSuggesterAccountId(value);
                }
            }

            public EntityId SuggesterId
            {
                get
                {
                    return this.result.SuggesterId;
                }
                set
                {
                    this.SetSuggesterId(value);
                }
            }

            public string SuggesterName
            {
                get
                {
                    return this.result.SuggesterName;
                }
                set
                {
                    this.SetSuggesterName(value);
                }
            }

            protected override Suggestion.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

