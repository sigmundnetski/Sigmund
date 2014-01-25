namespace bnet.protocol.authentication
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class VersionInfoNotification : GeneratedMessageLite<VersionInfoNotification, Builder>
    {
        private static readonly string[] _versionInfoNotificationFieldNames = new string[] { "version_info" };
        private static readonly uint[] _versionInfoNotificationFieldTags = new uint[] { 10 };
        private static readonly VersionInfoNotification defaultInstance = new VersionInfoNotification().MakeReadOnly();
        private bool hasVersionInfo;
        private int memoizedSerializedSize = -1;
        private bnet.protocol.authentication.VersionInfo versionInfo_;
        public const int VersionInfoFieldNumber = 1;

        static VersionInfoNotification()
        {
            object.ReferenceEquals(AuthenticationService.Descriptor, null);
        }

        private VersionInfoNotification()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(VersionInfoNotification prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            VersionInfoNotification notification = obj as VersionInfoNotification;
            if (notification == null)
            {
                return false;
            }
            return ((this.hasVersionInfo == notification.hasVersionInfo) && (!this.hasVersionInfo || this.versionInfo_.Equals(notification.versionInfo_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasVersionInfo)
            {
                hashCode ^= this.versionInfo_.GetHashCode();
            }
            return hashCode;
        }

        private VersionInfoNotification MakeReadOnly()
        {
            return this;
        }

        public static VersionInfoNotification ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static VersionInfoNotification ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static VersionInfoNotification ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static VersionInfoNotification ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static VersionInfoNotification ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static VersionInfoNotification ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static VersionInfoNotification ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static VersionInfoNotification ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static VersionInfoNotification ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static VersionInfoNotification ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<VersionInfoNotification, Builder>.PrintField("version_info", this.hasVersionInfo, this.versionInfo_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _versionInfoNotificationFieldNames;
            if (this.hasVersionInfo)
            {
                output.WriteMessage(1, strArray[0], this.VersionInfo);
            }
        }

        public static VersionInfoNotification DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override VersionInfoNotification DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasVersionInfo
        {
            get
            {
                return this.hasVersionInfo;
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
                    if (this.hasVersionInfo)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, this.VersionInfo);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override VersionInfoNotification ThisMessage
        {
            get
            {
                return this;
            }
        }

        public bnet.protocol.authentication.VersionInfo VersionInfo
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.versionInfo_ != null)
                {
                    goto Label_0012;
                }
                return bnet.protocol.authentication.VersionInfo.DefaultInstance;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<VersionInfoNotification, VersionInfoNotification.Builder>
        {
            private VersionInfoNotification result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = VersionInfoNotification.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(VersionInfoNotification cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override VersionInfoNotification BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override VersionInfoNotification.Builder Clear()
            {
                this.result = VersionInfoNotification.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public VersionInfoNotification.Builder ClearVersionInfo()
            {
                this.PrepareBuilder();
                this.result.hasVersionInfo = false;
                this.result.versionInfo_ = null;
                return this;
            }

            public override VersionInfoNotification.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new VersionInfoNotification.Builder(this.result);
                }
                return new VersionInfoNotification.Builder().MergeFrom(this.result);
            }

            public override VersionInfoNotification.Builder MergeFrom(VersionInfoNotification other)
            {
                if (other != VersionInfoNotification.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasVersionInfo)
                    {
                        this.MergeVersionInfo(other.VersionInfo);
                    }
                }
                return this;
            }

            public override VersionInfoNotification.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override VersionInfoNotification.Builder MergeFrom(IMessageLite other)
            {
                if (other is VersionInfoNotification)
                {
                    return this.MergeFrom((VersionInfoNotification) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override VersionInfoNotification.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(VersionInfoNotification._versionInfoNotificationFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = VersionInfoNotification._versionInfoNotificationFieldTags[index];
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
                            bnet.protocol.authentication.VersionInfo.Builder builder = bnet.protocol.authentication.VersionInfo.CreateBuilder();
                            if (this.result.hasVersionInfo)
                            {
                                builder.MergeFrom(this.VersionInfo);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.VersionInfo = builder.BuildPartial();
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

            public VersionInfoNotification.Builder MergeVersionInfo(bnet.protocol.authentication.VersionInfo value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasVersionInfo && (this.result.versionInfo_ != bnet.protocol.authentication.VersionInfo.DefaultInstance))
                {
                    this.result.versionInfo_ = bnet.protocol.authentication.VersionInfo.CreateBuilder(this.result.versionInfo_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.versionInfo_ = value;
                }
                this.result.hasVersionInfo = true;
                return this;
            }

            private VersionInfoNotification PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    VersionInfoNotification result = this.result;
                    this.result = new VersionInfoNotification();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public VersionInfoNotification.Builder SetVersionInfo(bnet.protocol.authentication.VersionInfo value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasVersionInfo = true;
                this.result.versionInfo_ = value;
                return this;
            }

            public VersionInfoNotification.Builder SetVersionInfo(bnet.protocol.authentication.VersionInfo.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasVersionInfo = true;
                this.result.versionInfo_ = builderForValue.Build();
                return this;
            }

            public override VersionInfoNotification DefaultInstanceForType
            {
                get
                {
                    return VersionInfoNotification.DefaultInstance;
                }
            }

            public bool HasVersionInfo
            {
                get
                {
                    return this.result.hasVersionInfo;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override VersionInfoNotification MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override VersionInfoNotification.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }

            public bnet.protocol.authentication.VersionInfo VersionInfo
            {
                get
                {
                    return this.result.VersionInfo;
                }
                set
                {
                    this.SetVersionInfo(value);
                }
            }
        }
    }
}

