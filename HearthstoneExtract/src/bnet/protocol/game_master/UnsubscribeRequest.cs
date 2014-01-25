namespace bnet.protocol.game_master
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class UnsubscribeRequest : GeneratedMessageLite<UnsubscribeRequest, Builder>
    {
        private static readonly string[] _unsubscribeRequestFieldNames = new string[] { "subscription_id" };
        private static readonly uint[] _unsubscribeRequestFieldTags = new uint[] { 8 };
        private static readonly UnsubscribeRequest defaultInstance = new UnsubscribeRequest().MakeReadOnly();
        private bool hasSubscriptionId;
        private int memoizedSerializedSize = -1;
        private ulong subscriptionId_;
        public const int SubscriptionIdFieldNumber = 1;

        static UnsubscribeRequest()
        {
            object.ReferenceEquals(GameMaster.Descriptor, null);
        }

        private UnsubscribeRequest()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(UnsubscribeRequest prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            UnsubscribeRequest request = obj as UnsubscribeRequest;
            if (request == null)
            {
                return false;
            }
            return ((this.hasSubscriptionId == request.hasSubscriptionId) && (!this.hasSubscriptionId || this.subscriptionId_.Equals(request.subscriptionId_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasSubscriptionId)
            {
                hashCode ^= this.subscriptionId_.GetHashCode();
            }
            return hashCode;
        }

        private UnsubscribeRequest MakeReadOnly()
        {
            return this;
        }

        public static UnsubscribeRequest ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static UnsubscribeRequest ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static UnsubscribeRequest ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static UnsubscribeRequest ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static UnsubscribeRequest ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static UnsubscribeRequest ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static UnsubscribeRequest ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static UnsubscribeRequest ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static UnsubscribeRequest ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static UnsubscribeRequest ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<UnsubscribeRequest, Builder>.PrintField("subscription_id", this.hasSubscriptionId, this.subscriptionId_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _unsubscribeRequestFieldNames;
            if (this.hasSubscriptionId)
            {
                output.WriteUInt64(1, strArray[0], this.SubscriptionId);
            }
        }

        public static UnsubscribeRequest DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override UnsubscribeRequest DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasSubscriptionId
        {
            get
            {
                return this.hasSubscriptionId;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasSubscriptionId)
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
                    if (this.hasSubscriptionId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt64Size(1, this.SubscriptionId);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        [CLSCompliant(false)]
        public ulong SubscriptionId
        {
            get
            {
                return this.subscriptionId_;
            }
        }

        protected override UnsubscribeRequest ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<UnsubscribeRequest, UnsubscribeRequest.Builder>
        {
            private UnsubscribeRequest result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = UnsubscribeRequest.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(UnsubscribeRequest cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override UnsubscribeRequest BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override UnsubscribeRequest.Builder Clear()
            {
                this.result = UnsubscribeRequest.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public UnsubscribeRequest.Builder ClearSubscriptionId()
            {
                this.PrepareBuilder();
                this.result.hasSubscriptionId = false;
                this.result.subscriptionId_ = 0L;
                return this;
            }

            public override UnsubscribeRequest.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new UnsubscribeRequest.Builder(this.result);
                }
                return new UnsubscribeRequest.Builder().MergeFrom(this.result);
            }

            public override UnsubscribeRequest.Builder MergeFrom(UnsubscribeRequest other)
            {
                if (other != UnsubscribeRequest.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasSubscriptionId)
                    {
                        this.SubscriptionId = other.SubscriptionId;
                    }
                }
                return this;
            }

            public override UnsubscribeRequest.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override UnsubscribeRequest.Builder MergeFrom(IMessageLite other)
            {
                if (other is UnsubscribeRequest)
                {
                    return this.MergeFrom((UnsubscribeRequest) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override UnsubscribeRequest.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(UnsubscribeRequest._unsubscribeRequestFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = UnsubscribeRequest._unsubscribeRequestFieldTags[index];
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
                    this.result.hasSubscriptionId = input.ReadUInt64(ref this.result.subscriptionId_);
                }
                return this;
            }

            private UnsubscribeRequest PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    UnsubscribeRequest result = this.result;
                    this.result = new UnsubscribeRequest();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            [CLSCompliant(false)]
            public UnsubscribeRequest.Builder SetSubscriptionId(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasSubscriptionId = true;
                this.result.subscriptionId_ = value;
                return this;
            }

            public override UnsubscribeRequest DefaultInstanceForType
            {
                get
                {
                    return UnsubscribeRequest.DefaultInstance;
                }
            }

            public bool HasSubscriptionId
            {
                get
                {
                    return this.result.hasSubscriptionId;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override UnsubscribeRequest MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            [CLSCompliant(false)]
            public ulong SubscriptionId
            {
                get
                {
                    return this.result.SubscriptionId;
                }
                set
                {
                    this.SetSubscriptionId(value);
                }
            }

            protected override UnsubscribeRequest.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

