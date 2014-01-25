namespace bnet.protocol.connection
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
    public sealed class DisconnectNotification : GeneratedMessageLite<DisconnectNotification, Builder>
    {
        private static readonly string[] _disconnectNotificationFieldNames = new string[] { "error_code", "reason" };
        private static readonly uint[] _disconnectNotificationFieldTags = new uint[] { 8, 0x12 };
        private static readonly DisconnectNotification defaultInstance = new DisconnectNotification().MakeReadOnly();
        private uint errorCode_;
        public const int ErrorCodeFieldNumber = 1;
        private bool hasErrorCode;
        private bool hasReason;
        private int memoizedSerializedSize = -1;
        private string reason_ = string.Empty;
        public const int ReasonFieldNumber = 2;

        static DisconnectNotification()
        {
            object.ReferenceEquals(Connect.Descriptor, null);
        }

        private DisconnectNotification()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(DisconnectNotification prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            DisconnectNotification notification = obj as DisconnectNotification;
            if (notification == null)
            {
                return false;
            }
            if ((this.hasErrorCode != notification.hasErrorCode) || (this.hasErrorCode && !this.errorCode_.Equals(notification.errorCode_)))
            {
                return false;
            }
            return ((this.hasReason == notification.hasReason) && (!this.hasReason || this.reason_.Equals(notification.reason_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasErrorCode)
            {
                hashCode ^= this.errorCode_.GetHashCode();
            }
            if (this.hasReason)
            {
                hashCode ^= this.reason_.GetHashCode();
            }
            return hashCode;
        }

        private DisconnectNotification MakeReadOnly()
        {
            return this;
        }

        public static DisconnectNotification ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static DisconnectNotification ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static DisconnectNotification ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DisconnectNotification ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DisconnectNotification ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DisconnectNotification ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DisconnectNotification ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static DisconnectNotification ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DisconnectNotification ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DisconnectNotification ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<DisconnectNotification, Builder>.PrintField("error_code", this.hasErrorCode, this.errorCode_, writer);
            GeneratedMessageLite<DisconnectNotification, Builder>.PrintField("reason", this.hasReason, this.reason_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _disconnectNotificationFieldNames;
            if (this.hasErrorCode)
            {
                output.WriteUInt32(1, strArray[0], this.ErrorCode);
            }
            if (this.hasReason)
            {
                output.WriteString(2, strArray[1], this.Reason);
            }
        }

        public static DisconnectNotification DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override DisconnectNotification DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
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

        public bool HasErrorCode
        {
            get
            {
                return this.hasErrorCode;
            }
        }

        public bool HasReason
        {
            get
            {
                return this.hasReason;
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
                return true;
            }
        }

        public string Reason
        {
            get
            {
                return this.reason_;
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
                    if (this.hasReason)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(2, this.Reason);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override DisconnectNotification ThisMessage
        {
            get
            {
                return this;
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<DisconnectNotification, DisconnectNotification.Builder>
        {
            private DisconnectNotification result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = DisconnectNotification.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(DisconnectNotification cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override DisconnectNotification BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override DisconnectNotification.Builder Clear()
            {
                this.result = DisconnectNotification.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public DisconnectNotification.Builder ClearErrorCode()
            {
                this.PrepareBuilder();
                this.result.hasErrorCode = false;
                this.result.errorCode_ = 0;
                return this;
            }

            public DisconnectNotification.Builder ClearReason()
            {
                this.PrepareBuilder();
                this.result.hasReason = false;
                this.result.reason_ = string.Empty;
                return this;
            }

            public override DisconnectNotification.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new DisconnectNotification.Builder(this.result);
                }
                return new DisconnectNotification.Builder().MergeFrom(this.result);
            }

            public override DisconnectNotification.Builder MergeFrom(DisconnectNotification other)
            {
                if (other != DisconnectNotification.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasErrorCode)
                    {
                        this.ErrorCode = other.ErrorCode;
                    }
                    if (other.HasReason)
                    {
                        this.Reason = other.Reason;
                    }
                }
                return this;
            }

            public override DisconnectNotification.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override DisconnectNotification.Builder MergeFrom(IMessageLite other)
            {
                if (other is DisconnectNotification)
                {
                    return this.MergeFrom((DisconnectNotification) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override DisconnectNotification.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(DisconnectNotification._disconnectNotificationFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = DisconnectNotification._disconnectNotificationFieldTags[index];
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
                            this.result.hasErrorCode = input.ReadUInt32(ref this.result.errorCode_);
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
                    this.result.hasReason = input.ReadString(ref this.result.reason_);
                }
                return this;
            }

            private DisconnectNotification PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    DisconnectNotification result = this.result;
                    this.result = new DisconnectNotification();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            [CLSCompliant(false)]
            public DisconnectNotification.Builder SetErrorCode(uint value)
            {
                this.PrepareBuilder();
                this.result.hasErrorCode = true;
                this.result.errorCode_ = value;
                return this;
            }

            public DisconnectNotification.Builder SetReason(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasReason = true;
                this.result.reason_ = value;
                return this;
            }

            public override DisconnectNotification DefaultInstanceForType
            {
                get
                {
                    return DisconnectNotification.DefaultInstance;
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

            public bool HasErrorCode
            {
                get
                {
                    return this.result.hasErrorCode;
                }
            }

            public bool HasReason
            {
                get
                {
                    return this.result.hasReason;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override DisconnectNotification MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public string Reason
            {
                get
                {
                    return this.result.Reason;
                }
                set
                {
                    this.SetReason(value);
                }
            }

            protected override DisconnectNotification.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

