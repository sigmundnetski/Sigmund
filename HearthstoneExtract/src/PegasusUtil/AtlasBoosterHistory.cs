namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using PegasusShared;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class AtlasBoosterHistory : GeneratedMessageLite<AtlasBoosterHistory, Builder>
    {
        private static readonly string[] _atlasBoosterHistoryFieldNames = new string[] { "action", "when" };
        private static readonly uint[] _atlasBoosterHistoryFieldTags = new uint[] { 8, 0x12 };
        private int action_;
        public const int ActionFieldNumber = 1;
        private static readonly AtlasBoosterHistory defaultInstance = new AtlasBoosterHistory().MakeReadOnly();
        private bool hasAction;
        private bool hasWhen;
        private int memoizedSerializedSize = -1;
        private Date when_;
        public const int WhenFieldNumber = 2;

        static AtlasBoosterHistory()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private AtlasBoosterHistory()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(AtlasBoosterHistory prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            AtlasBoosterHistory history = obj as AtlasBoosterHistory;
            if (history == null)
            {
                return false;
            }
            if ((this.hasAction != history.hasAction) || (this.hasAction && !this.action_.Equals(history.action_)))
            {
                return false;
            }
            return ((this.hasWhen == history.hasWhen) && (!this.hasWhen || this.when_.Equals(history.when_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasAction)
            {
                hashCode ^= this.action_.GetHashCode();
            }
            if (this.hasWhen)
            {
                hashCode ^= this.when_.GetHashCode();
            }
            return hashCode;
        }

        private AtlasBoosterHistory MakeReadOnly()
        {
            return this;
        }

        public static AtlasBoosterHistory ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static AtlasBoosterHistory ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasBoosterHistory ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasBoosterHistory ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static AtlasBoosterHistory ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasBoosterHistory ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static AtlasBoosterHistory ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static AtlasBoosterHistory ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasBoosterHistory ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static AtlasBoosterHistory ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<AtlasBoosterHistory, Builder>.PrintField("action", this.hasAction, this.action_, writer);
            GeneratedMessageLite<AtlasBoosterHistory, Builder>.PrintField("when", this.hasWhen, this.when_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _atlasBoosterHistoryFieldNames;
            if (this.hasAction)
            {
                output.WriteInt32(1, strArray[0], this.Action);
            }
            if (this.hasWhen)
            {
                output.WriteMessage(2, strArray[1], this.When);
            }
        }

        public int Action
        {
            get
            {
                return this.action_;
            }
        }

        public static AtlasBoosterHistory DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override AtlasBoosterHistory DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasAction
        {
            get
            {
                return this.hasAction;
            }
        }

        public bool HasWhen
        {
            get
            {
                return this.hasWhen;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasAction)
                {
                    return false;
                }
                if (!this.hasWhen)
                {
                    return false;
                }
                if (!this.When.IsInitialized)
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
                    if (this.hasAction)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(1, this.Action);
                    }
                    if (this.hasWhen)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(2, this.When);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override AtlasBoosterHistory ThisMessage
        {
            get
            {
                return this;
            }
        }

        public Date When
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.when_ != null)
                {
                    goto Label_0012;
                }
                return Date.DefaultInstance;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<AtlasBoosterHistory, AtlasBoosterHistory.Builder>
        {
            private AtlasBoosterHistory result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = AtlasBoosterHistory.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(AtlasBoosterHistory cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override AtlasBoosterHistory BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override AtlasBoosterHistory.Builder Clear()
            {
                this.result = AtlasBoosterHistory.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public AtlasBoosterHistory.Builder ClearAction()
            {
                this.PrepareBuilder();
                this.result.hasAction = false;
                this.result.action_ = 0;
                return this;
            }

            public AtlasBoosterHistory.Builder ClearWhen()
            {
                this.PrepareBuilder();
                this.result.hasWhen = false;
                this.result.when_ = null;
                return this;
            }

            public override AtlasBoosterHistory.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new AtlasBoosterHistory.Builder(this.result);
                }
                return new AtlasBoosterHistory.Builder().MergeFrom(this.result);
            }

            public override AtlasBoosterHistory.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override AtlasBoosterHistory.Builder MergeFrom(IMessageLite other)
            {
                if (other is AtlasBoosterHistory)
                {
                    return this.MergeFrom((AtlasBoosterHistory) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override AtlasBoosterHistory.Builder MergeFrom(AtlasBoosterHistory other)
            {
                if (other != AtlasBoosterHistory.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasAction)
                    {
                        this.Action = other.Action;
                    }
                    if (other.HasWhen)
                    {
                        this.MergeWhen(other.When);
                    }
                }
                return this;
            }

            public override AtlasBoosterHistory.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(AtlasBoosterHistory._atlasBoosterHistoryFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = AtlasBoosterHistory._atlasBoosterHistoryFieldTags[index];
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
                        {
                            this.result.hasAction = input.ReadInt32(ref this.result.action_);
                            continue;
                        }
                        case 0x12:
                        {
                            Date.Builder builder = Date.CreateBuilder();
                            if (this.result.hasWhen)
                            {
                                builder.MergeFrom(this.When);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.When = builder.BuildPartial();
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

            public AtlasBoosterHistory.Builder MergeWhen(Date value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasWhen && (this.result.when_ != Date.DefaultInstance))
                {
                    this.result.when_ = Date.CreateBuilder(this.result.when_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.when_ = value;
                }
                this.result.hasWhen = true;
                return this;
            }

            private AtlasBoosterHistory PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    AtlasBoosterHistory result = this.result;
                    this.result = new AtlasBoosterHistory();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public AtlasBoosterHistory.Builder SetAction(int value)
            {
                this.PrepareBuilder();
                this.result.hasAction = true;
                this.result.action_ = value;
                return this;
            }

            public AtlasBoosterHistory.Builder SetWhen(Date value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasWhen = true;
                this.result.when_ = value;
                return this;
            }

            public AtlasBoosterHistory.Builder SetWhen(Date.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasWhen = true;
                this.result.when_ = builderForValue.Build();
                return this;
            }

            public int Action
            {
                get
                {
                    return this.result.Action;
                }
                set
                {
                    this.SetAction(value);
                }
            }

            public override AtlasBoosterHistory DefaultInstanceForType
            {
                get
                {
                    return AtlasBoosterHistory.DefaultInstance;
                }
            }

            public bool HasAction
            {
                get
                {
                    return this.result.hasAction;
                }
            }

            public bool HasWhen
            {
                get
                {
                    return this.result.hasWhen;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override AtlasBoosterHistory MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override AtlasBoosterHistory.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            public Date When
            {
                get
                {
                    return this.result.When;
                }
                set
                {
                    this.SetWhen(value);
                }
            }
        }
    }
}

