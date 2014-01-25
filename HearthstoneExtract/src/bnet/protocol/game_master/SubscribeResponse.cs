namespace bnet.protocol.game_master
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
    public sealed class SubscribeResponse : GeneratedMessageLite<SubscribeResponse, Builder>
    {
        private static readonly string[] _subscribeResponseFieldNames = new string[] { "subscription_id" };
        private static readonly uint[] _subscribeResponseFieldTags = new uint[] { 8 };
        private static readonly SubscribeResponse defaultInstance = new SubscribeResponse().MakeReadOnly();
        private bool hasSubscriptionId;
        private int memoizedSerializedSize = -1;
        private ulong subscriptionId_;
        public const int SubscriptionIdFieldNumber = 1;

        static SubscribeResponse()
        {
            object.ReferenceEquals(GameMaster.Descriptor, null);
        }

        private SubscribeResponse()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(SubscribeResponse prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            SubscribeResponse response = obj as SubscribeResponse;
            if (response == null)
            {
                return false;
            }
            return ((this.hasSubscriptionId == response.hasSubscriptionId) && (!this.hasSubscriptionId || this.subscriptionId_.Equals(response.subscriptionId_)));
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

        private SubscribeResponse MakeReadOnly()
        {
            return this;
        }

        public static SubscribeResponse ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static SubscribeResponse ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static SubscribeResponse ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static SubscribeResponse ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static SubscribeResponse ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static SubscribeResponse ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static SubscribeResponse ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static SubscribeResponse ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static SubscribeResponse ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static SubscribeResponse ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<SubscribeResponse, Builder>.PrintField("subscription_id", this.hasSubscriptionId, this.subscriptionId_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _subscribeResponseFieldNames;
            if (this.hasSubscriptionId)
            {
                output.WriteUInt64(1, strArray[0], this.SubscriptionId);
            }
        }

        public static SubscribeResponse DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override SubscribeResponse DefaultInstanceForType
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

        protected override SubscribeResponse ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<SubscribeResponse, SubscribeResponse.Builder>
        {
            private SubscribeResponse result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = SubscribeResponse.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(SubscribeResponse cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override SubscribeResponse BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override SubscribeResponse.Builder Clear()
            {
                this.result = SubscribeResponse.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public SubscribeResponse.Builder ClearSubscriptionId()
            {
                this.PrepareBuilder();
                this.result.hasSubscriptionId = false;
                this.result.subscriptionId_ = 0L;
                return this;
            }

            public override SubscribeResponse.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new SubscribeResponse.Builder(this.result);
                }
                return new SubscribeResponse.Builder().MergeFrom(this.result);
            }

            public override SubscribeResponse.Builder MergeFrom(SubscribeResponse other)
            {
                if (other != SubscribeResponse.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasSubscriptionId)
                    {
                        this.SubscriptionId = other.SubscriptionId;
                    }
                }
                return this;
            }

            public override SubscribeResponse.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override SubscribeResponse.Builder MergeFrom(IMessageLite other)
            {
                if (other is SubscribeResponse)
                {
                    return this.MergeFrom((SubscribeResponse) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override SubscribeResponse.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(SubscribeResponse._subscribeResponseFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = SubscribeResponse._subscribeResponseFieldTags[index];
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

            private SubscribeResponse PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    SubscribeResponse result = this.result;
                    this.result = new SubscribeResponse();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            [CLSCompliant(false)]
            public SubscribeResponse.Builder SetSubscriptionId(ulong value)
            {
                this.PrepareBuilder();
                this.result.hasSubscriptionId = true;
                this.result.subscriptionId_ = value;
                return this;
            }

            public override SubscribeResponse DefaultInstanceForType
            {
                get
                {
                    return SubscribeResponse.DefaultInstance;
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

            protected override SubscribeResponse MessageBeingBuilt
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

            protected override SubscribeResponse.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

