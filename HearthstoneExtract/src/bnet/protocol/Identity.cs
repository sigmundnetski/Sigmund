namespace bnet.protocol
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class Identity : GeneratedMessageLite<Identity, Builder>
    {
        private static readonly string[] _identityFieldNames = new string[] { "account_id", "game_account_id" };
        private static readonly uint[] _identityFieldTags = new uint[] { 10, 0x12 };
        private EntityId accountId_;
        public const int AccountIdFieldNumber = 1;
        private static readonly Identity defaultInstance = new Identity().MakeReadOnly();
        private EntityId gameAccountId_;
        public const int GameAccountIdFieldNumber = 2;
        private bool hasAccountId;
        private bool hasGameAccountId;
        private int memoizedSerializedSize = -1;

        static Identity()
        {
            object.ReferenceEquals(Entity.Descriptor, null);
        }

        private Identity()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(Identity prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            Identity identity = obj as Identity;
            if (identity == null)
            {
                return false;
            }
            if ((this.hasAccountId != identity.hasAccountId) || (this.hasAccountId && !this.accountId_.Equals(identity.accountId_)))
            {
                return false;
            }
            return ((this.hasGameAccountId == identity.hasGameAccountId) && (!this.hasGameAccountId || this.gameAccountId_.Equals(identity.gameAccountId_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasAccountId)
            {
                hashCode ^= this.accountId_.GetHashCode();
            }
            if (this.hasGameAccountId)
            {
                hashCode ^= this.gameAccountId_.GetHashCode();
            }
            return hashCode;
        }

        private Identity MakeReadOnly()
        {
            return this;
        }

        public static Identity ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static Identity ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static Identity ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Identity ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static Identity ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Identity ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static Identity ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static Identity ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Identity ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static Identity ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<Identity, Builder>.PrintField("account_id", this.hasAccountId, this.accountId_, writer);
            GeneratedMessageLite<Identity, Builder>.PrintField("game_account_id", this.hasGameAccountId, this.gameAccountId_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _identityFieldNames;
            if (this.hasAccountId)
            {
                output.WriteMessage(1, strArray[0], this.AccountId);
            }
            if (this.hasGameAccountId)
            {
                output.WriteMessage(2, strArray[1], this.GameAccountId);
            }
        }

        public EntityId AccountId
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.accountId_ != null)
                {
                    goto Label_0012;
                }
                return EntityId.DefaultInstance;
            }
        }

        public static Identity DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override Identity DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public EntityId GameAccountId
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.gameAccountId_ != null)
                {
                    goto Label_0012;
                }
                return EntityId.DefaultInstance;
            }
        }

        public bool HasAccountId
        {
            get
            {
                return this.hasAccountId;
            }
        }

        public bool HasGameAccountId
        {
            get
            {
                return this.hasGameAccountId;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (this.HasAccountId && !this.AccountId.IsInitialized)
                {
                    return false;
                }
                if (this.HasGameAccountId && !this.GameAccountId.IsInitialized)
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
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, this.AccountId);
                    }
                    if (this.hasGameAccountId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(2, this.GameAccountId);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override Identity ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public sealed class Builder : GeneratedBuilderLite<Identity, Identity.Builder>
        {
            private Identity result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = Identity.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(Identity cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override Identity BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override Identity.Builder Clear()
            {
                this.result = Identity.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public Identity.Builder ClearAccountId()
            {
                this.PrepareBuilder();
                this.result.hasAccountId = false;
                this.result.accountId_ = null;
                return this;
            }

            public Identity.Builder ClearGameAccountId()
            {
                this.PrepareBuilder();
                this.result.hasGameAccountId = false;
                this.result.gameAccountId_ = null;
                return this;
            }

            public override Identity.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new Identity.Builder(this.result);
                }
                return new Identity.Builder().MergeFrom(this.result);
            }

            public Identity.Builder MergeAccountId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasAccountId && (this.result.accountId_ != EntityId.DefaultInstance))
                {
                    this.result.accountId_ = EntityId.CreateBuilder(this.result.accountId_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.accountId_ = value;
                }
                this.result.hasAccountId = true;
                return this;
            }

            public override Identity.Builder MergeFrom(Identity other)
            {
                if (other != Identity.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasAccountId)
                    {
                        this.MergeAccountId(other.AccountId);
                    }
                    if (other.HasGameAccountId)
                    {
                        this.MergeGameAccountId(other.GameAccountId);
                    }
                }
                return this;
            }

            public override Identity.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override Identity.Builder MergeFrom(IMessageLite other)
            {
                if (other is Identity)
                {
                    return this.MergeFrom((Identity) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override Identity.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(Identity._identityFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = Identity._identityFieldTags[index];
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
                            if (this.result.hasAccountId)
                            {
                                builder.MergeFrom(this.AccountId);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.AccountId = builder.BuildPartial();
                            continue;
                        }
                        case 0x12:
                        {
                            EntityId.Builder builder2 = EntityId.CreateBuilder();
                            if (this.result.hasGameAccountId)
                            {
                                builder2.MergeFrom(this.GameAccountId);
                            }
                            input.ReadMessage(builder2, extensionRegistry);
                            this.GameAccountId = builder2.BuildPartial();
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

            public Identity.Builder MergeGameAccountId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasGameAccountId && (this.result.gameAccountId_ != EntityId.DefaultInstance))
                {
                    this.result.gameAccountId_ = EntityId.CreateBuilder(this.result.gameAccountId_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.gameAccountId_ = value;
                }
                this.result.hasGameAccountId = true;
                return this;
            }

            private Identity PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    Identity result = this.result;
                    this.result = new Identity();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public Identity.Builder SetAccountId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasAccountId = true;
                this.result.accountId_ = value;
                return this;
            }

            public Identity.Builder SetAccountId(EntityId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasAccountId = true;
                this.result.accountId_ = builderForValue.Build();
                return this;
            }

            public Identity.Builder SetGameAccountId(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasGameAccountId = true;
                this.result.gameAccountId_ = value;
                return this;
            }

            public Identity.Builder SetGameAccountId(EntityId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasGameAccountId = true;
                this.result.gameAccountId_ = builderForValue.Build();
                return this;
            }

            public EntityId AccountId
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

            public override Identity DefaultInstanceForType
            {
                get
                {
                    return Identity.DefaultInstance;
                }
            }

            public EntityId GameAccountId
            {
                get
                {
                    return this.result.GameAccountId;
                }
                set
                {
                    this.SetGameAccountId(value);
                }
            }

            public bool HasAccountId
            {
                get
                {
                    return this.result.hasAccountId;
                }
            }

            public bool HasGameAccountId
            {
                get
                {
                    return this.result.hasGameAccountId;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override Identity MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override Identity.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

