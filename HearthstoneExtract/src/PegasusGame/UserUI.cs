namespace PegasusGame
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
    public sealed class UserUI : GeneratedMessageLite<UserUI, Builder>
    {
        private static readonly string[] _userUIFieldNames = new string[] { "emote", "mouse_info" };
        private static readonly uint[] _userUIFieldTags = new uint[] { 0x10, 10 };
        private static readonly UserUI defaultInstance = new UserUI().MakeReadOnly();
        private int emote_;
        public const int EmoteFieldNumber = 2;
        private bool hasEmote;
        private bool hasMouseInfo;
        private int memoizedSerializedSize = -1;
        private PegasusGame.MouseInfo mouseInfo_;
        public const int MouseInfoFieldNumber = 1;

        static UserUI()
        {
            object.ReferenceEquals(PegasusGamelite.Descriptor, null);
        }

        private UserUI()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(UserUI prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            UserUI rui = obj as UserUI;
            if (rui == null)
            {
                return false;
            }
            if ((this.hasMouseInfo != rui.hasMouseInfo) || (this.hasMouseInfo && !this.mouseInfo_.Equals(rui.mouseInfo_)))
            {
                return false;
            }
            return ((this.hasEmote == rui.hasEmote) && (!this.hasEmote || this.emote_.Equals(rui.emote_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasMouseInfo)
            {
                hashCode ^= this.mouseInfo_.GetHashCode();
            }
            if (this.hasEmote)
            {
                hashCode ^= this.emote_.GetHashCode();
            }
            return hashCode;
        }

        private UserUI MakeReadOnly()
        {
            return this;
        }

        public static UserUI ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static UserUI ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static UserUI ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static UserUI ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static UserUI ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static UserUI ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static UserUI ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static UserUI ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static UserUI ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static UserUI ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<UserUI, Builder>.PrintField("mouse_info", this.hasMouseInfo, this.mouseInfo_, writer);
            GeneratedMessageLite<UserUI, Builder>.PrintField("emote", this.hasEmote, this.emote_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _userUIFieldNames;
            if (this.hasMouseInfo)
            {
                output.WriteMessage(1, strArray[1], this.MouseInfo);
            }
            if (this.hasEmote)
            {
                output.WriteInt32(2, strArray[0], this.Emote);
            }
        }

        public static UserUI DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override UserUI DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public int Emote
        {
            get
            {
                return this.emote_;
            }
        }

        public bool HasEmote
        {
            get
            {
                return this.hasEmote;
            }
        }

        public bool HasMouseInfo
        {
            get
            {
                return this.hasMouseInfo;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (this.HasMouseInfo && !this.MouseInfo.IsInitialized)
                {
                    return false;
                }
                return true;
            }
        }

        public PegasusGame.MouseInfo MouseInfo
        {
            get
            {
                // This item is obfuscated and can not be translated.
                if (this.mouseInfo_ != null)
                {
                    goto Label_0012;
                }
                return PegasusGame.MouseInfo.DefaultInstance;
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
                    if (this.hasMouseInfo)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeMessageSize(1, this.MouseInfo);
                    }
                    if (this.hasEmote)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeInt32Size(2, this.Emote);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override UserUI ThisMessage
        {
            get
            {
                return this;
            }
        }

        [DebuggerNonUserCode, CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
        public sealed class Builder : GeneratedBuilderLite<UserUI, UserUI.Builder>
        {
            private UserUI result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = UserUI.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(UserUI cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override UserUI BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override UserUI.Builder Clear()
            {
                this.result = UserUI.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public UserUI.Builder ClearEmote()
            {
                this.PrepareBuilder();
                this.result.hasEmote = false;
                this.result.emote_ = 0;
                return this;
            }

            public UserUI.Builder ClearMouseInfo()
            {
                this.PrepareBuilder();
                this.result.hasMouseInfo = false;
                this.result.mouseInfo_ = null;
                return this;
            }

            public override UserUI.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new UserUI.Builder(this.result);
                }
                return new UserUI.Builder().MergeFrom(this.result);
            }

            public override UserUI.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override UserUI.Builder MergeFrom(IMessageLite other)
            {
                if (other is UserUI)
                {
                    return this.MergeFrom((UserUI) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override UserUI.Builder MergeFrom(UserUI other)
            {
                if (other != UserUI.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasMouseInfo)
                    {
                        this.MergeMouseInfo(other.MouseInfo);
                    }
                    if (other.HasEmote)
                    {
                        this.Emote = other.Emote;
                    }
                }
                return this;
            }

            public override UserUI.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(UserUI._userUIFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = UserUI._userUIFieldTags[index];
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
                            PegasusGame.MouseInfo.Builder builder = PegasusGame.MouseInfo.CreateBuilder();
                            if (this.result.hasMouseInfo)
                            {
                                builder.MergeFrom(this.MouseInfo);
                            }
                            input.ReadMessage(builder, extensionRegistry);
                            this.MouseInfo = builder.BuildPartial();
                            continue;
                        }
                        case 0x10:
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
                    this.result.hasEmote = input.ReadInt32(ref this.result.emote_);
                }
                return this;
            }

            public UserUI.Builder MergeMouseInfo(PegasusGame.MouseInfo value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                if (this.result.hasMouseInfo && (this.result.mouseInfo_ != PegasusGame.MouseInfo.DefaultInstance))
                {
                    this.result.mouseInfo_ = PegasusGame.MouseInfo.CreateBuilder(this.result.mouseInfo_).MergeFrom(value).BuildPartial();
                }
                else
                {
                    this.result.mouseInfo_ = value;
                }
                this.result.hasMouseInfo = true;
                return this;
            }

            private UserUI PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    UserUI result = this.result;
                    this.result = new UserUI();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public UserUI.Builder SetEmote(int value)
            {
                this.PrepareBuilder();
                this.result.hasEmote = true;
                this.result.emote_ = value;
                return this;
            }

            public UserUI.Builder SetMouseInfo(PegasusGame.MouseInfo value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasMouseInfo = true;
                this.result.mouseInfo_ = value;
                return this;
            }

            public UserUI.Builder SetMouseInfo(PegasusGame.MouseInfo.Builder builderForValue)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
                this.PrepareBuilder();
                this.result.hasMouseInfo = true;
                this.result.mouseInfo_ = builderForValue.Build();
                return this;
            }

            public override UserUI DefaultInstanceForType
            {
                get
                {
                    return UserUI.DefaultInstance;
                }
            }

            public int Emote
            {
                get
                {
                    return this.result.Emote;
                }
                set
                {
                    this.SetEmote(value);
                }
            }

            public bool HasEmote
            {
                get
                {
                    return this.result.hasEmote;
                }
            }

            public bool HasMouseInfo
            {
                get
                {
                    return this.result.hasMouseInfo;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override UserUI MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public PegasusGame.MouseInfo MouseInfo
            {
                get
                {
                    return this.result.MouseInfo;
                }
                set
                {
                    this.SetMouseInfo(value);
                }
            }

            protected override UserUI.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated, DebuggerNonUserCode]
        public static class Types
        {
            [GeneratedCode("ProtoGen", "2.4.1.473"), CompilerGenerated]
            public enum PacketID
            {
                ID = 15
            }
        }
    }
}

