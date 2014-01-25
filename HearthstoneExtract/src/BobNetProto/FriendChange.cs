namespace BobNetProto
{
    using Google.ProtocolBuffers;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode]
    public sealed class FriendChange : GeneratedMessageLite<FriendChange, Builder>
    {
        private static readonly string[] _friendChangeFieldNames = new string[] { "action", "name" };
        private static readonly uint[] _friendChangeFieldTags = new uint[] { 0x18, 10 };
        private Types.FriendAction action_ = Types.FriendAction.FRIEND_LOGON;
        public const int ActionFieldNumber = 3;
        private static readonly FriendChange defaultInstance = new FriendChange().MakeReadOnly();
        private bool hasAction;
        private bool hasName;
        private int memoizedSerializedSize = -1;
        private string name_ = string.Empty;
        public const int NameFieldNumber = 1;

        static FriendChange()
        {
            object.ReferenceEquals(BobNetlite.Descriptor, null);
        }

        private FriendChange()
        {
        }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public static Builder CreateBuilder(FriendChange prototype)
        {
            return new Builder(prototype);
        }

        public override Builder CreateBuilderForType()
        {
            return new Builder();
        }

        public override bool Equals(object obj)
        {
            FriendChange change = obj as FriendChange;
            if (change == null)
            {
                return false;
            }
            if ((this.hasName != change.hasName) || (this.hasName && !this.name_.Equals(change.name_)))
            {
                return false;
            }
            return ((this.hasAction == change.hasAction) && (!this.hasAction || this.action_.Equals(change.action_)));
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetType().GetHashCode();
            if (this.hasName)
            {
                hashCode ^= this.name_.GetHashCode();
            }
            if (this.hasAction)
            {
                hashCode ^= this.action_.GetHashCode();
            }
            return hashCode;
        }

        private FriendChange MakeReadOnly()
        {
            return this;
        }

        public static FriendChange ParseDelimitedFrom(Stream input)
        {
            return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static FriendChange ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static FriendChange ParseFrom(byte[] data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static FriendChange ParseFrom(ByteString data)
        {
            return CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static FriendChange ParseFrom(ICodedInputStream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static FriendChange ParseFrom(Stream input)
        {
            return CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static FriendChange ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static FriendChange ParseFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static FriendChange ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static FriendChange ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
        {
            return CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public override void PrintTo(TextWriter writer)
        {
            GeneratedMessageLite<FriendChange, Builder>.PrintField("name", this.hasName, this.name_, writer);
            GeneratedMessageLite<FriendChange, Builder>.PrintField("action", this.hasAction, this.action_, writer);
        }

        public override Builder ToBuilder()
        {
            return CreateBuilder(this);
        }

        public override void WriteTo(ICodedOutputStream output)
        {
            int serializedSize = this.SerializedSize;
            string[] strArray = _friendChangeFieldNames;
            if (this.hasName)
            {
                output.WriteString(1, strArray[1], this.Name);
            }
            if (this.hasAction)
            {
                output.WriteEnum(3, strArray[0], (int) this.Action, this.Action);
            }
        }

        public Types.FriendAction Action
        {
            get
            {
                return this.action_;
            }
        }

        public static FriendChange DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }

        public override FriendChange DefaultInstanceForType
        {
            get
            {
                return DefaultInstance;
            }
        }

        public bool HasAction
        {
            get
            {
                return this.hasAction;
            }
        }

        public bool HasName
        {
            get
            {
                return this.hasName;
            }
        }

        public override bool IsInitialized
        {
            get
            {
                if (!this.hasName)
                {
                    return false;
                }
                if (!this.hasAction)
                {
                    return false;
                }
                return true;
            }
        }

        public string Name
        {
            get
            {
                return this.name_;
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
                    if (this.hasName)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeStringSize(1, this.Name);
                    }
                    if (this.hasAction)
                    {
                        memoizedSerializedSize += CodedOutputStream.ComputeEnumSize(3, (int) this.Action);
                    }
                    this.memoizedSerializedSize = memoizedSerializedSize;
                }
                return memoizedSerializedSize;
            }
        }

        protected override FriendChange ThisMessage
        {
            get
            {
                return this;
            }
        }

        [GeneratedCode("ProtoGen", "2.4.1.473"), DebuggerNonUserCode, CompilerGenerated]
        public sealed class Builder : GeneratedBuilderLite<FriendChange, FriendChange.Builder>
        {
            private FriendChange result;
            private bool resultIsReadOnly;

            public Builder()
            {
                this.result = FriendChange.DefaultInstance;
                this.resultIsReadOnly = true;
            }

            internal Builder(FriendChange cloneFrom)
            {
                this.result = cloneFrom;
                this.resultIsReadOnly = true;
            }

            public override FriendChange BuildPartial()
            {
                if (this.resultIsReadOnly)
                {
                    return this.result;
                }
                this.resultIsReadOnly = true;
                return this.result.MakeReadOnly();
            }

            public override FriendChange.Builder Clear()
            {
                this.result = FriendChange.DefaultInstance;
                this.resultIsReadOnly = true;
                return this;
            }

            public FriendChange.Builder ClearAction()
            {
                this.PrepareBuilder();
                this.result.hasAction = false;
                this.result.action_ = FriendChange.Types.FriendAction.FRIEND_LOGON;
                return this;
            }

            public FriendChange.Builder ClearName()
            {
                this.PrepareBuilder();
                this.result.hasName = false;
                this.result.name_ = string.Empty;
                return this;
            }

            public override FriendChange.Builder Clone()
            {
                if (this.resultIsReadOnly)
                {
                    return new FriendChange.Builder(this.result);
                }
                return new FriendChange.Builder().MergeFrom(this.result);
            }

            public override FriendChange.Builder MergeFrom(FriendChange other)
            {
                if (other != FriendChange.DefaultInstance)
                {
                    this.PrepareBuilder();
                    if (other.HasName)
                    {
                        this.Name = other.Name;
                    }
                    if (other.HasAction)
                    {
                        this.Action = other.Action;
                    }
                }
                return this;
            }

            public override FriendChange.Builder MergeFrom(ICodedInputStream input)
            {
                return this.MergeFrom(input, ExtensionRegistry.Empty);
            }

            public override FriendChange.Builder MergeFrom(IMessageLite other)
            {
                if (other is FriendChange)
                {
                    return this.MergeFrom((FriendChange) other);
                }
                base.MergeFrom(other);
                return this;
            }

            public override FriendChange.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
            {
                uint num;
                string str;
                this.PrepareBuilder();
                while (input.ReadTag(out num, out str))
                {
                    object obj2;
                    if ((num == 0) && (str != null))
                    {
                        int index = Array.BinarySearch<string>(FriendChange._friendChangeFieldNames, str, StringComparer.Ordinal);
                        if (index >= 0)
                        {
                            num = FriendChange._friendChangeFieldTags[index];
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
                            this.result.hasName = input.ReadString(ref this.result.name_);
                            continue;
                        }
                        case 0x18:
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
                    if (input.ReadEnum<FriendChange.Types.FriendAction>(ref this.result.action_, out obj2))
                    {
                        this.result.hasAction = true;
                    }
                    else if (!(obj2 is int))
                    {
                        continue;
                    }
                }
                return this;
            }

            private FriendChange PrepareBuilder()
            {
                if (this.resultIsReadOnly)
                {
                    FriendChange result = this.result;
                    this.result = new FriendChange();
                    this.resultIsReadOnly = false;
                    this.MergeFrom(result);
                }
                return this.result;
            }

            public FriendChange.Builder SetAction(FriendChange.Types.FriendAction value)
            {
                this.PrepareBuilder();
                this.result.hasAction = true;
                this.result.action_ = value;
                return this;
            }

            public FriendChange.Builder SetName(string value)
            {
                Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
                this.PrepareBuilder();
                this.result.hasName = true;
                this.result.name_ = value;
                return this;
            }

            public FriendChange.Types.FriendAction Action
            {
                get
                {
                    return this.result.Action;
                }
                set
                {
                    this.SetAction(value);
                }
            }

            public override FriendChange DefaultInstanceForType
            {
                get
                {
                    return FriendChange.DefaultInstance;
                }
            }

            public bool HasAction
            {
                get
                {
                    return this.result.hasAction;
                }
            }

            public bool HasName
            {
                get
                {
                    return this.result.hasName;
                }
            }

            public override bool IsInitialized
            {
                get
                {
                    return this.result.IsInitialized;
                }
            }

            protected override FriendChange MessageBeingBuilt
            {
                get
                {
                    return this.PrepareBuilder();
                }
            }

            public string Name
            {
                get
                {
                    return this.result.Name;
                }
                set
                {
                    this.SetName(value);
                }
            }

            protected override FriendChange.Builder ThisBuilder
            {
                get
                {
                    return this;
                }
            }
        }

        [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("ProtoGen", "2.4.1.473")]
        public static class Types
        {
            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum FriendAction
            {
                FRIEND_AVAILABLE = 3,
                FRIEND_LOGOFF = 2,
                FRIEND_LOGON = 1,
                FRIEND_UNAVAILABLE = 4
            }

            [CompilerGenerated, GeneratedCode("ProtoGen", "2.4.1.473")]
            public enum PacketID
            {
                ID = 0x9d
            }
        }
    }
}

