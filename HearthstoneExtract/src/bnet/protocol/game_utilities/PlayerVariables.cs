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

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class PlayerVariables : GeneratedMessageLite<PlayerVariables, Builder>
    {
        private static readonly string[] _playerVariablesFieldNames = new string[] { "attribute", "identity", "rating" };
        private static readonly uint[] _playerVariablesFieldTags = new uint[] { 0x1a, 10, 0x11 };
        private PopsicleList<bnet.protocol.game_utilities.Attribute> attribute_ = new PopsicleList<bnet.protocol.game_utilities.Attribute>();
        public const int AttributeFieldNumber = 3;
        private static readonly PlayerVariables defaultInstance = new PlayerVariables().MakeReadOnly();
        private bool hasIdentity;
        private bool hasRating;
        private bnet.protocol.game_utilities.Identity identity_;
        public const int IdentityFieldNumber = 1;
        private int memoizedSerializedSize = -1;
        private double rating_;
        public const int RatingFieldNumber = 2;

        static PlayerVariables()
        {
            object.ReferenceEquals(GameUtils.Descriptor, null);
        }

        private PlayerVariables()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(PlayerVariables prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            PlayerVariables variables = obj as PlayerVariables;
            if (variables == null)
            {
                return false;
            }
            if ((this.hasIdentity != variables.hasIdentity) || (this.hasIdentity && !this.identity_.Equals(variables.identity_)))
            {
                return false;
            }
            if ((this.hasRating != variables.hasRating) || (this.hasRating && !this.rating_.Equals(variables.rating_)))
            {
                return false;
            }
            if (this.attribute_.Count != variables.attribute_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.attribute_.Count; i++)
            {
                if (!this.attribute_[i].Equals(variables.attribute_[i]))
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
            if (this.hasIdentity)
            {
                hashCode ^= this.identity_.GetHashCode();
            }
            if (this.hasRating)
            {
                hashCode ^= this.rating_.GetHashCode();
            }
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

        private PlayerVariables MakeReadOnly()
        {
            this.attribute_.MakeReadOnly();
            return this;
        }

        public static PlayerVariables ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static PlayerVariables ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static PlayerVariables ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static PlayerVariables ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static PlayerVariables ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static PlayerVariables ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static PlayerVariables ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static PlayerVariables ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static PlayerVariables ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static PlayerVariables ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<PlayerVariables, Builder>.PrintField("identity", this.hasIdentity, this.identity_, writer);
            GeneratedMessageLite<PlayerVariables, Builder>.PrintField("rating", this.hasRating, this.rating_, writer);
            GeneratedMessageLite<PlayerVariables, Builder>.PrintField<bnet.protocol.game_utilities.Attribute>("attribute", this.attribute_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _playerVariablesFieldNames;
            if (this.hasIdentity)
            {
                output.WriteMessage(1, strArray[1], this.Identity);
            }
            if (this.hasRating)
            {
                output.WriteDouble(2, strArray[2], this.Rating);
            }
            if (this.attribute_.Count > 0)
            {
                output.WriteMessageArray<bnet.protocol.game_utilities.Attribute>(3, strArray[0], this.attribute_);
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

        public static PlayerVariables DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override PlayerVariables DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasIdentity
        {
            get
            {
                return this.hasIdentity;
            }
        }

        public bool HasRating
        {
            get
            {
                return this.hasRating;
            }
        }

        public bnet.protocol.game_utilities.Identity Identity
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.identity_ != null)
                {
                    goto Label_0012;
                }
                return bnet.protocol.game_utilities.Identity.DefaultInstance;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasIdentity)
                {
                    return false;
                }
                if (!this.Identity.IsInitialized)
                {
                    return false;
                }
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

        public double Rating
        {
            get
            {
                return this.rating_;
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
                    if (this.hasIdentity)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, this.Identity);
                    }
                    if (this.hasRating)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeDoubleSize(2, this.Rating);
                    }
                    IEnumerator<bnet.protocol.game_utilities.Attribute> enumerator = this.AttributeList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            bnet.protocol.game_utilities.Attribute current = enumerator.Current;
                            memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(3, current);
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

        protected override PlayerVariables ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<PlayerVariables, PlayerVariables.Builder>
        {
            private PlayerVariables result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = PlayerVariables.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(PlayerVariables cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public PlayerVariables.Builder AddAttribute(bnet.protocol.game_utilities.Attribute value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.attribute_.Add(value);
                return this;
            }

            public PlayerVariables.Builder AddAttribute(bnet.protocol.game_utilities.Attribute.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.attribute_.Add(builderForValue.Build());
                return this;
            }

            public PlayerVariables.Builder AddRangeAttribute(IEnumerable<bnet.protocol.game_utilities.Attribute> values)
            {
                this.PrepareBuilder();
                this.result.attribute_.Add(values);
                return this;
            }

            public override PlayerVariables BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override PlayerVariables.Builder Clear()
            {
                this.result = PlayerVariables.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public PlayerVariables.Builder ClearAttribute()
            {
                this.PrepareBuilder();
                this.result.attribute_.Clear();
                return this;
            }

            public PlayerVariables.Builder ClearIdentity()
            {
                this.PrepareBuilder();
                this.result.hasIdentity = false;
                this.result.identity_ = null;
                return this;
            }

            public PlayerVariables.Builder ClearRating()
            {
                this.PrepareBuilder();
                this.result.hasRating = false;
                this.result.rating_ = 0.0;
                return this;
            }

            public override PlayerVariables.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new PlayerVariables.Builder(this.result);
                }
                return new PlayerVariables.Builder().MergeFrom(this.result);
            }

            public bnet.protocol.game_utilities.Attribute GetAttribute(int index)
            {
                return this.result.GetAttribute(index);
            }

            public override PlayerVariables.Builder MergeFrom(PlayerVariables other)
            {
                if (other != PlayerVariables.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasIdentity)
                    {
                        this.MergeIdentity(other.Identity);
                    }
                    if (other.HasRating)
                    {
                        this.Rating = other.Rating;
                    }
                    if (other.attribute_.Count != 0)
                    {
                        this.result.attribute_.Add(other.attribute_);
                    }
                }
                return this;
            }

            public override PlayerVariables.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override PlayerVariables.Builder MergeFrom(IMessageLite other)
            {
                if (other is PlayerVariables)
                {
                    return this.MergeFrom((PlayerVariables) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override PlayerVariables.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(PlayerVariables._playerVariablesFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = PlayerVariables._playerVariablesFieldTags[index];
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
                            bnet.protocol.game_utilities.Identity.Builder builder = bnet.protocol.game_utilities.Identity.CreateBuilder();
                            if (this.result.hasIdentity)
                            {
                                builder.MergeFrom(this.Identity);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.Identity = builder.BuildPartial();
                            continue;
                        }
                        case 0x11:
                        {
                            this.result.hasRating = input.ReadDouble(ref this.result.rating_);
                            continue;
                        }
                        case 0x1a:
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

            public PlayerVariables.Builder MergeIdentity(bnet.protocol.game_utilities.Identity value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasIdentity && (this.result.identity_ != bnet.protocol.game_utilities.Identity.DefaultInstance))
                {
                    this.result.identity_ = bnet.protocol.game_utilities.Identity.CreateBuilder(this.result.identity_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.identity_ = value;
                }
                this.result.hasIdentity = true;
                return this;
            }

            private PlayerVariables PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    PlayerVariables result = this.result;
                    this.result = new PlayerVariables();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public PlayerVariables.Builder SetAttribute(int index, bnet.protocol.game_utilities.Attribute value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.attribute_[index] = value;
                return this;
            }

            public PlayerVariables.Builder SetAttribute(int index, bnet.protocol.game_utilities.Attribute.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.attribute_[index] = builderForValue.Build();
                return this;
            }

            public PlayerVariables.Builder SetIdentity(bnet.protocol.game_utilities.Identity value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasIdentity = true;
                this.result.identity_ = value;
                return this;
            }

            public PlayerVariables.Builder SetIdentity(bnet.protocol.game_utilities.Identity.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasIdentity = true;
                this.result.identity_ = builderForValue.Build();
                return this;
            }

            public PlayerVariables.Builder SetRating(double value)
            {
                this.PrepareBuilder();
                this.result.hasRating = true;
                this.result.rating_ = value;
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

            public override PlayerVariables DefaultInstanceForType
            {
                get
                {
                    return PlayerVariables.DefaultInstance;
                }
            }

            public bool HasIdentity
            {
                get
                {
                    return this.result.hasIdentity;
                }
            }

            public bool HasRating
            {
                get
                {
                    return this.result.hasRating;
                }
            }

            public bnet.protocol.game_utilities.Identity Identity
            {
                get
                {
                    return this.result.Identity;
                }
                set
                {
                    this.SetIdentity(value);
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override PlayerVariables MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public double Rating
            {
                get
                {
                    return this.result.Rating;
                }
                set
                {
                    this.SetRating(value);
                }
            }

            protected override PlayerVariables.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

