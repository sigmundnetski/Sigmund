namespace bnet.protocol.invitation
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
    public sealed class SendInvitationResponse : GeneratedMessageLite<SendInvitationResponse, Builder>
    {
        private static readonly string[] _sendInvitationResponseFieldNames = new string[] { "invitation" };
        private static readonly uint[] _sendInvitationResponseFieldTags = new uint[] { 0x12 };
        private static readonly SendInvitationResponse defaultInstance = new SendInvitationResponse().MakeReadOnly();
        private bool hasInvitation;
        private bnet.protocol.invitation.Invitation invitation_;
        public const int InvitationFieldNumber = 2;
        private int memoizedSerializedSize = -1;

        static SendInvitationResponse()
        {
            object.ReferenceEquals(InvitationTypes.Descriptor, null);
        }

        private SendInvitationResponse()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(SendInvitationResponse prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            SendInvitationResponse response = obj as SendInvitationResponse;
            if (response == null)
            {
                return false;
            }
            return ((this.hasInvitation == response.hasInvitation) && (!this.hasInvitation || this.invitation_.Equals(response.invitation_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasInvitation)
            {
                hashCode ^= this.invitation_.GetHashCode();
            }
            return hashCode;
        }

        private SendInvitationResponse MakeReadOnly()
        {
            return this;
        }

        public static SendInvitationResponse ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static SendInvitationResponse ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static SendInvitationResponse ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static SendInvitationResponse ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static SendInvitationResponse ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static SendInvitationResponse ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static SendInvitationResponse ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static SendInvitationResponse ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static SendInvitationResponse ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static SendInvitationResponse ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<SendInvitationResponse, Builder>.PrintField("invitation", this.hasInvitation, this.invitation_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _sendInvitationResponseFieldNames;
            if (this.hasInvitation)
            {
                output.WriteMessage(2, strArray[0], this.Invitation);
            }
        }

        public static SendInvitationResponse DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override SendInvitationResponse DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasInvitation
        {
            get
            {
                return this.hasInvitation;
            }
        }

        public bnet.protocol.invitation.Invitation Invitation
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.invitation_ != null)
                {
                    goto Label_0012;
                }
                return bnet.protocol.invitation.Invitation.DefaultInstance;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (this.HasInvitation && !this.Invitation.IsInitialized)
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
                    if (this.hasInvitation)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(2, this.Invitation);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override SendInvitationResponse ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<SendInvitationResponse, SendInvitationResponse.Builder>
        {
            private SendInvitationResponse result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = SendInvitationResponse.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(SendInvitationResponse cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override SendInvitationResponse BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override SendInvitationResponse.Builder Clear()
            {
                this.result = SendInvitationResponse.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public SendInvitationResponse.Builder ClearInvitation()
            {
                this.PrepareBuilder();
                this.result.hasInvitation = false;
                this.result.invitation_ = null;
                return this;
            }

            public override SendInvitationResponse.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new SendInvitationResponse.Builder(this.result);
                }
                return new SendInvitationResponse.Builder().MergeFrom(this.result);
            }

            public override SendInvitationResponse.Builder MergeFrom(SendInvitationResponse other)
            {
                if (other != SendInvitationResponse.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasInvitation)
                    {
                        this.MergeInvitation(other.Invitation);
                    }
                }
                return this;
            }

            public override SendInvitationResponse.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override SendInvitationResponse.Builder MergeFrom(IMessageLite other)
            {
                if (other is SendInvitationResponse)
                {
                    return this.MergeFrom((SendInvitationResponse) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override SendInvitationResponse.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(SendInvitationResponse._sendInvitationResponseFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = SendInvitationResponse._sendInvitationResponseFieldTags[index];
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

                        case 0x12:
                        {
                            bnet.protocol.invitation.Invitation.Builder builder = bnet.protocol.invitation.Invitation.CreateBuilder();
                            if (this.result.hasInvitation)
                            {
                                builder.MergeFrom(this.Invitation);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.Invitation = builder.BuildPartial();
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

            public SendInvitationResponse.Builder MergeInvitation(bnet.protocol.invitation.Invitation value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasInvitation && (this.result.invitation_ != bnet.protocol.invitation.Invitation.DefaultInstance))
                {
                    this.result.invitation_ = bnet.protocol.invitation.Invitation.CreateBuilder(this.result.invitation_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.invitation_ = value;
                }
                this.result.hasInvitation = true;
                return this;
            }

            private SendInvitationResponse PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    SendInvitationResponse result = this.result;
                    this.result = new SendInvitationResponse();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public SendInvitationResponse.Builder SetInvitation(bnet.protocol.invitation.Invitation value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasInvitation = true;
                this.result.invitation_ = value;
                return this;
            }

            public SendInvitationResponse.Builder SetInvitation(bnet.protocol.invitation.Invitation.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasInvitation = true;
                this.result.invitation_ = builderForValue.Build();
                return this;
            }

            public override SendInvitationResponse DefaultInstanceForType
            {
                get
                {
                    return SendInvitationResponse.DefaultInstance;
                }
            }

            public bool HasInvitation
            {
                get
                {
                    return this.result.hasInvitation;
                }
            }

            public bnet.protocol.invitation.Invitation Invitation
            {
                get
                {
                    return this.result.Invitation;
                }
                set
                {
                    this.SetInvitation(value);
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override SendInvitationResponse MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            protected override SendInvitationResponse.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }
    }
}

