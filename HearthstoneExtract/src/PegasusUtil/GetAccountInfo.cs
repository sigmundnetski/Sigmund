namespace PegasusUtil
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class GetAccountInfo : GeneratedMessageLite<GetAccountInfo, Builder>
    {
        private static readonly string[] _getAccountInfoFieldNames = new string[] { "request" };
        private static readonly uint[] _getAccountInfoFieldTags = new uint[] { 8 };
        private static readonly GetAccountInfo defaultInstance = new GetAccountInfo().MakeReadOnly();
        private bool hasRequest;
        private int memoizedSerializedSize = -1;
        private PegasusUtil.GetAccountInfo.Types.Request request_ = PegasusUtil.GetAccountInfo.Types.Request.LAST_LOGIN;
        public const int RequestFieldNumber = 1;

        static GetAccountInfo()
        {
            object.ReferenceEquals(PegasusUtillite.Descriptor, null);
        }

        private GetAccountInfo()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(GetAccountInfo prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            GetAccountInfo info = obj as GetAccountInfo;
            if (info == null)
            {
                return false;
            }
            return ((this.hasRequest == info.hasRequest) && (!this.hasRequest || this.request_.Equals(info.request_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasRequest)
            {
                hashCode ^= this.request_.GetHashCode();
            }
            return hashCode;
        }

        private GetAccountInfo MakeReadOnly()
        {
            return this;
        }

        public static GetAccountInfo ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static GetAccountInfo ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static GetAccountInfo ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GetAccountInfo ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GetAccountInfo ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GetAccountInfo ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GetAccountInfo ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static GetAccountInfo ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GetAccountInfo ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GetAccountInfo ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<GetAccountInfo, Builder>.PrintField("request", this.hasRequest, this.request_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _getAccountInfoFieldNames;
            if (this.hasRequest)
            {
                output.WriteEnum(1, strArray[0], (int) this.Request, this.Request);
            }
        }

        public static GetAccountInfo DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override GetAccountInfo DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasRequest
        {
            get
            {
                return this.hasRequest;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasRequest)
                {
                    return false;
                }
                return true;
            }
        }

        public PegasusUtil.GetAccountInfo.Types.Request Request
        {
            get
            {
                return this.request_;
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
                    if (this.hasRequest)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeEnumSize(1, (int) this.Request);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override GetAccountInfo ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<GetAccountInfo, GetAccountInfo.Builder>
        {
            private GetAccountInfo result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = GetAccountInfo.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(GetAccountInfo cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override GetAccountInfo BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override GetAccountInfo.Builder Clear()
            {
                this.result = GetAccountInfo.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public GetAccountInfo.Builder ClearRequest()
            {
                this.PrepareBuilder();
                this.result.hasRequest = false;
                this.result.request_ = PegasusUtil.GetAccountInfo.Types.Request.LAST_LOGIN;
                return this;
            }

            public override GetAccountInfo.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new GetAccountInfo.Builder(this.result);
                }
                return new GetAccountInfo.Builder().MergeFrom(this.result);
            }

            public override GetAccountInfo.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override GetAccountInfo.Builder MergeFrom(IMessageLite other)
            {
                if (other is GetAccountInfo)
                {
                    return this.MergeFrom((GetAccountInfo) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override GetAccountInfo.Builder MergeFrom(GetAccountInfo other)
            {
                if (other != GetAccountInfo.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasRequest)
                    {
                        this.Request = other.Request;
                    }
                }
                return this;
            }

            public override GetAccountInfo.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    object obj2;
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(GetAccountInfo._getAccountInfoFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = GetAccountInfo._getAccountInfoFieldTags[index];
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
                    if (input.ReadEnum<PegasusUtil.GetAccountInfo.Types.Request>(ref this.result.request_, out obj2))
                    {
                        this.result.hasRequest = true;
                    }
                    else if (!(obj2 is int))
                    {
                        continue;
                    }
                }
                return this;
            }

            private GetAccountInfo PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    GetAccountInfo result = this.result;
                    this.result = new GetAccountInfo();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public GetAccountInfo.Builder SetRequest(PegasusUtil.GetAccountInfo.Types.Request value)
            {
                this.PrepareBuilder();
                this.result.hasRequest = true;
                this.result.request_ = value;
                return this;
            }

            public override GetAccountInfo DefaultInstanceForType
            {
                get
                {
                    return GetAccountInfo.DefaultInstance;
                }
            }

            public bool HasRequest
            {
                get
                {
                    return this.result.hasRequest;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override GetAccountInfo MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public PegasusUtil.GetAccountInfo.Types.Request Request
            {
                get
                {
                    return this.result.Request;
                }
                set
                {
                    this.SetRequest(value);
                }
            }

            protected override GetAccountInfo.Builder ThisBuilder
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
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0xc9,
                System = 0
            }

            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum Request
            {
                ARCANE_DUST_BALANCE = 0x11,
                BOOSTERS = 6,
                CAMPAIGN_INFO = 11,
                CARD_USAGE = 7,
                CARD_VALUES = 15,
                CLIENT_OPTIONS = 14,
                COLLECTION = 3,
                DECK_LIMIT = 10,
                DECK_LIST = 2,
                DISCONNECTED = 0x10,
                FEATURES = 0x12,
                GAMES_PLAYED = 9,
                GOLD_BALANCE = 20,
                HERO_XP = 0x15,
                LAST_LOGIN = 1,
                MEDAL_HISTORY = 5,
                MEDAL_INFO = 4,
                MOTD = 13,
                NOTICES = 12,
                PLAYER_RECORD = 8,
                REWARD_PROGRESS = 0x13
            }
        }
    }
}

