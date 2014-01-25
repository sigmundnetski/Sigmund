namespace bnet.protocol.authentication
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
    public sealed class GenerateSSOTokenResponse : GeneratedMessageLite<GenerateSSOTokenResponse, Builder>
    {
        private static readonly string[] _generateSSOTokenResponseFieldNames = new string[] { "sso_id", "sso_secret" };
        private static readonly uint[] _generateSSOTokenResponseFieldTags = new uint[] { 10, 0x12 };
        private static readonly GenerateSSOTokenResponse defaultInstance = new GenerateSSOTokenResponse().MakeReadOnly();
        private bool hasSsoId;
        private bool hasSsoSecret;
        private int memoizedSerializedSize = -1;
        private ByteString ssoId_ = ByteString.Empty;
        public const int SsoIdFieldNumber = 1;
        private ByteString ssoSecret_ = ByteString.Empty;
        public const int SsoSecretFieldNumber = 2;

        static GenerateSSOTokenResponse()
        {
            object.ReferenceEquals(AuthenticationService.Descriptor, null);
        }

        private GenerateSSOTokenResponse()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(GenerateSSOTokenResponse prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            GenerateSSOTokenResponse response = obj as GenerateSSOTokenResponse;
            if (response == null)
            {
                return false;
            }
            if ((this.hasSsoId != response.hasSsoId) || (this.hasSsoId && !this.ssoId_.Equals(response.ssoId_)))
            {
                return false;
            }
            return ((this.hasSsoSecret == response.hasSsoSecret) && (!this.hasSsoSecret || this.ssoSecret_.Equals(response.ssoSecret_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasSsoId)
            {
                hashCode ^= this.ssoId_.GetHashCode();
            }
            if (this.hasSsoSecret)
            {
                hashCode ^= this.ssoSecret_.GetHashCode();
            }
            return hashCode;
        }

        private GenerateSSOTokenResponse MakeReadOnly()
        {
            return this;
        }

        public static GenerateSSOTokenResponse ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static GenerateSSOTokenResponse ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static GenerateSSOTokenResponse ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GenerateSSOTokenResponse ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static GenerateSSOTokenResponse ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GenerateSSOTokenResponse ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static GenerateSSOTokenResponse ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static GenerateSSOTokenResponse ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GenerateSSOTokenResponse ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static GenerateSSOTokenResponse ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<GenerateSSOTokenResponse, Builder>.PrintField("sso_id", this.hasSsoId, this.ssoId_, writer);
            GeneratedMessageLite<GenerateSSOTokenResponse, Builder>.PrintField("sso_secret", this.hasSsoSecret, this.ssoSecret_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _generateSSOTokenResponseFieldNames;
            if (this.hasSsoId)
            {
                output.WriteBytes(1, strArray[0], this.SsoId);
            }
            if (this.hasSsoSecret)
            {
                output.WriteBytes(2, strArray[1], this.SsoSecret);
            }
        }

        public static GenerateSSOTokenResponse DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override GenerateSSOTokenResponse DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasSsoId
        {
            get
            {
                return this.hasSsoId;
            }
        }

        public bool HasSsoSecret
        {
            get
            {
                return this.hasSsoSecret;
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
                    if (this.hasSsoId)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBytesSize(1, this.SsoId);
                    }
                    if (this.hasSsoSecret)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeBytesSize(2, this.SsoSecret);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        public ByteString SsoId
        {
            get
            {
                return this.ssoId_;
            }
        }

        public ByteString SsoSecret
        {
            get
            {
                return this.ssoSecret_;
            }
        }

        protected override GenerateSSOTokenResponse ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<GenerateSSOTokenResponse, GenerateSSOTokenResponse.Builder>
        {
            private GenerateSSOTokenResponse result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = GenerateSSOTokenResponse.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(GenerateSSOTokenResponse cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override GenerateSSOTokenResponse BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override GenerateSSOTokenResponse.Builder Clear()
            {
                this.result = GenerateSSOTokenResponse.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public GenerateSSOTokenResponse.Builder ClearSsoId()
            {
                this.PrepareBuilder();
                this.result.hasSsoId = false;
                this.result.ssoId_ = ByteString.Empty;
                return this;
            }

            public GenerateSSOTokenResponse.Builder ClearSsoSecret()
            {
                this.PrepareBuilder();
                this.result.hasSsoSecret = false;
                this.result.ssoSecret_ = ByteString.Empty;
                return this;
            }

            public override GenerateSSOTokenResponse.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new GenerateSSOTokenResponse.Builder(this.result);
                }
                return new GenerateSSOTokenResponse.Builder().MergeFrom(this.result);
            }

            public override GenerateSSOTokenResponse.Builder MergeFrom(GenerateSSOTokenResponse other)
            {
                if (other != GenerateSSOTokenResponse.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasSsoId)
                    {
                        this.SsoId = other.SsoId;
                    }
                    if (other.HasSsoSecret)
                    {
                        this.SsoSecret = other.SsoSecret;
                    }
                }
                return this;
            }

            public override GenerateSSOTokenResponse.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override GenerateSSOTokenResponse.Builder MergeFrom(IMessageLite other)
            {
                if (other is GenerateSSOTokenResponse)
                {
                    return this.MergeFrom((GenerateSSOTokenResponse) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override GenerateSSOTokenResponse.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(GenerateSSOTokenResponse._generateSSOTokenResponseFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = GenerateSSOTokenResponse._generateSSOTokenResponseFieldTags[index];
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
                            this.result.hasSsoId = input.ReadBytes(ref this.result.ssoId_);
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
                    this.result.hasSsoSecret = input.ReadBytes(ref this.result.ssoSecret_);
                }
                return this;
            }

            private GenerateSSOTokenResponse PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    GenerateSSOTokenResponse result = this.result;
                    this.result = new GenerateSSOTokenResponse();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public GenerateSSOTokenResponse.Builder SetSsoId(ByteString value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasSsoId = true;
                this.result.ssoId_ = value;
                return this;
            }

            public GenerateSSOTokenResponse.Builder SetSsoSecret(ByteString value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasSsoSecret = true;
                this.result.ssoSecret_ = value;
                return this;
            }

            public override GenerateSSOTokenResponse DefaultInstanceForType
            {
                get
                {
                    return GenerateSSOTokenResponse.DefaultInstance;
                }
            }

            public bool HasSsoId
            {
                get
                {
                    return this.result.hasSsoId;
                }
            }

            public bool HasSsoSecret
            {
                get
                {
                    return this.result.hasSsoSecret;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override GenerateSSOTokenResponse MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public ByteString SsoId
            {
                get
                {
                    return this.result.SsoId;
                }
                set
                {
                    this.SetSsoId(value);
                }
            }

            public ByteString SsoSecret
            {
                get
                {
                    return this.result.SsoSecret;
                }
                set
                {
                    this.SetSsoSecret(value);
                }
            }

            protected override GenerateSSOTokenResponse.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

