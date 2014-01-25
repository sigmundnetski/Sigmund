namespace bnet.protocol.authentication
{
    using bnet.protocol;
    using Google.ProtocolBuffers;
    using Google.ProtocolBuffers.Collections;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class LogonResult : GeneratedMessageLite<LogonResult, Builder>
    {
        private static readonly string[] _logonResultFieldNames = new string[] { "account", "available_region", "connected_region", "email", "error_code", "game_account" };
        private static readonly uint[] _logonResultFieldTags = new uint[] { 0x12, 40, 0x30, 0x22, 8, 0x1a };
        private EntityId account_;
        public const int AccountFieldNumber = 2;
        private PopsicleList<uint> availableRegion_ = new PopsicleList<uint>();
        public const int AvailableRegionFieldNumber = 5;
        private uint connectedRegion_;
        public const int ConnectedRegionFieldNumber = 6;
        private static readonly LogonResult defaultInstance = new LogonResult().MakeReadOnly();
        private string email_ = string.Empty;
        public const int EmailFieldNumber = 4;
        private uint errorCode_;
        public const int ErrorCodeFieldNumber = 1;
        private PopsicleList<EntityId> gameAccount_ = new PopsicleList<EntityId>();
        public const int GameAccountFieldNumber = 3;
        private bool hasAccount;
        private bool hasConnectedRegion;
        private bool hasEmail;
        private bool hasErrorCode;
        private int memoizedSerializedSize = -1;

        static LogonResult()
        {
            object.ReferenceEquals(AuthenticationService.Descriptor, null);
        }

        private LogonResult()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(LogonResult prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            LogonResult result = obj as LogonResult;
            if (result == null)
            {
                return false;
            }
            if ((this.hasErrorCode != result.hasErrorCode) || (this.hasErrorCode && !this.errorCode_.Equals(result.errorCode_)))
            {
                return false;
            }
            if ((this.hasAccount != result.hasAccount) || (this.hasAccount && !this.account_.Equals(result.account_)))
            {
                return false;
            }
            if (this.gameAccount_.Count != result.gameAccount_.Count)
            {
                return false;
            }
            for (int i = 0; i < this.gameAccount_.Count; i++)
            {
                if (!this.gameAccount_[i].Equals(result.gameAccount_[i]))
                {
                    return false;
                }
            }
            if ((this.hasEmail != result.hasEmail) || (this.hasEmail && !this.email_.Equals(result.email_)))
            {
                return false;
            }
            if (this.availableRegion_.Count != result.availableRegion_.Count)
            {
                return false;
            }
            for (int j = 0; j < this.availableRegion_.Count; j++)
            {
                uint num3 = this.availableRegion_[j];
                if (!num3.Equals(result.availableRegion_[j]))
                {
                    return false;
                }
            }
            return ((this.hasConnectedRegion == result.hasConnectedRegion) && (!this.hasConnectedRegion || this.connectedRegion_.Equals(result.connectedRegion_)));
        }

        [CLSCompliant(false)]
        public uint GetAvailableRegion(int index)
        {
            return this.availableRegion_[index];
        }

        public EntityId GetGameAccount(int index)
        {
            return this.gameAccount_[index];
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasErrorCode)
            {
                hashCode ^= this.errorCode_.GetHashCode();
            }
            if (this.hasAccount)
            {
                hashCode ^= this.account_.GetHashCode();
            }
            IEnumerator<EntityId> enumerator = this.gameAccount_.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    EntityId current = enumerator.Current;
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
            if (this.hasEmail)
            {
                hashCode ^= this.email_.GetHashCode();
            }
            IEnumerator<uint> enumerator2 = this.availableRegion_.GetEnumerator();
            try
            {
                while (enumerator2.MoveNext())
                {
                    uint num2 = enumerator2.Current;
                    hashCode ^= num2.GetHashCode();
                }
            }
            finally
            {
                if (enumerator2 == null)
                {
                }
                enumerator2.Dispose();
            }
            if (this.hasConnectedRegion)
            {
                hashCode ^= this.connectedRegion_.GetHashCode();
            }
            return hashCode;
        }

        private LogonResult MakeReadOnly()
        {
            this.gameAccount_.MakeReadOnly();
            this.availableRegion_.MakeReadOnly();
            return this;
        }

        public static LogonResult ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static LogonResult ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static LogonResult ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static LogonResult ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static LogonResult ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static LogonResult ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static LogonResult ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static LogonResult ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static LogonResult ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static LogonResult ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<LogonResult, Builder>.PrintField("error_code", this.hasErrorCode, this.errorCode_, writer);
            GeneratedMessageLite<LogonResult, Builder>.PrintField("account", this.hasAccount, this.account_, writer);
            GeneratedMessageLite<LogonResult, Builder>.PrintField<EntityId>("game_account", this.gameAccount_, writer);
            GeneratedMessageLite<LogonResult, Builder>.PrintField("email", this.hasEmail, this.email_, writer);
            GeneratedMessageLite<LogonResult, Builder>.PrintField<uint>("available_region", this.availableRegion_, writer);
            GeneratedMessageLite<LogonResult, Builder>.PrintField("connected_region", this.hasConnectedRegion, this.connectedRegion_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _logonResultFieldNames;
            if (this.hasErrorCode)
            {
                output.WriteUInt32(1, strArray[4], this.ErrorCode);
            }
            if (this.hasAccount)
            {
                output.WriteMessage(2, strArray[0], this.Account);
            }
            if (this.gameAccount_.Count > 0)
            {
                output.WriteMessageArray<EntityId>(3, strArray[5], this.gameAccount_);
            }
            if (this.hasEmail)
            {
                output.WriteString(4, strArray[3], this.Email);
            }
            if (this.availableRegion_.Count > 0)
            {
                output.WriteUInt32Array(5, strArray[1], this.availableRegion_);
            }
            if (this.hasConnectedRegion)
            {
                output.WriteUInt32(6, strArray[2], this.ConnectedRegion);
            }
        }

        public EntityId Account
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.account_ != null)
                {
                    goto Label_0012;
                }
                return EntityId.DefaultInstance;
            }
        }

        public int AvailableRegionCount
        {
            get
            {
                return this.availableRegion_.Count;
            }
        }

        [CLSCompliant(false)]
        public IList<uint> AvailableRegionList
        {
            get
            {
                return Lists.AsReadOnly<uint>(this.availableRegion_);
            }
        }

        [CLSCompliant(false)]
        public uint ConnectedRegion
        {
            get
            {
                return this.connectedRegion_;
            }
        }

        public static LogonResult DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override LogonResult DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public string Email
        {
            get
            {
                return this.email_;
            }
        }

        [CLSCompliant(false)]
        public uint ErrorCode
        {
            get
            {
                return this.errorCode_;
            }
        }

        public int GameAccountCount
        {
            get
            {
                return this.gameAccount_.Count;
            }
        }

        public IList<EntityId> GameAccountList
        {
            get
            {
                return this.gameAccount_;
            }
        }

        public bool HasAccount
        {
            get
            {
                return this.hasAccount;
            }
        }

        public bool HasConnectedRegion
        {
            get
            {
                return this.hasConnectedRegion;
            }
        }

        public bool HasEmail
        {
            get
            {
                return this.hasEmail;
            }
        }

        public bool HasErrorCode
        {
            get
            {
                return this.hasErrorCode;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasErrorCode)
                {
                    return false;
                }
                if (this.HasAccount && !this.Account.IsInitialized)
                {
                    return false;
                }
                IEnumerator<EntityId> enumerator = this.GameAccountList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        EntityId current = enumerator.Current;
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
                    if (this.hasErrorCode)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(1, this.ErrorCode);
                    }
                    if (this.hasAccount)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(2, this.Account);
                    }
                    IEnumerator<EntityId> enumerator = this.GameAccountList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            EntityId current = enumerator.Current;
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
                    if (this.hasEmail)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(4, this.Email);
                    }
                    int num2 = 0;
                    IEnumerator<uint> enumerator2 = this.AvailableRegionList.GetEnumerator();
                    try
                    {
                        while (enumerator2.MoveNext())
                        {
                            uint num3 = enumerator2.Current;
                            num2 += CodedOutputStream.ComputeUInt32SizeNoTag(num3);
                        }
                    }
                    finally
                    {
                        if (enumerator2 == null)
                        {
                        }
                        enumerator2.Dispose();
                    }
                    memoizedSerializedSize += num2;
                    memoizedSerializedSize += 1 * this.availableRegion_.Count;
                    if (this.hasConnectedRegion)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeUInt32Size(6, this.ConnectedRegion);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override LogonResult ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<LogonResult, LogonResult.Builder>
        {
            private LogonResult result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = LogonResult.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(LogonResult cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            [CLSCompliant(false)]
            public LogonResult.Builder AddAvailableRegion(uint value)
            {
                this.PrepareBuilder();
                this.result.availableRegion_.Add(value);
                return this;
            }

            public LogonResult.Builder AddGameAccount(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.gameAccount_.Add(value);
                return this;
            }

            public LogonResult.Builder AddGameAccount(EntityId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.gameAccount_.Add(builderForValue.Build());
                return this;
            }

            [CLSCompliant(false)]
            public LogonResult.Builder AddRangeAvailableRegion(IEnumerable<uint> values)
            {
                this.PrepareBuilder();
                this.result.availableRegion_.Add(values);
                return this;
            }

            public LogonResult.Builder AddRangeGameAccount(IEnumerable<EntityId> values)
            {
                this.PrepareBuilder();
                this.result.gameAccount_.Add(values);
                return this;
            }

            public override LogonResult BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override LogonResult.Builder Clear()
            {
                this.result = LogonResult.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public LogonResult.Builder ClearAccount()
            {
                this.PrepareBuilder();
                this.result.hasAccount = false;
                this.result.account_ = null;
                return this;
            }

            public LogonResult.Builder ClearAvailableRegion()
            {
                this.PrepareBuilder();
                this.result.availableRegion_.Clear();
                return this;
            }

            public LogonResult.Builder ClearConnectedRegion()
            {
                this.PrepareBuilder();
                this.result.hasConnectedRegion = false;
                this.result.connectedRegion_ = 0;
                return this;
            }

            public LogonResult.Builder ClearEmail()
            {
                this.PrepareBuilder();
                this.result.hasEmail = false;
                this.result.email_ = string.Empty;
                return this;
            }

            public LogonResult.Builder ClearErrorCode()
            {
                this.PrepareBuilder();
                this.result.hasErrorCode = false;
                this.result.errorCode_ = 0;
                return this;
            }

            public LogonResult.Builder ClearGameAccount()
            {
                this.PrepareBuilder();
                this.result.gameAccount_.Clear();
                return this;
            }

            public override LogonResult.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new LogonResult.Builder(this.result);
                }
                return new LogonResult.Builder().MergeFrom(this.result);
            }

            [CLSCompliant(false)]
            public uint GetAvailableRegion(int index)
            {
                return this.result.GetAvailableRegion(index);
            }

            public EntityId GetGameAccount(int index)
            {
                return this.result.GetGameAccount(index);
            }

            public LogonResult.Builder MergeAccount(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasAccount && (this.result.account_ != EntityId.DefaultInstance))
                {
                    this.result.account_ = EntityId.CreateBuilder(this.result.account_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.account_ = value;
                }
                this.result.hasAccount = true;
                return this;
            }

            public override LogonResult.Builder MergeFrom(LogonResult other)
            {
                if (other != LogonResult.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasErrorCode)
                    {
                        this.ErrorCode = other.ErrorCode;
                    }
                    if (other.HasAccount)
                    {
                        this.MergeAccount(other.Account);
                    }
                    if (other.gameAccount_.Count != 0)
                    {
                        this.result.gameAccount_.Add(other.gameAccount_);
                    }
                    if (other.HasEmail)
                    {
                        this.Email = other.Email;
                    }
                    if (other.availableRegion_.Count != 0)
                    {
                        this.result.availableRegion_.Add(other.availableRegion_);
                    }
                    if (other.HasConnectedRegion)
                    {
                        this.ConnectedRegion = other.ConnectedRegion;
                    }
                }
                return this;
            }

            public override LogonResult.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override LogonResult.Builder MergeFrom(IMessageLite other)
            {
                if (other is LogonResult)
                {
                    return this.MergeFrom((LogonResult) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override LogonResult.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    EntityId.Builder builder;
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(LogonResult._logonResultFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = LogonResult._logonResultFieldTags[index];
                        }
                        else
                        {
                            this.ParseUnknownField(input, extensionRegistry, num, str);
                            continue;
                        }
                    }
                    switch (num)
                    {
                        case 40:
                        case 0x2a:
                        {
                            input.ReadUInt32Array(num, str, this.result.availableRegion_);
                            continue;
                        }
                        case 0:
                            throw InvalidProtocolBufferException.InvalidTag();

                        case 8:
                            goto Label_00C2;

                        case 0x12:
                            goto Label_00E3;

                        case 0x1a:
                            goto Label_011F;

                        case 0x22:
                            goto Label_013D;

                        case 0x30:
                            goto Label_0176;

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
                Label_00C2:
                    this.result.hasErrorCode = input.ReadUInt32(ref this.result.errorCode_);
                    continue;
                Label_00E3:
                    builder = EntityId.CreateBuilder();
                    if (this.result.hasAccount)
                    {
                        builder.MergeFrom(this.Account);
                    }
                    input.ReadMessage(builder, extensionRegistry);
                    this.Account = builder.BuildPartial();
                    continue;
                Label_011F:
                    input.ReadMessageArray<EntityId>(num, str, this.result.gameAccount_, EntityId.DefaultInstance, extensionRegistry);
                    continue;
                Label_013D:
                    this.result.hasEmail = input.ReadString(ref this.result.email_);
                    continue;
                Label_0176:
                    this.result.hasConnectedRegion = input.ReadUInt32(ref this.result.connectedRegion_);
                }
                return this;
            }

            private LogonResult PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    LogonResult other = this.result;
                    this.result = new LogonResult();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(other);
                }
                return this.result;
            }

            public LogonResult.Builder SetAccount(EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasAccount = true;
                this.result.account_ = value;
                return this;
            }

            public LogonResult.Builder SetAccount(EntityId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasAccount = true;
                this.result.account_ = builderForValue.Build();
                return this;
            }

            [CLSCompliant(false)]
            public LogonResult.Builder SetAvailableRegion(int index, uint value)
            {
                this.PrepareBuilder();
                this.result.availableRegion_[index] = value;
                return this;
            }

            [CLSCompliant(false)]
            public LogonResult.Builder SetConnectedRegion(uint value)
            {
                this.PrepareBuilder();
                this.result.hasConnectedRegion = true;
                this.result.connectedRegion_ = value;
                return this;
            }

            public LogonResult.Builder SetEmail(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasEmail = true;
                this.result.email_ = value;
                return this;
            }

            [CLSCompliant(false)]
            public LogonResult.Builder SetErrorCode(uint value)
            {
                this.PrepareBuilder();
                this.result.hasErrorCode = true;
                this.result.errorCode_ = value;
                return this;
            }

            public LogonResult.Builder SetGameAccount(int index, EntityId value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.gameAccount_[index] = value;
                return this;
            }

            public LogonResult.Builder SetGameAccount(int index, EntityId.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.gameAccount_[index] = builderForValue.Build();
                return this;
            }

            public EntityId Account
            {
                get
                {
                    return this.result.Account;
                }
                set
                {
                    this.SetAccount(value);
                }
            }

            public int AvailableRegionCount
            {
                get
                {
                    return this.result.AvailableRegionCount;
                }
            }

            [CLSCompliant(false)]
            public IPopsicleList<uint> AvailableRegionList
            {
                get
                {
                    return this.PrepareBuilder().availableRegion_;
                }
            }

            [CLSCompliant(false)]
            public uint ConnectedRegion
            {
                get
                {
                    return this.result.ConnectedRegion;
                }
                set
                {
                    this.SetConnectedRegion(value);
                }
            }

            public override LogonResult DefaultInstanceForType
            {
                get
                {
                    return LogonResult.DefaultInstance;
                }
            }

            public string Email
            {
                get
                {
                    return this.result.Email;
                }
                set
                {
                    this.SetEmail(value);
                }
            }

            [CLSCompliant(false)]
            public uint ErrorCode
            {
                get
                {
                    return this.result.ErrorCode;
                }
                set
                {
                    this.SetErrorCode(value);
                }
            }

            public int GameAccountCount
            {
                get
                {
                    return this.result.GameAccountCount;
                }
            }

            public IPopsicleList<EntityId> GameAccountList
            {
                get
                {
                    return this.PrepareBuilder().gameAccount_;
                }
            }

            public bool HasAccount
            {
                get
                {
                    return this.result.hasAccount;
                }
            }

            public bool HasConnectedRegion
            {
                get
                {
                    return this.result.hasConnectedRegion;
                }
            }

            public bool HasEmail
            {
                get
                {
                    return this.result.hasEmail;
                }
            }

            public bool HasErrorCode
            {
                get
                {
                    return this.result.hasErrorCode;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override LogonResult MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override LogonResult.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

