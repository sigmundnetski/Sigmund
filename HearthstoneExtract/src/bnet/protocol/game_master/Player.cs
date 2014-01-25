namespace bnet.protocol.game_master
{
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Collections;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class Player : GeneratedMessageLite<Player, Builder>
    {
        private static readonly string[] _playerFieldNames = new string[] { "attribute", "identity" };
        private static readonly uint[] _playerFieldTags = new uint[] { 0x12, 10 };
        private PopsicleList<bnet.protocol.game_master.Attribute> attribute_ = new PopsicleList<bnet.protocol.game_master.Attribute>();
        public const int AttributeFieldNumber = 2;
        private static readonly Player defaultInstance = new Player().MakeReadOnly();
        private bool hasIdentity;
        private bnet.protocol.game_master.Identity identity_;
        public const int IdentityFieldNumber = 1;
        private int memoizedSerializedSize = -1;

        static Player()
        {
            object.ReferenceEquals(GameMaster.Descriptor, null);
        }

        private Player()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(Player prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            Player player = obj as Player;
            if (player == null)
            {
                return false;
            }
            if ((this.hasIdentity != player.hasIdentity) || (this.hasIdentity && !this.identity_.Equals(player.identity_)))
            {
                return false;
            }
            if (this.attribute_.Count != player.attribute_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.attribute_.Count; i++)
            {
                if (!this.attribute_[i].Equals(player.attribute_[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public bnet.protocol.game_master.Attribute GetAttribute(int index)
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
            IEnumerator<bnet.protocol.game_master.Attribute> enumerator = this.attribute_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    bnet.protocol.game_master.Attribute current = enumerator.Current;
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

        private Player MakeReadOnly()
        {
            this.attribute_.MakeReadOnly();
            return this;
        }

        public static Player ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static Player ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static Player ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Player ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Player ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Player ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Player ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static Player ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Player ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Player ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<Player, Builder>.PrintField("identity", this.hasIdentity, this.identity_, writer);
            GeneratedMessageLite<Player, Builder>.PrintField<bnet.protocol.game_master.Attribute>("attribute", this.attribute_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _playerFieldNames;
            if (this.hasIdentity)
            {
                output.WriteMessage(1, strArray[1], this.Identity);
            }
            if (this.attribute_.Count > 0)
            {
                output.WriteMessageArray<bnet.protocol.game_master.Attribute>(2, strArray[0], this.attribute_);
            }
        }

        public int AttributeCount
        {
            get
            {
                return this.attribute_.Count;
            }
        }

        public IList<bnet.protocol.game_master.Attribute> AttributeList
        {
            get
            {
                return this.attribute_;
            }
        }

        public static Player DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override Player DefaultInstanceForType
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

        public bnet.protocol.game_master.Identity Identity
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.identity_ != null)
                {
                    goto Label_0012;
                }
                return bnet.protocol.game_master.Identity.DefaultInstance;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (this.HasIdentity && !this.Identity.IsInitialized)
                {
                    return false;
                }
                IEnumerator<bnet.protocol.game_master.Attribute> enumerator = this.AttributeList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        bnet.protocol.game_master.Attribute current = enumerator.Current;
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
                    if (this.hasIdentity)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, this.Identity);
                    }
                    IEnumerator<bnet.protocol.game_master.Attribute> enumerator = this.AttributeList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            bnet.protocol.game_master.Attribute current = enumerator.Current;
                            memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(2, current);
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

        protected override Player ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<Player, Player.Builder>
        {
            private Player result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = Player.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(Player cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public Player.Builder AddAttribute(bnet.protocol.game_master.Attribute value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.attribute_.Add(value);
                return this;
            }

            public Player.Builder AddAttribute(bnet.protocol.game_master.Attribute.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.attribute_.Add(builderForValue.Build());
                return this;
            }

            public Player.Builder AddRangeAttribute(IEnumerable<bnet.protocol.game_master.Attribute> values)
            {
                this.PrepareBuilder();
                this.result.attribute_.Add(values);
                return this;
            }

            public override Player BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override Player.Builder Clear()
            {
                this.result = Player.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public Player.Builder ClearAttribute()
            {
                this.PrepareBuilder();
                this.result.attribute_.Clear();
                return this;
            }

            public Player.Builder ClearIdentity()
            {
                this.PrepareBuilder();
                this.result.hasIdentity = false;
                this.result.identity_ = null;
                return this;
            }

            public override Player.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new Player.Builder(this.result);
                }
                return new Player.Builder().MergeFrom(this.result);
            }

            public bnet.protocol.game_master.Attribute GetAttribute(int index)
            {
                return this.result.GetAttribute(index);
            }

            public override Player.Builder MergeFrom(Player other)
            {
                if (other != Player.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasIdentity)
                    {
                        this.MergeIdentity(other.Identity);
                    }
                    if (other.attribute_.Count != 0)
                    {
                        this.result.attribute_.Add(other.attribute_);
                    }
                }
                return this;
            }

            public override Player.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override Player.Builder MergeFrom(IMessageLite other)
            {
                if (other is Player)
                {
                    return this.MergeFrom((Player) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override Player.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(Player._playerFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = Player._playerFieldTags[index];
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
                            bnet.protocol.game_master.Identity.Builder builder = bnet.protocol.game_master.Identity.CreateBuilder();
                            if (this.result.hasIdentity)
                            {
                                builder.MergeFrom(this.Identity);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.Identity = builder.BuildPartial();
                            continue;
                        }
                        case 0x12:
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
                    input.ReadMessageArray<bnet.protocol.game_master.Attribute>(num, str, this.result.attribute_, bnet.protocol.game_master.Attribute.DefaultInstance, extensionRegistry);
                }
                return this;
            }

            public Player.Builder MergeIdentity(bnet.protocol.game_master.Identity value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasIdentity && (this.result.identity_ != bnet.protocol.game_master.Identity.DefaultInstance))
                {
                    this.result.identity_ = bnet.protocol.game_master.Identity.CreateBuilder(this.result.identity_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.identity_ = value;
                }
                this.result.hasIdentity = true;
                return this;
            }

            private Player PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    Player result = this.result;
                    this.result = new Player();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public Player.Builder SetAttribute(int index, bnet.protocol.game_master.Attribute value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.attribute_[index] = value;
                return this;
            }

            public Player.Builder SetAttribute(int index, bnet.protocol.game_master.Attribute.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.attribute_[index] = builderForValue.Build();
                return this;
            }

            public Player.Builder SetIdentity(bnet.protocol.game_master.Identity value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasIdentity = true;
                this.result.identity_ = value;
                return this;
            }

            public Player.Builder SetIdentity(bnet.protocol.game_master.Identity.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasIdentity = true;
                this.result.identity_ = builderForValue.Build();
                return this;
            }

            public int AttributeCount
            {
                get
                {
                    return this.result.AttributeCount;
                }
            }

            public IPopsicleList<bnet.protocol.game_master.Attribute> AttributeList
            {
                get
                {
                    return this.PrepareBuilder().attribute_;
                }
            }

            public override Player DefaultInstanceForType
            {
                get
                {
                    return Player.DefaultInstance;
                }
            }

            public bool HasIdentity
            {
                get
                {
                    return this.result.hasIdentity;
                }
            }

            public bnet.protocol.game_master.Identity Identity
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

            protected override Player MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override Player.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

